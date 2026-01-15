import { useState, useEffect } from 'react'
import { bridge } from '../api/bridge'
import { useNavigate } from 'react-router-dom'
import '../styles/BillingForm.css'

function BillingForm() {
    const navigate = useNavigate()
    const [invoices, setInvoices] = useState([])
    const [selectedId, setSelectedId] = useState('')
    const [selectedInvoice, setSelectedInvoice] = useState(null)

    // Payment State
    const [amount, setAmount] = useState('')
    const [method, setMethod] = useState('Cash') // Cash, Card
    const [tendered, setTendered] = useState('')
    const [isPaid, setIsPaid] = useState(false)
    const [message, setMessage] = useState(null)

    // Virtual Card State
    const [cardNumber, setCardNumber] = useState('')
    const [expiry, setExpiry] = useState('')
    const [cvv, setCvv] = useState('')
    const [cardHolder, setCardHolder] = useState('')

    // Mock Data
    const mockInvoices = [
        { RentalId: 101, display: 'Rental #101 - Toyota Camry', CustomerName: 'John Doe', BalanceDue: 5000, Items: [{ desc: 'Rental Fee (5 Days)', cost: 12500 }, { desc: 'Deposit Paid', cost: -7500 }], isMock: true },
        { RentalId: 102, display: 'Rental #102 - Honda Civic', CustomerName: 'Jane Smith', BalanceDue: 1200, Items: [{ desc: 'Late Fee (2 Days)', cost: 1200 }], isMock: true },
        { RentalId: 103, display: 'Rental #103 - Ford Explorer', CustomerName: 'Mike Ross', BalanceDue: 8500, Items: [{ desc: 'Damage Repair', cost: 8500 }], isMock: true }
    ]

    useEffect(() => {
        bridge.getUnpaidInvoices().then(data => {
            if (!data.error && data.length > 0) setInvoices(data)
            else setInvoices(mockInvoices)
        })
    }, [])

    const handleSelectInvoice = (id) => {
        const inv = invoices.find(i => i.RentalId == id)
        setSelectedId(id)
        setSelectedInvoice(inv)
        setAmount('')
        setTendered('')
        setIsPaid(false)
        setMessage(null)
        // Reset Card
        setCardNumber('')
        setExpiry('')
        setCvv('')
        setCardHolder('')
        if (inv) setAmount(inv.BalanceDue) // Auto-fill amount logic moved here for better UX
    }

    const handleQuickCash = (val) => {
        if (!amount) return
        if (val === 'Exact') setTendered(amount)
        else setTendered(parseFloat(val))
    }

    const handleSubmit = async (e) => {
        e.preventDefault()
        if (!selectedId) return

        // Mock Handle
        if (selectedInvoice?.isMock) {
            setIsPaid(true)
            setMessage({ type: 'success', text: method === 'Cash' ? 'Cash Payment Accepted' : 'Card Authorized Successfully' })
            return
        }

        const result = await bridge.processPayment({ rentalId: selectedId, amount, method })

        if (result.success) {
            setIsPaid(true)
            setMessage({ type: 'success', text: 'Payment Processed Successfully' })
        } else {
            setMessage({ type: 'error', text: result.message })
        }
    }

    // Calculations
    const changeDue = (parseFloat(tendered) || 0) - (parseFloat(amount) || 0)

    // Auto-spacing for card
    const handleCardInput = (e) => {
        const v = e.target.value.replace(/\s/g, '').replace(/\D/g, '')
        const spaced = v.match(/.{1,4}/g)?.join(' ') || v
        setCardNumber(spaced.substring(0, 19))
    }

    return (
        <div className="billing-container">
            {/* LEFT: INVOICE RECEIPT */}
            <div className="invoice-panel">
                <div style={{ marginBottom: '20px' }}>
                    <button onClick={() => navigate('/agent')} style={{ background: 'none', border: 'none', cursor: 'pointer', fontSize: '14px', color: '#64748b' }}>
                        ← Back to Dashboard
                    </button>
                    <select
                        className="form-control"
                        value={selectedId}
                        onChange={(e) => handleSelectInvoice(e.target.value)}
                        style={{ padding: '12px', fontSize: '14px', marginTop: '12px', width: '100%' }}
                    >
                        <option value="">-- Click to Load Invoice --</option>
                        {invoices.map(i => <option key={i.RentalId} value={i.RentalId}>{i.display}</option>)}
                    </select>
                </div>

                {selectedInvoice ? (
                    <div className="invoice-preview-card">
                        {isPaid && <div style={{
                            position: 'absolute', top: '40%', left: '50%', transform: 'translate(-50%, -50%) rotate(-15deg)',
                            border: '4px solid #16a34a', color: '#16a34a', fontSize: '40px', fontWeight: '900', padding: '10px 20px', borderRadius: '8px', opacity: 0.8
                        }}>PAID</div>}

                        <div className="invoice-header">
                            <div className="invoice-h1">VORMAS</div>
                            <div className="invoice-meta">Official Receipt #{selectedInvoice.RentalId}</div>
                            <div className="invoice-meta">{new Date().toLocaleDateString()}</div>
                        </div>

                        <div className="invoice-items">
                            <div style={{ marginBottom: '12px', fontWeight: 'bold' }}>Bill To: {selectedInvoice.CustomerName}</div>
                            {selectedInvoice.Items?.map((item, idx) => (
                                <div key={idx} className="line-item">
                                    <span>{item.desc}</span>
                                    <span>₱{item.cost.toLocaleString()}</span>
                                </div>
                            ))}
                            <div className="line-item total">
                                <span>TOTAL</span>
                                <span>₱{selectedInvoice.BalanceDue.toLocaleString()}</span>
                            </div>
                        </div>

                        <div className="invoice-footer">
                            Thank you for your business.<br />Please keep this receipt for your records.
                        </div>
                    </div>
                ) : (
                    <div className="empty-state">
                        <h3>Waiting for Selection...</h3>
                    </div>
                )}
            </div>

            {/* RIGHT: TERMINAL */}
            <div className="payment-panel">
                <div className="terminal-header">
                    <div className="terminal-title">Checkout Terminal</div>
                    <div className="terminal-subtitle">Select payment method below</div>
                </div>

                {message && !isPaid && (
                    <div style={{ padding: '12px', background: '#fee2e2', color: '#b91c1c', borderRadius: '8px', marginBottom: '16px' }}>{message.text}</div>
                )}

                <div className="method-grid">
                    {['Cash', 'Card'].map(m => (
                        <div
                            key={m}
                            className={`method-btn ${method === m ? 'active' : ''}`}
                            onClick={() => setMethod(m)}
                        >
                            <span className="method-icon">{m === 'Cash' ? '💵' : '💳'}</span>
                            <span className="method-label">{m === 'Cash' ? 'CASH' : 'CARD'}</span>
                        </div>
                    ))}
                </div>

                <div className="amount-display-group">
                    <span className="currency-prefix">₱</span>
                    <input
                        className="amount-input-large"
                        value={amount}
                        readOnly // Auto-filled from invoice to prevent errors
                        placeholder="0.00"
                    />
                </div>

                {/* CASH MODE */}
                {method === 'Cash' && (
                    <div style={{ animation: 'fadeIn 0.2s' }}>
                        <div style={{ marginBottom: '8px', fontSize: '12px', fontWeight: 'bold', color: '#64748b' }}>AMOUNT TENDERED</div>
                        <input
                            type="number"
                            style={{ width: '100%', padding: '16px', fontSize: '24px', border: '2px solid #cbd5e1', borderRadius: '12px', fontFamily: 'monospace' }}
                            placeholder="Enter cash..."
                            value={tendered}
                            onChange={e => setTendered(e.target.value)}
                            disabled={!selectedInvoice || isPaid}
                        />
                        <div className="quick-cash-row">
                            <div className="cash-pill" onClick={() => handleQuickCash('Exact')}>Exact</div>
                            <div className="cash-pill" onClick={() => handleQuickCash(1000)}>₱1000</div>
                            <div className="cash-pill" onClick={() => handleQuickCash(5000)}>₱5000</div>
                            <div className="cash-pill" onClick={() => handleQuickCash(10000)}>₱10000</div>
                        </div>

                        {changeDue >= 0 && (
                            <div className="change-display">
                                <div className="change-label">Change Due</div>
                                <div className="change-amount">₱{changeDue.toLocaleString()}</div>
                            </div>
                        )}
                    </div>
                )}

                {/* CARD MODE */}
                {method === 'Card' && (
                    <div className="virtual-card" style={{ animation: 'fadeIn 0.2s' }}>
                        <div className="card-chip"></div>
                        <div className="card-input-group">
                            <div className="card-label">Card Number</div>
                            <input
                                className="card-input"
                                placeholder="0000 0000 0000 0000"
                                value={cardNumber}
                                onChange={handleCardInput}
                                maxLength={19}
                                disabled={isPaid}
                            />
                        </div>
                        <div className="card-row">
                            <div className="card-input-group" style={{ flex: 1 }}>
                                <div className="card-label">Expiry</div>
                                <input className="card-input" placeholder="MM/YY" value={expiry} onChange={e => setExpiry(e.target.value)} maxLength={5} disabled={isPaid} />
                            </div>
                            <div className="card-input-group" style={{ flex: 1 }}>
                                <div className="card-label">CVV</div>
                                <input className="card-input" placeholder="123" type="password" value={cvv} onChange={e => setCvv(e.target.value)} maxLength={3} disabled={isPaid} />
                            </div>
                        </div>
                        <div className="card-input-group" style={{ marginBottom: 0 }}>
                            <div className="card-label">Cardholder Name</div>
                            <input className="card-input" placeholder="JOHN DOE" value={cardHolder} onChange={e => setCardHolder(e.target.value.toUpperCase())} disabled={isPaid} />
                        </div>
                    </div>
                )}

                {/* ACTIONS */}
                {!isPaid ? (
                    <button
                        className={`btn-process ${method === 'Card' ? 'card-mode' : ''}`}
                        onClick={handleSubmit}
                        disabled={!selectedInvoice || (method === 'Cash' && changeDue < 0) || (method === 'Card' && cardNumber.length < 16)}
                    >
                        {method === 'Cash' ? 'CONFIRM PAYMENT ➔' : 'AUTHORIZE CHARGE 🔒'}
                    </button>
                ) : (
                    <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '12px', marginTop: 'auto' }}>
                        <button className="btn-process" style={{ background: 'white', color: '#0f172a', border: '1px solid #cbd5e1' }} onClick={() => window.print()}>
                            PRINT RECEIPT
                        </button>
                        <button className="btn-process" style={{ background: '#16a34a' }} onClick={() => {
                            setInvoices(prev => prev.filter(i => i.RentalId !== selectedInvoice.RentalId));
                            setSelectedInvoice(null);
                            setSelectedId('');
                            setIsPaid(false);
                            setAmount(''); setTendered('');
                        }}>
                            NEXT SALE ➔
                        </button>
                    </div>
                )}
            </div>
        </div>
    )
}

export default BillingForm
