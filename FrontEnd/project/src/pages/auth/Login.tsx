import {useState} from 'react';
import {useNavigate, Link} from 'react-router-dom';
import {TextField, Button, Paper, Typography} from '@mui/material';
import {Guitar as Hospital} from 'lucide-react';
import {authApi} from '../../api/auth';
import {useAuthStore} from '../../stores/authStore';
import {ErrorAlert} from '../../components/ErrorAlert';

import type {ValidationError, BusinessError} from '../../types/api';

export const Login = () => {
    const navigate = useNavigate();
    const setToken = useAuthStore((state) => state.setToken);
    const {hasRole} = useAuthStore();
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<ValidationError | BusinessError | null>(null);
    const [formData, setFormData] = useState({
        userNameOrEmail: '',
        password: '',
    });

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setError(null);

        try {
            const response = await authApi.login(formData);
            setToken(response.token);
            if (hasRole('Admin')) {
                navigate('/admin');
            } else if (hasRole('User')) {
                navigate('/user')
            }
        } catch (err: any) {
            setError(err.response?.data || {title: 'Error', detail: 'An unexpected error occurred'});
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="min-h-screen bg-gray-100 flex items-center justify-center p-4">
            <Paper className="p-8 w-full max-w-md">
                <div className="flex flex-col items-center mb-8">
                    <Hospital className="w-12 h-12 text-primary mb-4"/>
                    <Typography variant="h4" component="h1" className="text-center">
                        HAMS Login
                    </Typography>
                </div>

                <form onSubmit={handleSubmit} className="space-y-4">
                    <TextField
                        fullWidth
                        label="Username or Email"
                        variant="outlined"
                        value={formData.userNameOrEmail}
                        onChange={(e) => setFormData({...formData, userNameOrEmail: e.target.value})}
                        disabled={loading}
                    />

                    <TextField
                        fullWidth
                        label="Password"
                        type="password"
                        variant="outlined"
                        value={formData.password}
                        onChange={(e) => setFormData({...formData, password: e.target.value})}
                        disabled={loading}
                    />

                    <Button
                        fullWidth
                        variant="contained"
                        color="primary"
                        type="submit"
                        disabled={loading}
                        className="mt-4"
                    >
                        {loading ? 'Logging in...' : 'Login'}
                    </Button>

                    <Typography variant="body2" className="text-center mt-4">
                        Don't have an account?{' '}
                        <Link to="/register" className="text-primary hover:underline">
                            Register here
                        </Link>
                    </Typography>
                </form>
            </Paper>

            <ErrorAlert error={error} onClose={() => setError(null)}/>
        </div>
    );
};