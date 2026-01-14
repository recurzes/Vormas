import { useState } from 'react'

function RateManagement() {
    const [rates, setRates] = useState([
        { class: 'Economy', daily: 1500, weekly: 9000, monthly: 30000 },
        { class: 'Standard', daily: 2500, weekly: 15000, monthly: 50000 },
        { class: 'SUV', daily: 3500, weekly: 21000, monthly: 70000 },
        { class: 'Luxury', daily: 8000, weekly: 48000, monthly: 150000 },
        { class: 'Van', daily: 4000, weekly: 24000, monthly: 85000 },
    ])
    const [searchQuery, setSearchQuery] = useState('')

    const handleRateChange = (index, field, value) => {
        const newRates = [...rates]
        newRates[index][field] = value
        setRates(newRates)
    }

    const handleSave = () => {
        alert('Rates updated successfully!')
    }

    const filteredRates = rates.filter(r =>
        r.class.toLowerCase().includes(searchQuery.toLowerCase())
    )

    return (
        <div>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '24px' }}>
                <h1 className="page-title">Rate Configuration</h1>
            </div>

            <div className="charts-grid">
                <div className="chart-card">
                    <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '16px' }}>
                        <h3 className="chart-title">Base Rates (Daily)</h3>
                        <input
                            type="text"
                            placeholder="Search class..."
                            className="filter-input"
                            style={{ width: '150px', padding: '6px' }}
                            value={searchQuery}
                            onChange={e => setSearchQuery(e.target.value)}
                        />
                    </div>

                    <table className="data-table">
                        <thead>
                            <tr>
                                <th>Vehicle Class</th>
                                <th>Daily Rate</th>
                                <th>Weekly Rate</th>
                                <th>Monthly Rate</th>
                            </tr>
                        </thead>
                        <tbody>
                            {filteredRates.length > 0 ? filteredRates.map((r, i) => (
                                <tr key={r.class}>
                                    <td style={{ fontWeight: 500 }}>{r.class}</td>
                                    <td>
                                        <input
                                            type="number"
                                            value={r.daily}
                                            onChange={(e) => handleRateChange(i, 'daily', e.target.value)}
                                            className="filter-input"
                                            style={{ width: '100px' }}
                                        />
                                    </td>
                                    <td>
                                        <input
                                            type="number"
                                            value={r.weekly}
                                            onChange={(e) => handleRateChange(i, 'weekly', e.target.value)}
                                            className="filter-input"
                                            style={{ width: '100px' }}
                                        />
                                    </td>
                                    <td>
                                        <input
                                            type="number"
                                            value={r.monthly}
                                            onChange={(e) => handleRateChange(i, 'monthly', e.target.value)}
                                            className="filter-input"
                                            style={{ width: '100px' }}
                                        />
                                    </td>
                                </tr>
                            )) : (
                                <tr>
                                    <td colSpan="4" style={{ textAlign: 'center', padding: '16px' }}>No rates found.</td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                    <div style={{ padding: '16px' }}>
                        <button onClick={handleSave} className="btn btn-outline" style={{ width: '100%' }}>Update Base Rates</button>
                    </div>
                </div>

                <div className="chart-card">
                    <h3 className="chart-title">Seasonal Adjustments</h3>
                    <div style={{ display: 'flex', flexDirection: 'column', gap: '12px' }}>
                        <div style={{ padding: '12px', border: '1px solid var(--border)', borderRadius: '8px' }}>
                            <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '4px' }}>
                                <strong>Peak Season</strong>
                                <span className="status-badge active">+20%</span>
                            </div>
                            <div style={{ fontSize: '12px', color: 'var(--text-secondary)' }}>Dec 15 - Jan 15</div>
                        </div>

                        <div style={{ padding: '12px', border: '1px solid var(--border)', borderRadius: '8px' }}>
                            <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '4px' }}>
                                <strong>Holy Week</strong>
                                <span className="status-badge active">+25%</span>
                            </div>
                            <div style={{ fontSize: '12px', color: 'var(--text-secondary)' }}>Mar 25 - Mar 31</div>
                        </div>

                        <button className="btn btn-primary" style={{ marginTop: '8px' }}>+ Add Season</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default RateManagement
