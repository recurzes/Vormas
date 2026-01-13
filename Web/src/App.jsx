import { Routes, Route, NavLink, useLocation } from 'react-router-dom'
import Dashboard from './pages/Dashboard'
import Calendar from './pages/Calendar'
import ReportsViewer from './pages/ReportsViewer'
import FleetManagement from './pages/FleetManagement'
import UserManagement from './pages/UserManagement'
import RateManagement from './pages/RateManagement'
import DamageClaims from './pages/DamageClaims'
import RentalAgent from './pages/RentalAgent'
import ReservationForm from './pages/ReservationForm'
import RentalForm from './pages/RentalForm'
import ReturnForm from './pages/ReturnForm'
import BillingForm from './pages/BillingForm'
import MaintenanceForm from './pages/MaintenanceForm'
import ReportsForm from './pages/ReportsForm'

function App() {
  const location = useLocation()
  const agentRoutes = ['/agent', '/reservation', '/rental', '/return', '/billing', '/maintenance', '/reports-view']
  const isAgent = agentRoutes.some(path => location.pathname.startsWith(path))

  return (
    <div className="app">
      {!isAgent && (
        <nav className="nav">
          <span className="nav-brand">Vormas System</span>
          <div className="nav-links">
            <NavLink to="/" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>Dashboard</NavLink>
            <NavLink to="/fleet" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>Fleet</NavLink>
            <NavLink to="/users" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>Users</NavLink>
            <NavLink to="/rates" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>Rates</NavLink>
            <NavLink to="/damage-claims" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>Damage</NavLink>
            <NavLink to="/calendar" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>Calendar</NavLink>
            <NavLink to="/reports" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>Reports</NavLink>
            <NavLink to="/agent" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>Agent</NavLink>
          </div>
        </nav>
      )}

      <main className="main-content">
        <Routes>
          <Route path="/" element={<Dashboard />} />
          <Route path="/fleet" element={<FleetManagement />} />
          <Route path="/users" element={<UserManagement />} />
          <Route path="/rates" element={<RateManagement />} />
          <Route path="/damage-claims" element={<DamageClaims />} />
          <Route path="/calendar" element={<Calendar />} />
          <Route path="/reports" element={<ReportsViewer />} />
          <Route path="/agent" element={<RentalAgent />} />
          <Route path="/reservation" element={<ReservationForm />} />
          <Route path="/rental" element={<RentalForm />} />
          <Route path="/return" element={<ReturnForm />} />
          <Route path="/billing" element={<BillingForm />} />
          <Route path="/maintenance" element={<MaintenanceForm />} />
          <Route path="/reports-view" element={<ReportsForm />} />
        </Routes>
      </main>
    </div>
  )
}

export default App
