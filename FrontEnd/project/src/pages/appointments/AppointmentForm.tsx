import { useState, useEffect } from 'react';
import {Dialog, DialogTitle, DialogContent, TextField, MenuItem,
    FormControl, InputLabel, Select
} from '@mui/material';
import { DateTimePicker } from '@mui/x-date-pickers';
import { appointmentsApi } from '../../api/appointments';
import { ErrorAlert } from '../../components/ErrorAlert';
import { LoadingSpinner } from '../../components/LoadingSpinner';
import { Appointment, ValidationError, BusinessError } from '../../types/api';
import * as React from 'react';

export const AppointmentForm = ({ open, onClose, onSubmit, appointment }: AppointmentFormProps) => {
    const [formData, setFormData] = useState({
        appointmentDate: new Date(),
        notes: '',
        hospitalId:'',
        doctorId: '',
        patientId: '',
    });

    const [error, setError] = useState<ValidationError | BusinessError | null>(null);
    const [loading, setLoading] = useState(false);

    // HASTANELER
    const { data: hospitals, loading: hospitalLoading, error: hospitalError } = useFetch("http://localhost:5010/api/Hospitals/GetAll");

    // DOKTORLAR
    const { data: doctors, loading: doctorLoading, error: doctorError } = useFetch(
        formData.hospitalId
            ? `http://localhost:5010/api/Doctors/GetAllByHospitalId?hospitalId=${formData.hospitalId}`
            : null
    );

    useEffect(() => {
        if (open && appointment) {
            setFormData({
                appointmentDate: new Date(appointment.appointmentDate),
                notes: appointment.notes,
                doctorId: appointment.doctorId,
                patientId: appointment.patientId,
            });
        }
    }, [open, appointment]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setError(null);
        try {
            if (appointment) {
                await appointmentsApi.update({
                    id: appointment.id,
                    ...formData,
                    appointmentDate: formData.appointmentDate.toISOString(),
                });
            } else {
                await appointmentsApi.add({
                    ...formData,
                    appointmentDate: formData.appointmentDate.toISOString(),
                });
            }
            onSubmit();
        } catch (err: any) {
            setError(err.response?.data || { title: 'Error', detail: 'Failed to save appointment' });
        } finally {
            setLoading(false);
        }
    };

    if (loading || hospitalLoading || doctorLoading) return <LoadingSpinner />;

    return (
        <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
            <form onSubmit={handleSubmit}>
                <DialogTitle>{appointment ? 'Edit Appointment' : 'New Appointment'}</DialogTitle>
                <DialogContent>
                    <div className="space-y-4 mt-4">
                        <DateTimePicker
                            label="Appointment Date"
                            value={formData.appointmentDate}
                            onChange={(date) =>
                                setFormData({ ...formData, appointmentDate: date || new Date() })
                            }
                            slotProps={{ textField: { fullWidth: true } }}
                        />

                        {/* Hospital Select */}
                        <FormControl fullWidth>
                            <InputLabel>Hospital</InputLabel>
                            <Select
                                value={formData.hospitalId}
                                label="Hospital"
                                onChange={(e) =>
                                    setFormData({
                                        ...formData,
                                        hospitalId: e.target.value,
                                        doctorId: '', // doktoru sıfırla
                                    })
                                }
                            >
                                {hospitals.map((hospital: any) => (
                                    <MenuItem key={hospital.id} value={hospital.id}>
                                        {hospital.name}
                                    </MenuItem>
                                ))}
                            </Select>
                        </FormControl>

                        {/* Doctor Select */}
                        <FormControl fullWidth disabled={!formData.hospitalId}>
                            <InputLabel>Doctor</InputLabel>
                            <Select
                                value={formData.doctorId}
                                label="Doctor"
                                onChange={(e) =>
                                    setFormData({ ...formData, doctorId: e.target.value })
                                }
                            >
                                {doctors?.map((doc: any) => (
                                    <MenuItem key={doc.id} value={doc.id}>
                                        Dr. {doc.fullName} - {doc.specialty}
                                    </MenuItem>
                                ))}
                            </Select>
                        </FormControl>

                        <TextField
                            fullWidth
                            multiline
                            rows={4}
                            label="Notes"
                            value={formData.notes}
                            onChange={(e) =>
                                setFormData({ ...formData, notes: e.target.value })
                            }
                        />
                    </div>
                </DialogContent>
            </form>

            <ErrorAlert
                error={error || doctorError || hospitalError}
                onClose={() => setError(null)}
            />
        </Dialog>
    );
};
