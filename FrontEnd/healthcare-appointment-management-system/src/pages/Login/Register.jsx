import React, {useContext, useState} from 'react';
import AuthContext from "../../context/AuthContext.jsx";
import {register} from "../../context/api.js";
import AppRegistrationIcon from '@mui/icons-material/AppRegistration';
import {
    Button,
    Paper,
    TextField,
    Typography,
    Alert, Link
} from "@mui/material";
import {DatePicker} from '@mui/x-date-pickers/DatePicker';
import dayjs from "dayjs";
import {useNavigate} from "react-router-dom";

function Register() {
    const {registerUser} = useContext(AuthContext);
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        userName: "",
        firstName: "",
        lastName: "",
        birthDate: dayjs("2000-04-07"),
        email: "",
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
            const dataToSend = {
                ...formData,
                birthDate: formData.birthDate?.format("YYYY-MM-DD")
            };

            await register(dataToSend);

            setSuccessMessage("Kayıt başarılı! Giriş sayfasına yönlendiriliyorsunuz...");
            setTimeout(() => window.location.href = "/login", 2000);
        } catch (error) {
            const data = error.response?.data;

            if (Array.isArray(data?.Errors)) {
                setErrorMessages(data.Errors.flatMap(e => e.Errors));
            } else if (typeof data?.errors === 'object') {
                setErrorMessages(Object.values(data.errors).flat());
            } else {
                setErrorMessages([data?.title || "Bilinmeyen bir hata oluştu."]);
            }
        }
    };

    return (

        <Paper sx={{maxWidth: 400, margin: "50px auto", padding: "15px", textAlign:"center"}}>
            <Typography variant="h6" color="textSecondary">Register</Typography>
            <form onSubmit={handleSubmit}>
                <TextField
                    label="UserName"
                    type="text"
                    name="userName"
                    variant="outlined"
                    autoComplete={"userName"}
                    fullWidth
                    margin="normal"
                    onChange={handleChange}
                />

                <TextField
                    label="FirstName"
                    type="text"
                    name="firstName"
                    autoComplete={"firstName"}
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    onChange={handleChange}
                />

                <TextField
                    label="LastName"
                    autoComplete={"lastname"}
                    type="text"
                    name="lastName"
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    onChange={handleChange}
                />

                <TextField
                    label="Email"
                    type="email"
                    name="email"
                    autoComplete={"email"}
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    onChange={handleChange}
                />

                <DatePicker
                    label="BirthDate"
                    autoComplete={"birthDate"}
                    value={formData.birthDate}
                    onChange={(newValue) =>
                        setFormData({...formData, birthDate: newValue})
                    }
                    slotProps={{
                        textField: {
                            fullWidth: true,
                            margin: "normal",
                            name: "birthDate"
                        }
                    }}
                />

                <TextField
                    label="Password"
                    type="password"
                    name="password"
                    autoComplete={"password"}
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

                <Button
                    variant="contained"
                    type="submit"
                    endIcon={<AppRegistrationIcon/>}
                    fullWidth
                >
                    Register
                </Button>

            </form>
            <Typography sx={{marginTop:"1rem"}}>Hesabın var mı? <Link
                component="button"
                variant="body2"
                onClick={() => {
                    navigate("/login")
                }}
            >
                Giriş Yap
            </Link></Typography>
        </Paper>

    );
}

export default Register;
