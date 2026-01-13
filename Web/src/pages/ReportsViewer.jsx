import { useState, useEffect } from 'react'
import { format } from 'date-fns'

function ReportsViewer() {
  const [reportCategory, setReportCategory] = useState('basic')
  const [reportType, setReportType] = useState('rentals')
  const [fromDate, setFromDate] = useState('')
  const [toDate, setToDate] = useState('')
  const [statusFilter, setStatusFilter] = useState('')
  const [data, setData] = useState([])
  const [loading, setLoading] = useState(false)
  const [isLiveData, setIsLiveData] = useState(false)

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

  const handleCategoryChange = (cat) => {
    setReportCategory(cat)
    const firstType = reportCategories[cat].types[0].value
    setReportType(firstType)
    setStatusFilter('')
    fetchReport(firstType)
  }

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
    downloadFile(csvContent, 'text/csv', `${reportType}-report.csv`)
  }

  const handleExportExcel = () => {
    if (data.length === 0) return
    const headers = Object.keys(data[0])
    const tsvContent = [
      headers.join('\t'),
      ...data.map(row => headers.map(h => row[h] ?? '').join('\t'))
    ].join('\n')
    downloadFile(tsvContent, 'application/vnd.ms-excel', `${reportType}-report.xls`)
  }

  const handlePrint = () => {
    if (data.length === 0) return
    const printWindow = window.open('', '_blank')
    const headers = Object.keys(data[0])
    printWindow.document.write(`
      <html>
      <head>
        <title>${reportType} Report - ${format(new Date(), 'yyyy-MM-dd')}</title>
        <style>
          body { font-family: Arial, sans-serif; margin: 20px; }
          h1 { color: #1e40af; }
          table { width: 100%; border-collapse: collapse; margin-top: 20px; }
          th { background: #1e40af; color: white; padding: 10px; text-align: left; }
          td { border: 1px solid #ddd; padding: 8px; }
          tr:nth-child(even) { background: #f9f9f9; }
          .footer { margin-top: 20px; color: #666; font-size: 12px; }
        </style>
      </head>
      <body>
        <h1>Vormas - ${reportCategories[reportCategory].types.find(t => t.value === reportType)?.label || reportType}</h1>
        <p>Generated: ${format(new Date(), 'MMMM dd, yyyy HH:mm')}</p>
        <table>
          <thead><tr>${headers.map(h => `<th>${h}</th>`).join('')}</tr></thead>
          <tbody>${data.map(row => `<tr>${headers.map(h => `<td>${formatValue(h, row[h])}</td>`).join('')}</tr>`).join('')}</tbody>
        </table>
        <div class="footer">Total Records: ${data.length}</div>
      </body>
      </html>
    `)
    printWindow.document.close()
    printWindow.print()
  }

  const downloadFile = (content, type, filename) => {
    const blob = new Blob([content], { type })
    const url = URL.createObjectURL(blob)
    const a = document.createElement('a')
    a.href = url
    a.download = filename
    a.click()
    URL.revokeObjectURL(url)
  }

  const formatValue = (col, val) => {
    if (val === null || val === undefined) return '-'
    if (['total', 'balance', 'charge', 'revenue', 'totalRevenue', 'avgRevenuePerRental'].includes(col)) {
      return `₱${Number(val).toLocaleString()}`
    }
    if (['utilizationRate', 'percentage'].includes(col)) {
      return `${val}%`
    }
    return val
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
              <th key={col}>{col.charAt(0).toUpperCase() + col.slice(1).replace(/([A-Z])/g, ' $1')}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.map((row, i) => (
            <tr key={i}>
              {columns.map(col => (
                <td key={col}>
                  {col === 'status' || col === 'type' || col === 'severity' ? (
                    <span className={`status-badge ${String(row[col]).toLowerCase()}`}>{row[col]}</span>
                  ) : (
                    formatValue(col, row[col])
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
      <h1 className="page-title">Reports & Analytics</h1>

      {/* Category Tabs */}
      <div className="report-tabs">
        {Object.entries(reportCategories).map(([key, cat]) => (
          <button
            key={key}
            className={`tab-btn ${reportCategory === key ? 'active' : ''}`}
            onClick={() => handleCategoryChange(key)}
          >
            {cat.label}
          </button>
        ))}
      </div>

      {/* Filters */}
      <div className="chart-card" style={{ marginBottom: '16px' }}>
        <div className="filters-bar">
          <div className="filter-group">
            <label className="filter-label">Report:</label>
            <select 
              className="filter-select" 
              value={reportType} 
              onChange={(e) => handleReportTypeChange(e.target.value)}
            >
              {reportCategories[reportCategory].types.map(t => (
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

          {statusOptions[reportType] && (
            <div className="filter-group">
              <label className="filter-label">Status:</label>
              <select 
                className="filter-select" 
                value={statusFilter} 
                onChange={(e) => setStatusFilter(e.target.value)}
              >
                <option value="">All</option>
                {statusOptions[reportType].map(s => (
                  <option key={s} value={s}>{s}</option>
                ))}
              </select>
            </div>
          )}

          <button className="btn btn-primary" onClick={handleApplyFilters}>
            Apply
          </button>
        </div>
      </div>

      {/* Export buttons */}
      <div className="export-bar">
        <button className="btn btn-outline" onClick={handleExportCSV} title="Export as CSV">
          CSV
        </button>
        <button className="btn btn-outline" onClick={handleExportExcel} title="Export as Excel">
          Excel
        </button>
        <button className="btn btn-outline" onClick={handlePrint} title="Print Report">
          Print
        </button>
      </div>

      {/* Data Table */}
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
