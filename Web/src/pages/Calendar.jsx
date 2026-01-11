import { useState, useEffect } from 'react'
import { format, startOfMonth, endOfMonth, eachDayOfInterval, isSameMonth, addMonths, subMonths, getDay } from 'date-fns'

function Calendar() {
  const [currentDate, setCurrentDate] = useState(new Date())
  const [events, setEvents] = useState([])
  const [loading, setLoading] = useState(true)
  const [isLiveData, setIsLiveData] = useState(false)

  const monthStart = startOfMonth(currentDate)
  const monthEnd = endOfMonth(currentDate)
  const days = eachDayOfInterval({ start: monthStart, end: monthEnd })
  
  // Add padding days for week alignment
  const startDayOfWeek = getDay(monthStart)
  const paddingDays = Array(startDayOfWeek).fill(null)
  const allDays = [...paddingDays, ...days]

  useEffect(() => {
    const fetchEvents = async () => {
      setLoading(true)
      try {
        const month = currentDate.getMonth() + 1
        const year = currentDate.getFullYear()
        const res = await fetch(`/api/calendar?month=${month}&year=${year}`)
        if (res.ok) {
          const data = await res.json()
          setEvents(data)
          setIsLiveData(data.length > 0 || true) // API responded
        }
      } catch (error) {
        console.log('Calendar fetch error:', error.message)
      } finally {
        setLoading(false)
      }
    }
    
    fetchEvents()
  }, [currentDate])

  const getEventsForDate = (date) => {
    if (!date) return []
    const dateStr = format(date, 'yyyy-MM-dd')
    return events.filter(e => e.date === dateStr)
  }

  const weekDays = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']

  return (
    <div>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '24px' }}>
        <h1 className="page-title" style={{ margin: 0 }}>
          Vehicle Availability - {format(currentDate, 'MMMM yyyy')}
        </h1>
        <div style={{ display: 'flex', gap: '8px' }}>
          <button className="btn btn-outline" onClick={() => setCurrentDate(subMonths(currentDate, 1))}>
            ← Previous
          </button>
          <button className="btn btn-outline" onClick={() => setCurrentDate(new Date())}>
            Today
          </button>
          <button className="btn btn-outline" onClick={() => setCurrentDate(addMonths(currentDate, 1))}>
            Next →
          </button>
        </div>
      </div>

      {loading ? (
        <div className="loading">Loading calendar...</div>
      ) : (
        <>
          <div style={{ marginBottom: '16px', display: 'flex', gap: '16px' }}>
            <span><span className="calendar-event rental" style={{ marginRight: '4px' }}>■</span> Active Rental</span>
            <span><span className="calendar-event reservation" style={{ marginRight: '4px' }}>■</span> Reservation</span>
          </div>
          
          <div className="calendar-grid">
            {weekDays.map(day => (
              <div key={day} className="calendar-header">{day}</div>
            ))}
            
            {allDays.map((day, index) => {
              const dayEvents = getEventsForDate(day)
              return (
                <div 
                  key={index} 
                  className={`calendar-day ${day && !isSameMonth(day, currentDate) ? 'other-month' : ''}`}
                >
                  {day && (
                    <>
                      <div className="calendar-date">{format(day, 'd')}</div>
                      {dayEvents.slice(0, 3).map((event, i) => (
                        <div key={i} className={`calendar-event ${event.type}`}>
                          {event.title}
                        </div>
                      ))}
                      {dayEvents.length > 3 && (
                        <div style={{ fontSize: '11px', color: 'var(--text-secondary)' }}>
                          +{dayEvents.length - 3} more
                        </div>
                      )}
                    </>
                  )}
                </div>
              )
            })}
          </div>
          
          <p style={{ fontSize: '12px', color: '#64748b', marginTop: '16px', textAlign: 'center' }}>
            {isLiveData ? '🟢 Connected to backend' : '📅 Mock data'}
            {events.length === 0 && ' • No rentals this month'}
          </p>
        </>
      )}
    </div>
  )
}

export default Calendar
