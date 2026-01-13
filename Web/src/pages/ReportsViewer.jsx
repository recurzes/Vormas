import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { format } from 'date-fns'
import {
  AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer,
  PieChart, Pie, Cell, BarChart, Bar, Legend
} from 'recharts'
import jsPDF from 'jspdf'
import autoTable from 'jspdf-autotable'
import '../styles/ReportsViewer.css'


function ReportsViewer() {
  const [reportCategory, setReportCategory] = useState('basic')
  const navigate = useNavigate()
  const [timeRange, setTimeRange] = useState('30d')
  const [data, setData] = useState([])
  const [loading, setLoading] = useState(false)
  const [isLiveData, setIsLiveData] = useState(false)
  const [exportFormat, setExportFormat] = useState('csv')

  const reportCategories = {
    basic: {
      label: 'Basic Reports',
      types: [
        { value: 'rentals', label: 'All Rentals' },
        { value: 'invoices', label: 'Invoices' },
        { value: 'damages', label: 'Damage Claims' },
        { value: 'customers', label: 'Customers' }
      ]
    },
    fleet: {
      label: 'Fleet Reports',
      types: [
        { value: 'fleet-by-category', label: 'Vehicles by Category' },
        { value: 'fleet-maintenance', label: 'Vehicles Under Maintenance' },
        { value: 'fleet-utilization', label: 'Fleet Utilization Rate' }
      ]
    },
    rental: {
      label: 'Rental Reports',
      types: [
        { value: 'active-rentals', label: 'Active Rentals' },
        { value: 'daily-rentals', label: 'Daily Rentals Summary' },
        { value: 'rentals-by-category', label: 'Rentals by Category' },
        { value: 'rental-duration', label: 'Rental Duration Analysis' }
      ]
    },
    operational: {
      label: 'Operational Reports',
      types: [
        { value: 'popular-vehicles', label: 'Most Popular Vehicles' },
        { value: 'late-returns', label: 'Late Returns' },
        { value: 'revenue-per-vehicle', label: 'Revenue per Vehicle' }
      ]
    }
  }

  const statusOptions = {
    rentals: ['Active', 'Completed', 'Cancelled', 'Overdue'],
    invoices: ['Unpaid', 'PartiallyPaid', 'Paid', 'Refunded'],
    damages: ['PendingApproval', 'Approved', 'Rejected'],
    customers: ['Individual', 'Corporate', 'Frequent', 'Blacklisted']
  }

  // KPI Data for the dashboard cards
  const kpiData = [
    { icon: '💰', label: 'Total Revenue', value: '₱1.2M', trend: '+12%', status: 'up' },
    { icon: '🚗', label: 'Active Rentals', value: '24', trend: '+5%', status: 'up' },
    { icon: '👥', label: 'New Customers', value: '18', trend: '+8%', status: 'up' },
    { icon: '⚠️', label: 'Pending Claims', value: '3', trend: '-2%', status: 'down' }
  ]

  // Revenue chart data
  const revenueData = [
    { date: 'Jan 1', revenue: 45000 },
    { date: 'Jan 5', revenue: 52000 },
    { date: 'Jan 10', revenue: 48000 },
    { date: 'Jan 15', revenue: 61000 },
    { date: 'Jan 20', revenue: 55000 },
    { date: 'Jan 25', revenue: 67000 },
    { date: 'Jan 30', revenue: 72000 }
  ]

  // Fleet status pie chart data
  const fleetStatusData = [
    { name: 'Available', value: 15, color: '#22c55e' },
    { name: 'Rented', value: 10, color: '#4f46e5' },
    { name: 'Maintenance', value: 3, color: '#f59e0b' },
    { name: 'Reserved', value: 2, color: '#64748b' }
  ]

  // Mock table data for recent transactions
  const mockTableData = [
    { id: 'R-1001', date: '2026-01-13', customer: 'Juan Dela Cruz', vehicle: 'Toyota Camry', status: 'Completed', amount: 15000 },
    { id: 'R-1002', date: '2026-01-12', customer: 'Maria Santos', vehicle: 'Honda Civic', status: 'Active', amount: 12000 },
    { id: 'R-1003', date: '2026-01-11', customer: 'Pedro Reyes', vehicle: 'Ford Ranger', status: 'Completed', amount: 18500 },
    { id: 'R-1004', date: '2026-01-10', customer: 'Ana Garcia', vehicle: 'Mitsubishi Montero', status: 'Overdue', amount: 22000 },
    { id: 'R-1005', date: '2026-01-09', customer: 'Carlos Mendoza', vehicle: 'Nissan Almera', status: 'Completed', amount: 9500 }
  ]

  const fetchReport = async () => {
    setLoading(true)
    setTimeout(() => {
      setData(mockTableData)
      setLoading(false)
    }, 500)
  };

  const downloadReport = () => {
    // Build CSV content
    const lines = []

    // KPI Summary Section
    lines.push('=== KPI SUMMARY ===')
    lines.push('Metric,Value,Trend')
    kpiData.forEach(k => {
      lines.push(`"${k.label}","${k.value}","${k.trend}"`)
    })
    lines.push('')

    // Revenue Data Section
    lines.push('=== REVENUE PERFORMANCE ===')
    lines.push('Date,Revenue (₱)')
    revenueData.forEach(r => {
      lines.push(`${r.date},${r.revenue}`)
    })
    lines.push('')

    // Fleet Status Section
    lines.push('=== FLEET UTILIZATION ===')
    lines.push('Status,Count')
    fleetStatusData.forEach(f => {
      lines.push(`${f.name},${f.value}`)
    })
    lines.push('')

    // Transactions Table Section
    lines.push('=== RECENT TRANSACTIONS ===')
    lines.push('Date,Rental ID,Customer,Vehicle,Status,Amount (₱)')
    const tableData = data.length > 0 ? data : mockTableData
    tableData.forEach(row => {
      lines.push(`${row.date},"${row.id}","${row.customer}","${row.vehicle}",${row.status},${row.amount}`)
    })

    // Create and download file
    const csvContent = lines.join('\n')
    const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' })
    const url = URL.createObjectURL(blob)
    const link = document.createElement('a')
    link.href = url
    const timestamp = format(new Date(), 'yyyy-MM-dd_HH-mm')
    link.download = `VORMAS_Report_${timeRange}_${timestamp}.csv`
    document.body.appendChild(link)
    link.click()
    document.body.removeChild(link)
    URL.revokeObjectURL(url)
  }

  const downloadPDF = () => {
    const doc = new jsPDF()
    const timestamp = format(new Date(), 'yyyy-MM-dd HH:mm')
    const pageWidth = doc.internal.pageSize.getWidth()

    // Header
    doc.setFillColor(79, 70, 229) // Indigo
    doc.rect(0, 0, pageWidth, 35, 'F')
    doc.setTextColor(255, 255, 255)
    doc.setFontSize(22)
    doc.setFont('helvetica', 'bold')
    doc.text('VORMAS', 14, 18)
    doc.setFontSize(10)
    doc.setFont('helvetica', 'normal')
    doc.text('Vehicle Rental Management System', 14, 26)
    doc.text(`Generated: ${timestamp}`, pageWidth - 14, 18, { align: 'right' })
    doc.text(`Period: ${timeRange === 'today' ? 'Today' : timeRange === '7d' ? 'Last 7 Days' : timeRange === '30d' ? 'This Month' : 'Year to Date'}`, pageWidth - 14, 26, { align: 'right' })

    let yPos = 45

    // KPI Summary Section
    doc.setTextColor(30, 41, 59)
    doc.setFontSize(14)
    doc.setFont('helvetica', 'bold')
    doc.text('Key Performance Indicators', 14, yPos)
    yPos += 8

    autoTable(doc, {
      startY: yPos,
      head: [['Metric', 'Value', 'Trend']],
      body: kpiData.map(k => [k.label, k.value, k.trend]),
      headStyles: { fillColor: [79, 70, 229], textColor: 255 },
      alternateRowStyles: { fillColor: [248, 250, 252] },
      margin: { left: 14, right: 14 }
    })

    yPos = doc.lastAutoTable.finalY + 15

    // Revenue Performance Section
    doc.setFontSize(14)
    doc.setFont('helvetica', 'bold')
    doc.text('Revenue Performance', 14, yPos)
    yPos += 8

    autoTable(doc, {
      startY: yPos,
      head: [['Date', 'Revenue (PHP)']],
      body: revenueData.map(r => [r.date, `₱${r.revenue.toLocaleString()}`]),
      headStyles: { fillColor: [79, 70, 229], textColor: 255 },
      alternateRowStyles: { fillColor: [248, 250, 252] },
      margin: { left: 14, right: 14 }
    })

    yPos = doc.lastAutoTable.finalY + 15

    // Fleet Utilization Section
    doc.setFontSize(14)
    doc.setFont('helvetica', 'bold')
    doc.text('Fleet Utilization', 14, yPos)
    yPos += 8

    autoTable(doc, {
      startY: yPos,
      head: [['Status', 'Count']],
      body: fleetStatusData.map(f => [f.name, f.value]),
      headStyles: { fillColor: [79, 70, 229], textColor: 255 },
      alternateRowStyles: { fillColor: [248, 250, 252] },
      margin: { left: 14, right: 14 }
    })

    // Add new page for transactions
    doc.addPage()

    // Reset header for new page
    doc.setFillColor(79, 70, 229)
    doc.rect(0, 0, pageWidth, 25, 'F')
    doc.setTextColor(255, 255, 255)
    doc.setFontSize(16)
    doc.setFont('helvetica', 'bold')
    doc.text('Recent Transactions', 14, 16)

    yPos = 35

    // Transactions Table
    const tableData = data.length > 0 ? data : mockTableData
    autoTable(doc, {
      startY: yPos,
      head: [['Date', 'Rental ID', 'Customer', 'Vehicle', 'Status', 'Amount']],
      body: tableData.map(row => [
        format(new Date(row.date), 'MMM dd, yyyy'),
        row.id,
        row.customer,
        row.vehicle,
        row.status,
        `₱${row.amount.toLocaleString()}`
      ]),
      headStyles: { fillColor: [79, 70, 229], textColor: 255 },
      alternateRowStyles: { fillColor: [248, 250, 252] },
      margin: { left: 14, right: 14 },
      columnStyles: {
        5: { halign: 'right' }
      }
    })

    // Footer
    const pageCount = doc.internal.getNumberOfPages()
    for (let i = 1; i <= pageCount; i++) {
      doc.setPage(i)
      doc.setFontSize(9)
      doc.setTextColor(100, 116, 139)
      doc.text(`Page ${i} of ${pageCount}`, pageWidth / 2, doc.internal.pageSize.getHeight() - 10, { align: 'center' })
      doc.text('VORMAS - Confidential Report', 14, doc.internal.pageSize.getHeight() - 10)
    }

    // Save the PDF
    const fileTimestamp = format(new Date(), 'yyyy-MM-dd_HH-mm')
    doc.save(`VORMAS_Report_${timeRange}_${fileTimestamp}.pdf`)
  }

  const handleDownload = () => {
    if (exportFormat === 'pdf') {
      downloadPDF()
    } else {
      downloadReport()
    }
  }

  return (
    <div className="reports-container">
      {/* Top Bar */}
      <div className="reports-top-bar">
        <div style={{ display: 'flex', alignItems: 'center', gap: '16px' }}>
          <h1 className="page-title" style={{ margin: 0 }}>Executive Insight Dashboard</h1>
        </div>

        <div className="controls-group">
          <select className="date-select" value={timeRange} onChange={e => setTimeRange(e.target.value)}>
            <option value="today">Today</option>
            <option value="7d">Last 7 Days</option>
            <option value="30d">This Month</option>
            <option value="ytd">Year to Date</option>
          </select>
          <select
            className="date-select"
            value={exportFormat}
            onChange={e => setExportFormat(e.target.value)}
            style={{ minWidth: '80px' }}
          >
            <option value="csv">CSV</option>
            <option value="pdf">PDF</option>
          </select>
          <button className="export-btn" onClick={handleDownload}>
            Download {exportFormat.toUpperCase()} 📥
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
