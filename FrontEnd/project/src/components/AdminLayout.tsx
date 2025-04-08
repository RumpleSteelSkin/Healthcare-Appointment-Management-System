import { useState } from 'react';
import { Outlet, useNavigate } from 'react-router-dom';
import {
  AppBar,
  Toolbar,
  IconButton,
  Typography,
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  ListItemButton,
} from '@mui/material';
import { Menu, Users, Calendar, LogOut, Guitar as Hospital, UserCog, Building2 } from 'lucide-react';
import { useAuthStore } from '../stores/authStore';

export const AdminLayout = () => {
  const navigate = useNavigate();
  const logout = useAuthStore((state) => state.logout);
  const [drawerOpen, setDrawerOpen] = useState(false);

  const handleLogout = () => {
    logout();
    navigate('/login');
  };

  const menuItems = [
    { text: 'Users', icon: <Users size={24} />, path: '/admin/users' },
    { text: 'Roles', icon: <UserCog size={24} />, path: '/admin/roles' },
    { text: 'Hospitals', icon: <Building2 size={24} />, path: '/admin/hospitals' },
    { text: 'Appointments', icon: <Calendar size={24} />, path: '/admin/appointments' },
  ];

  return (
    <div className="min-h-screen bg-gray-100">
      <AppBar position="fixed">
        <Toolbar>
          <IconButton
            color="inherit"
            edge="start"
            onClick={() => setDrawerOpen(true)}
            className="mr-2"
          >
            <Menu />
          </IconButton>
          <Hospital className="mr-2" />
          <Typography variant="h6" component="div" className="flex-grow">
            HAMS Admin
          </Typography>
          <IconButton color="inherit" onClick={handleLogout}>
            <LogOut />
          </IconButton>
        </Toolbar>
      </AppBar>

      <Drawer anchor="left" open={drawerOpen} onClose={() => setDrawerOpen(false)}>
        <div className="w-64">
          <List>
            {menuItems.map((item) => (
              <ListItem key={item.text} disablePadding>
                <ListItemButton onClick={() => {
                  navigate(item.path);
                  setDrawerOpen(false);
                }}>
                  <ListItemIcon>{item.icon}</ListItemIcon>
                  <ListItemText primary={item.text} />
                </ListItemButton>
              </ListItem>
            ))}
          </List>
        </div>
      </Drawer>

      <div className="pt-16 p-4">
        <Outlet />
      </div>
    </div>
  );
};