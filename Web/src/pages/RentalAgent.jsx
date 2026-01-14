import { useState, useEffect } from 'react'
import { useNavigate, useLocation } from 'react-router-dom'
import { LineChart, Line, ResponsiveContainer, Tooltip } from 'recharts'

function SmartKpiCard({ label, value, subtext, trend, trendDir, chartData, color }) {
    const isUp = trendDir === 'up';
    // Using legacy vars for direct color support if needed, but classes preferred
    return (
        <div className="smart-card">
            <div className="smart-card-header">
                <span>{label}</span>
                {/* Mini Sparkline could go here if Recharts was lightweight enough for strict embedding */}
            </div>
            <div className="smart-card-value text-slate-800">{value}</div>

            <div className="flex items-end justify-between mt-2" style={{ display: 'flex', alignItems: 'flex-end', justifyContent: 'space-between', height: '40px' }}>
                <div className="smart-trend">
                    <span className={isUp ? 'trend-up' : 'trend-down'}>
                        {isUp ? '↑' : '↓'} {trend}
                    </span>
                    <span style={{ color: '#94a3b8', fontWeight: '400', marginLeft: '4px' }}>vs last week</span>
                </div>

                <div style={{ width: '80px', height: '30px' }}>
                    <ResponsiveContainer width="100%" height="100%">
                        <LineChart data={chartData}>
                            <Line type="monotone" dataKey="val" stroke={color || "#3b82f6"} strokeWidth={2} dot={false} />
                        </LineChart>
                    </ResponsiveContainer>
                </div>
            </div>
        </div>
    )
}

function SmartActionTile({ label, subtitle, icon, onClick, badge }) {
    return (
        <div className="smart-action-tile" onClick={onClick}>
            {badge && <div className="notification-badge" />}
            <div className="tile-icon-wrapper">
                {icon}
            </div>
            <div className="tile-content">
                <div className="tile-title">{label}</div>
                <div className="tile-subtitle">{subtitle}</div>
            </div>
        </div>
    )
}

function FeedItem({ title, sub, time, type }) {
    const icons = {
        alert: '⚠',
        info: 'ℹ',
        success: '✅'
    };

    // Simple color mapping
    const bg = type === 'alert' ? '#fee2e2' : type === 'success' ? '#dcfce7' : '#e0e7ff';
    const text = type === 'alert' ? '#991b1b' : type === 'success' ? '#166534' : '#3730a3';

    return (
        <div className="feed-item">
            <div className="feed-icon" style={{ background: bg, color: text }}>
                {icons[type] || '•'}
            </div>
            <div className="feed-content">
                <h4>{title}</h4>
                <p>{sub}</p>
                <span className="feed-time">{time}</span>
            </div>
        </div>
    )
}

function SidebarItem({ icon, label, to, active }) {
    return (
        <a className={`sidebar-item ${active ? 'active' : ''}`} href={to}>
            <span>{icon}</span>
            <span>{label}</span>
        </a>
    )
}

// Icons (Simple SVGs representing Duotone style)
const Icons = {
    Book: (
        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
            <rect x="3" y="4" width="18" height="18" rx="2" ry="2"></rect>
            <line x1="16" y1="2" x2="16" y2="6"></line>
            <line x1="8" y1="2" x2="8" y2="6"></line>
            <line x1="3" y1="10" x2="21" y2="10"></line>
        </svg>
    ),
    Key: (
        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
            <path d="M21 2l-2 2m-7.61 7.61a5.5 5.5 0 1 1-7.778 7.778 5.5 5.5 0 0 1 7.777-7.777zm0 0L15.5 7.5m0 0l3 3L22 7l-3-3m-3.5 3.5L19 4"></path>
        </svg>
    ),
    Return: (
        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
            <polyline points="9 11 12 14 22 4"></polyline>
            <path d="M21 12v7a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h11"></path>
        </svg>
    ),
    Invoice: (
        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
            <rect x="2" y="5" width="20" height="14" rx="2"></rect>
            <line x1="2" y1="10" x2="22" y2="10"></line>
        </svg>
    ),
    Wrench: (
        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
            <path d="M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z"></path>
        </svg>
    ),
    Chart: (
        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
            <line x1="18" y1="20" x2="18" y2="10"></line>
            <line x1="12" y1="20" x2="12" y2="4"></line>
            <line x1="6" y1="20" x2="6" y2="14"></line>
        </svg>
    ),
}

