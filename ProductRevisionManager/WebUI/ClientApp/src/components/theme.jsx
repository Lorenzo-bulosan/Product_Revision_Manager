const { createTheme } = require("@mui/material");

export const ui_colors = {
  primary: "#333333",
};

export const theme = createTheme({
  palette: {
    primary: {
      main: "#333333",
    },
  },
  components: {
    MuiTypography: {
      styleOverrides: {
        body1: {
          fontSize: 5,
          fontWeight: 200,
        },
        caption: {
          fontSize: 2,
          fontWeight: 200,
        },
        h1: {
          fontSize: 25,
        },
        h2: {
          fontSize: 15,
        },
        h5: {
          fontSize: 6,
        },
      },
    },

    MuiButton: {
      styleOverrides: {
        text: {
          color: "#3a3a3a97",
        },
      },
    },
  },
});
