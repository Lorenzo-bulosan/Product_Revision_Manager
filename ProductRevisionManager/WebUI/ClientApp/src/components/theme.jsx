const { createTheme } = require("@mui/material");

export const ui_colors = {
    primary: "#333333",
    secondary: "#206969"
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
                fontSize: 15,
                fontWeight: 400,
            },
            caption: {
                fontSize: 12,
                fontWeight: 400,
            },
            h1: {
                fontSize: 35,
            },
            h2: {
                fontSize: 25,
            },
            h5: {
                fontSize: 16,
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