function RentalAgent() {
    const navigate = useNavigate()
    const location = useLocation()
    const [loading, setLoading] = useState(false)

    // Mock Data
    const sparkData1 = [{ val: 40 }, { val: 30 }, { val: 45 }, { val: 50 }, { val: 48 }, { val: 60 }, { val: 55 }];
    const sparkData2 = [{ val: 20 }, { val: 25 }, { val: 30 }, { val: 28 }, { val: 35 }, { val: 40 }, { val: 38 }];
    const sparkData3 = [{ val: 10 }, { val: 8 }, { val: 12 }, { val: 15 }, { val: 14 }, { val: 18 }, { val: 20 }];

    const navigateTo = (target) => {
        const routes = {
            'ReservationForm': '/reservation',
            'RentalForm': '/rental',
            'ReturnForm': '/return',
            'BillingForm': '/billing',
            'MaintenanceForm': '/maintenance',
            'ReportsForm': '/reports-view'
        }

        if (routes[target]) {
            navigate(routes[target])
        } else {
            console.log("Nav:", target)
        }
    }

    return (
        <div className="agent-layout">

            {/* 1. Vertical Sidebar */}
            <aside className="agent-sidebar">
                <div className="agent-logo">
                    <div className="agent-logo-icon">V</div>
                    Vormas
                </div>

                <nav className="sidebar-nav">
                    <SidebarItem icon="⚡" label="Dashboard" to="#" active={true} />
                    <SidebarItem icon="🚗" label="Fleet" to="/fleet" />
                    <SidebarItem icon="👥" label="Customers" to="/users" />
                    <SidebarItem icon="📅" label="Calendar" to="/calendar" />
                    <SidebarItem icon="📊" label="Reports" to="/reports" />

                    <div className="sidebar-section-title">System</div>
                    <SidebarItem icon="⚙" label="Settings" to="/rates" />
                    <SidebarItem icon="🔧" label="Maintenance" to="/maintenance" />
                </nav>
            </aside>

            {/* 2. Main Content Area */}
            <main className="agent-main">
                <div className="agent-content-area">
                    <div className="agent-header">
                        <h1 className="agent-greeting">Hello, Agent 👋</h1>
                        <p className="agent-subtitle">Here's what's happening today at Vormas.</p>
                    </div>

                    {/* 3. KPI / Smart Cards */}
                    <div className="smart-card-grid">
                        <SmartKpiCard
                            label="Active Rentals"
                            value="14"
                            trend="12%"
                            trendDir="up"
                            chartData={sparkData1}
                            color="#3b82f6"
                        />
                        <SmartKpiCard
                            label="Pending Returns"
                            value="3"
                            trend="2"
                            trendDir="down"
                            chartData={sparkData2}
                            color="#f59e0b"
                        />
                        <SmartKpiCard
                            label="New Reservations"
                            value="8"
                            trend="5%"
                            trendDir="up"
                            chartData={sparkData3}
                            color="#22c55e"
                        />
                    </div>

                    {/* 4. Smart Action Tiles (Command Center) */}
                    <div className="command-center">
                        <div className="section-label">
                            <span style={{ fontSize: '18px' }}>🚀</span>
                            Quick Actions
                        </div>
                        <div className="command-grid">
                            <SmartActionTile
                                label="Book Vehicle"
                                subtitle="Start new rental"
                                icon={Icons.Book}
                                onClick={() => navigateTo('ReservationForm')}
                            />
                            <SmartActionTile
                                label="Dispatch Car"
                                subtitle="Handover keys"
                                icon={Icons.Key}
                                onClick={() => navigateTo('RentalForm')}
                            />
                            <SmartActionTile
                                label="Receive Return"
                                subtitle="Check-in & Inspection"
                                icon={Icons.Return}
                                badge={true}
                                onClick={() => navigateTo('ReturnForm')}
                            />
                            <SmartActionTile
                                label="Fleet Service"
                                subtitle="Repairs & Cleaning"
                                icon={Icons.Wrench}
                                onClick={() => navigateTo('MaintenanceForm')}
                            />
                            <SmartActionTile
                                label="Create Invoice"
                                subtitle="Billing & Payments"
                                icon={Icons.Invoice}
                                onClick={() => navigateTo('BillingForm')}
                            />
                            <SmartActionTile
                                label="View Reports"
                                subtitle="Analytics & Export"
                                icon={Icons.Chart}
                                onClick={() => navigateTo('ReportsForm')}
                            />
                        </div>
                    </div>
                </div>

                {/* 5. Right Panel (Feed & Stats) */}
                <div className="agent-right-panel">

                    {/* Daily Cash Flow Widget */}
                    <div className="panel-widget">
                        <div className="widget-header">
                            <div className="widget-title">Daily Cash Flow</div>
                            <span style={{ fontSize: '12px', color: '#64748b' }}>₱15,400 / ₱25k</span>
                        </div>
                        <div className="smart-card-value" style={{ fontSize: '24px' }}>₱15,400</div>
                        <div className="progress-container">
                            <div className="progress-bar-bg">
                                <div className="progress-fill" style={{ width: '65%' }}></div>
                            </div>
                            <div className="progress-header" style={{ marginTop: '4px' }}>
                                <span>65% to goal</span>
                            </div>
                        </div>
                    </div>

                    {/* Vehicle Availability Widget */}
                    <div className="panel-widget">
                        <div className="widget-header">
                            <div className="widget-title">Vehicle Status</div>
                        </div>
                        <div className="status-bar-container">
                            <div className="status-segment" style={{ width: '45%', background: '#3b82f6' }}></div>
                            <div className="status-segment" style={{ width: '25%', background: '#f59e0b' }}></div>
                            <div className="status-segment" style={{ width: '30%', background: '#22c55e' }}></div>
                        </div>
                        <div className="status-legend">
                            <div className="legend-item"><div className="legend-dot" style={{ background: '#3b82f6' }}></div> 12 Rented</div>
                            <div className="legend-item"><div className="legend-dot" style={{ background: '#f59e0b' }}></div> 5 Maint.</div>
                            <div className="legend-item"><div className="legend-dot" style={{ background: '#22c55e' }}></div> 8 Available</div>
                        </div>
                    </div>

                    {/* Live Feed */}
                    <div className="panel-widget" style={{ flex: 1 }}>
                        <div className="widget-header">
                            <div className="widget-title">Live Feed</div>
                            <span style={{ fontSize: '10px', background: '#fee2e2', color: '#dc2626', padding: '2px 6px', borderRadius: '4px' }}>2 Urgent</span>
                        </div>
                        <div style={{ display: 'flex', flexDirection: 'column', gap: '4px' }}>
                            <FeedItem
                                type="alert"
                                title="Overdue Return"
                                sub="Toyota Camry #402 is 2 hours overdue."
                                time="10 min ago"
                            />
                            <FeedItem
                                type="info"
                                title="New Reservation"
                                sub="John Doe booked Ford Mustang."
                                time="32 min ago"
                            />
                            <FeedItem
                                type="success"
                                title="Payment Received"
                                sub="Invoice #INV-2024-001 paid."
                                time="1 hour ago"
                            />
                            <FeedItem
                                type="info"
                                title="Maintenance Alert"
                                sub="Oil change due for Honda Civic."
                                time="2 hours ago"
                            />
                        </div>
                    </div>

                </div>
            </main>
        </div>
    )
}

export default RentalAgent
