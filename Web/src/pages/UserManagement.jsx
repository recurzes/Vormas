import { useState } from 'react'

function UserManagement() {
    const [activeTab, setActiveTab] = useState('users')
    const [users, setUsers] = useState([
        { id: 1, name: 'Admin User', email: 'admin@vormas.com', role: 'Administrator', status: 'Active' },
        { id: 2, name: 'John Doe', email: 'john@example.com', role: 'Staff', status: 'Active' },
        { id: 3, name: 'Jane Smith', email: 'jane@example.com', role: 'Staff', status: 'Inactive' },
        { id: 4, name: 'Robert Johnson', email: 'rob@example.com', role: 'Driver', status: 'Active' },
    ])

    // Role Definitions State
    const [roles, setRoles] = useState([
        { id: 1, name: 'Administrator', access: 'Full Access', permissions: 'Manage All, Settings, Reports, Users' },
        { id: 2, name: 'Staff', access: 'Restricted', permissions: 'View/Edit bookings, View vehicles' },
        { id: 3, name: 'Driver', access: 'Basic', permissions: 'View assigned trips only' }
    ])

    const [isUserModalOpen, setIsUserModalOpen] = useState(false)
    const [isRoleModalOpen, setIsRoleModalOpen] = useState(false)

    const [userFormData, setUserFormData] = useState({ name: '', email: '', role: 'Staff' })
    const [roleFormData, setRoleFormData] = useState({ id: null, name: '', access: '', permissions: '' })

    const [searchQuery, setSearchQuery] = useState('')
    const [roleFilter, setRoleFilter] = useState('All Roles')

    const handleAddUser = () => {
        const newId = users.length + 1
        setUsers([...users, { id: newId, ...userFormData, status: 'Active' }])
        setIsUserModalOpen(false)
        setUserFormData({ name: '', email: '', role: 'Staff' })
    }

    const toggleStatus = (id) => {
        setUsers(users.map(u => {
            if (u.id === id) {
                return { ...u, status: u.status === 'Active' ? 'Inactive' : 'Active' }
            }
            return u
        }))
    }

    const handleEditRole = (role) => {
        setRoleFormData({ ...role })
        setIsRoleModalOpen(true)
    }

    const handleSaveRole = () => {
        setRoles(roles.map(r => r.id === roleFormData.id ? roleFormData : r))
        setIsRoleModalOpen(false)
    }

    // Filter Logic
    const filteredUsers = users.filter(u => {
        const matchesSearch =
            u.name.toLowerCase().includes(searchQuery.toLowerCase()) ||
            u.email.toLowerCase().includes(searchQuery.toLowerCase())

        const matchesRole = roleFilter === 'All Roles' || u.role === roleFilter

        return matchesSearch && matchesRole
    })

    return (
        <div>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '24px' }}>
                <h1 className="page-title">User Management</h1>
                {activeTab === 'users' && (
                    <button onClick={() => setIsUserModalOpen(true)} className="btn btn-primary">+ Add User</button>
                )}
            </div>

            <div style={{ marginBottom: '20px', borderBottom: '1px solid var(--border)', display: 'flex', justifyContent: 'space-between', alignItems: 'flex-end' }}>
                <div>
                    <button
                        onClick={() => setActiveTab('users')}
                        style={{
                            padding: '12px 24px',
                            background: 'none',
                            border: 'none',
                            borderBottom: activeTab === 'users' ? '2px solid var(--accent)' : '2px solid transparent',
                            color: activeTab === 'users' ? 'var(--accent)' : 'var(--text-secondary)',
                            fontWeight: 500,
                            cursor: 'pointer'
                        }}
                    >
                        Users
                    </button>
                    <button
                        onClick={() => setActiveTab('roles')}
                        style={{
                            padding: '12px 24px',
                            background: 'none',
                            border: 'none',
                            borderBottom: activeTab === 'roles' ? '2px solid var(--accent)' : '2px solid transparent',
                            color: activeTab === 'roles' ? 'var(--accent)' : 'var(--text-secondary)',
                            fontWeight: 500,
                            cursor: 'pointer'
                        }}
                    >
                        Roles & Permissions
                    </button>
                </div>
            </div>

            <div className="filters-bar">
                {activeTab === 'users' ? (
                    <>
                        <div className="filter-group">
                            <span className="filter-label">Search:</span>
                            <input
                                type="text"
                                placeholder="Search name or email..."
                                className="filter-input"
                                style={{ width: '250px' }}
                                value={searchQuery}
                                onChange={(e) => setSearchQuery(e.target.value)}
                            />
                        </div>
                        <div className="filter-group">
                            <span className="filter-label">Role:</span>
                            <select
                                className="filter-select"
                                value={roleFilter}
                                onChange={(e) => setRoleFilter(e.target.value)}
                            >
                                <option>All Roles</option>
                                <option>Administrator</option>
                                <option>Staff</option>
                                <option>Driver</option>
                            </select>
                        </div>
                    </>
                ) : (
                    <div style={{ padding: '8px 0', color: 'var(--text-secondary)' }}>
                        Manage system roles and their access levels. Note: Role names are system-defined.
                    </div>
                )}
            </div>

            {activeTab === 'users' && (
                <div className="kpi-grid" style={{ gridTemplateColumns: 'repeat(3, 1fr)', marginBottom: '24px' }}>
                    <div className="kpi-card">
                        <div className="kpi-label">Total Users</div>
                        <div className="kpi-value">{users.length}</div>
                    </div>
                    <div className="kpi-card">
                        <div className="kpi-label">Active Now</div>
                        <div className="kpi-value">{users.filter(u => u.status === 'Active').length}</div>
                    </div>
                    <div className="kpi-card">
                        <div className="kpi-label">Inactive</div>
                        <div className="kpi-value">{users.filter(u => u.status === 'Inactive').length}</div>
                    </div>
                </div>
            )}

            <div className="kpi-card" style={{ padding: 0, overflow: 'hidden' }}>
                {activeTab === 'users' ? (
                    <table className="data-table">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Email</th>
                                <th>Role</th>
                                <th>Status</th>
                                <th>Last Login</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {filteredUsers.length > 0 ? filteredUsers.map(u => (
                                <tr key={u.id}>
                                    <td style={{ fontWeight: 500 }}>{u.name}</td>
                                    <td>{u.email}</td>
                                    <td>
                                        <span style={{
                                            padding: '2px 8px',
                                            borderRadius: '4px',
                                            background: u.role === 'Administrator' ? '#e0e7ff' : '#f1f5f9',
                                            color: u.role === 'Administrator' ? '#3730a3' : '#475569',
                                            fontSize: '12px',
                                            fontWeight: 500
                                        }}>
                                            {u.role}
                                        </span>
                                    </td>
                                    <td>
                                        <span className={`status-badge ${u.status === 'Active' ? 'active' : 'cancelled'}`}>
                                            {u.status}
                                        </span>
                                    </td>
                                    <td style={{ color: 'var(--text-secondary)', fontSize: '13px' }}>2 hours ago</td>
                                    <td>
                                        <button
                                            onClick={() => toggleStatus(u.id)}
                                            className="btn btn-outline"
                                            style={{ padding: '4px 8px', fontSize: '12px' }}
                                        >
                                            {u.status === 'Active' ? 'Deactivate' : 'Activate'}
                                        </button>
                                    </td>
                                </tr>
                            )) : (
                                <tr>
                                    <td colSpan="6" style={{ textAlign: 'center', padding: '24px', color: '#64748b' }}>
                                        No users found.
                                    </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                ) : (
                    <table className="data-table">
                        <thead>
                            <tr>
                                <th>Role Name</th>
                                <th>Users Assigned</th>
                                <th>Access Level</th>
                                <th>Permissions</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {roles.map(r => (
                                <tr key={r.id}>
                                    <td style={{ fontWeight: 500 }}>{r.name}</td>
                                    <td>{users.filter(u => u.role === r.name).length}</td>
                                    <td>
                                        <span className={`status-badge ${r.access === 'Full Access' ? 'active' :
                                                r.access === 'Restricted' ? 'pending' : 'cancelled'
                                            }`}>
                                            {r.access}
                                        </span>
                                    </td>
                                    <td style={{ fontSize: '12px', color: 'var(--text-secondary)' }}>{r.permissions}</td>
                                    <td><button onClick={() => handleEditRole(r)} className="btn btn-outline" style={{ padding: '4px 8px', fontSize: '12px' }}>Edit</button></td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                )}
            </div>

            {/* Add User Modal */}
            {isUserModalOpen && (
                <div style={{
                    position: 'fixed', top: 0, left: 0, right: 0, bottom: 0,
                    background: 'rgba(0,0,0,0.5)', display: 'flex', alignItems: 'center', justifyContent: 'center'
                }}>
                    <div style={{ background: 'white', padding: '24px', borderRadius: '8px', width: '400px' }}>
                        <h2 style={{ marginBottom: '16px' }}>Add New User</h2>
                        <div style={{ display: 'flex', flexDirection: 'column', gap: '12px' }}>
                            <input
                                placeholder="Full Name"
                                className="filter-input"
                                value={userFormData.name}
                                onChange={e => setUserFormData({ ...userFormData, name: e.target.value })}
                            />
                            <input
                                placeholder="Email Address"
                                className="filter-input"
                                value={userFormData.email}
                                onChange={e => setUserFormData({ ...userFormData, email: e.target.value })}
                            />
                            <select
                                className="filter-select"
                                value={userFormData.role}
                                onChange={e => setUserFormData({ ...userFormData, role: e.target.value })}
                            >
                                <option value="Staff">Staff</option>
                                <option value="Administrator">Administrator</option>
                                <option value="Driver">Driver</option>
                            </select>
                            <div style={{ display: 'flex', gap: '8px', marginTop: '16px' }}>
                                <button onClick={handleAddUser} className="btn btn-primary" style={{ flex: 1 }}>Save</button>
                                <button onClick={() => setIsUserModalOpen(false)} className="btn btn-outline" style={{ flex: 1 }}>Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
            )}

            {/* Edit Role Modal */}
            {isRoleModalOpen && (
                <div style={{
                    position: 'fixed', top: 0, left: 0, right: 0, bottom: 0,
                    background: 'rgba(0,0,0,0.5)', display: 'flex', alignItems: 'center', justifyContent: 'center'
                }}>
                    <div style={{ background: 'white', padding: '24px', borderRadius: '8px', width: '400px' }}>
                        <h2 style={{ marginBottom: '16px' }}>Edit Role: {roleFormData.name}</h2>

                        <div style={{ display: 'flex', flexDirection: 'column', gap: '16px' }}>
                            <div>
                                <label style={{ display: 'block', marginBottom: '8px', fontSize: '14px', fontWeight: 500 }}>Access Level</label>
                                <select
                                    className="filter-select"
                                    style={{ width: '100%' }}
                                    value={roleFormData.access}
                                    onChange={e => setRoleFormData({ ...roleFormData, access: e.target.value })}
                                >
                                    <option value="Full Access">Full Access</option>
                                    <option value="Restricted">Restricted</option>
                                    <option value="Basic">Basic</option>
                                </select>
                            </div>

                            <div>
                                <label style={{ display: 'block', marginBottom: '8px', fontSize: '14px', fontWeight: 500 }}>Permissions Description</label>
                                <textarea
                                    className="filter-input"
                                    style={{ width: '100%', minHeight: '80px', fontFamily: 'inherit' }}
                                    value={roleFormData.permissions}
                                    onChange={e => setRoleFormData({ ...roleFormData, permissions: e.target.value })}
                                />
                            </div>

                            <div style={{ display: 'flex', gap: '8px', marginTop: '8px' }}>
                                <button onClick={handleSaveRole} className="btn btn-primary" style={{ flex: 1 }}>Update Role</button>
                                <button onClick={() => setIsRoleModalOpen(false)} className="btn btn-outline" style={{ flex: 1 }}>Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    )
}

export default UserManagement
