import { FC, useEffect, useState } from 'react';
import { UserResponseDto } from "../../types/api.ts";
import { usersApi } from '../../api/users.ts';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Box, Button, CircularProgress } from "@mui/material";
import { ArrowUpToLine, Info, Trash2 } from "lucide-react";

const UsersPage: FC = () => {
    const [users, setUsers] = useState<UserResponseDto[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const [deleting, setDeleting] = useState<boolean>(false); // Silme durumu için durum ekledik

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

    if (loading) {
        return (
            <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
                <CircularProgress />
            </div>
        );
    }

    if (error) {
        return (
            <div style={{ color: 'red', textAlign: 'center', marginTop: '20px' }}>
                Error: {error}
            </div>
        );
    }

    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} stickyHeader aria-label="sticky table">
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
                                    <Button><Info color={"#1975d0"} /></Button>
                                    <Button><ArrowUpToLine color={"#ff5900"} /></Button>
                                    <Button onClick={() => handleDeleteUser(row.id)} disabled={deleting}>
                                        <Trash2 color={"#ff0000"} />
                                    </Button>
                                </Box>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}

export default UsersPage;
