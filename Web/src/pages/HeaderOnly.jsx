import { useEffect, useState, useCallback } from 'react'
import { useSearchParams } from 'react-router-dom'
import Header, { isWebView2 } from '../components/Header'

export default function HeaderOnly() {
  const [isInWebView] = useState(isWebView2())
  const [activeWinForm, setActiveWinForm] = useState(null)
  const [searchParams] = useSearchParams()
  
  const initialForm = searchParams.get('form')
  
  useEffect(() => {
    if (initialForm) {
      setActiveWinForm(initialForm)
    }
  }, [initialForm])

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
  }, [])

  const handleReactActivate = useCallback(() => {
    setActiveWinForm(null)
  }, [])

  return (
    <div className="app header-only">
      <Header 
        onWinFormActivate={handleWinFormActivate}
        onReactActivate={handleReactActivate}
        activeWinForm={activeWinForm}
      />
    </div>
  )
}
