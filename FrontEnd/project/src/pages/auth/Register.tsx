import { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { TextField, Button, Paper, Typography } from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers';
import { Guitar as Hospital } from 'lucide-react';
import { authApi } from '../../api/auth';
import { ErrorAlert } from '../../components/ErrorAlert';
import type { ValidationError, BusinessError } from '../../types/api';

export const Register = () => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<ValidationError | BusinessError | null>(null);
  const [formData, setFormData] = useState({
    userName: '',
    firstName: '',
    lastName: '',
    email: '',
    birthDate: null as Date | null,
    password: '',
  });

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!formData.birthDate) return;

    setLoading(true);
    setError(null);

    try {
      await authApi.register({
        ...formData,
        birthDate: formData.birthDate.toISOString(),
      });
      navigate('/login');
    } catch (err: any) {
      setError(err.response?.data || { title: 'Error', detail: 'An unexpected error occurred' });
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex items-center justify-center p-4">
      <Paper className="p-8 w-full max-w-md">
        <div className="flex flex-col items-center mb-8">
          <Hospital className="w-12 h-12 text-primary mb-4" />
          <Typography variant="h4" component="h1" className="text-center">
            HAMS Registration
          </Typography>
        </div>

        <form onSubmit={handleSubmit} className="space-y-4">
          <TextField
            fullWidth
            label="Username"
            variant="outlined"
            value={formData.userName}
            onChange={(e) => setFormData({ ...formData, userName: e.target.value })}
            disabled={loading}
          />

          <TextField
            fullWidth
            label="First Name"
            variant="outlined"
            value={formData.firstName}
            onChange={(e) => setFormData({ ...formData, firstName: e.target.value })}
            disabled={loading}
          />

          <TextField
            fullWidth
            label="Last Name"
            variant="outlined"
            value={formData.lastName}
            onChange={(e) => setFormData({ ...formData, lastName: e.target.value })}
            disabled={loading}
          />

          <TextField
            fullWidth
            label="Email"
            type="email"
            variant="outlined"
            value={formData.email}
            onChange={(e) => setFormData({ ...formData, email: e.target.value })}
            disabled={loading}
          />

          <DatePicker
            label="Birth Date"
            value={formData.birthDate}
            onChange={(date) => setFormData({ ...formData, birthDate: date })}
            disabled={loading}
            slotProps={{ textField: { fullWidth: true } }}
          />

          <TextField
            fullWidth
            label="Password"
            type="password"
            variant="outlined"
            value={formData.password}
            onChange={(e) => setFormData({ ...formData, password: e.target.value })}
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
            {loading ? 'Registering...' : 'Register'}
          </Button>

          <Typography variant="body2" className="text-center mt-4">
            Already have an account?{' '}
            <Link to="/login" className="text-primary hover:underline">
              Login here
            </Link>
          </Typography>
        </form>
      </Paper>

      <ErrorAlert error={error} onClose={() => setError(null)} />
    </div>
  );
};