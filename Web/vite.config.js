import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
const MOCK_DATA = {
  kpis: {
    totalRevenue: 30240,
    outstandingBalance: 20240,
    activeRentals: 0,
    completedRentals: 2,
    totalCustomers: 2,
    fleetSize: 4,
    availableVehicles: 4,
    pendingDamages: 3,
    totalDamageCosts: 2500
  },
  revenueTrend: [
    { month: 'Oct', revenue: 45000 },
    { month: 'Nov', revenue: 52000 },
    { month: 'Dec', revenue: 48000 },
    { month: 'Jan', revenue: 30240 }
  ],
  vehicleUtilization: [
    { name: 'Available', value: 4 },
    { name: 'Rented', value: 0 }
  ],
  calendar: [
    { date: '2026-01-05', type: 'rental', title: 'V100 - John Doe', vehicleCode: 'V100' },
    { date: '2026-01-06', type: 'rental', title: 'V100 - John Doe', vehicleCode: 'V100' },
    { date: '2026-01-07', type: 'rental', title: 'V101 - Maria Santos', vehicleCode: 'V101' },
    { date: '2026-01-08', type: 'rental', title: 'V101 - Maria Santos', vehicleCode: 'V101' },
  ],
  reports: {
    rentals: [
      { id: 100, customer: 'John Doe', vehicle: 'V100 Toyota Vios', pickup: '2026-01-05', return: '2026-01-08', status: 'Completed' },
      { id: 101, customer: 'Maria Santos', vehicle: 'V101 Honda City', pickup: '2026-01-06', return: '2026-01-09', status: 'Completed' }
    ],
    invoices: [
      { id: 100, customer: 'John Doe', total: 13440, balance: 8440, status: 'Unpaid', date: '2026-01-09' },
      { id: 101, customer: 'Maria Santos', total: 16800, balance: 11800, status: 'Unpaid', date: '2026-01-09' }
    ],
    damages: [
      { id: 100, vehicle: 'V100', description: 'Scratched front bumper', severity: 'Minor', charge: 0, status: 'PendingApproval' },
      { id: 103, vehicle: 'V101', description: 'Broken side mirror', severity: 'Minor', charge: 2500, status: 'Approved' }
    ],
    customers: [
      { id: 100, name: 'John Doe', email: 'john.doe@email.com', type: 'Individual', rentals: 1 },
      { id: 101, name: 'Maria Santos', email: 'maria.santos@email.com', type: 'Frequent', rentals: 1 }
    ]
  }
}

