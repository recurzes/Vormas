import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { format } from 'date-fns'
import {
  AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer,
  PieChart, Pie, Cell, BarChart, Bar, Legend
} from 'recharts'
import '../styles/ReportsViewer.css'


function ReportsViewer() {
  const navigate = useNavigate()
  const [timeRange, setTimeRange] = useState('30d')
  const [data, setData] = useState([])
  const [loading, setLoading] = useState(false)

  // Mock Data for Charts (Executive Insight)
  const revenueData = [
    { date: 'Jan 01', revenue: 45000 }, { date: 'Jan 05', revenue: 52000 },
    { date: 'Jan 10', revenue: 48000 }, { date: 'Jan 15', revenue: 61000 },
    { date: 'Jan 20', revenue: 55000 }, { date: 'Jan 25', revenue: 67000 },
    { date: 'Jan 30', revenue: 72000 }
  ]

  const fleetStatusData = [
    { name: 'Rented', value: 18, color: '#4f46e5' },
    { name: 'Available', value: 8, color: '#22c55e' },
    { name: 'Maintenance', value: 4, color: '#f59e0b' }
  ]

  // Mock KPIs
  const kpiData = [
    { label: 'Total Revenue', value: '₱400,000', trend: '+12.5%', status: 'up', icon: '💰' },
    { label: 'Completed Rentals', value: '142', trend: '+8%', status: 'up', icon: '🚗' },
    { label: 'Fleet Utilization', value: '85%', trend: '+5%', status: 'up', icon: '📊' },
    { label: 'Pending Payments', value: '₱45,200', trend: '-2%', status: 'down', icon: '⏳' } // Down is good for pending
  ]

  // Mock Ledger Data
  const mockTableData = [
    { id: 101, vehicle: 'Toyota Camry', customer: 'John Doe', status: 'Active', amount: 12500, date: '2024-01-10' },
    { id: 102, vehicle: 'Honda Civic', customer: 'Jane Smith', status: 'Completed', amount: 8500, date: '2024-01-12' },
    { id: 103, vehicle: 'Ford Explorer', customer: 'Mike Ross', status: 'Late', amount: 15000, date: '2024-01-08' },
    { id: 104, vehicle: 'Toyota Vios', customer: 'Rachel Zane', status: 'Cancelled', amount: 0, date: '2024-01-14' },
    { id: 105, vehicle: 'Mitsubishi Montero', customer: 'Harvey Specter', status: 'Completed', amount: 22000, date: '2024-01-05' },
    { id: 106, vehicle: 'Nissan Terra', customer: 'Donna Paulsen', status: 'Active', amount: 18000, date: '2024-01-15' }
  ]

  useEffect(() => {
    setLoading(true)
    setTimeout(() => {
      setData(mockTableData)
      setLoading(false)
    }, 500)
  }, [timeRange])

  return (
    <div className="reports-container">
      {/* Top Bar */}
      <div className="reports-top-bar">
        <div style={{ display: 'flex', alignItems: 'center', gap: '16px' }}>
          <button
            onClick={() => navigate('/agent')}
            className="back-btn"
          >
            ← Back
          </button>
          <h1 className="page-title" style={{ margin: 0 }}>Executive Insight Dashboard</h1>
        </div>

        <div className="controls-group">
          <select className="date-select" value={timeRange} onChange={e => setTimeRange(e.target.value)}>
            <option value="today">Today</option>
            <option value="7d">Last 7 Days</option>
            <option value="30d">This Month</option>
            <option value="ytd">Year to Date</option>
          </select>
          <button className="export-btn">
            Download Report 📥
          </button>
        </div>
      </div>

      {/* KPI Strip */}
      <div className="kpi-grid">
        {kpiData.map((k, i) => (
          <div key={i} className="analytics-card">
            <div className="kpi-header">
              <span className="kpi-icon">{k.icon}</span>
              <span className="kpi-trend-pill" style={{
                background: k.status === 'up' ? '#dcfce7' : '#fee2e2',
                color: k.status === 'up' ? '#166534' : '#991b1b'
              }}>
                {k.trend}
              </span>
            </div>
            <div className="kpi-body">
              <div className="kpi-value">{k.value}</div>
              <div className="kpi-title">{k.label}</div>
            </div>
          </div>
        ))}
      </div>

      {/* Visualization Zone (60/40 Split) */}
      <div className="charts-split">
        {/* Revenue Trend */}
        <div className="chart-panel main-chart">
          <div className="panel-header">
            <div className="panel-title">Revenue Performance</div>
          </div>
          <div style={{ flex: 1, minHeight: 0 }}>
            <ResponsiveContainer width="100%" height="100%">
              <AreaChart data={revenueData}>
                <defs>
                  <linearGradient id="colorRevenue" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#4f46e5" stopOpacity={0.8} />
                    <stop offset="95%" stopColor="#4f46e5" stopOpacity={0} />
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                <XAxis dataKey="date" axisLine={false} tickLine={false} tick={{ fontSize: 12, fill: '#94a3b8' }} dy={10} />
                <YAxis axisLine={false} tickLine={false} tick={{ fontSize: 12, fill: '#94a3b8' }} tickFormatter={v => `₱${v / 1000}k`} />
                <Tooltip
                  contentStyle={{ borderRadius: '12px', border: 'none', boxShadow: '0 10px 15px -3px rgba(0, 0, 0, 0.1)' }}
                  formatter={(value) => [`₱${value.toLocaleString()}`, 'Revenue']}
                />
                <Area type="monotone" dataKey="revenue" stroke="#4f46e5" strokeWidth={3} fillOpacity={1} fill="url(#colorRevenue)" />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </div>

        {/* Fleet Status */}
        <div className="chart-panel secondary-chart">
          <div className="panel-header">
            <div className="panel-title">Fleet Utilization</div>
          </div>
          <div style={{ flex: 1, minHeight: 0, position: 'relative' }}>
            <ResponsiveContainer width="100%" height="100%">
              <PieChart>
                <Pie
                  data={fleetStatusData}
                  cx="50%"
                  cy="50%"
                  innerRadius={80}
                  outerRadius={100}
                  paddingAngle={5}
                  dataKey="value"
                >
                  {fleetStatusData.map((entry, index) => (
                    <Cell key={`cell-${index}`} fill={entry.color} stroke="none" />
                  ))}
                </Pie>
                <Tooltip />
                <Legend verticalAlign="bottom" height={36} iconType="circle" />
              </PieChart>
            </ResponsiveContainer>
            {/* Center Text */}
            <div style={{
              position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -65%)',
              textAlign: 'center', pointerEvents: 'none'
            }}>
              <div style={{ fontSize: '24px', fontWeight: '800', color: '#1e293b' }}>30</div>
              <div style={{ fontSize: '11px', color: '#64748b', fontWeight: '600', textTransform: 'uppercase' }}>Total Cars</div>
            </div>
          </div>
        </div>
      </div>

      {/* Detailed Ledger */}
      <div className="ledger-panel">
        <div className="panel-header">
          <div className="panel-title">Recent Transactions</div>
          <button style={{ color: '#4f46e5', background: 'none', border: 'none', cursor: 'pointer', fontWeight: '600', fontSize: '13px' }}>View All →</button>
        </div>
        <table className="reports-table">
          <thead>
            <tr>
              <th>Date</th>
              <th>Rental ID</th>
              <th>Customer</th>
              <th>Vehicle</th>
              <th>Status</th>
              <th style={{ textAlign: 'right' }}>Amount</th>
            </tr>
          </thead>
          <tbody>
            {data.map((row, i) => (
              <tr key={i}>
                <td style={{ color: '#64748b' }}>{format(new Date(row.date), 'MMM dd, yyyy')}</td>
                <td style={{ fontFamily: 'monospace', fontWeight: '600' }}>#{row.id}</td>
                <td>
                  <div style={{ fontWeight: '500', color: '#1e293b' }}>{row.customer}</div>
                </td>
                <td style={{ color: '#475569' }}>{row.vehicle}</td>
                <td>
                  <span className={`status-badge ${row.status.toLowerCase()}`}>
                    {row.status === 'Completed' && '✓ '}
                    {row.status}
                  </span>
                </td>
                <td style={{ textAlign: 'right', fontWeight: '600' }}>₱{row.amount.toLocaleString()}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  )
}

export default ReportsViewer
