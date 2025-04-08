import {useState, useEffect} from 'react';
import {
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    IconButton,
    Button,
    Typography,
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
} from '@mui/material';
import {Edit2, Trash2, Plus} from 'lucide-react';
import {appointmentsApi} from '../../api/appointments';
import {LoadingSpinner} from '../../components/LoadingSpinner';
import {ErrorAlert} from '../../components/ErrorAlert';
import {AppointmentForm} from './AppointmentForm';
import type {Appointment, ValidationError, BusinessError, AppointmentDto} from '../../types/api';

export const AppointmentsList = () => {
    const [appointments, setAppointments] = useState<AppointmentDto[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<ValidationError | BusinessError | null>(null);
    const [openForm, setOpenForm] = useState(false);
    const [selectedAppointment, setSelectedAppointment] = useState<Appointment | null>(null);
    const [deleteConfirmOpen, setDeleteConfirmOpen] = useState(false);
    const [appointmentToDelete, setAppointmentToDelete] = useState<string | null>(null);
    interface ApiErrorResponse {
        status: number;
        message: string;
        errors?: Array<{ property: string; messages: string[] }>; // Eğer hata detayları varsa
    }

    const fetchAppointments = async () => {
        setLoading(true);
        setError(null);
        try {
            const data = await appointmentsApi.getAll();
            setAppointments(data);
        } catch (err) {
            const error = err as { response?: { data?: ApiErrorResponse } };
            setError({title: 'Error', detail: 'Failed to fetch appointments'} || error.response?.data);
        } finally {
            setLoading(false);
        }
    };



    useEffect(() => {
        fetchAppointments();
    }, []);

    const handleEdit = (appointment: Appointment) => {
        setSelectedAppointment(appointment);
        setOpenForm(true);
    };

    const handleDelete = async () => {
        if (!appointmentToDelete) return;

        setLoading(true);
        try {
            await appointmentsApi.delete(appointmentToDelete);
            await fetchAppointments();
            setDeleteConfirmOpen(false);
            setAppointmentToDelete(null);
        } catch (err: any) {
            setError(err.response?.data || {title: 'Error', detail: 'Failed to delete appointment'});
        } finally {
            setLoading(false);
        }
    };

    const handleFormSubmit = async () => {
        setOpenForm(false);
        setSelectedAppointment(null);
        await fetchAppointments();
    };

    if (loading) return <LoadingSpinner/>;

    return (
        <>
            <div className="flex justify-between items-center mb-6">
                <Typography variant="h5" component="h2">
                    Appointments
                </Typography>
                <Button
                    variant="contained"
                    color="primary"
                    startIcon={<Plus size={20}/>}
                    onClick={() => setOpenForm(true)}
                >
                    New Appointment
                </Button>
            </div>

            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Date</TableCell>
                            <TableCell>Notes</TableCell>
                            <TableCell>Doctor</TableCell>
                            <TableCell>Patient</TableCell>
                            <TableCell align="right">Actions</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {appointments.map((appointment) => (
                            <TableRow key={appointment.id}>
                                <TableCell>{appointment.appointmentDate}</TableCell>
                                <TableCell>{appointment.notes}</TableCell>
                                <TableCell>{appointment.doctorFullName}</TableCell>
                                <TableCell>{appointment.patientFullName}</TableCell>
                                <TableCell>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>


                </Table>
            </TableContainer>

            <Dialog
                open={deleteConfirmOpen}
                onClose={() => setDeleteConfirmOpen(false)}
                maxWidth="sm"
                fullWidth
            >
                <DialogTitle>Confirm Delete</DialogTitle>
                <DialogContent>
                    Are you sure you want to delete this appointment?
                </DialogContent>
                <DialogActions>
                    <Button onClick={() => setDeleteConfirmOpen(false)}>Cancel</Button>
                    <Button onClick={handleDelete} color="error" variant="contained">
                        Delete
                    </Button>
                </DialogActions>
            </Dialog>

            <AppointmentForm
                open={openForm}
                onClose={() => {
                    setOpenForm(false);
                    setSelectedAppointment(null);
                }}
                onSubmit={handleFormSubmit}
                appointment={selectedAppointment}
            />

            <ErrorAlert error={error} onClose={() => setError(null)}/>
        </>
    );
};