function apiPlugin() {
  let pool = null
  let dbAvailable = false
  
  return {
    name: 'vormas-api',
    async configureServer(server) {
      try {
        const mysql = await import('mysql2/promise')
        pool = mysql.createPool({
          host: 'localhost',
          port: 3306,
          user: 'root',
          password: '',
          database: 'vormas',
          waitForConnections: true,
          connectionLimit: 5
        })
        
        // Test connection
        const conn = await pool.getConnection()
        conn.release()
        dbAvailable = true
        console.log('MySQL connected - using stored procedures')
      } catch (err) {
        console.log('MySQL not available - using mock data')
        console.log('Start MySQL/XAMPP to use live data')
        dbAvailable = false
      }
      
      const sendJson = (res, data) => {
        res.setHeader('Content-Type', 'application/json')
        res.end(JSON.stringify(data))
      }
      
      const callProcedure = async (procedureName, params, mockData) => {
        if (!dbAvailable || !pool) return mockData
        try {
          const conn = await pool.getConnection()
          const [rows] = await conn.query(`CALL ${procedureName}(${params.map(() => '?').join(',') || ''})`, params)
          conn.release()
          // Stored procedures return results in first element
          return rows[0] || rows
        } catch (err) {
          console.log(`Procedure ${procedureName} error:`, err.message)
          return mockData
        }
      }
      
      server.middlewares.use('/api/kpis', async (req, res, next) => {
        if (req.method !== 'GET') return next()
        
        const result = await callProcedure('prcGetDashboardKPIs', [], [MOCK_DATA.kpis])
        const data = Array.isArray(result) ? result[0] : result
        
        sendJson(res, {
          totalRevenue: Number(data.totalRevenue || 0),
          outstandingBalance: Number(data.outstandingBalance || 0),
          activeRentals: Number(data.activeRentals || 0),
          completedRentals: Number(data.completedRentals || 0),
          totalCustomers: Number(data.totalCustomers || 0),
          fleetSize: Number(data.fleetSize || 0),
          availableVehicles: Number(data.availableVehicles || 0),
          pendingDamages: Number(data.pendingDamages || 0),
          totalDamageCosts: Number(data.totalDamageCosts || 0)
        })
      })
      
      server.middlewares.use('/api/revenue-trend', async (req, res, next) => {
        if (req.method !== 'GET') return next()
        
        const rows = await callProcedure('prcGetRevenueTrend', [], MOCK_DATA.revenueTrend)
        sendJson(res, rows.map(r => ({ month: r.month, revenue: Number(r.revenue) })))
      })
      
      server.middlewares.use('/api/vehicle-utilization', async (req, res, next) => {
        if (req.method !== 'GET') return next()
        
        const rows = await callProcedure('prcGetVehicleUtilization', [], MOCK_DATA.vehicleUtilization)
        sendJson(res, rows)
      })
      
      server.middlewares.use('/api/calendar', async (req, res, next) => {
        if (req.method !== 'GET') return next()
        
        const url = new URL(req.url, 'http://localhost')
        const month = parseInt(url.searchParams.get('month')) || (new Date().getMonth() + 1)
        const year = parseInt(url.searchParams.get('year')) || new Date().getFullYear()
        
        const rentals = await callProcedure('prcGetCalendarEvents', [month, year], [])
        
        if (!dbAvailable || rentals.length === 0) {
          return sendJson(res, MOCK_DATA.calendar)
        }

        const events = []
        rentals.forEach(rental => {
          const start = new Date(rental.PickupDateTime)
          const end = new Date(rental.ReturnDateTime || start)
          
          for (let d = new Date(start); d <= end; d.setDate(d.getDate() + 1)) {
            events.push({
              date: d.toISOString().split('T')[0],
              type: 'rental',
              title: `${rental.VehicleCode} - ${rental.customerName}`,
              vehicleCode: rental.VehicleCode
            })
          }
        })
        
        sendJson(res, events)
      })
      
      // Reports endpoint - expanded with fleet and rental reports
      server.middlewares.use('/api/reports', async (req, res, next) => {
        if (req.method !== 'GET') return next()
        
        const url = new URL(req.url, 'http://localhost')
        const type = url.searchParams.get('type') || 'rentals'
        const from = url.searchParams.get('from') || '2020-01-01'
        const to = url.searchParams.get('to') || '2030-12-31'
        const limit = parseInt(url.searchParams.get('limit')) || 10
        
        // Map report types to stored procedures
        const procedures = {
          // Basic reports
          rentals: { name: 'prcGetRentalsReport', params: [] },
          invoices: { name: 'prcGetInvoicesReport', params: [] },
          damages: { name: 'prcGetDamagesReport', params: [] },
          customers: { name: 'prcGetCustomersReport', params: [] },
          // Fleet reports
          'fleet-by-category': { name: 'prcGetFleetByCategory', params: [] },
          'fleet-maintenance': { name: 'prcGetFleetMaintenance', params: [] },
          // Rental reports
          'active-rentals': { name: 'prcGetActiveRentalsDetailed', params: [] },
          'daily-rentals': { name: 'prcGetDailyRentals', params: [from, to] },
          'rentals-by-category': { name: 'prcGetRentalsByCategory', params: [from, to] },
          'rental-duration': { name: 'prcGetRentalDurationAnalysis', params: [from, to] },
          // Operational reports
          'fleet-utilization': { name: 'prcGetFleetUtilization', params: [from, to] },
          'popular-vehicles': { name: 'prcGetMostPopularVehicles', params: [limit] },
          'late-returns': { name: 'prcGetLateReturns', params: [] },
          // Revenue
          'revenue-per-vehicle': { name: 'prcGetRevenuePerVehicle', params: [from, to] }
        }
        
        const proc = procedures[type]
        if (!proc) {
          return sendJson(res, MOCK_DATA.reports[type] || [])
        }
        
        const rows = await callProcedure(proc.name, proc.params, MOCK_DATA.reports[type] || [])
        sendJson(res, rows)
      })
      
      // Analytics/Performance metrics endpoint
      server.middlewares.use('/api/analytics', async (req, res, next) => {
        if (req.method !== 'GET') return next()
        
        const url = new URL(req.url, 'http://localhost')
        const from = url.searchParams.get('from') || new Date(Date.now() - 30*24*60*60*1000).toISOString().split('T')[0]
        const to = url.searchParams.get('to') || new Date().toISOString().split('T')[0]
        
        const mockMetrics = {
          fleetUtilizationRate: 25.5,
          revenuePerVehicle: 7560,
          avgRentalRate: 15120,
          avgRentalDuration: 3.5,
          customerRetentionRate: 15.0,
          totalRentals: 2,
          totalRevenue: 30240,
          totalCustomers: 2
        }
        
        const result = await callProcedure('prcGetPerformanceMetrics', [from, to], [mockMetrics])
        const data = Array.isArray(result) ? result[0] : result
        sendJson(res, data)
      })
    }
  }
}

export default defineConfig({
  plugins: [react(), apiPlugin()],
  server: {
    port: 5173,
    host: true
  }
})
