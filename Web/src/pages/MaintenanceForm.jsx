import { useState, useEffect } from 'react'
import { bridge } from '../api/bridge'
import { useNavigate } from 'react-router-dom'
import { format, differenceInDays, parseISO } from 'date-fns'
import '../styles/MaintenanceForm.css' // Import new styles

function MaintenanceForm() {
    const navigate = useNavigate()
    const [vehicles, setVehicles] = useState([])
    const [selectedVehicleId, setSelectedVehicleId] = useState('')
    const [selectedVehicle, setSelectedVehicle] = useState(null)

    // Form State
    const [category, setCategory] = useState('Routine')
    const [priority, setPriority] = useState('low')
    const [description, setDescription] = useState('')
    const [expectedDate, setExpectedDate] = useState('')
    const [assignedVendor, setAssignedVendor] = useState('')
    const [projectedCost, setProjectedCost] = useState('')

    // Active Tickets State (Mocked init)
    const [activeTickets, setActiveTickets] = useState([
        { id: 901, vehicle: 'Ford Explorer (SUV-999)', category: 'Accident', priority: 'high', desc: 'Rear bumper collision repair', reported: '2024-01-10', expected: '2024-01-15', status: 'In Shop' },
        { id: 902, vehicle: 'Honda Civic (ABC-789)', category: 'Routine', priority: 'low', desc: '5,000km PMS and Oil Change', reported: '2024-01-12', expected: '2024-01-12', status: 'In Shop' },
        { id: 903, vehicle: 'Toyota Camry (XYZ-123)', category: 'Inspection', priority: 'med', desc: 'Annual Safety Inspection', reported: '2024-01-08', expected: '2024-01-14', status: 'Waiting for Parts' }
    ])

    // Filter State
    const [filter, setFilter] = useState('All')

    // Manage/Complete Modal State
    const [showManageModal, setShowManageModal] = useState(false)
    const [selectedTicket, setSelectedTicket] = useState(null)
    const [finalCost, setFinalCost] = useState('')
    const [serviceNotes, setServiceNotes] = useState('')
    const [message, setMessage] = useState(null)

    useEffect(() => {
        bridge.getVehicles().then(data => { if (!data.error) setVehicles(data) })
    }, [])

    const handleVehicleSelect = (e) => {
        const id = parseInt(e.target.value)
        setSelectedVehicleId(id)
        const v = vehicles.find(veh => veh.id === id)
        setSelectedVehicle(v || null)
    }

    const handleLogTicket = async (e) => {
        e.preventDefault()
        if (!selectedVehicle) return

        const newTicket = {
            id: Date.now(),
            vehicle: selectedVehicle.display,
            category,
            priority,
            desc: description,
            reported: format(new Date(), 'yyyy-MM-dd'),
            expected: expectedDate,
            status: 'In Shop',
            vendor: assignedVendor,
            projectedCost: projectedCost
        }

        await bridge.logMaintenance({
            vehicleId: selectedVehicle.id,
            description: `[${category}] ${description} (${assignedVendor})`,
            expectedCompletion: expectedDate
        })

        setActiveTickets([newTicket, ...activeTickets])
        setMessage({ type: 'success', text: 'Service Ticket Created Successfully' })

        // Reset Form
        setDescription('')
        setPriority('low')
        setCategory('Routine')
        setExpectedDate('')
        setAssignedVendor('')
        setProjectedCost('')
        setTimeout(() => setMessage(null), 3000)
    }

    const openManageModal = (ticket) => {
        setSelectedTicket(ticket)
        setFinalCost('')
        setServiceNotes('')
        setShowManageModal(true)
    }

    const handleFinalizeService = async () => {
        if (!selectedTicket) return
        await bridge.completeMaintenance(selectedTicket.vehicleId || 0)
        setActiveTickets(activeTickets.filter(t => t.id !== selectedTicket.id))
        setShowManageModal(false)
        setSelectedTicket(null)
        setMessage({ type: 'success', text: `Service Finalized! Recorded Cost: ₱${finalCost}` })
        setTimeout(() => setMessage(null), 3000)
    }

    // Calculated Metrics
    const activeCount = activeTickets.length
    const estTotalCost = activeTickets.reduce((acc, t) => acc + (parseFloat(t.projectedCost) || 5000), 0)
    const availability = Math.round(((vehicles.length - activeCount) / (vehicles.length || 1)) * 100)

    // Filter Logic
    const filteredTickets = activeTickets.filter(t => {
        if (filter === 'All') return true
        if (filter === 'High Priority') return t.priority === 'high'
        if (filter === 'Waiting for Parts') return t.status === 'Waiting for Parts'
        if (filter === 'Routine') return t.category === 'Routine'
        return true
    })

    const categories = ['Routine', 'Accident', 'Inspection', 'Engine', 'Body', 'Tires']

    const getCatClass = (cat) => {
        if (cat === 'Routine') return 'cat-routine'
        if (cat === 'Accident') return 'cat-accident'
        if (cat === 'Inspection') return 'cat-inspection'
        return 'cat-general'
    }

    return (
        <div style={{ maxWidth: '1200px', margin: '0 auto', padding: '20px' }}>
            <div style={{ marginBottom: '16px' }}>
                <button
                    onClick={() => navigate('/agent')}
                    style={{
                        background: '#f1f5f9',
                        border: 'none',
                        borderRadius: '6px',
                        padding: '8px 16px',
                        color: '#0f172a',
                        fontWeight: '600',
                        cursor: 'pointer',
                        display: 'flex',
                        alignItems: 'center',
                        gap: '6px',
                        fontSize: '14px'
                    }}
                >
                    <span>←</span> Back
                </button>
            </div>
            <h2 className="page-title">Fleet Health Command Center</h2>

            {/* Top Metrics Bar */}
            <div className="metrics-bar">
                <div className="metric-card">
                    <div className="metric-icon-wrapper" style={{ background: availability > 80 ? '#dcfce7' : '#fee2e2', color: availability > 80 ? '#15803d' : '#b91c1c' }}>
                        📊
                    </div>
                    <div>
                        <div style={{ fontSize: '12px', color: '#64748b', fontWeight: 'bold' }}>FLEET AVAILABILITY</div>
                        <div style={{ fontSize: '24px', fontWeight: '800', color: '#1e293b' }}>{availability}%</div>
                    </div>
                </div>
                <div className="metric-card">
                    <div className="metric-icon-wrapper" style={{ background: '#eff6ff', color: '#2563eb' }}>
                        🔧
                    </div>
                    <div>
                        <div style={{ fontSize: '12px', color: '#64748b', fontWeight: 'bold' }}>ACTIVE REPAIRS</div>
                        <div style={{ fontSize: '24px', fontWeight: '800', color: '#1e293b' }}>{activeCount}</div>
                    </div>
                </div>
                <div className="metric-card">
                    <div className="metric-icon-wrapper" style={{ background: '#fff7ed', color: '#ea580c' }}>
                        💰
                    </div>
                    <div>
                        <div style={{ fontSize: '12px', color: '#64748b', fontWeight: 'bold' }}>EST. REPAIR COSTS</div>
                        <div style={{ fontSize: '24px', fontWeight: '800', color: '#1e293b' }}>₱{estTotalCost.toLocaleString()}</div>
                    </div>
                </div>
            </div>

            <div className="maintenance-container" style={{ height: 'calc(100vh - 200px)' }}>

                {/* Left Col: New Card-Based Form */}
                <div className="ticket-form-col">
                    <div className="form-card">
                        <div className="form-card-header">
                            <h3 style={{ fontSize: '16px', fontWeight: '700', color: '#1e293b', margin: 0 }}>Log New Ticket</h3>
                            <div style={{ fontSize: '12px', color: '#64748b', marginTop: '4px' }}>Create a service request for fleet vehicles.</div>
                        </div>

                        <div className="form-card-body">
                            {message && <div className={`alert ${message.type === 'error' ? 'alert-danger' : 'alert-success'}`} style={{ fontSize: '12px', marginBottom: '16px' }}>{message.text}</div>}

                            <form onSubmit={handleLogTicket}>
                                {/* Section 1: Vehicle Context */}
                                <div className="form-section">
                                    <div className="form-section-header">Vehicle Context</div>
                                    <div className="form-group">
                                        <select
                                            className="form-control"
                                            value={selectedVehicleId}
                                            onChange={handleVehicleSelect}
                                            required
                                            style={{ fontSize: '14px', padding: '10px' }}
                                        >
                                            <option value="">-- Select Fleet Vehicle --</option>
                                            {vehicles.map(v => <option key={v.id} value={v.id}>{v.display}</option>)}
                                        </select>
                                    </div>

                                    {selectedVehicle && (
                                        <div className="vehicle-snapshot">
                                            <div className="snapshot-details">
                                                <span className="snapshot-name">{selectedVehicle.display}</span>
                                                <span className="snapshot-meta">ID: #{selectedVehicle.id} • Type: {selectedVehicle.type}</span>
                                            </div>
                                            <span className="snapshot-status available">Available</span>
                                        </div>
                                    )}
                                </div>

                                <div className="form-divider" style={{ height: '1px', background: '#e2e8f0', margin: '24px 0' }}></div>

                                {/* Section 2: Classification */}
                                <div className="form-section">
                                    <div className="form-section-header">Classification</div>

                                    <div className="form-group">
                                        <label className="filter-label" style={{ marginBottom: '8px', display: 'block' }}>Issue Category</label>
                                        <div className="chip-group">
                                            {categories.map(cat => (
                                                <div
                                                    key={cat}
                                                    className={`chip-option ${category === cat ? 'active' : ''}`}
                                                    onClick={() => setCategory(cat)}
                                                >
                                                    {cat}
                                                </div>
                                            ))}
                                        </div>
                                    </div>

                                    <div className="form-group" style={{ marginTop: '16px' }}>
                                        <label className="filter-label" style={{ marginBottom: '8px', display: 'block' }}>Priority Level</label>
                                        <div className="priority-wrapper">
                                            {[
                                                { id: 'low', label: 'Routine', color: 'blue' },
                                                { id: 'med', label: 'Urgent', color: 'orange' },
                                                { id: 'high', label: 'Critical', color: 'red' }
                                            ].map(p => (
                                                <div
                                                    key={p.id}
                                                    className={`priority-option ${p.id} ${priority === p.id ? 'selected' : ''}`}
                                                    onClick={() => setPriority(p.id)}
                                                >
                                                    <div className={`priority-radio ${priority === p.id ? 'checked' : ''}`}></div>
                                                    <span className="priority-label">{p.label}</span>
                                                </div>
                                            ))}
                                        </div>
                                    </div>
                                </div>

                                <div className="form-divider" style={{ height: '1px', background: '#e2e8f0', margin: '24px 0' }}></div>

                                {/* Section 3: Work Order Details */}
                                <div className="form-section">
                                    <div className="form-section-header">Work Order Details</div>

                                    <div className="work-order-grid">
                                        {/* Row 1 */}
                                        <div className="form-group">
                                            <label className="filter-label">Assigned Vendor</label>
                                            <div className="input-with-icon">
                                                <span className="input-icon-prefix">🏪</span>
                                                <input
                                                    type="text"
                                                    className="form-control has-prefix"
                                                    placeholder="Repair Shop / Dealer"
                                                    value={assignedVendor}
                                                    onChange={e => setAssignedVendor(e.target.value)}
                                                />
                                            </div>
                                        </div>

                                        <div className="form-group">
                                            <label className="filter-label">Est. Completion</label>
                                            <input
                                                type="date"
                                                className="form-control"
                                                value={expectedDate}
                                                onChange={e => setExpectedDate(e.target.value)}
                                            />
                                        </div>

                                        {/* Row 2 */}
                                        <div className="form-group">
                                            <label className="filter-label">Projected Cost</label>
                                            <div className="input-with-icon">
                                                <span className="input-icon-prefix">₱</span>
                                                <input
                                                    type="number"
                                                    className="form-control font-mono has-prefix"
                                                    placeholder="0.00"
                                                    value={projectedCost}
                                                    onChange={e => setProjectedCost(e.target.value)}
                                                />
                                            </div>
                                        </div>

                                        <div className="form-group">
                                            <label className="filter-label">Status Preview</label>
                                            <div className="status-pill-container">
                                                <span className="status-pill pending">
                                                    In Shop (Pending)
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    {/* Full Width Scope */}
                                    <div className="form-group scope-group">
                                        <label className="filter-label bold-label">SCOPE OF WORK / TECHNICAL NOTES</label>
                                        <textarea
                                            className="form-control scope-input"
                                            rows="4"
                                            required
                                            placeholder="Describe the issue, noises, or specific service required..."
                                            value={description}
                                            onChange={e => setDescription(e.target.value)}
                                        ></textarea>
                                    </div>
                                </div>

                                <button type="submit" className="btn btn-primary" style={{ width: '100%', padding: '12px', fontSize: '15px', fontWeight: 'bold' }}>Create Service Ticket</button>
                            </form>
                        </div>
                    </div>
                </div>

                {/* Right Col: Active Feed */}
                <div className="active-issues-col">
                    <div className="filter-pills">
                        {['All', 'High Priority', 'Waiting for Parts', 'Routine'].map(f => (
                            <div
                                key={f}
                                className={`filter-pill ${filter === f ? 'active' : ''}`}
                                onClick={() => setFilter(f)}
                            >
                                {f}
                            </div>
                        ))}
                    </div>

                    <div className="tickets-grid">
                        {filteredTickets.map(ticket => {
                            const daysInShop = differenceInDays(new Date(), parseISO(ticket.reported))
                            const isOverdue = ticket.expected && new Date() > parseISO(ticket.expected)

                            return (
                                <div key={ticket.id} className={`ticket-card ${ticket.priority === 'high' ? 'high' : ticket.priority === 'med' ? 'med' : 'low'}`}>
                                    <div className="ticket-header">
                                        <div>
                                            <span className={`cat-badge ${getCatClass(ticket.category)}`}>{ticket.category}</span>
                                            <span style={{ fontSize: '11px', color: '#94a3b8' }}>#{ticket.id}</span>
                                        </div>
                                        <div className={`time-badge ${isOverdue ? 'overdue' : ''}`}>
                                            ⏱️ {daysInShop} Days
                                        </div>
                                    </div>

                                    <div className="ticket-vehicle">{ticket.vehicle}</div>
                                    <div style={{ fontSize: '12px', color: '#475569', marginBottom: '8px', lineHeight: '1.4' }}>
                                        {ticket.desc}
                                    </div>

                                    {ticket.vendor && (
                                        <div style={{ fontSize: '11px', color: '#64748b', marginBottom: '8px' }}>
                                            📍 At: <strong>{ticket.vendor}</strong>
                                        </div>
                                    )}

                                    <div className="ticket-meta">
                                        <span>Exp: {ticket.expected || 'TBD'}</span>
                                        <span>Est: ₱{(parseFloat(ticket.projectedCost) || 0).toLocaleString()}</span>
                                    </div>

                                    <button
                                        className="btn-manage"
                                        onClick={() => openManageModal(ticket)}
                                    >
                                        ⚙️ Manage
                                    </button>
                                </div>
                            )
                        })}
                    </div>
                </div>

                {/* Manage Modal */}
                {showManageModal && (
                    <div className="modal-overlay">
                        <div className="modal-card">
                            <h3 className="page-title" style={{ fontSize: '18px', marginBottom: '16px' }}>Manage Service Ticket</h3>
                            <p style={{ fontSize: '13px', color: '#64748b', marginBottom: '20px' }}>
                                Ticket #{selectedTicket?.id} - <strong>{selectedTicket?.vehicle}</strong>
                            </p>

                            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '12px', marginBottom: '20px' }}>
                                <button className="btn btn-outline" style={{ fontSize: '12px' }}>📝 Add Note</button>
                                <button className="btn btn-outline" style={{ fontSize: '12px' }}>🔄 Update Status</button>
                            </div>

                            <div style={{ borderTop: '1px solid #e2e8f0', paddingTop: '20px' }}>
                                <h4 style={{ fontSize: '14px', fontWeight: 'bold', marginBottom: '12px' }}>Finalize & Close</h4>
                                <div className="form-group">
                                    <label className="filter-label">Actual Service Cost (₱)</label>
                                    <input
                                        type="number"
                                        className="form-control font-mono"
                                        placeholder="0.00"
                                        value={finalCost}
                                        onChange={e => setFinalCost(e.target.value)}
                                        autoFocus
                                    />
                                </div>

                                <div style={{ display: 'flex', gap: '12px' }}>
                                    <button className="btn btn-success" style={{ flex: 1 }} onClick={handleFinalizeService}>Finalize</button>
                                    <button className="btn btn-outline" style={{ flex: 1 }} onClick={() => setShowManageModal(false)}>Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                )}
            </div>
        </div>
    )
}
export default MaintenanceForm
