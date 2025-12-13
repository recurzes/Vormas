using System;
using System.Collections.Generic;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Vormas.Helpers
{
    public class DataReaderMapper
    {
        public static T MapToModel<T>(MySqlDataReader reader) where T : new()
        {
            T model = new T();
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                if (!property.CanWrite)
                    continue;

                try
                {
                    // Try to get ordinal (column index) by property name
                    int ordinal = reader.GetOrdinal(property.Name);

                    // Check if the value is null
                    if (reader.IsDBNull(ordinal))
                    {
                        Type propertyType = property.PropertyType;
                        bool isNullable = !propertyType.IsValueType || Nullable.GetUnderlyingType(propertyType) != null;

                        if (isNullable)
                        {
                            property.SetValue(model, null, null);
                        }

                        continue;
                    }

                    object value = reader.GetValue(ordinal);

                    // Handle specific type conversions
                    if (property.PropertyType == typeof(bool) && value is sbyte)
                    {
                        property.SetValue(model, Convert.ToBoolean(value), null);
                    }
                    else if (property.PropertyType == typeof(bool?) && value is sbyte)
                    {
                        property.SetValue(model, Convert.ToBoolean(value), null);
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        property.SetValue(model, Enum.Parse(property.PropertyType, value.ToString()), null);
                    }
                    else if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                    {
                        // Handle nullable types
                        Type underlyingType = Nullable.GetUnderlyingType(property.PropertyType);
                        property.SetValue(model, Convert.ChangeType(value, underlyingType), null);
                    }
                    else
                    {
                        property.SetValue(model, Convert.ChangeType(value, property.PropertyType), null);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($@"Error mapping property {property.Name}: {ex.Message}");
                }
            }

            return model;
        }

        public static List<T> MapToList<T>(MySqlDataReader reader) where T : new()
        {
            List<T> list = new List<T>();

            while (reader.Read())
            {
                list.Add(MapToModel<T>(reader));
            }

            return list;
        }
    }
}