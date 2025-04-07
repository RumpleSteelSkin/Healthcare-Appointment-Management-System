import React, {useContext, useEffect, useState} from "react";
import AuthContext from "../../context/AuthContext.jsx";
import { decodeJwt, hasRole } from "../../context/tokenDecoder.js";
import {login} from "../../context/api.js";
import {Button, Paper, TextField, Typography, Container, Alert, Link} from "@mui/material";
import LoginIcon from "@mui/icons-material/Login";
import {useNavigate} from "react-router-dom";

function Login() {
    const {setAuthToken} = useContext(AuthContext);
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        userNameOrEmail: "",
        password: "",
    });

    const [errorMessages, setErrorMessages] = useState([]);
    const [successMessage, setSuccessMessage] = useState("");

    const handleChange = (e) => {
        setFormData({...formData, [e.target.name]: e.target.value});
    };
    const handleSubmit = async (e) => {
        e.preventDefault();
        setErrorMessages([]);
        setSuccessMessage("");

        try {
            const response = await login(formData);
            const token = response.token;
            setAuthToken?.(token);

            const decoded = decodeJwt(token);

            if (!decoded) {
                setErrorMessages(["Token çözümlenemedi."]);
                return;
            }

            setSuccessMessage("Giriş başarılı! Yönlendiriliyorsunuz...");

            if (hasRole(decoded, "Admin")) {
                navigate('/adminDashboard');
            } else if (hasRole(decoded, "User")) {
                navigate('/home');
            } else {
                navigate('/');
            }

        } catch (error) {
            if (error.response) {
                const data = error.response.data;
                if (data?.Errors) {
                    const errorMessages = data.Errors.flatMap(e => e.Errors);
                    setErrorMessages(errorMessages);

                } else if (data?.detail) {
                    setErrorMessages([data.detail]);
                } else {
                    setErrorMessages(["Bir hata oluştu. Lütfen tekrar deneyin."]);
                }
            } else if (error.request) {
                setErrorMessages(["Sunucu ile bağlantı kurulamadı. Lütfen internet bağlantınızı kontrol edin."]);
            } else {
                setErrorMessages(["Bir hata oluştu. Lütfen tekrar deneyin."]);
            }
        }
    };



    return (
        <Container>
            <Paper sx={{maxWidth: 400, margin: "50px auto", padding: "15px", textAlign: "center"}}>
                <Typography variant="h6" color={"textSecondary"}>
                    Login
                </Typography>

                <form onSubmit={handleSubmit}>
                    <TextField
                        label="Kullanıcı Adı veya Email"
                        type="text"
                        autoComplete={"userNameOrEmail"}
                        name="userNameOrEmail"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        onChange={handleChange}
                    />

                    <TextField
                        label="Şifre"
                        type="password"
                        autoComplete={"password"}
                        name="password"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        onChange={handleChange}
                    />

                    {successMessage && <Alert severity="success" sx={{textAlign:"left",marginY:"10px"}}>{successMessage}</Alert>}
                    {errorMessages.length > 0 && (
                        <Alert severity="error" sx={{textAlign:"left",marginY:"10px"}}>
                            <ul>
                                {errorMessages.map((msg, index) => (
                                    <li key={index}>{msg}</li>
                                ))}
                            </ul>
                        </Alert>
                    )}

                    <Button variant="contained" type="submit" endIcon={<LoginIcon/>} fullWidth>
                        Login
                    </Button>
                </form>

                <Typography sx={{marginTop:"1rem"}}>Henüz bir hesabın yok mu? <Link
                    component="button"
                    variant="body2"
                    onClick={() => {
                        navigate("/register")
                    }}
                >
                    Hesap Oluştur
                </Link></Typography>


            </Paper>
        </Container>
    );
}

export default Login;
