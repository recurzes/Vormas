import { NavLink, useSearchParams } from 'react-router-dom'
import { useState } from 'react'

const isWebView2 = () => !!window.chrome?.webview?.postMessage

const sendToWinForms = (message) => {
  if (isWebView2()) {
    window.chrome.webview.postMessage(message)
    return true
  }
  return false
}

function WinFormNavButton({ formName, children, activeWinForm, onActivate }) {
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

  const isActive = activeWinForm === formName
  return (
    <button 
      onClick={handleClick} 
      className={`nav-link nav-button ${isActive ? 'active' : ''}`}
    >
      {children}
    </button>
  )
}

function ReactNavLink({ to, children, onActivate, isHeaderMode, activeRoute }) {
  const [isInWebView] = useState(isWebView2())
  
  const handleClick = (e) => {
    if (isInWebView) {
      if (isHeaderMode) {
        e.preventDefault()
        sendToWinForms(`navigate:${to}`)
      }
      if (onActivate) onActivate(to)
    }
  }
  
  const isActive = activeRoute === to
  
  if (isInWebView && isHeaderMode) {
    return (
      <button 
        onClick={handleClick} 
        className={`nav-link nav-button ${isActive ? 'active' : ''}`}
      >
        {children}
      </button>
    )
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
}function UserActions({ isHeaderMode, onReactActivate }) {
  const [isInWebView] = useState(isWebView2())

  const handleProfileClick = () => {
    if (isInWebView && isHeaderMode) {
      sendToWinForms('navigate:/profile')
    }
    if (onReactActivate) onReactActivate('/profile')
  }

  const handleLogout = () => {
    if (isInWebView) {
      sendToWinForms('logout')
    } else {
      window.location.href = '/'
    }
  }

  return (
    <div className="user-actions">
      {isInWebView && isHeaderMode ? (
        <button className="nav-link nav-button" onClick={handleProfileClick}>
          Profile
        </button>
      ) : (
        <NavLink to="/profile" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
          Profile
        </NavLink>
      )}
      <button className="btn-logout" onClick={handleLogout}>
        Logout
      </button>
    </div>
  )
}

function UserActions({ isHeaderMode, onReactActivate }) {
  const [isInWebView] = useState(isWebView2())

  const handleProfileClick = () => {
    if (isInWebView && isHeaderMode) {
      sendToWinForms('navigate:/profile')
    }
    if (onReactActivate) onReactActivate('/profile')
  }

  const handleLogout = () => {
    if (isInWebView) {
      sendToWinForms('logout')
    } else {
      window.location.href = '/'
    }
  }

  return (
    <div className="user-actions">
      {isInWebView && isHeaderMode ? (
        <button className="nav-link nav-button" onClick={handleProfileClick}>
          Profile
        </button>
      ) : (
        <NavLink to="/profile" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
          Profile
        </NavLink>
      )}
      <button className="btn-logout" onClick={handleLogout}>
        Logout
      </button>
    </div>
  )
}

export default function Header({ onWinFormActivate, onReactActivate, activeWinForm, activeRoute }) {
  const [searchParams] = useSearchParams()
  const isHeaderMode = searchParams.get('mode') === 'header' || searchParams.get('mode') === 'agent-header'
  
  return (
    <nav className="nav">
      <span className="nav-brand">Vormas System</span>
      <div className="nav-links">
        <ReactNavLink to="/" onActivate={onReactActivate} isHeaderMode={isHeaderMode} activeRoute={activeRoute}>Dashboard</ReactNavLink>
        <WinFormNavButton formName="openFleet" activeWinForm={activeWinForm} onActivate={onWinFormActivate}>Fleet</WinFormNavButton>
        <WinFormNavButton formName="openUsers" activeWinForm={activeWinForm} onActivate={onWinFormActivate}>Users</WinFormNavButton>
        <WinFormNavButton formName="openRates" activeWinForm={activeWinForm} onActivate={onWinFormActivate}>Rates</WinFormNavButton>
        <WinFormNavButton formName="openDamage" activeWinForm={activeWinForm} onActivate={onWinFormActivate}>Damage</WinFormNavButton>
        <ReactNavLink to="/calendar" onActivate={onReactActivate} isHeaderMode={isHeaderMode} activeRoute={activeRoute}>Calendar</ReactNavLink>
        <ReactNavLink to="/reports" onActivate={onReactActivate} isHeaderMode={isHeaderMode} activeRoute={activeRoute}>Reports</ReactNavLink>
        <ReactNavLink to="/analytics" onActivate={onReactActivate} isHeaderMode={isHeaderMode} activeRoute={activeRoute}>Analytics</ReactNavLink>
      </div>
      <UserActions isHeaderMode={isHeaderMode} onReactActivate={onReactActivate} />
    </nav>
  )
}

export { isWebView2, sendToWinForms }
