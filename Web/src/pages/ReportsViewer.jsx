import { useState, useEffect } from 'react'
import { format } from 'date-fns'

function ReportsViewer() {
  const [reportType, setReportType] = useState('rentals')
  const [fromDate, setFromDate] = useState('')
  const [toDate, setToDate] = useState('')
  const [statusFilter, setStatusFilter] = useState('')
  const [data, setData] = useState([])
  const [loading, setLoading] = useState(false)
  const [isLiveData, setIsLiveData] = useState(false)

  const reportTypes = [
    { value: 'rentals', label: 'Rentals' },
    { value: 'invoices', label: 'Invoices' },
    { value: 'damages', label: 'Damage Claims' },
    { value: 'customers', label: 'Customers' }
  ]

  const statusOptions = {
    rentals: ['Active', 'Completed', 'Cancelled', 'Overdue'],
    invoices: ['Unpaid', 'PartiallyPaid', 'Paid', 'Refunded'],
    damages: ['PendingApproval', 'Approved', 'Rejected'],
    customers: ['Individual', 'Corporate', 'Frequent', 'Blacklisted']
  }

  const fetchReport = async (type = reportType) => {
    setLoading(true)
    try {
      const params = new URLSearchParams({ type })
      if (fromDate) params.append('from', fromDate)
      if (toDate) params.append('to', toDate)
      if (statusFilter) params.append('status', statusFilter)
      
      const res = await fetch(`/api/reports?${params}`)
      if (res.ok) {
        const result = await res.json()
        setData(result)
        setIsLiveData(true)
      }
    } catch (error) {
      console.log('Reports fetch error:', error.message)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    fetchReport()
  }, [])

  const handleReportTypeChange = (newType) => {
    setReportType(newType)
    setStatusFilter('')
    fetchReport(newType)
  }

  const handleApplyFilters = () => {
    fetchReport()
  }

  const handleExportCSV = () => {
    if (data.length === 0) return
    
    const headers = Object.keys(data[0])
    const csvContent = [
      headers.join(','),
      ...data.map(row => headers.map(h => `"${row[h] ?? ''}"`).join(','))
    ].join('\n')
    
    const blob = new Blob([csvContent], { type: 'text/csv' })
    const url = URL.createObjectURL(blob)
    const a = document.createElement('a')
    a.href = url
    a.download = `${reportType}-report-${format(new Date(), 'yyyy-MM-dd')}.csv`
    a.click()
  }

  const renderTable = () => {
    if (data.length === 0) {
      return <div className="empty-state">No data found. Try adjusting your filters.</div>
    }

    const columns = Object.keys(data[0])
    
    return (
      <table className="data-table">
        <thead>
          <tr>
            {columns.map(col => (
              <th key={col}>{col.charAt(0).toUpperCase() + col.slice(1)}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.map((row, i) => (
            <tr key={i}>
              {columns.map(col => (
                <td key={col}>
                  {col === 'status' || col === 'type' ? (
                    <span className={`status-badge ${String(row[col]).toLowerCase()}`}>{row[col]}</span>
                  ) : col === 'total' || col === 'balance' || col === 'charge' ? (
                    `₱${Number(row[col] || 0).toLocaleString()}`
                  ) : (
                    row[col]
                  )}
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    )
  }

  return (
    <div>
      <h1 className="page-title">Reports Viewer</h1>

      <div className="chart-card" style={{ marginBottom: '16px' }}>
        <div className="filters-bar">
          <div className="filter-group">
            <label className="filter-label">Report Type:</label>
            <select 
              className="filter-select" 
              value={reportType} 
              onChange={(e) => handleReportTypeChange(e.target.value)}
            >
              {reportTypes.map(t => (
                <option key={t.value} value={t.value}>{t.label}</option>
              ))}
            </select>
          </div>

          <div className="filter-group">
            <label className="filter-label">From:</label>
            <input 
              type="date" 
              className="filter-input" 
              value={fromDate} 
              onChange={(e) => setFromDate(e.target.value)} 
            />
          </div>

          <div className="filter-group">
            <label className="filter-label">To:</label>
            <input 
              type="date" 
              className="filter-input" 
              value={toDate} 
              onChange={(e) => setToDate(e.target.value)} 
            />
          </div>

          <div className="filter-group">
            <label className="filter-label">Status:</label>
            <select 
              className="filter-select" 
              value={statusFilter} 
              onChange={(e) => setStatusFilter(e.target.value)}
            >
              <option value="">All</option>
              {(statusOptions[reportType] || []).map(s => (
                <option key={s} value={s}>{s}</option>
              ))}
            </select>
          </div>

          <button className="btn btn-primary" onClick={handleApplyFilters}>
            Apply Filters
          </button>
          
          <button className="btn btn-outline" onClick={handleExportCSV}>
            Export CSV
          </button>
        </div>
      </div>

      <div className="chart-card">
        {loading ? (
          <div className="loading">Loading report data...</div>
        ) : (
          renderTable()
        )}
      </div>
      
      <p style={{ fontSize: '12px', color: '#64748b', marginTop: '16px', textAlign: 'center' }}>
        {isLiveData ? '🟢 Connected to backend' : '📋 Mock data'}
        {data.length > 0 && ` • ${data.length} records`}
      </p>
    </div>
  )
}

export default ReportsViewer
