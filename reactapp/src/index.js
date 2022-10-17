import React from 'react';
import ReactDOM from 'react-dom/client';
import { UserProvider } from "./hooks/UserContext"
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
// Set up Theme
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { BrowserRouter } from 'react-router-dom';

const theme = createTheme({
  palette: {
    primary: { 
      main: "#4B624B" },
    red: {
      main: "#EA526F"
    }
  },
  typography: {
    h2: {
      fontFamily: ['Skranji', 'cursive'].join(',')
    },
    p: {
      fontFamily: ['Roboto', 'Oxygen',
    'Ubuntu', 'Cantarell', 'Fira Sans', 'Droid Sans', 'Helvetica Neue',
    'sans-serif'].join(",")
    }
    
  },
  components: {
    MuiToolbar: {
      styleOverrides: {
        dense: {
          height: 32,
          minHeight: 32
        }
      }
    },
  },
});

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <UserProvider>
      <ThemeProvider theme={theme}>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </ThemeProvider>
    </UserProvider>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
