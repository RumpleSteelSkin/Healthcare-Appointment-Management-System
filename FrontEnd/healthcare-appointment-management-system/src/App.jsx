import {BrowserRouter, Routes, Route, useNavigate} from "react-router-dom";
import {AuthProvider} from "./context/AuthContext.jsx";
import Register from "./pages/Login/Register.jsx";
import {AdapterDayjs} from "@mui/x-date-pickers/AdapterDayjs";
import {LocalizationProvider} from "@mui/x-date-pickers/LocalizationProvider";
import {Container} from "@mui/material";
import Login from "./pages/Login/Login.jsx";
import Home from "./pages/UserHome/Home.jsx";
import AdminDashboard from "./pages/Dashboard/AdminDashboard.jsx";
import {useEffect} from "react";

const RedirectToLogin = () => {
    const navigate = useNavigate();
    useEffect(() => {
        navigate("/login");
    }, [navigate]);
    return null;
};
export default function App() {
    return (
        <AuthProvider>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
                <BrowserRouter>
                    <Container>
                        <Routes>
                            <Route path={"/"} element={<RedirectToLogin/>}/>
                            <Route path={"/register"} element={<Register/>}/>
                            <Route path={"/login"} element={<Login/>}/>
                            <Route path={"/home"} element={<Home/>}/>
                            <Route path={"/adminDashboard"} element={<AdminDashboard/>}/>
                        </Routes>
                    </Container>
                </BrowserRouter>
            </LocalizationProvider>
        </AuthProvider>
    );
}
