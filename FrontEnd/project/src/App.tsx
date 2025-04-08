import {BrowserRouter as Router, Routes, Route, Navigate} from 'react-router-dom';
import {ThemeProvider, CssBaseline} from '@mui/material';
import {LocalizationProvider} from '@mui/x-date-pickers';
import {AdapterDateFns} from '@mui/x-date-pickers/AdapterDateFns';
import {theme} from './theme';
import {ProtectedRoute} from './components/ProtectedRoute';
import {Login} from './pages/auth/Login';
import {Register} from './pages/auth/Register';
import {AdminLayout} from './components/AdminLayout';
import {AppointmentsList} from './pages/appointments/AppointmentsList';
import UsersPage from "./pages/users/UsersPage.tsx";

function App() {
    return (
        <ThemeProvider theme={theme}>
            <LocalizationProvider dateAdapter={AdapterDateFns}>
                <CssBaseline/>
                <Router>
                    <Routes>
                        <Route path="/login" element={<Login/>}/>
                        <Route path="/register" element={<Register/>}/>


                        <Route path="/admin" element={<ProtectedRoute requiredRole="Admin">
                            <AdminLayout/>
                        </ProtectedRoute>}
                        >
                            <Route index element={<Navigate to="/admin/users" replace/>}/>
                            <Route path="users" element={<UsersPage/>}/>
                            <Route path="roles" element={<div>Roles Management (Coming Soon)</div>}/>
                            <Route path="hospitals" element={<div>Hospitals Management (Coming Soon)</div>}/>
                            <Route path="appointments" element={<AppointmentsList/>}/>
                        </Route>

                        {/* Protected User Routes */}
                        <Route
                            path="/user/*"
                            element={
                                <ProtectedRoute requiredRole="User">
                                    <div>User Layout (Coming Soon)</div>
                                </ProtectedRoute>
                            }
                        />

                        <Route path="/" element={<Navigate to="/login"/>}/>
                    </Routes>
                </Router>
            </LocalizationProvider>
        </ThemeProvider>
    );
}

export default App;