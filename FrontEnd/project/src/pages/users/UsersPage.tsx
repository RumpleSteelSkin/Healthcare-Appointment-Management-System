import {FC, useEffect, useState} from 'react';
import {UserResponseDto} from "../../types/api.ts";
import {usersApi} from '../../api/users.ts';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import {Box, Button, CircularProgress, Modal, Typography} from "@mui/material";
import {ArrowUpToLine, Info, Trash2} from "lucide-react";

const UsersPage: FC = () => {
    const [users, setUsers] = useState<UserResponseDto[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    const style = {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: 400,
        bgcolor: 'background.paper',
        border: '2px solid #000',
        boxShadow: 24,
        p: 4,
    };
    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const data = await usersApi.getAll();
                setUsers(data);
            } catch (err) {
                setError('Failed to fetch users');
            } finally {
                setLoading(false);
            }
        };
        fetchUsers();
    }, []);

    const [deleting, setDeleting] = useState<boolean>(false);
    const handleDeleteUser = async (userId: string) => {
        if (window.confirm("Are you sure you want to delete this user?")) {
            setDeleting(true);
            try {
                await usersApi.deleteUser(userId);
                setUsers(users.filter(user => user.id !== userId));
            } catch (err) {
                setError('Failed to delete user');
            } finally {
                setDeleting(false);
            }
        }
    };

    const [updating, setUpdating] = useState<boolean>(false);
    const handleUpdateUser = async (userId: string, userName: string, firstName: string, lastName: string, birthDate: string, email: string, password: string) => {
        if (window.confirm("Are you sure you want to update this user?")) {
            setUpdating(true);
            try {
                await usersApi.updateUser(userId, userName, firstName, lastName, birthDate, email, password);
                setUsers(users.filter(user => user.id == userId));
            } catch (err) {
                setError("Failed to update user");
            } finally {
                setUpdating(false);
            }
        }
    }

    if (loading) {
        return (
            <div style={{display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh'}}>
                <CircularProgress/>
            </div>
        );
    }

    if (error) {
        return (
            <div style={{color: 'red', textAlign: 'center', marginTop: '20px'}}>
                Error: {error}
            </div>
        );
    }

    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{minWidth: 650}} stickyHeader aria-label="sticky table">
                    <TableHead>
                        <TableRow>
                            <TableCell>UserName</TableCell>
                            <TableCell>FullName</TableCell>
                            <TableCell>Email</TableCell>
                            <TableCell></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {users.map((row) => (
                            <TableRow hover key={row.id}>
                                <TableCell>{row.userName}</TableCell>
                                <TableCell>{row.fullName}</TableCell>
                                <TableCell>{row.email}</TableCell>
                                <TableCell align="right">
                                    <Box display="flex" justifyContent="flex-end">
                                        <Button><Info color={"#1975d0"}/></Button>
                                        <Button onClick={handleOpen}><ArrowUpToLine color={"#ff5900"}/></Button>
                                        <Button onClick={() => handleDeleteUser(row.id)} disabled={deleting}><Trash2
                                            color={"#ff0000"}/></Button>
                                    </Box>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>

            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        Text in a modal
                    </Typography>
                    <Typography id="modal-modal-description" sx={{mt: 2}}>
                        Duis mollis, est non commodo luctus, nisi erat porttitor ligula.
                    </Typography>
                </Box>
            </Modal>
        </>
    );
}

export default UsersPage;
