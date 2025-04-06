import { IconButton, Menu, MenuItem } from '@mui/material';
import Brightness4Icon from '@mui/icons-material/Brightness4';
import Brightness7Icon from '@mui/icons-material/Brightness7';
import SettingsBrightnessIcon from '@mui/icons-material/SettingsBrightness';
import { useState } from 'react';
import { useTheme } from './ThemeContext.jsx';

export default function ThemeSwitcher() {
    const { mode, toggleTheme } = useTheme();
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);

    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    const handleThemeChange = (newMode) => {
        toggleTheme(newMode);
        handleClose();
    };

    return (
        <>
            <IconButton
                sx={{ position: 'absolute', top: 16, right: 16 }}
                onClick={handleClick}
                color="inherit"
            >
                {mode === 'light' && <Brightness7Icon />}
                {mode === 'dark' && <Brightness4Icon />}
                {mode === 'system' && <SettingsBrightnessIcon />}
            </IconButton>
            <Menu
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
            >
                <MenuItem onClick={() => handleThemeChange('light')}>
                    <Brightness7Icon sx={{ mr: 1 }} /> Açık Mod
                </MenuItem>
                <MenuItem onClick={() => handleThemeChange('dark')}>
                    <Brightness4Icon sx={{ mr: 1 }} /> Koyu Mod
                </MenuItem>
                <MenuItem onClick={() => handleThemeChange('system')}>
                    <SettingsBrightnessIcon sx={{ mr: 1 }} /> Sistem
                </MenuItem>
            </Menu>
        </>
    );
}