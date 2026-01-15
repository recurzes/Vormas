import { useState, useEffect } from 'react'
import { bridge } from '../api/bridge'
import { useNavigate } from 'react-router-dom'
import '../styles/RentalForm.css'

function RentalForm() {
    const navigate = useNavigate()
    const [step, setStep] = useState(1) // 1: Identify, 2: Insect, 3: Release
    const [reservations, setReservations] = useState([])
    const [searchTerm, setSearchTerm] = useState('')
    const [selectedRes, setSelectedRes] = useState(null)
    const [processing, setProcessing] = useState(false)
    const [message, setMessage] = useState(null)

    // Step 2 State
    const [startMileage, setStartMileage] = useState('')
    const [prevMileage, setPrevMileage] = useState(null)
    const [fuelLevel, setFuelLevel] = useState(100)
    const [inspectChecks, setInspectChecks] = useState({
        tires: false,
        lights: false,
        scratches: false
    })

    // Step 3 State
    const [finalChecks, setFinalChecks] = useState({
        license: false,
        deposit: false
    })

    // Mock Data for "Blind" Form Issue
    const mockReservations = [
        {
            id: 901,
            display: '#901 - John Doe (Toyota Camry)',
            customerName: 'John Doe',
            vehicleModel: 'Toyota Camry',
            vehicleColor: 'Silver Metallic',
            licenseNumber: 'N02-93-12845',
            depositStatus: 'Paid',
            phone: '0917-555-0101',
            dueTime: '10:00 AM',
            pickupDate: 'Today',
            returnDate: 'Jan 20, 2024',
            customerId: 101,
            vehicleId: 201,
            isMock: true
        },
        {
            id: 902,
            display: '#902 - Jane Smith (Honda Civic)',
            customerName: 'Jane Smith',
            vehicleModel: 'Honda Civic',
            vehicleColor: 'Cosmic Blue',
            licenseNumber: 'N11-04-58291',
            depositStatus: 'Pending',
            phone: '0918-555-0102',
            dueTime: '11:00 AM',
            pickupDate: 'Today',
            returnDate: 'Jan 22, 2024',
            customerId: 102,
            vehicleId: 202,
            isMock: true
        }
    ]

    useEffect(() => {
        bridge.getPendingReservations().then(data => {
            if (!data.error && data.length > 0) {
                // Enrich data if coming from backend
                setReservations(data.map(d => ({
                    ...d,
                    vehicleColor: 'Unknown Color',
                    licenseNumber: 'XXX-XX-XXXXX',
                    depositStatus: 'Paid',
                    phone: '09XX-XXX-XXXX',
                    dueTime: 'Now',
                    pickupDate: 'Today',
                    returnDate: 'TBD'
                })))
            } else {
                setReservations(mockReservations)
            }
        })
    }, [])

    const handleSelect = (res) => {
        setSelectedRes(res)

        // Reset state for new selection
        setStep(1) // Stay on 1 to confirm selection visually, user will click Next
        setInspectChecks({ tires: false, lights: false, scratches: false })
        setFinalChecks({ license: false, deposit: false })
        setStartMileage('')
        setMessage(null)

        // Simulate fetching previous mileage
        const randomBase = Math.floor(Math.random() * 50000) + 10000
        setPrevMileage(randomBase)
    }

    const handleNext = () => setStep(s => s + 1)
    const handleBack = () => setStep(s => s - 1)

    const isStartMileageValid = !startMileage || (parseFloat(startMileage) >= (prevMileage || 0))

    // Validation Logic
    const step1Valid = !!selectedRes
    const step2Valid = startMileage && isStartMileageValid && inspectChecks.tires && inspectChecks.lights && inspectChecks.scratches
    const step3Valid = finalChecks.license && finalChecks.deposit

    const handleSubmit = async () => {
        if (!selectedRes || !step3Valid) return
        setProcessing(true)

        // Mock Handle
        if (selectedRes.isMock) {
            setMessage({ type: 'success', text: "Start Rental Authorized! 🚗 Keys Released." })
            setTimeout(() => navigate('/agent'), 2500)
            return
        }

        const result = await bridge.createRental({
            reservationId: selectedRes.id,
            vehicleId: selectedRes.vehicleId,
            customerId: selectedRes.customerId,
            startMileage: parseInt(startMileage)
        })

        if (result.success) {
            setMessage({ type: 'success', text: "Start Rental Authorized! 🚗 Keys Released." })
            setTimeout(() => navigate('/agent'), 2500)
        } else {
            setMessage({ type: 'error', text: result.message })
            setProcessing(false)
        }
    }

    const filteredReservations = reservations.filter(r =>
        r.customerName.toLowerCase().includes(searchTerm.toLowerCase()) ||
        r.vehicleModel.toLowerCase().includes(searchTerm.toLowerCase())
    )

    const StepIndicator = ({ num, label }) => (
        <div className={`step-item ${step === num ? 'active' : ''} ${step > num ? 'completed' : ''}`}>
            <div className="step-circle">
                {step > num ? '✓' : num}
            </div>
            <span>{label}</span>
        </div>
    )

    return (
        <div className="wizard-container">
            {/* Top Back Button (As per previous request) */}
            <div style={{ position: 'absolute', top: '30px', left: '26px' }}>
                {/* Integrated into page flow now inside wizard logic if possible, 
                 but keeping outside container flow as requested before might be tricky.
                 Let's put a small back button above the card. */}
            </div>

            <div className="wizard-main">
                <div className="wizard-header">
                    <div className="wizard-title-row">
                        <div style={{ display: 'flex', alignItems: 'center', gap: '16px' }}>
                            <button
                                onClick={() => navigate('/agent')}
                                className="btn-back"
                                style={{ padding: '8px 12px', fontSize: '13px' }}
                            >
                                ← Exit
                            </button>
                            <h2 className="wizard-title">Rental Handoff Wizard</h2>
                        </div>
                    </div>
                    <div className="wizard-steps">
                        <StepIndicator num={1} label="Identify" />
                        <StepIndicator num={2} label="Vehicle Check" />
                        <StepIndicator num={3} label="Release" />
                    </div>
                </div>

                <div className="wizard-content">
                    {message && (
                        <div style={{
                            padding: '16px', borderRadius: '12px', marginBottom: '24px',
                            background: message.type === 'error' ? '#fee2e2' : '#dcfce7',
                            color: message.type === 'error' ? '#991b1b' : '#166534',
                            fontSize: '16px', fontWeight: 'bold', textAlign: 'center'
                        }}>
                            {message.text}
                        </div>
                    )}

                    {/* STEP 1: IDENTIFICATION */}
                    {step === 1 && (
                        <div>
                            <h3 style={{ fontSize: '18px', fontWeight: 'bold', marginBottom: '16px', color: '#1e293b' }}>Today's Scheduled Pickups</h3>
                            <div className="search-bar-wrapper">
                                <input
                                    type="text"
                                    className="search-input"
                                    placeholder="Search customer or vehicle..."
                                    value={searchTerm}
                                    onChange={e => setSearchTerm(e.target.value)}
                                    autoFocus
                                />
                            </div>
                            <div className="pickup-list">
                                {filteredReservations.map(r => (
                                    <div
                                        key={r.id}
                                        className={`pickup-row ${selectedRes?.id === r.id ? 'selected' : ''}`}
                                        onClick={() => handleSelect(r)}
                                    >
                                        <div className="pickup-time">{r.dueTime}</div>
                                        <div className="pickup-details">
                                            <div className="pickup-name">{r.customerName}</div>
                                            <div className="pickup-vehicle">🚗 {r.vehicleModel}</div>
                                        </div>
                                        <div style={{ color: '#64748b' }}>➔</div>
                                    </div>
                                ))}
                            </div>
                        </div>
                    )}

                    {/* STEP 2: INSPECTION */}
                    {step === 2 && (
                        <div>
                            <h3 style={{ fontSize: '18px', fontWeight: 'bold', marginBottom: '24px', color: '#1e293b' }}>Vehicle Condition Check</h3>

                            <div className="odometer-section">
                                <div className="odometer-label">
                                    <span>Odometer Reading</span>
                                    <span>Previous: {prevMileage?.toLocaleString()} km</span>
                                </div>
                                <input
                                    type="number"
                                    className={`odometer-input ${!isStartMileageValid ? 'error' : ''}`}
                                    value={startMileage}
                                    onChange={e => setStartMileage(e.target.value)}
                                    placeholder="000000"
                                />
                                {!isStartMileageValid && (
                                    <div style={{ color: '#ef4444', fontSize: '12px', fontWeight: 'bold', marginTop: '8px' }}>
                                        ⚠️ Mileage cannot be lower than previous record.
                                    </div>
                                )}
                            </div>

                            <div className="fuel-slider-container">
                                <div className="odometer-label">Fuel Level: {fuelLevel}%</div>
                                <input
                                    type="range"
                                    min="0" max="100"
                                    value={fuelLevel}
                                    onChange={e => setFuelLevel(e.target.value)}
                                    style={{ width: '100%', cursor: 'pointer' }}
                                />
                                <div style={{ display: 'flex', justifyContent: 'space-between', fontSize: '12px', color: '#64748b', marginTop: '4px' }}>
                                    <span>Empty</span>
                                    <span>Full</span>
                                </div>
                            </div>

                            <div style={{ marginTop: '32px' }}>
                                <div className="odometer-label">Detailed Inspection Checklist</div>
                                <div className="checklist-group">
                                    <div
                                        className={`check-card ${inspectChecks.tires ? 'checked' : ''}`}
                                        onClick={() => setInspectChecks(p => ({ ...p, tires: !p.tires }))}
                                    >
                                        <div style={{ fontSize: '24px', marginBottom: '8px' }}>🛞</div>
                                        <div style={{ fontWeight: '600', fontSize: '14px' }}>Tires OK</div>
                                    </div>
                                    <div
                                        className={`check-card ${inspectChecks.lights ? 'checked' : ''}`}
                                        onClick={() => setInspectChecks(p => ({ ...p, lights: !p.lights }))}
                                    >
                                        <div style={{ fontSize: '24px', marginBottom: '8px' }}>💡</div>
                                        <div style={{ fontWeight: '600', fontSize: '14px' }}>Lights OK</div>
                                    </div>
                                    <div
                                        className={`check-card ${inspectChecks.scratches ? 'checked' : ''}`}
                                        onClick={() => setInspectChecks(p => ({ ...p, scratches: !p.scratches }))}
                                    >
                                        <div style={{ fontSize: '24px', marginBottom: '8px' }}>🔍</div>
                                        <div style={{ fontWeight: '600', fontSize: '14px' }}>No New Damage</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    )}

                    {/* STEP 3: RELEASE */}
                    {step === 3 && (
                        <div>
                            <h3 style={{ fontSize: '18px', fontWeight: 'bold', marginBottom: '24px', color: '#1e293b' }}>Final Confirmation</h3>

                            <div className="final-Checks">
                                <div className="final-check-item">
                                    <input
                                        type="checkbox"
                                        className="custom-checkbox"
                                        checked={finalChecks.license}
                                        onChange={e => setFinalChecks(p => ({ ...p, license: !p.license }))}
                                    />
                                    <span style={{ fontWeight: '500', color: '#334155' }}>Driver's License Verified (Matches Identity)</span>
                                </div>
                                <div className="final-check-item">
                                    <input
                                        type="checkbox"
                                        className="custom-checkbox"
                                        checked={finalChecks.deposit}
                                        onChange={e => setFinalChecks(p => ({ ...p, deposit: !p.deposit }))}
                                    />
                                    <span style={{ fontWeight: '500', color: '#334155' }}>Security Deposit Collected / Authorized</span>
                                </div>
                            </div>

                            <div style={{ marginTop: '24px', background: '#eef2ff', padding: '16px', borderRadius: '8px', color: '#3730a3', fontSize: '14px' }}>
                                <strong>Note:</strong> Releasing the vehicle will generate a timestamped Handover Record and notify the customer.
                            </div>
                        </div>
                    )}
                </div>

                <div className="wizard-footer">
                    {step > 1 ? (
                        <button className="btn-back" onClick={handleBack}>Back</button>
                    ) : (
                        <div></div>
                    )}

                    {step < 3 ? (
                        <button className="btn-next" onClick={handleNext} disabled={(step === 1 && !step1Valid) || (step === 2 && !step2Valid)}>
                            Next Step ➔
                        </button>
                    ) : (
                        <button className="btn-submit" onClick={handleSubmit} disabled={!step3Valid || processing}>
                            {processing ? 'Processing...' : 'Handover Keys 🔑'}
                        </button>
                    )}
                </div>
            </div>

            {/* --- RIGHT SIDEBAR: MANIFEST --- */}
            <div className="wizard-sidebar">
                <div className="sidebar-header">
                    <div className="sidebar-title">Rental Manifest</div>
                </div>

                {selectedRes ? (
                    <div className="manifest-content">
                        {/* Driver Details */}
                        <div className="manifest-section">
                            <span className="manifest-label">Driver Details</span>
                            <div className="manifest-value-main">{selectedRes.customerName}</div>
                            <div className="manifest-value-sub">{selectedRes.phone}</div>
                            <div className="license-valid-badge">License Valid</div>
                        </div>

                        {/* Vehicle Details */}
                        <div className="manifest-section">
                            <span className="manifest-label">Vehicle Assigned</span>
                            <div className="manifest-value-main">{selectedRes.vehicleModel}</div>
                            <div className="manifest-value-sub">{selectedRes.vehicleColor}</div>
                            <div className="manifest-value-sub" style={{ marginTop: '4px' }}>Plate: ABC-1234</div>
                        </div>

                        {/* Schedule */}
                        <div className="manifest-section">
                            <span className="manifest-label">Schedule</span>
                            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '12px' }}>
                                <div>
                                    <div style={{ fontSize: '12px', color: '#64748b' }}>Pickup</div>
                                    <div style={{ fontWeight: '600', color: '#334155' }}>{selectedRes.pickupDate}</div>
                                </div>
                                <div>
                                    <div style={{ fontSize: '12px', color: '#64748b' }}>Return</div>
                                    <div style={{ fontWeight: '600', color: '#334155' }}>{selectedRes.returnDate}</div>
                                </div>
                            </div>
                        </div>

                        {/* Status */}
                        <div className="manifest-section" style={{ marginTop: 'auto', border: 'none' }}>
                            <div style={{ background: '#f8fafc', padding: '12px', borderRadius: '8px', textAlign: 'center' }}>
                                <div style={{ fontSize: '11px', color: '#64748b', textTransform: 'uppercase', fontWeight: 'bold' }}>Reservation Status</div>
                                <div style={{ color: '#0f172a', fontWeight: 'bold' }}>Confirmed</div>
                            </div>
                        </div>
                    </div>
                ) : (
                    <div className="manifest-empty">
                        <p>Select a pending pickup to view manifest details.</p>
                    </div>
                )}
            </div>
        </div>
    )
}

export default RentalForm
