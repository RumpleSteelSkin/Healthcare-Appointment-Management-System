import {useState} from "react";
import {useNavigate} from "react-router-dom";
import {loginRequest, getCurrentUser} from "../../auth/";
import {useAuth} from "../../auth/AuthProvider";
import {TextField, Button, Typography, Box} from "@mui/material";

export default function Login() {
    const [form, setForm] = useState({userNameOrEmail: "", password: ""});
    const [error, setError] = useState(null);
    const auth = useAuth();
    const navigate = useNavigate();

    const handleChange = (e) => {
        setForm({...form, [e.target.name]: e.target.value});
    };

    const parseJwt = (token) => {
        try {
            return JSON.parse(atob(token.split('.')[1]));
        } catch (e) {
            return null;
        }
    };

    const handleSubmit = async () => {
        try {
            const {token} = await loginRequest(form);
            const decoded = parseJwt(token); // 👈 Token'dan role'ü oku

            const userInfo = await getCurrentUser(token); // sunucudan detay al
            userInfo.role = decoded.role; // token'dan gelen role ekle

            auth.login(token, userInfo);

            if (decoded.role.includes("Admin")) navigate("/admin");
            else if (decoded.role.includes("User")) navigate("/user");
            else navigate("/"); // bilinmeyen role
        } catch (err) {
            setError(err.title || "Login failed");
        }
    };

    return (
        <Box>
            <Typography variant="h4">Login</Typography>
            <TextField label="Username or Email" name="userNameOrEmail" fullWidth margin="normal"
                       onChange={handleChange}/>
            <TextField label="Password" name="password" type="password" fullWidth margin="normal"
                       onChange={handleChange}/>
            {error && <Typography color="error">{error}</Typography>}
            <Button variant="contained" onClick={handleSubmit}>Login</Button>
        </Box>
    );
}
