import { Routes, Route, NavLink, useLocation } from 'react-router-dom'
import { useEffect, useState, useCallback } from 'react'
import Dashboard from './pages/Dashboard'
import Calendar from './pages/Calendar'
import ReportsViewer from './pages/ReportsViewer'
import Analytics from './pages/Analytics'
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

const isWebView2 = () => !!window.chrome?.webview?.postMessage

const sendToWinForms = (message) => {
  if (isWebView2()) {
    window.chrome.webview.postMessage(message)
    return true
  }
  return false
}

function WinFormNavButton({ formName, children, onActivate }) {
  const [isInWebView] = useState(isWebView2())
  
  const handleClick = () => {
    sendToWinForms(formName)
    if (onActivate) onActivate(formName)
  }
  
  if (!isInWebView) {
    const routeMap = {
      'openFleet': '/fleet',
      'openUsers': '/users',
      'openRates': '/rates',
      'openDamage': '/damage-claims'
    }
    return (
      <NavLink 
        to={routeMap[formName]} 
        className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}
      >
        {children}
      </NavLink>
    )
  }

  return (
    <button 
      onClick={handleClick} 
      className="nav-link nav-button"
    >
      {children}
    </button>
  )
}

function ReactNavLink({ to, children, onActivate }) {
  const [isInWebView] = useState(isWebView2())
  
  const handleClick = () => {
    if (isInWebView && onActivate) {
      sendToWinForms('showReact')
      onActivate()
    }
  }
  
  return (
    <NavLink 
      to={to} 
      onClick={handleClick}
      className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}
    >
      {children}
    </NavLink>
  )
}

function App() {
  const location = useLocation()
  const agentRoutes = ['/agent', '/reservation', '/rental', '/return', '/billing', '/maintenance', '/reports-view']
  const isAgent = agentRoutes.some(path => location.pathname.startsWith(path))
  const [isInWebView] = useState(isWebView2())
  const [winFormsActive, setWinFormsActive] = useState(false)
  const [activeWinForm, setActiveWinForm] = useState(null)

  useEffect(() => {
    if (isInWebView) {
      const handleMessage = (event) => {
        const message = event.data
        if (message === 'winFormsActive:true') {
          setWinFormsActive(true)
        } else if (message === 'winFormsActive:false') {
          setWinFormsActive(false)
          setActiveWinForm(null)
        }
      }
      window.chrome.webview.addEventListener('message', handleMessage)
      return () => window.chrome.webview.removeEventListener('message', handleMessage)
    }
  }, [isInWebView])

  const handleWinFormActivate = useCallback((formName) => {
    setActiveWinForm(formName)
    setWinFormsActive(true)
  }, [])

  const handleReactActivate = useCallback(() => {
    setActiveWinForm(null)
    setWinFormsActive(false)
  }, [])

  const getWinFormButtonClass = (formName) => {
    return activeWinForm === formName ? 'nav-link nav-button active' : 'nav-link nav-button'
  }

  return (
    <div className="app">
      <nav className="nav">
        <span className="nav-brand">Vormas System</span>
        <div className="nav-links">
          <ReactNavLink to="/" onActivate={handleReactActivate}>Dashboard</ReactNavLink>
          <WinFormNavButton formName="openFleet" onActivate={handleWinFormActivate}>Fleet</WinFormNavButton>
          <WinFormNavButton formName="openUsers" onActivate={handleWinFormActivate}>Users</WinFormNavButton>
          <WinFormNavButton formName="openRates" onActivate={handleWinFormActivate}>Rates</WinFormNavButton>
          <WinFormNavButton formName="openDamage" onActivate={handleWinFormActivate}>Damage</WinFormNavButton>
          <ReactNavLink to="/calendar" onActivate={handleReactActivate}>Calendar</ReactNavLink>
          <ReactNavLink to="/reports" onActivate={handleReactActivate}>Reports</ReactNavLink>
          <ReactNavLink to="/analytics" onActivate={handleReactActivate}>Analytics</ReactNavLink>
        </div>
      </nav>

      <main className="main-content">
        <Routes>
          <Route path="/" element={<Dashboard />} />
          {!isInWebView && (
            <>
              <Route path="/fleet" element={<FleetManagement />} />
              <Route path="/users" element={<UserManagement />} />
              <Route path="/rates" element={<RateManagement />} />
              <Route path="/damage-claims" element={<DamageClaims />} />
            </>
          )}
          <Route path="/calendar" element={<Calendar />} />
          <Route path="/reports" element={<ReportsViewer />} />
          <Route path="/agent" element={<RentalAgent />} />
          <Route path="/reservation" element={<ReservationForm />} />
          <Route path="/rental" element={<RentalForm />} />
          <Route path="/return" element={<ReturnForm />} />
          <Route path="/billing" element={<BillingForm />} />
          <Route path="/maintenance" element={<MaintenanceForm />} />
          <Route path="/reports-view" element={<ReportsForm />} />
          <Route path="/analytics" element={<Analytics />} />
        </Routes>
      </main>
    </div>
  )
}

export default App
