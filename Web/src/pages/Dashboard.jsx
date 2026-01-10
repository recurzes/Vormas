import { useState, useEffect } from 'react'
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, PieChart, Pie, Cell } from 'recharts'

const COLORS = ['#3b82f6', '#22c55e', '#f59e0b', '#ef4444', '#8b5cf6']

function KpiCard({ label, value, subtext, icon, color }) {
  return (
    <div className="kpi-card">
      <div className="kpi-card-header">
        <span className="kpi-label">{label}</span>
        <div className={`kpi-icon ${color}`}>{icon}</div>
      </div>
      <div className="kpi-value">{value}</div>
      {subtext && <div className="kpi-subtext">{subtext}</div>}
    </div>
  )
}

function Dashboard() {
  const [loading, setLoading] = useState(true)
  const [kpis, setKpis] = useState(null)
  const [revenueData, setRevenueData] = useState([])
  const [vehicleData, setVehicleData] = useState([])
  const [isLiveData, setIsLiveData] = useState(false)

  useEffect(() => {
    const fetchData = async () => {
      try {
        const [kpisRes, revenueRes, vehicleRes] = await Promise.all([
          fetch('/api/kpis'),
          fetch('/api/revenue-trend'),
          fetch('/api/vehicle-utilization')
        ])
        
        if (kpisRes.ok && revenueRes.ok && vehicleRes.ok) {
          setKpis(await kpisRes.json())
          setRevenueData(await revenueRes.json())
          setVehicleData(await vehicleRes.json())
          setIsLiveData(true)
        }
      } catch (error) {
        console.log('Using mock data:', error.message)
      } finally {
        setLoading(false)
      }
    }
    
    fetchData()
  }, [])

  if (loading) {
    return <div className="loading">Loading dashboard...</div>
  }

  const formatCurrency = (val) => `₱${val?.toLocaleString() || 0}`

  return (
    <div>
      <h1 className="page-title">Dashboard Overview</h1>
      
      {/* KPI Cards */}
      <div className="kpi-grid">
        <KpiCard 
          label="Total Revenue" 
          value={formatCurrency(kpis?.totalRevenue)} 
          subtext="All completed invoices"
          icon="₱" 
          color="blue" 
        />
        <KpiCard 
          label="Outstanding Balance" 
          value={formatCurrency(kpis?.outstandingBalance)} 
          subtext="Unpaid invoices"
          icon="!" 
          color="yellow" 
        />
        <KpiCard 
          label="Active Rentals" 
          value={kpis?.activeRentals || 0} 
          subtext={`${kpis?.completedRentals || 0} completed`}
          icon="🚗" 
          color="green" 
        />
        <KpiCard 
          label="Fleet Size" 
          value={kpis?.fleetSize || 0} 
          subtext={`${kpis?.availableVehicles || 0} available`}
          icon="🚙" 
          color="blue" 
        />
        <KpiCard 
          label="Total Customers" 
          value={kpis?.totalCustomers || 0}
          icon="👥" 
          color="green" 
        />
        <KpiCard 
          label="Pending Damages" 
          value={kpis?.pendingDamages || 0} 
          subtext={`₱${(kpis?.totalDamageCosts || 0).toLocaleString()} charged`}
          icon="⚠" 
          color="red" 
        />
      </div>

      {/* Charts */}
      <div className="charts-grid">
        <div className="chart-card">
          <h3 className="chart-title">Revenue Trend</h3>
          <ResponsiveContainer width="100%" height={280}>
            <LineChart data={revenueData}>
              <CartesianGrid strokeDasharray="3 3" stroke="#e2e8f0" />
              <XAxis dataKey="month" stroke="#64748b" fontSize={12} />
              <YAxis stroke="#64748b" fontSize={12} tickFormatter={(v) => `₱${v/1000}k`} />
              <Tooltip 
                formatter={(v) => [`₱${v.toLocaleString()}`, 'Revenue']}
                contentStyle={{ borderRadius: '8px', border: '1px solid #e2e8f0' }}
              />
              <Line 
                type="monotone" 
                dataKey="revenue" 
                stroke="#3b82f6" 
                strokeWidth={2}
                dot={{ fill: '#3b82f6', strokeWidth: 2 }}
              />
            </LineChart>
          </ResponsiveContainer>
        </div>
        
        <div className="chart-card">
          <h3 className="chart-title">Fleet Status</h3>
          <ResponsiveContainer width="100%" height={280}>
            <PieChart>
              <Pie
                data={vehicleData}
                cx="50%"
                cy="50%"
                innerRadius={60}
                outerRadius={100}
                paddingAngle={5}
                dataKey="value"
                label={({ name, value }) => `${name}: ${value}`}
              >
                {vehicleData.map((entry, index) => (
                  <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                ))}
              </Pie>
              <Tooltip />
            </PieChart>
          </ResponsiveContainer>
        </div>
      </div>
      
      <p style={{ fontSize: '12px', color: '#64748b', marginTop: '16px', textAlign: 'center' }}>
        {isLiveData ? '🟢 Live data from database' : '📊 Mock data (database not connected)'}
      </p>
    </div>
  )
}

export default Dashboard
