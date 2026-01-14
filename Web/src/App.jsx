import { Routes, Route, useSearchParams } from 'react-router-dom'
import { useEffect, useState, useCallback } from 'react'
import Header, { isWebView2 } from './components/Header'
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

function App() {
  const [isInWebView] = useState(isWebView2())
  const [activeWinForm, setActiveWinForm] = useState(null)
  const [activeRoute, setActiveRoute] = useState('/')
  const [searchParams] = useSearchParams()
  
  const mode = searchParams.get('mode')
  const isHeaderOnly = mode === 'header'
  const isContentOnly = mode === 'content'

  useEffect(() => {
    if (isInWebView) {
      const handleMessage = (event) => {
        const message = event.data
        if (message === 'winFormsActive:false') {
          setActiveWinForm(null)
        }
      }
      window.chrome.webview.addEventListener('message', handleMessage)
      return () => window.chrome.webview.removeEventListener('message', handleMessage)
    }
  }, [isInWebView])

  const handleWinFormActivate = useCallback((formName) => {
    setActiveWinForm(formName)
    setActiveRoute(null)
  }, [])

  const handleReactActivate = useCallback((route) => {
    setActiveWinForm(null)
    setActiveRoute(route)
  }, [])

  if (isHeaderOnly) {
    return (
      <div className="app header-only">
        <Header 
          onWinFormActivate={handleWinFormActivate}
          onReactActivate={handleReactActivate}
          activeWinForm={activeWinForm}
          activeRoute={activeRoute}
        />
      </div>
    )
  }

  return (
    <div className="app">
      {!isContentOnly && (
        <Header 
          onWinFormActivate={handleWinFormActivate}
          onReactActivate={handleReactActivate}
          activeWinForm={activeWinForm}
          activeRoute={activeRoute}
        />
      )}

      <main className={isContentOnly ? "main-content content-only" : "main-content"}>
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
