export const bridge = {
    async getCustomers() {
        if (!window.chrome?.webview?.hostObjects?.backend) {
            console.warn("Backend bridge not found (dev mode?)");
            return [{ id: 1, name: "John Doe (Mock)" }, { id: 2, name: "Jane Smith (Mock)" }];
        }
        const json = await window.chrome.webview.hostObjects.backend.GetCustomers();
        const data = JSON.parse(json);
        if (data.error) throw new Error(data.error);
        return data;
    },

    async getVehicles() {
        if (!window.chrome?.webview?.hostObjects?.backend) {
            console.warn("Backend bridge not found (dev mode?)");
            return [
                { id: 101, display: "Toyota Camry (XYZ-123)", rate: 2500, type: "Sedan" },
                { id: 102, display: "Honda Civic (ABC-789)", rate: 2200, type: "Sedan" },
                { id: 103, display: "Ford Explorer (SUV-999)", rate: 4500, type: "SUV" }
            ];
        }
        const json = await window.chrome.webview.hostObjects.backend.GetVehicles();
        const data = JSON.parse(json);
        if (data.error) throw new Error(data.error);
        return data;
    },

    async createReservation(reservation) {
        if (!window.chrome?.webview?.hostObjects?.backend) {
            console.log("Mock Create Reservation:", reservation);
            return { success: true, message: "Mock Reservation Created" };
        }
        const jsonStr = JSON.stringify(reservation);
        const responseJson = await window.chrome.webview.hostObjects.backend.CreateReservation(jsonStr);
        return JSON.parse(responseJson);
    },

    // --- Rental ---
    async getPendingReservations() {
        if (!window.chrome?.webview?.hostObjects?.backend) return [];
        const json = await window.chrome.webview.hostObjects.backend.GetPendingReservations();
        return JSON.parse(json);
    },
    async createRental(rental) {
        if (!window.chrome?.webview?.hostObjects?.backend) return { success: true };
        const json = await window.chrome.webview.hostObjects.backend.CreateRental(JSON.stringify(rental));
        return JSON.parse(json);
    },

    // --- Return ---
    async getActiveRentals() {
        if (!window.chrome?.webview?.hostObjects?.backend) return [];
        const json = await window.chrome.webview.hostObjects.backend.GetActiveRentals();
        return JSON.parse(json);
    },
    async completeRental(data) {
        if (!window.chrome?.webview?.hostObjects?.backend) return { success: true };
        const json = await window.chrome.webview.hostObjects.backend.CompleteRental(JSON.stringify(data));
        return JSON.parse(json);
    },

    // --- Billing ---
    async getUnpaidInvoices() {
        if (!window.chrome?.webview?.hostObjects?.backend) return [];
        const json = await window.chrome.webview.hostObjects.backend.GetUnpaidInvoices();
        return JSON.parse(json);
    },
    async processPayment(data) {
        if (!window.chrome?.webview?.hostObjects?.backend) return { success: true };
        const json = await window.chrome.webview.hostObjects.backend.ProcessPayment(JSON.stringify(data));
        return JSON.parse(json);
    },

    // --- Maintenance ---
    async logMaintenance(data) {
        if (!window.chrome?.webview?.hostObjects?.backend) return { success: true };
        const json = await window.chrome.webview.hostObjects.backend.LogMaintenance(JSON.stringify(data));
        return JSON.parse(json);
    },
    async completeMaintenance(vehicleId) {
        if (!window.chrome?.webview?.hostObjects?.backend) return { success: true };
        const json = await window.chrome.webview.hostObjects.backend.CompleteMaintenance(vehicleId);
        return JSON.parse(json);
    },

    // --- Reports ---
    async getReportData() {
        if (!window.chrome?.webview?.hostObjects?.backend) return { stats: {}, recent: [] };
        const json = await window.chrome.webview.hostObjects.backend.GetReportData();
        return JSON.parse(json);
    },

    async getDashboardStats() {
        if (!window.chrome?.webview?.hostObjects?.backend) return { activeRentals: 0, availableVehicles: 0, pendingReturns: 0 };
        const json = await window.chrome.webview.hostObjects.backend.GetDashboardStats();
        return JSON.parse(json);
    }
};
