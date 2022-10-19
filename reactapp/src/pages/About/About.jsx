import { Box, Typography } from "@mui/material";
import React from "react";

const boxStyle = {
    paddingLeft: "22px",
    paddingRight: "22px",
    display: "flex"
}

const imgStyle = {
    width: "250px",
    marginRight: "18px",
    objectFit: "cover"
}

const About = () => {
    const text1 = "According to legend, an Athenian messenger was sent from Marathon to Athens, a distance of about 25 miles (40 km), and there he announced the Persian defeat before dying of exhaustion. This tale became the basis for the modern marathon race.Herodotus, however, relates that a trained runner, Pheidippides (also spelled Phidippides, or Philippides), was sent from Athens to Sparta before the battle in order to request assistance from the Spartans; he is said to have covered about 150 miles (240 km) in about two days."
    const text2 = "The purpose of this application is to use this story to motivate you to get moving. Go out and try to run the same distance in as many sessions as you are confortable and preferably with better running shoes than Pheidippides."
    return(
        <>
        <Box sx={boxStyle}>
            <img id="aboutPhoto" style={imgStyle} src={require('../../media/Pheidippides.jpg')}></img>
            <Typography id="aboutText" flexWrap variant="h6">{text1}</Typography>
        </Box>
        <Box sx={boxStyle}>
            <Typography variant="h6">{text2}</Typography>
        </Box>
        </>
    );
};

export default About;