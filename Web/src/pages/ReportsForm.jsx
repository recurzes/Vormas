import { useState, useEffect } from 'react'
import { bridge } from '../api/bridge'
import { useNavigate } from 'react-router-dom'

function ReportsForm() {
    const navigate = useNavigate()
    const [data, setData] = useState({ stats: { totalRentals: 0, totalRevenue: 0 }, recent: [] })

    useEffect(() => {
        bridge.getReportData().then(res => {
            if (!res.error) setData(res)
        })
    }, [])

    return (
        <div className="form-container" style={{ padding: '20px', maxWidth: '800px', margin: '0 auto' }}>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '20px' }}>
                <h2 className="page-title" style={{ margin: 0 }}>Reports & Stats</h2>
                <button onClick={() => navigate('/agent')} className="btn btn-secondary">Back</button>
            </div>

            <div className="kpi-grid" style={{ marginBottom: '30px' }}>
                <div className="kpi-card">
                    <div className="kpi-label">Total Rentals Completed</div>
                    <div className="kpi-value">{data.stats.totalRentals}</div>
                </div>
                <div className="kpi-card">
                    <div className="kpi-label">Total Revenue Generated</div>
                    <div className="kpi-value" style={{ color: '#16a34a' }}>₱{data.stats.totalRevenue?.toLocaleString()}</div>
                </div>
            </div>

            <h3 style={{ fontSize: '18px', fontWeight: 'bold', marginBottom: '15px' }}>Recent Rentals</h3>
            <div className="data-table-container">
                <table className="data-table" style={{ width: '100%', borderCollapse: 'collapse' }}>
                    <thead>
                        <tr style={{ background: '#f1f5f9', textAlign: 'left' }}>
                            <th style={{ padding: '10px' }}>Rental ID</th>
                            <th style={{ padding: '10px' }}>Pickup Date</th>
                            <th style={{ padding: '10px' }}>Status</th>
                            <th style={{ padding: '10px' }}>Total Amount</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.recent.map(r => (
                            <tr key={r.RentalId} style={{ borderBottom: '1px solid #e2e8f0' }}>
                                <td style={{ padding: '10px' }}>#{r.RentalId}</td>
                                <td style={{ padding: '10px' }}>{new Date(r.PickupDate).toLocaleDateString()}</td>
                                <td style={{ padding: '10px' }}>
                                    <span className={`status-badge ${r.Status?.toLowerCase()}`}>{r.Status}</span>
                                </td>
                                <td style={{ padding: '10px' }}>₱{parseFloat(r.TotalAmount).toLocaleString()}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    )
}
export default ReportsForm
