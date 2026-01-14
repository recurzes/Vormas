import { useState, useEffect } from 'react'
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, PieChart, Pie, Cell } from 'recharts'
import { format, subDays } from 'date-fns'

const COLORS = ['#3b82f6', '#22c55e', '#f59e0b', '#ef4444', '#8b5cf6']

function Analytics() {
  const [metrics, setMetrics] = useState(null)
  const [utilizationData, setUtilizationData] = useState([])
  const [popularVehicles, setPopularVehicles] = useState([])
  const [loading, setLoading] = useState(true)
  const [dateRange, setDateRange] = useState({
    from: format(subDays(new Date(), 30), 'yyyy-MM-dd'),
    to: format(new Date(), 'yyyy-MM-dd')
  })

  useEffect(() => {
    fetchAllData()
  }, [dateRange])

  const fetchAllData = async () => {
    setLoading(true)
    try {
      const params = `from=${dateRange.from}&to=${dateRange.to}`
      
      const [metricsRes, utilizationRes, popularRes] = await Promise.all([
        fetch(`/api/analytics?${params}`),
        fetch(`/api/reports?type=fleet-utilization&${params}`),
        fetch(`/api/reports?type=popular-vehicles&limit=5`)
      ])
      
      if (metricsRes.ok) setMetrics(await metricsRes.json())
      if (utilizationRes.ok) setUtilizationData(await utilizationRes.json())
      if (popularRes.ok) setPopularVehicles(await popularRes.json())
    } catch (error) {
      console.log('Analytics fetch error:', error.message)
    } finally {
      setLoading(false)
    }
  }

  const handleDateChange = (field, value) => {
    setDateRange(prev => ({ ...prev, [field]: value }))
  }

  if (loading) {
    return <div className="loading">Loading analytics...</div>
  }

  return (
    <div>
      <h1 className="page-title">Performance Analytics</h1>

      {/* Date Range Selector */}
      <div className="chart-card" style={{ marginBottom: '24px' }}>
        <div className="filters-bar">
          <div className="filter-group">
            <label className="filter-label">From:</label>
            <input 
              type="date" 
              className="filter-input" 
              value={dateRange.from} 
              onChange={(e) => handleDateChange('from', e.target.value)} 
            />
          </div>
          <div className="filter-group">
            <label className="filter-label">To:</label>
            <input 
              type="date" 
              className="filter-input" 
              value={dateRange.to} 
              onChange={(e) => handleDateChange('to', e.target.value)} 
            />
          </div>
          <button className="btn btn-primary" onClick={fetchAllData}>
            Refresh
          </button>
        </div>
      </div>

      {/* Key Metrics */}
      <div className="analytics-grid">
        <div className="metric-card">
          <div className="metric-label">Fleet Utilization Rate</div>
          <div className="metric-value">{metrics?.fleetUtilizationRate || 0}%</div>
          <div className="metric-subtext">Rental Days / Available Days</div>
        </div>
        <div className="metric-card green">
          <div className="metric-label">Revenue Per Vehicle</div>
          <div className="metric-value">₱{Number(metrics?.revenuePerVehicle || 0).toLocaleString()}</div>
          <div className="metric-subtext">Average per vehicle</div>
        </div>
        <div className="metric-card orange">
          <div className="metric-label">Avg Rental Duration</div>
          <div className="metric-value">{metrics?.avgRentalDuration || 0} days</div>
          <div className="metric-subtext">Average rental length</div>
        </div>
        <div className="metric-card purple">
          <div className="metric-label">Customer Retention</div>
          <div className="metric-value">{metrics?.customerRetentionRate || 0}%</div>
          <div className="metric-subtext">Repeat customers</div>
        </div>
      </div>

      {/* Summary Stats */}
      <div className="kpi-grid">
        <div className="kpi-card">
          <div className="kpi-label">Total Rentals</div>
          <div className="kpi-value">{metrics?.totalRentals || 0}</div>
        </div>
        <div className="kpi-card">
          <div className="kpi-label">Total Revenue</div>
          <div className="kpi-value">₱{Number(metrics?.totalRevenue || 0).toLocaleString()}</div>
        </div>
        <div className="kpi-card">
          <div className="kpi-label">Avg Rate Per Rental</div>
          <div className="kpi-value">₱{Number(metrics?.avgRentalRate || 0).toLocaleString()}</div>
        </div>
        <div className="kpi-card">
          <div className="kpi-label">Unique Customers</div>
          <div className="kpi-value">{metrics?.totalCustomers || 0}</div>
        </div>
      </div>

      {/* Charts */}
      <div className="charts-grid">
        {/* Fleet Utilization Chart */}
        <div className="chart-card">
          <h3 className="chart-title">Fleet Utilization by Vehicle</h3>
          {utilizationData.length > 0 ? (
            <ResponsiveContainer width="100%" height={300}>
              <BarChart data={utilizationData.slice(0, 10)}>
                <CartesianGrid strokeDasharray="3 3" stroke="#e2e8f0" />
                <XAxis dataKey="code" stroke="#64748b" fontSize={12} />
                <YAxis stroke="#64748b" fontSize={12} tickFormatter={(v) => `${v}%`} />
                <Tooltip 
                  formatter={(v) => [`${v}%`, 'Utilization Rate']}
                  contentStyle={{ borderRadius: '8px', border: '1px solid #e2e8f0' }}
                />
                <Bar dataKey="utilizationRate" fill="#3b82f6" radius={[4, 4, 0, 0]} />
              </BarChart>
            </ResponsiveContainer>
          ) : (
            <div className="empty-state">No utilization data available</div>
          )}
        </div>

        {/* Popular Vehicles */}
        <div className="chart-card">
          <h3 className="chart-title">Most Popular Vehicles</h3>
          {popularVehicles.length > 0 ? (
            <ResponsiveContainer width="100%" height={300}>
              <PieChart>
                <Pie
                  data={popularVehicles}
                  cx="50%"
                  cy="50%"
                  innerRadius={60}
                  outerRadius={100}
                  paddingAngle={5}
                  dataKey="totalRentals"
                  nameKey="code"
                  label={({ code, totalRentals }) => `${code}: ${totalRentals}`}
                >
                  {popularVehicles.map((entry, index) => (
                    <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                  ))}
                </Pie>
                <Tooltip 
                  formatter={(v, name, props) => [v, 'Rentals']}
                  contentStyle={{ borderRadius: '8px', border: '1px solid #e2e8f0' }}
                />
              </PieChart>
            </ResponsiveContainer>
          ) : (
            <div className="empty-state">No rental data available</div>
          )}
        </div>
      </div>

      {/* Vehicle Utilization Table */}
      <div className="chart-card">
        <h3 className="chart-title">Vehicle Utilization Details</h3>
        {utilizationData.length > 0 ? (
          <table className="data-table">
            <thead>
              <tr>
                <th>Code</th>
                <th>Vehicle</th>
                <th>Category</th>
                <th>Rental Days</th>
                <th>Available Days</th>
                <th>Utilization Rate</th>
              </tr>
            </thead>
            <tbody>
              {utilizationData.map((v, i) => (
                <tr key={i}>
                  <td>{v.code}</td>
                  <td>{v.vehicle}</td>
                  <td>{v.category}</td>
                  <td>{v.rentalDays}</td>
                  <td>{v.availableDays}</td>
                  <td>
                    <span className={`status-badge ${v.utilizationRate > 50 ? 'active' : v.utilizationRate > 20 ? 'pending' : 'cancelled'}`}>
                      {v.utilizationRate}%
                    </span>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        ) : (
          <div className="empty-state">No data available</div>
        )}
      </div>
    </div>
  )
}

export default Analytics
