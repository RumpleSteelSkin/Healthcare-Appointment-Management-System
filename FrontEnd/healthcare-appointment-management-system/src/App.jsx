import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./pages/Login/Login";
import Register from "./pages/Login/Register";
import AdminPage from "./pages/AdminPage";
import UserPage from "./pages/UserPage";
import { AuthProvider } from "./auth/AuthProvider";
import PrivateRoute from "./auth/PrivateRoute";

export default function App() {
    return (
        <AuthProvider>
            <BrowserRouter>
                <Routes>
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />

                    <Route path="/admin" element={
                        <PrivateRoute role="Admin"><AdminPage /></PrivateRoute>
                    }/>

                    <Route path="/user" element={
                        <PrivateRoute role="User"><UserPage /></PrivateRoute>
                    }/>
                </Routes>
            </BrowserRouter>
        </AuthProvider>
    );
}
