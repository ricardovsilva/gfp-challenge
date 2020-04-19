const LIGHT_GREY = "#d3d3d3";

export default {
  home: {
    maxWidth: "920px",
    margin: "auto",
  },
  sidebar: {
    position: "relative",
    margin: 0,
    container: {
      position: "fixed",
      height: "630px",
      width: "400px",
    },
  },
  cart: {
    card: {
      height: "100%",
      paddingBottom: "40px",
    },
    timesOfDay: {
      marginTop: "10px",
    },
    dishes: {
      overflow: "scroll",
      overflowX: "hidden",
      maxHeight: "180px",
      marginBottom: "10px",
    },
    container: {
      maxHeight: "290px",
      position: "relative",
    },
  },
  submitOrderButton: {
    position: "absolute",
    bottom: 20,
    right: 10,
    cursor: "pointer",
  },
  orderTable: {
    paddingTop: "20px",
    overflow: "scroll",
    maxHeight: "270px",
  },
  disabledText: {
    color: LIGHT_GREY,
  },
};
