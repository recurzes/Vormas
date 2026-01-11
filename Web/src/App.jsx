import { Routes, Route, NavLink } from 'react-router-dom'
import Dashboard from './pages/Dashboard'
import Calendar from './pages/Calendar'
import ReportsViewer from './pages/ReportsViewer'

function App() {
  return (
    <div className="app">
      <nav className="nav">
        <span className="nav-brand">Vormas Reports</span>
        <div className="nav-links">
          <NavLink to="/" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
            Dashboard
          </NavLink>
          <NavLink to="/calendar" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
            Calendar
          </NavLink>
          <NavLink to="/reports" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
            Reports
          </NavLink>
        </div>
      </nav>
      
      <main className="main-content">
        <Routes>
          <Route path="/" element={<Dashboard />} />
          <Route path="/calendar" element={<Calendar />} />
          <Route path="/reports" element={<ReportsViewer />} />
        </Routes>
      </main>
    </div>
  )
}

export default App
