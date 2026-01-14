import { useState } from 'react'

function FleetManagement() {
  const [vehicles, setVehicles] = useState([
    { id: 1, make: 'Toyota', model: 'Camry', year: 2023, plate: 'ABC-123', status: 'Available' },
    { id: 2, make: 'Honda', model: 'Civic', year: 2023, plate: 'XYZ-789', status: 'Rented' },
    { id: 3, make: 'Ford', model: 'Explorer', year: 2022, plate: 'SUV-001', status: 'Maintenance' },
    { id: 4, make: 'BMW', model: '3 Series', year: 2024, plate: 'LUX-888', status: 'Available' },
    { id: 5, make: 'Toyota', model: 'Fortuner', year: 2024, plate: 'SUV-999', status: 'Available' },
  ])
  const [isModalOpen, setIsModalOpen] = useState(false)
  const [formData, setFormData] = useState({ make: '', model: '', year: '', plate: '', status: 'Available' })
  const [searchQuery, setSearchQuery] = useState('')
  const [statusFilter, setStatusFilter] = useState('All Statuses')

  const handleAdd = () => {
    const newId = vehicles.length + 1
    setVehicles([...vehicles, { id: newId, ...formData }])
    setIsModalOpen(false)
    setFormData({ make: '', model: '', year: '', plate: '', status: 'Available' })
  }

  const handleDelete = (id) => {
    if (confirm('Are you sure you want to delete this vehicle?')) {
      setVehicles(vehicles.filter(v => v.id !== id))
    }
  }

  // Filter Logic
  const filteredVehicles = vehicles.filter(v => {
    const matchesSearch =
      v.make.toLowerCase().includes(searchQuery.toLowerCase()) ||
      v.model.toLowerCase().includes(searchQuery.toLowerCase()) ||
      v.plate.toLowerCase().includes(searchQuery.toLowerCase())

    const matchesStatus = statusFilter === 'All Statuses' || v.status === statusFilter

    return matchesSearch && matchesStatus
  })

  return (
    <div>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '24px' }}>
        <h1 className="page-title">Fleet Management</h1>
        <button onClick={() => setIsModalOpen(true)} className="btn btn-primary">+ Add Vehicle</button>
      </div>

      <div className="filters-bar">
        <div className="filter-group">
          <span className="filter-label">Search:</span>
          <input
            type="text"
            placeholder="Search make, model, plate..."
            className="filter-input"
            style={{ width: '250px' }}
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
          />
        </div>
        <div className="filter-group">
          <span className="filter-label">Status:</span>
          <select
            className="filter-select"
            value={statusFilter}
            onChange={(e) => setStatusFilter(e.target.value)}
          >
            <option>All Statuses</option>
            <option>Available</option>
            <option>Rented</option>
            <option>Maintenance</option>
          </select>
        </div>
      </div>

      <div className="kpi-card" style={{ padding: 0, overflow: 'hidden' }}>
        <table className="data-table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Make & Model</th>
              <th>Year</th>
              <th>License Plate</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {filteredVehicles.length > 0 ? filteredVehicles.map(v => (
              <tr key={v.id}>
                <td>#{v.id}</td>
                <td style={{ fontWeight: 500 }}>{v.make} {v.model}</td>
                <td>{v.year}</td>
                <td><span style={{ fontFamily: 'monospace' }}>{v.plate}</span></td>
                <td>
                  <span className={`status-badge ${v.status === 'Available' ? 'active' :
                      v.status === 'Rented' ? 'completed' : 'cancelled'
                    }`}>
                    {v.status}
                  </span>
                </td>
                <td>
                  <button onClick={() => handleDelete(v.id)} className="btn btn-outline" style={{ padding: '4px 8px', fontSize: '12px', color: '#ef4444', borderColor: '#ef4444' }}>Delete</button>
                </td>
              </tr>
            )) : (
              <tr>
                <td colSpan="6" style={{ textAlign: 'center', padding: '24px', color: '#64748b' }}>
                  No vehicles found matching filters.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      {isModalOpen && (
        <div style={{
          position: 'fixed', top: 0, left: 0, right: 0, bottom: 0,
          background: 'rgba(0,0,0,0.5)', display: 'flex', alignItems: 'center', justifyContent: 'center'
        }}>
          <div style={{ background: 'white', padding: '24px', borderRadius: '8px', width: '400px' }}>
            <h2 style={{ marginBottom: '16px' }}>Add New Vehicle</h2>
            <div style={{ display: 'flex', flexDirection: 'column', gap: '12px' }}>
              <input
                placeholder="Make"
                className="filter-input"
                value={formData.make}
                onChange={e => setFormData({ ...formData, make: e.target.value })}
              />
              <input
                placeholder="Model"
                className="filter-input"
                value={formData.model}
                onChange={e => setFormData({ ...formData, model: e.target.value })}
              />
              <input
                placeholder="Year"
                className="filter-input"
                value={formData.year}
                onChange={e => setFormData({ ...formData, year: e.target.value })}
              />
              <input
                placeholder="Plate Number"
                className="filter-input"
                value={formData.plate}
                onChange={e => setFormData({ ...formData, plate: e.target.value })}
              />
              <select
                className="filter-select"
                value={formData.status}
                onChange={e => setFormData({ ...formData, status: e.target.value })}
              >
                <option value="Available">Available</option>
                <option value="Maintenance">Maintenance</option>
              </select>
              <div style={{ display: 'flex', gap: '8px', marginTop: '16px' }}>
                <button onClick={handleAdd} className="btn btn-primary" style={{ flex: 1 }}>Save</button>
                <button onClick={() => setIsModalOpen(false)} className="btn btn-outline" style={{ flex: 1 }}>Cancel</button>
              </div>
            </div>
          </div>
        </div>
      )}

    </div>
  )
}

export default FleetManagement
