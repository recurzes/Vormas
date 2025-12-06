namespace Vormas.Models
{
    public class User: Person
    {
        protected int UserId { get; set; }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
    }
}