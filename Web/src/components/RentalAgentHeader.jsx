import { useSearchParams } from 'react-router-dom'
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
  const handleClick = () => {
    sendToWinForms(formName)
    if (onActivate) onActivate(formName)
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

function ReactNavButton({ route, children, onActivate, activeRoute }) {
  const handleClick = () => {
    sendToWinForms(`navigate:${route}`)
    if (onActivate) onActivate(route)
  }
  
  const isActive = activeRoute === route
  return (
    <button 
      onClick={handleClick} 
      className={`nav-link nav-button ${isActive ? 'active' : ''}`}
    >
      {children}
    </button>
  )
}

export default function RentalAgentHeader({ onWinFormActivate, onReactActivate, activeWinForm, activeRoute }) {
  const [searchParams] = useSearchParams()
  const isHeaderMode = searchParams.get('mode') === 'agent-header'
  
  if (!isHeaderMode && !isWebView2()) {
    return null
  }
  
  return (
    <nav className="nav">
      <span className="nav-brand">Vormas - Rental Agent</span>
      <div className="nav-links">
        <ReactNavButton route="/analytics" onActivate={onReactActivate} activeRoute={activeRoute}>Analytics</ReactNavButton>
        <WinFormNavButton formName="openCustomers" activeWinForm={activeWinForm} onActivate={onWinFormActivate}>Customers</WinFormNavButton>
        <WinFormNavButton formName="openRent" activeWinForm={activeWinForm} onActivate={onWinFormActivate}>Rent</WinFormNavButton>
        <WinFormNavButton formName="openReserve" activeWinForm={activeWinForm} onActivate={onWinFormActivate}>Reserve</WinFormNavButton>
        <WinFormNavButton formName="openReturn" activeWinForm={activeWinForm} onActivate={onWinFormActivate}>Return</WinFormNavButton>
      </div>
    </nav>
  )
}

export { isWebView2, sendToWinForms }
