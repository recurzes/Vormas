import { useState } from 'react'

function DamageClaims() {
    const [claims, setClaims] = useState([
        { id: 'CLM-2024-001', vehicle: 'Toyota Camry (ABC-123)', date: '2024-01-10', type: 'Scratch', cost: 2500, status: 'Pending' },
        { id: 'CLM-2023-089', vehicle: 'Honda Civic (XYZ-789)', date: '2023-12-28', type: 'Dent', cost: 4500, status: 'Approved' },
        { id: 'CLM-2023-075', vehicle: 'Ford Explorer (SUV-001)', date: '2023-11-15', type: 'Broken Light', cost: 8500, status: 'Approved' },
    ])
    const [isModalOpen, setIsModalOpen] = useState(false)
    const [formData, setFormData] = useState({ vehicle: '', type: '', cost: '' })
    const [searchQuery, setSearchQuery] = useState('')
    const [statusFilter, setStatusFilter] = useState('All Statuses')

    const handleAdd = () => {
        const newId = `CLM-2024-${Math.floor(Math.random() * 1000)}`
        setClaims([{
            id: newId,
            vehicle: formData.vehicle,
            type: formData.type,
            cost: parseInt(formData.cost),
            date: new Date().toISOString().split('T')[0],
            status: 'Pending'
        }, ...claims])
        setIsModalOpen(false)
        setFormData({ vehicle: '', type: '', cost: '' })
    }

    const handleReview = (id) => {
        if (confirm('Approve this damage claim?')) {
            setClaims(claims.map(c => c.id === id ? { ...c, status: 'Approved' } : c))
        }
    }

    // Filter Logic
    const filteredClaims = claims.filter(c => {
        const matchesSearch =
            c.id.toLowerCase().includes(searchQuery.toLowerCase()) ||
            c.vehicle.toLowerCase().includes(searchQuery.toLowerCase()) ||
            c.type.toLowerCase().includes(searchQuery.toLowerCase())

        const matchesStatus = statusFilter === 'All Statuses' || c.status === statusFilter

        return matchesSearch && matchesStatus
    })

    return (
        <div>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '24px' }}>
                <h1 className="page-title">Damage Claims</h1>
                <button onClick={() => setIsModalOpen(true)} className="btn btn-primary">New Claim</button>
            </div>

            <div className="filters-bar">
                <div className="filter-group">
                    <span className="filter-label">Search:</span>
                    <input
                        type="text"
                        placeholder="Search ID, vehicle, type..."
                        className="filter-input"
                        style={{ width: '250px' }}
                        value={searchQuery}
                        onChange={(e) => setSearchQuery(e.target.value)}
                    />
                </div>
                <div className="filter-group">
                    <span className="filter-label">Status:</span>
                    <select
                        className="filter-select"
                        value={statusFilter}
                        onChange={(e) => setStatusFilter(e.target.value)}
                    >
                        <option>All Statuses</option>
                        <option>Pending</option>
                        <option>Approved</option>
                        <option>Rejected</option>
                    </select>
                </div>
            </div>

            <div className="kpi-grid">
                <div className="kpi-card">
                    <div className="kpi-label">Pending Approval</div>
                    <div className="kpi-value text-warning">{claims.filter(c => c.status === 'Pending').length}</div>
                </div>
                <div className="kpi-card">
                    <div className="kpi-label">Processing</div>
                    <div className="kpi-value">2</div>
                </div>
                <div className="kpi-card">
                    <div className="kpi-label">Total Claims (YTD)</div>
                    <div className="kpi-value">{claims.length}</div>
                </div>
            </div>

            <div className="kpi-card" style={{ padding: 0, overflow: 'hidden' }}>
                <table className="data-table">
                    <thead>
                        <tr>
                            <th>Claim ID</th>
                            <th>Vehicle</th>
                            <th>Date</th>
                            <th>Damage Type</th>
                            <th>Est. Cost</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredClaims.length > 0 ? filteredClaims.map(c => (
                            <tr key={c.id}>
                                <td style={{ fontWeight: 500 }}>{c.id}</td>
                                <td>{c.vehicle}</td>
                                <td>{c.date}</td>
                                <td>{c.type}</td>
                                <td>₱{c.cost.toLocaleString()}</td>
                                <td>
                                    <span className={`status-badge ${c.status === 'Approved' ? 'active' : 'pending'
                                        }`}>
                                        {c.status}
                                    </span>
                                </td>
                                <td>
                                    <button onClick={() => handleReview(c.id)} className="btn btn-outline" style={{ padding: '4px 8px', fontSize: '12px' }}>
                                        {c.status === 'Pending' ? 'Approve' : 'View'}
                                    </button>
                                </td>
                            </tr>
                        )) : (
                            <tr>
                                <td colSpan="7" style={{ textAlign: 'center', padding: '24px', color: '#64748b' }}>
                                    No claims found.
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>

            {isModalOpen && (
                <div style={{
                    position: 'fixed', top: 0, left: 0, right: 0, bottom: 0,
                    background: 'rgba(0,0,0,0.5)', display: 'flex', alignItems: 'center', justifyContent: 'center'
                }}>
                    <div style={{ background: 'white', padding: '24px', borderRadius: '8px', width: '400px' }}>
                        <h2 style={{ marginBottom: '16px' }}>New Damage Claim</h2>
                        <div style={{ display: 'flex', flexDirection: 'column', gap: '12px' }}>
                            <input
                                placeholder="Vehicle (e.g., Toyota Camry)"
                                className="filter-input"
                                value={formData.vehicle}
                                onChange={e => setFormData({ ...formData, vehicle: e.target.value })}
                            />
                            <input
                                placeholder="Damage Type (e.g., Scratch, Dent)"
                                className="filter-input"
                                value={formData.type}
                                onChange={e => setFormData({ ...formData, type: e.target.value })}
                            />
                            <input
                                placeholder="Estimated Cost"
                                type="number"
                                className="filter-input"
                                value={formData.cost}
                                onChange={e => setFormData({ ...formData, cost: e.target.value })}
                            />
                            <div style={{ display: 'flex', gap: '8px', marginTop: '16px' }}>
                                <button onClick={handleAdd} className="btn btn-primary" style={{ flex: 1 }}>Submit</button>
                                <button onClick={() => setIsModalOpen(false)} className="btn btn-outline" style={{ flex: 1 }}>Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    )
}

export default DamageClaims
