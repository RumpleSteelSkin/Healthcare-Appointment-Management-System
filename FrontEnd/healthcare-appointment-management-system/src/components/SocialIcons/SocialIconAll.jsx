import React from 'react';
import {Box, IconButton} from "@mui/material";
import GitHubIcon from "@mui/icons-material/GitHub";
import TwitterIcon from "@mui/icons-material/Twitter";

function SocialIconAll() {
    return (
        <>
            <Box sx={{mt: 4, display: 'flex', gap: 2}}>
                <IconButton
                    component="a"
                    href="https://github.com/rumplesteelskin"
                    target="_blank"
                    rel="noopener noreferrer"
                    color="inherit"
                >
                    <GitHubIcon/>
                </IconButton>
                <IconButton
                    component="a"
                    href="https://x.com/qutaair"
                    target="_blank"
                    rel="noopener noreferrer"
                    color="inherit"
                >
                    <TwitterIcon/>
                </IconButton>
            </Box>
        </>
    );
}

export default SocialIconAll;