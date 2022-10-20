import { React, useState } from "react";

import {logout} from "../../utils/Logout"

import MenuIcon from '@mui/icons-material/Menu';
import DirectionsRunRoundedIcon from '@mui/icons-material/DirectionsRunRounded';
import MoreIcon from '@mui/icons-material/MoreVert';
import { Logout } from "@mui/icons-material";

import PhotoCredits from "../../media/PhotoCredits";
import { AppBar, Button, Fab, IconButton, Menu, MenuItem, Toolbar, Tooltip, Typography } from "@mui/material";
import PublicTwoToneIcon from '@mui/icons-material/PublicTwoTone';
import Groups2TwoToneIcon from '@mui/icons-material/Groups2TwoTone';
import { styled } from '@mui/material/styles';
import { Box } from "@mui/system";
import { Link } from "react-router-dom";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";
import RegisterRunModal from "../RegisterRunModal/RegisterRunModal";


const Footer = (props) => {
    const {user} = useContext(UserContext);
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
    
    const buttonSize = { width: 50, height: 50 };

    const [openModal, setOpenModal] = useState(false);

    const handleOpenModal = () => {
        setOpenModal(true);
    }
    const handleCloseModal = () => setOpenModal(false);

    return(
        <>
        <RegisterRunModal open={openModal}
        close={handleCloseModal} {...props} />

            <AppBar position="relative" color="primary"
          sx={{top: 'auto', bottom: 0}}>
                <Toolbar>
                    <IconButton id="menu-button" color="inherit" aria-label="open drawer"
                        aria-controls={open ? 'main-menu' : undefined}
                        aria-haspopup="true"
                        aria-expanded={open ? 'true' : undefined}
                        onClick={handleClick}>
                            <MenuIcon style={{ width: 50, height: 50 }}/>
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
                            <MenuItem component={Link} to="/register">Register</MenuItem>
                            <MenuItem component={Link} to="/about">About</MenuItem>
                    </Menu>
                    <Tooltip title={<Typography variant="h5">Global Ranking</Typography>}>
                        {user.auth ? 
                            <IconButton component={Link} to="/global-ranking"><PublicTwoToneIcon style={buttonSize}/></IconButton>
                            :
                            <IconButton disabled={true} component={Link} to="/global-ranking"><PublicTwoToneIcon style={buttonSize}/></IconButton>}
                    </Tooltip>
                    
                    {user.auth ?
                    <StyledFab onClick={handleOpenModal} color="secondary" aria-label="add" style={{ width: 80, height: 80 }}>
                        <DirectionsRunRoundedIcon style={buttonSize} />
                    </StyledFab> 
                    :
                    <StyledFab color="secondary" aria-label="add" style={{ width: 80, height: 80 }}>
                        <DirectionsRunRoundedIcon style={buttonSize} />
                    </StyledFab>}

                    <Box sx={{ flexGrow: 1 }} />
                    <Tooltip title={<Typography variant="h5">Running Challenges</Typography>}>
                        {user.auth ? 
                        <IconButton component={Link} to="/private-marathons"><Groups2TwoToneIcon style={buttonSize}/></IconButton>
                        :
                        <IconButton disabled={true} component={Link} to="/private-marathons"><Groups2TwoToneIcon style={buttonSize}/></IconButton>}
                    </Tooltip>
                    {user.auth ? 
                    <IconButton color="inherit" onClick={ logout }><Logout style={buttonSize} /></IconButton>
                    : 
                    <IconButton disabled={true} color="inherit" onClick={ logout }><Logout style={buttonSize} /></IconButton>}
                    
                </Toolbar>
            </AppBar>

            <div className="footer">
                {/* <PhotoCredits /> */}
            </div>
        </>
    );
};

export default Footer;