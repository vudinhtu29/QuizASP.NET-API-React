import React from "react";
import {Box} from '@mui/material'

export default function Center(props){
    return(
        <Box 
        display="flex"
        flexDirection="column"
        alignItems="center"
        justifyContent="center"
        minHeight="100vh"

        sx={{
            backgroundColor: '#6a1b9a',
            padding:'20px',
        }}
    >
        <Box>
            {props.children}
        </Box>
    </Box>
    )
}