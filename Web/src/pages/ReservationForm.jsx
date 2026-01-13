import { useState, useEffect } from 'react'
import { bridge } from '../api/bridge'
import { useNavigate } from 'react-router-dom'
import { differenceInDays, addDays, format, parseISO } from 'date-fns'

function ReservationForm() {
    const navigate = useNavigate()
    const [step, setStep] = useState(1) // 1: Customer, 2: Vehicle, 3: Details
    const [customers, setCustomers] = useState([])
    const [vehicles, setVehicles] = useState([])
    const [loading, setLoading] = useState(true)
    const [searchTerm, setSearchTerm] = useState('')

    // Form State
    const [selectedCustomer, setSelectedCustomer] = useState(null)
    const [selectedVehicle, setSelectedVehicle] = useState(null)
    const [dateRange, setDateRange] = useState({
        start: new Date().toISOString().split('T')[0],
        end: addDays(new Date(), 3).toISOString().split('T')[0]
    })

    // Derived State
    const duration = differenceInDays(parseISO(dateRange.end), parseISO(dateRange.start))
    const totalDays = duration > 0 ? duration : 0
    const vehicleRate = selectedVehicle?.rate || 0
    const baseCost = vehicleRate * totalDays
    const taxes = baseCost * 0.12 // 12% VAT
    const totalCost = baseCost + taxes

    useEffect(() => {
        async function loadData() {
            try {
                // Mocking data if bridge fails or for dev
                let custs = [], vehs = []
                try {
                    [custs, vehs] = await Promise.all([bridge.getCustomers(), bridge.getVehicles()])
                } catch (e) {
                    console.warn("Using mock data", e)
                    custs = [
                        { id: 1, name: 'John Doe', license: 'Valid', phone: '555-0101' },
                        { id: 2, name: 'Jane Smith', license: 'Valid', phone: '555-0102' },
                        { id: 3, name: 'Robert Johnson', license: 'Expired', phone: '555-0103' },
                    ]
                    vehs = [
                        { id: 1, display: 'Toyota Camry 2024', rate: 2500, type: 'Sedan' },
                        { id: 2, display: 'Ford Explorer 2023', rate: 4500, type: 'SUV' },
                        { id: 3, display: 'Honda Civic 2022', rate: 2200, type: 'Sedan' },
                        { id: 4, display: 'Toyota Hiace Van', rate: 5000, type: 'Van' },
                    ]
                }
                setCustomers(custs)
                setVehicles(vehs)
            } finally {
                setLoading(false)
            }
        }
        loadData()
    }, [])

    const filteredCustomers = customers.filter(c =>
        c.name.toLowerCase().includes(searchTerm.toLowerCase())
    )

    const handleNext = () => setStep(s => s + 1)
    const handleBack = () => setStep(s => s - 1)

    const handleSubmit = async () => {
        if (!selectedCustomer || !selectedVehicle) return

        const payload = {
            customerId: selectedCustomer.id,
            vehicleId: selectedVehicle.id,
            startDate: dateRange.start,
            endDate: dateRange.end,
            totalCost: totalCost
        }

        console.log("Submitting:", payload)
        try {
            await bridge.createReservation(payload)
            navigate('/agent')
        } catch (e) {
            alert("Error creating reservation: " + e.message)
        }
    }

    // Step Indicators
    const Step = ({ num, label }) => (
        <div className={`step-indicator ${step === num ? 'active' : ''} ${step > num ? 'completed' : ''}`}>
            <span style={{
                width: '24px', height: '24px', borderRadius: '50%',
                background: step >= num ? (step > num ? '#22c55e' : '#4f46e5') : '#cbd5e1',
                color: 'white', display: 'flex', alignItems: 'center', justifyContent: 'center', fontSize: '12px'
            }}>
                {step > num ? '✓' : num}
            </span>
            {label}
        </div>
    )

    return (
        <div className="wizard-container" style={{ padding: '20px', background: '#f8fafc', minHeight: '100vh', display: 'flex', gap: '20px' }}>

            {/* Main Wizard Area */}
            <div className="wizard-main" style={{ flex: 1, background: 'white', borderRadius: '16px', border: '1px solid #e2e8f0', display: 'flex', flexDirection: 'column' }}>
                <div className="wizard-header" style={{ padding: '24px', borderBottom: '1px solid #e2e8f0' }}>
                    <h2 className="wizard-title" style={{ fontSize: '20px', fontWeight: 'bold', marginBottom: '16px' }}>New Booking</h2>
                    <div className="wizard-steps" style={{ display: 'flex', gap: '20px' }}>
                        <Step num={1} label="Customer" />
                        <Step num={2} label="Vehicle" />
                        <Step num={3} label="Details & Confirm" />
                    </div>
                </div>

                <div className="wizard-content" style={{ padding: '32px', flex: 1, overflowY: 'auto' }}>

                    {/* STEP 1: CUSTOMER */}
                    {step === 1 && (
                        <div>
                            <div className="form-section-title">Select Customer</div>
                            <div className="search-container" style={{ marginBottom: '20px' }}>
                                <input
                                    type="text"
                                    placeholder="Search by name or ID..."
                                    className="search-input"
                                    value={searchTerm}
                                    onChange={e => setSearchTerm(e.target.value)}
                                    autoFocus
                                />
                            </div>

                            <div className="customer-results">
                                {filteredCustomers.map(c => (
                                    <div
                                        key={c.id}
                                        className={`customer-result-item ${selectedCustomer?.id === c.id ? 'customer-card-selected' : ''}`}
                                        onClick={() => setSelectedCustomer(c)}
                                    >
                                        <div style={{ display: 'flex', alignItems: 'center', gap: '12px' }}>
                                            <div className="customer-avatar">{c.name.charAt(0)}</div>
                                            <div>
                                                <div style={{ fontWeight: '600' }}>{c.name}</div>
                                                <div style={{ fontSize: '12px', color: '#64748b' }}>{c.phone}</div>
                                            </div>
                                        </div>
                                        {c.license === 'Valid' ?
                                            <span style={{ fontSize: '12px', color: '#166534', background: '#dcfce7', padding: '2px 8px', borderRadius: '4px' }}>Valid License</span> :
                                            <span style={{ fontSize: '12px', color: '#991b1b', background: '#fee2e2', padding: '2px 8px', borderRadius: '4px' }}>License Expired</span>
                                        }
                                    </div>
                                ))}
                            </div>
                        </div>
                    )}

                    {/* STEP 2: VEHICLE */}
                    {step === 2 && (
                        <div>
                            <div className="form-section-title">Select Vehicle</div>
                            <div className="vehicle-grid">
                                {vehicles.map(v => (
                                    <div
                                        key={v.id}
                                        className={`vehicle-card ${selectedVehicle?.id === v.id ? 'selected' : ''}`}
                                        onClick={() => setSelectedVehicle(v)}
                                    >
                                        <div className="vehicle-thumb">🚗</div>
                                        <div className="vehicle-info">
                                            <div className="vehicle-name">{v.display}</div>
                                            <div className="vehicle-rate">₱{(v.rate || 0).toLocaleString()}/day</div>
                                            <div className="vehicle-badge">Available</div>
                                        </div>
                                    </div>
                                ))}
                            </div>
                        </div>
                    )}

                    {/* STEP 3: DETAILS */}
                    {step === 3 && (
                        <div>
                            <div className="form-section-title">Rental Duration</div>
                            <div className="date-row" style={{ display: 'flex', gap: '24px', alignItems: 'center', marginBottom: '32px' }}>
                                <div className="date-input-group" style={{ flex: 1 }}>
                                    <label>Pickup Date</label>
                                    <input
                                        type="date"
                                        className="filter-input"
                                        style={{ width: '100%' }}
                                        value={dateRange.start}
                                        onChange={e => setDateRange({ ...dateRange, start: e.target.value })}
                                    />
                                </div>
                                <div className="date-connector">
                                    <span className="duration-pill">{totalDays} Days</span>
                                </div>
                                <div className="date-input-group" style={{ flex: 1 }}>
                                    <label>Return Date</label>
                                    <input
                                        type="date"
                                        className="filter-input"
                                        style={{ width: '100%' }}
                                        value={dateRange.end}
                                        onChange={e => setDateRange({ ...dateRange, end: e.target.value })}
                                    />
                                </div>
                            </div>

                            <div className="form-section-title">Confirmation</div>
                            <div style={{ background: '#f8fafc', padding: '16px', borderRadius: '8px', border: '1px solid #e2e8f0' }}>
                                <p><strong>Customer:</strong> {selectedCustomer?.name}</p>
                                <p><strong>Vehicle:</strong> {selectedVehicle?.display}</p>
                                <p><strong>Period:</strong> {dateRange.start} to {dateRange.end}</p>
                            </div>
                        </div>
                    )}
                </div>

                <div className="wizard-footer" style={{ padding: '24px', borderTop: '1px solid #e2e8f0', display: 'flex', justifyContent: 'space-between' }}>
                    {step > 1 ?
                        <button className="btn btn-outline" onClick={handleBack}>Back</button> :
                        <button className="btn btn-outline" onClick={() => navigate('/agent')}>Cancel</button>
                    }

                    {step < 3 ?
                        <button className="btn btn-primary" onClick={handleNext} disabled={step === 1 && !selectedCustomer || step === 2 && !selectedVehicle}>Next Step</button> :
                        null
                    }
                </div>
            </div>

            {/* Right Sidebar: Cost Preview */}
            <div className="wizard-sidebar" style={{ width: '300px', background: 'white', borderRadius: '16px', border: '1px solid #e2e8f0', padding: '24px', display: 'flex', flexDirection: 'column' }}>
                <div className="cost-summary-title">Cost Preview</div>

                <div className="cost-row">
                    <span>Rate ({totalDays} days)</span>
                    <span>₱{baseCost.toLocaleString()}</span>
                </div>
                <div className="cost-row">
                    <span>VAT (12%)</span>
                    <span>₱{taxes.toLocaleString()}</span>
                </div>

                <div className="cost-row total">
                    <span>Total Est.</span>
                    <span style={{ fontSize: '24px', color: '#4f46e5' }}>₱{totalCost.toLocaleString()}</span>
                </div>

                <div className="wizard-actions" style={{ marginTop: 'auto' }}>
                    {step === 3 && (
                        <button className="btn btn-primary btn-block" style={{ width: '100%', padding: '12px' }} onClick={handleSubmit}>
                            Confirm Booking
                        </button>
                    )}
                </div>
            </div>

        </div>
    )
}

export default ReservationForm
