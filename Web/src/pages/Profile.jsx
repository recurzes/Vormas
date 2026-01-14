import { useState, useEffect } from 'react'
import { bridge } from '../api/bridge'

function Profile() {
  const [user, setUser] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phone: '',
    dateOfBirth: '',
    username: ''
  })
  const [loading, setLoading] = useState(true)
  const [saving, setSaving] = useState(false)
  const [message, setMessage] = useState('')

  useEffect(() => {
    fetchUserProfile()
  }, [])

  const fetchUserProfile = async () => {
    try {
      const data = await bridge.getUserProfile()
      setUser({
        firstName: data.firstName || '',
        lastName: data.lastName || '',
        email: data.email || '',
        phone: data.phone || '',
        dateOfBirth: data.dateOfBirth || '',
        username: data.username || ''
      })
    } catch (error) {
      console.log('Profile fetch error:', error.message)
      setMessage('Failed to load profile: ' + error.message)
    } finally {
      setLoading(false)
    }
  }

  const handleChange = (field, value) => {
    setUser(prev => ({ ...prev, [field]: value }))
    setMessage('')
  }

  const handleSave = async () => {
    setSaving(true)
    setMessage('')
    try {
        await bridge.updateUserProfile(user)
        setMessage('Profile updated successfully!')
    } catch (error) {
      setMessage('Error saving profile: ' + error.message)
    } finally {
      setSaving(false)
    }
  }

  if (loading) {
    return <div className="loading">Loading profile...</div>
  }

  return (
    <div style={{ maxWidth: '600px', margin: '0 auto' }}>
      <h1 className="page-title">My Profile</h1>
      
      <div className="chart-card">
        <h3 className="chart-title">Account Information</h3>
        
        <div style={{ display: 'flex', flexDirection: 'column', gap: '16px' }}>
          <div className="filter-group" style={{ flexDirection: 'column', alignItems: 'stretch' }}>
            <label className="filter-label">Username</label>
            <input
              type="text"
              className="filter-input"
              value={user.username}
              disabled
              style={{ background: '#f1f5f9', cursor: 'not-allowed' }}
            />
          </div>
          
          <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '16px' }}>
            <div className="filter-group" style={{ flexDirection: 'column', alignItems: 'stretch' }}>
              <label className="filter-label">First Name</label>
              <input
                type="text"
                className="filter-input"
                value={user.firstName}
                onChange={(e) => handleChange('firstName', e.target.value)}
              />
            </div>
            <div className="filter-group" style={{ flexDirection: 'column', alignItems: 'stretch' }}>
              <label className="filter-label">Last Name</label>
              <input
                type="text"
                className="filter-input"
                value={user.lastName}
                onChange={(e) => handleChange('lastName', e.target.value)}
              />
            </div>
          </div>
          
          <div className="filter-group" style={{ flexDirection: 'column', alignItems: 'stretch' }}>
            <label className="filter-label">Email</label>
            <input
              type="email"
              className="filter-input"
              value={user.email}
              onChange={(e) => handleChange('email', e.target.value)}
            />
          </div>
          
          <div className="filter-group" style={{ flexDirection: 'column', alignItems: 'stretch' }}>
            <label className="filter-label">Phone</label>
            <input
              type="tel"
              className="filter-input"
              value={user.phone}
              onChange={(e) => handleChange('phone', e.target.value)}
            />
          </div>
          
          <div className="filter-group" style={{ flexDirection: 'column', alignItems: 'stretch' }}>
            <label className="filter-label">Date of Birth</label>
            <input
              type="date"
              className="filter-input"
              value={user.dateOfBirth}
              onChange={(e) => handleChange('dateOfBirth', e.target.value)}
            />
          </div>
          
          {message && (
            <div style={{ 
              padding: '12px', 
              borderRadius: '8px', 
              background: message.includes('success') ? '#dcfce7' : '#fee2e2',
              color: message.includes('success') ? '#166534' : '#991b1b'
            }}>
              {message}
            </div>
          )}
          
          <div style={{ marginTop: '24px', display: 'flex', justifyContent: 'flex-end' }}>
            <button 
              className="btn btn-primary" // Assuming this class exists from user management or similar
              onClick={handleSave}
              disabled={saving}
              style={{ minWidth: '120px', padding: '10px 20px', background: '#3b82f6', color: 'white', border: 'none', borderRadius: '6px', cursor: 'pointer' }}
            >
              {saving ? 'Saving...' : 'Save Changes'}
            </button>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Profile
