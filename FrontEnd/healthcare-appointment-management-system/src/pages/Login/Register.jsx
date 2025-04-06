import { useState } from "react";
import { registerRequest } from "../../api/auth/";
import { TextField, Button, Typography, Box } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function Register() {
    const [form, setForm] = useState({
        userName: "",
        firstName: "",
        lastName: "",
        email: "",
        password: "",
    });
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async () => {
        try {
            await registerRequest(form);
            navigate("/login"); // Başarılıysa login sayfasına
        } catch (err) {
            const message = err?.Errors?.[0]?.Errors?.join(" ") || err.title || "Register failed";
            setError(message);
        }
    };

    return (
        <Box>
            <Typography variant="h4">Register</Typography>
            <TextField name="userName" label="Username" fullWidth margin="normal" onChange={handleChange} />
            <TextField name="firstName" label="First Name" fullWidth margin="normal" onChange={handleChange} />
            <TextField name="lastName" label="Last Name" fullWidth margin="normal" onChange={handleChange} />
            <TextField name="email" label="Email" type="email" fullWidth margin="normal" onChange={handleChange} />
            <TextField name="password" label="Password" type="password" fullWidth margin="normal" onChange={handleChange} />
            {error && <Typography color="error">{error}</Typography>}
            <Button variant="contained" onClick={handleSubmit}>Register</Button>
        </Box>
    );
}
