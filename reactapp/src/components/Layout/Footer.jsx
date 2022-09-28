import { React, useState } from "react";

import {logout} from "../../utils/Logout"

import MenuIcon from '@mui/icons-material/Menu';
import DirectionsRunRoundedIcon from '@mui/icons-material/DirectionsRunRounded';
import MoreIcon from '@mui/icons-material/MoreVert';
import { Logout } from "@mui/icons-material";

import PhotoCredits from "../../media/PhotoCredits";
import { AppBar, Fab, IconButton, Menu, MenuItem, Toolbar } from "@mui/material";
import { styled } from '@mui/material/styles';
import { Box } from "@mui/system";
import { Link } from "react-router-dom";

const Footer = () => {
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (e) => {
        setAnchorEl(e.currentTarget);
    }
    const handleClose = () => {
        setAnchorEl(null);
      };

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
                    <IconButton id="menu-button" color="inherit" aria-label="open drawer"
                        aria-controls={open ? 'main-menu' : undefined}
                        aria-haspopup="true"
                        aria-expanded={open ? 'true' : undefined}
                        onClick={handleClick}>
                            <MenuIcon />
                    </IconButton>
                    <Menu id='main-menu'
                        anchorEl={anchorEl}
                        open={open}
                        onClose={handleClose}
                        MenuListProps={{ 'aria-labelledby': 'menu-button' }}
                        anchorOrigin={{
                            vertical: 'top',
                            horizontal: 'left'
                        }}
                        transformOrigin={{
                            vertical: 'bottom',
                            horizontal: 'left'
                        }}>
                            <MenuItem component={Link} to="/check-progress">Check Progress</MenuItem>
                            <MenuItem component={Link} to="/users">Global Leaderboard</MenuItem>
                            <MenuItem component={Link} to="/private-marathons">Private Marathons</MenuItem>
                            <MenuItem component={Link} to="/login">Log In</MenuItem>
                    </Menu>

                    <StyledFab href="/register-run" color="secondary" aria-label="add" style={{ width: 80, height: 80 }}>
                        <DirectionsRunRoundedIcon style={{ width: 50, height: 50 }} />
                    </StyledFab>
                    <Box sx={{ flexGrow: 1 }} />
                    <IconButton color="inherit" onClick={ logout }><Logout /></IconButton>
                </Toolbar>
            </AppBar>

            <div className="footer">
                <PhotoCredits />
            </div>
        </>
    );
};

export default Footer;