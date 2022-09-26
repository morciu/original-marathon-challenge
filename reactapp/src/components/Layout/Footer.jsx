import React from "react";

import MenuIcon from '@mui/icons-material/Menu';
import DirectionsRunIcon from '@mui/icons-material/DirectionsRun';
import MoreIcon from '@mui/icons-material/MoreVert';

import PhotoCredits from "../../media/PhotoCredits";
import { AppBar, Fab, IconButton, Toolbar } from "@mui/material";
import { styled } from '@mui/material/styles';
import { Box } from "@mui/system";

const Footer = () => {

    const StyledFab = styled(Fab)({
        position: 'absolute',
        zIndex: 1,
        top: -30,
        left: 0,
        right: 0,
        margin: '0 auto',
      });

    return(
        <>
            <AppBar position="relative" color="primary"
          sx={{top: 'auto', bottom: 0}}>
                <Toolbar>
                    <IconButton color="inherit" aria-label="open drawer">
                        <MenuIcon />
                    </IconButton>
                    <StyledFab href="/register-run" color="secondary" aria-label="add" style={{ width: 80, height: 80 }}>
                        <DirectionsRunIcon style={{ width: 50, height: 50 }} />
                    </StyledFab>
                    <Box sx={{ flexGrow: 1 }} />
                    <IconButton color="inherit"><MoreIcon /></IconButton>
                </Toolbar>
            </AppBar>

            <div className="footer">
                <PhotoCredits />
            </div>
        </>
    );
};

export default Footer;