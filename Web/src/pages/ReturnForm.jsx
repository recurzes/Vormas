import { useState, useEffect } from 'react'
import { bridge } from '../api/bridge'
import { useNavigate } from 'react-router-dom'
import { differenceInDays, parseISO } from 'date-fns'
import '../styles/ReturnForm.css'

function ReturnForm() {
    const navigate = useNavigate()
    const [step, setStep] = useState(1) // 1: Intake, 2: Inspection, 3: Settlement
    const [rentals, setRentals] = useState([])
    const [selectedRental, setSelectedRental] = useState(null)
    const [paymentMethod, setPaymentMethod] = useState(null)
    const [processing, setProcessing] = useState(false)
    const [message, setMessage] = useState(null)

    // Form inputs
    const [returnMileage, setReturnMileage] = useState('')
    const [fuelLevel, setFuelLevel] = useState(100)
    const [hasDamages, setHasDamages] = useState(false)
    const [damageDesc, setDamageDesc] = useState('')
    const [damageCost, setDamageCost] = useState('')

    // Mock for "Blind" Form Issue
    const mockActiveRentals = [
        { RentalId: 801, display: '#801 - John Doe (Toyota Camry)', customerName: 'John Doe', vehicleModel: 'Toyota Camry', startMileage: 15000, rate: 2500, dueDate: '2024-01-20', deposit: 5000, isMock: true },
        { RentalId: 802, display: '#802 - Jane Smith (Honda Civic)', customerName: 'Jane Smith', vehicleModel: 'Honda Civic', startMileage: 20000, rate: 2200, dueDate: '2024-01-12', deposit: 3000, isMock: true }
    ]

    useEffect(() => {
        bridge.getActiveRentals().then(data => {
            if (!data.error && data.length > 0) {
                // Enriching data for demo 
                const enriched = data.map((r, i) => ({
                    ...r,
                    dueDate: i === 0 ? "2024-01-12" : "2024-01-20",
                    customerName: r.customerName || "John Doe",
                    customerPhone: "555-0100",
                    vehicleModel: r.vehicleModel || r.display,
                    startMileage: 15000 + (i * 1000),
                    rate: 2500,
                    deposit: 5000
                }))
                setRentals(enriched)
            } else {
                setRentals(mockActiveRentals)
            }
        })
    }, [])

    const handleSelect = (r) => {
        setSelectedRental(r)
        if (r) {
            setReturnMileage(r.startMileage + 100)
            setFuelLevel(100)
            setHasDamages(false)
            setDamageCost('')
            setPaymentMethod(null)
        }
    }

    // --- Real-time Billing Calculations ---
    const calculateBill = () => {
        if (!selectedRental) return { total: 0, items: [] }

        const items = []
        let total = 0

        // 1. Base Rate (Assuming 3 days for demo)
        const days = 3
        const baseCost = selectedRental.rate * days
        items.push({ label: `Base Rental (${days} days)`, amount: baseCost, sub: `@ ${selectedRental.rate}/day` })
        total += baseCost

        // 2. Late Fee 
        const isOverdue = selectedRental.dueDate === "2024-01-12"
        if (isOverdue) {
            const lateFee = selectedRental.rate * 1.5
            items.push({ label: 'Late Return Penalty', amount: lateFee, isFee: true })
            total += lateFee
        }

        // 3. Fuel Surcharge
        if (fuelLevel < 100) {
            const missing = 100 - fuelLevel
            const fuelCharge = missing * 20 // 20 per %
            items.push({ label: `Refueling Service`, amount: fuelCharge, isFee: true, sub: `${missing}% missing` })
            total += fuelCharge
        }

        // 4. Damages
        if (hasDamages && damageCost) {
            const dmg = parseFloat(damageCost) || 0
            items.push({ label: 'Repair Estimate', amount: dmg, isFee: true })
            total += dmg
        }

        return { total, items, isOverdue }
    }

    const { total, items, isOverdue } = calculateBill()

    const handleNext = () => setStep(s => s + 1)
    const handleBack = () => setStep(s => s - 1)

    const handleSubmit = async () => {
        if (!selectedRental) return
        setProcessing(true)

        // Mock Handle
        if (selectedRental.isMock) {
            setMessage({ type: 'success', text: "Return Processed! Invoice Printed. 📄" })
            setTimeout(() => navigate('/agent'), 2500)
            return
        }

        const result = await bridge.completeRental({
            rentalId: selectedRental.RentalId,
            endMileage: parseFloat(returnMileage),
            finalCost: total
        })

        if (result.success) {
            setMessage({ type: 'success', text: "Return Processed! Invoice Printed. 📄" })
            setTimeout(() => navigate('/agent'), 2500)
        } else {
            setMessage({ type: 'error', text: result.message })
            setProcessing(false)
        }
    }

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
            {/* Main Wizard Area */}
            <div className="wizard-main">
                <div className="wizard-header">
                    <div className="wizard-title-row">
                        <div style={{ display: 'flex', alignItems: 'center', gap: '16px' }}>
                            <button
                                onClick={() => navigate('/agent')}
                                className="toggle-btn"
                                style={{ padding: '8px 12px', fontSize: '13px', width: 'auto', border: '1px solid #cbd5e1' }}
                            >
                                ← Exit
                            </button>
                            <h2 className="wizard-title">Return Inspection</h2>
                        </div>
                    </div>
                    <div className="wizard-steps">
                        <StepIndicator num={1} label="Intake & Logistics" />
                        <StepIndicator num={2} label="Physical Check" />
                        <StepIndicator num={3} label="Settlement" />
                    </div>
                </div>

                <div className="wizard-content">
                    {message && (
                        <div style={{
                            padding: '16px', borderRadius: '12px', marginBottom: '24px',
                            background: message.type === 'error' ? '#fee2e2' : '#dcfce7',
                            color: message.type === 'error' ? '#991b1b' : '#166534',
                            fontWeight: 'bold', textAlign: 'center'
                        }}>
                            {message.text}
                        </div>
                    )}

                    {/* STEP 1: INTAKE */}
                    {step === 1 && (
                        <div>
                            <div className="section-title">1. Select Returning Vehicle</div>
                            <div style={{ display: 'grid', gap: '12px' }}>
                                {rentals.map(r => (
                                    <div
                                        key={r.RentalId}
                                        className={`rental-select-card ${selectedRental?.RentalId === r.RentalId ? 'selected' : ''}`}
                                        onClick={() => handleSelect(r)}
                                    >
                                        <div>
                                            <div style={{ fontWeight: '700', fontSize: '16px' }}>{r.vehicleModel}</div>
                                            <div style={{ fontSize: '13px', color: '#64748b' }}>Customer: {r.customerName}</div>
                                        </div>
                                        <div style={{ textAlign: 'right' }}>
                                            <div style={{ fontSize: '12px', fontWeight: 'bold', color: r.dueDate === '2024-01-12' ? '#ef4444' : '#1e293b' }}>
                                                DUE: {r.dueDate}
                                            </div>
                                            <div style={{ fontSize: '11px', color: '#94a3b8' }}>#{r.RentalId}</div>
                                        </div>
                                    </div>
                                ))}
                            </div>

                            {selectedRental && (
                                <div style={{ marginTop: '32px' }}>
                                    <div className="section-title">2. Odometer Verification</div>
                                    <div style={{ background: '#f8fafc', padding: '20px', borderRadius: '12px', border: '1px solid #e2e8f0', display: 'flex', alignItems: 'center', gap: '24px' }}>
                                        <div>
                                            <div style={{ fontSize: '12px', color: '#64748b', fontWeight: 'bold' }}>START</div>
                                            <div style={{ fontSize: '18px', fontWeight: '600' }}>{selectedRental.startMileage}</div>
                                        </div>
                                        <div style={{ color: '#cbd5e1', fontSize: '24px' }}>➜</div>
                                        <div style={{ flex: 1 }}>
                                            <div style={{ fontSize: '12px', color: '#64748b', fontWeight: 'bold', marginBottom: '4px' }}>RETURN READING</div>
                                            <input
                                                type="number"
                                                style={{ width: '100%', fontSize: '24px', fontWeight: 'bold', padding: '12px', border: '2px solid #cbd5e1', borderRadius: '8px', fontFamily: 'monospace' }}
                                                value={returnMileage}
                                                onChange={e => setReturnMileage(e.target.value)}
                                            />
                                        </div>
                                    </div>
                                    {parseInt(returnMileage) < selectedRental.startMileage && (
                                        <div style={{ color: '#ef4444', fontSize: '13px', marginTop: '8px', fontWeight: 'bold' }}>⚠️ Error: Return mileage cannot be lower than start.</div>
                                    )}
                                </div>
                            )}
                        </div>
                    )}

                    {/* STEP 2: PHYSICAL CHECK */}
                    {step === 2 && (
                        <div>
                            <div className="section-title">Fuel Level Assessment</div>
                            <div className="fuel-slider-wrapper">
                                <input
                                    type="range"
                                    min="0" max="100" step="10"
                                    value={fuelLevel}
                                    onChange={e => setFuelLevel(e.target.value)}
                                    style={{ width: '100%', cursor: 'pointer', height: '8px' }}
                                />
                                <div className="fuel-labels">
                                    <span>Empty ({fuelLevel}%)</span>
                                    <span>Full</span>
                                </div>
                                {fuelLevel < 100 && (
                                    <div style={{ marginTop: '12px', fontSize: '13px', color: '#b91c1c', fontWeight: '600' }}>
                                        Alert: Refueling Fee will be added.
                                    </div>
                                )}
                            </div>

                            <div className="section-title">New Damage Check</div>
                            <div style={{ marginBottom: '24px' }}>
                                <div style={{ fontSize: '14px', color: '#64748b', marginBottom: '12px' }}>Is there any visible new damage to the exterior or interior?</div>
                                <div className="damage-toggle">
                                    <div
                                        className={`toggle-btn no ${!hasDamages ? 'active' : ''}`}
                                        onClick={() => setHasDamages(false)}
                                    >
                                        No New Damage
                                    </div>
                                    <div
                                        className={`toggle-btn yes ${hasDamages ? 'active' : ''}`}
                                        onClick={() => setHasDamages(true)}
                                    >
                                        Yes, Issues Found
                                    </div>
                                </div>
                            </div>

                            {hasDamages && (
                                <div style={{ animation: 'fadeIn 0.3s ease-in' }}>
                                    <div style={{ marginBottom: '16px' }}>
                                        <label style={{ display: 'block', fontSize: '13px', fontWeight: 'bold', marginBottom: '8px' }}>Description of Damage</label>
                                        <textarea
                                            className="search-input"
                                            rows="3"
                                            placeholder="E.g., Scratch on rear bumper..."
                                            value={damageDesc}
                                            onChange={e => setDamageDesc(e.target.value)}
                                        ></textarea>
                                    </div>
                                    <div>
                                        <label style={{ display: 'block', fontSize: '13px', fontWeight: 'bold', marginBottom: '8px' }}>Est. Repair Cost</label>
                                        <input
                                            type="number"
                                            className="search-input"
                                            placeholder="0.00"
                                            value={damageCost}
                                            onChange={e => setDamageCost(e.target.value)}
                                        />
                                    </div>
                                </div>
                            )}
                        </div>
                    )}

                    {/* STEP 3: SETTLEMENT */}
                    {step === 3 && (
                        <div>
                            <div className="section-title">Payment Method</div>
                            <div className="payment-methods">
                                <div
                                    className={`pay-btn ${paymentMethod === 'card' ? 'active' : ''}`}
                                    onClick={() => setPaymentMethod('card')}
                                >
                                    Charge Card
                                </div>
                                <div
                                    className={`pay-btn ${paymentMethod === 'cash' ? 'active' : ''}`}
                                    onClick={() => setPaymentMethod('cash')}
                                >
                                    Cash Payment
                                </div>
                                <div
                                    className={`pay-btn ${paymentMethod === 'deposit' ? 'active' : ''}`}
                                    onClick={() => setPaymentMethod('deposit')}
                                >
                                    Deduct from Deposit
                                </div>
                            </div>

                            {paymentMethod === 'deposit' && (
                                <div style={{ background: '#f0fdf4', border: '1px solid #bbf7d0', padding: '16px', borderRadius: '8px', color: '#166534', fontSize: '14px' }}>
                                    <strong>Available Deposit:</strong> ₱5,000.00
                                    <br />
                                    Remaining after deduction: ₱{Math.max(0, 5000 - total).toLocaleString()}
                                </div>
                            )}

                            <div className="section-title">Manager Comments</div>
                            <textarea
                                className="search-input"
                                placeholder="Optional notes for this return record..."
                                rows="3"
                            ></textarea>
                        </div>
                    )}
                </div>

                <div className="wizard-footer">
                    {step > 1 ? (
                        <button className="btn-back" onClick={handleBack} style={{ border: '1px solid #cbd5e1', padding: '12px 24px', borderRadius: '8px', color: '#475569', fontWeight: '600' }}>Back</button>
                    ) : (<div></div>)}

                    {step < 3 ? (
                        <button
                            style={{ background: '#4f46e5', color: 'white', padding: '12px 24px', border: 'none', borderRadius: '8px', fontWeight: '600', cursor: 'pointer' }}
                            onClick={handleNext}
                            disabled={step === 1 && (!selectedRental || !returnMileage)}
                        >
                            Next Step ➔
                        </button>
                    ) : null}
                </div>
            </div>

            {/* --- RIGHT PANEL: LIVE RECEIPT --- */}
            <div className="receipt-sidebar">
                <div className="receipt-header">
                    <div className="receipt-title">Live Billing Receipt</div>
                    <div style={{ fontSize: '11px', opacity: 0.7, marginTop: '4px' }}>
                        {selectedRental ? `REF: #${selectedRental.RentalId}` : 'NO ACTIVE RENTAL'}
                    </div>
                </div>

                <div className="receipt-body">
                    {selectedRental && <div className="deposit-badge">DEPOSIT HELD: ₱{selectedRental.deposit.toLocaleString()}</div>}

                    {items.length === 0 ? (
                        <div style={{ color: '#94a3b8', fontStyle: 'italic', textAlign: 'center', marginTop: '40px' }}>
                            -- Receipt Empty --
                        </div>
                    ) : (
                        items.map((item, idx) => (
                            <div key={idx} className={`receipt-row ${item.isFee ? 'fee' : ''}`}>
                                <div>
                                    <div>{item.label}</div>
                                    {item.sub && <div style={{ fontSize: '10px', opacity: 0.7 }}>{item.sub}</div>}
                                </div>
                                <div>₱{item.amount.toLocaleString()}</div>
                            </div>
                        ))
                    )}

                    <div className="receipt-divider"></div>

                    <div className="receipt-total-row">
                        <div className="total-label">TOTAL DUE</div>
                        <div className="total-value">₱{total.toLocaleString()}</div>
                    </div>
                </div>

                {step === 3 && (
                    <div style={{ padding: '24px', background: '#f8fafc', borderTop: '1px solid #e2e8f0' }}>
                        <button
                            className="btn-primary-lg"
                            onClick={handleSubmit}
                            disabled={!paymentMethod || processing}
                        >
                            {processing ? 'Processing...' : 'Process Return ⎙'}
                        </button>
                    </div>
                )}
            </div>
        </div>
    )
}

export default ReturnForm
