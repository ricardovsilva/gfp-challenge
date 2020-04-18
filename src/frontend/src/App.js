import "primereact/resources/themes/nova-light/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.css";
import styles from "./components/styles";

import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { getMenu } from "./actions";

import Menu from "./components/Menu";
import Cart from "./components/Cart";

class App extends Component {
  componentDidMount = () => {
    this.props.getMenu();
  };

  render() {
    return (
      <>
        <div className="p-grid" style={styles.home}>
          <div className="p-col-8">
            <Menu />
          </div>
          <div className="p-col-4" style={{ backgroundColor: "#000" }}>
            <Cart style={styles.cart} />
          </div>
        </div>
      </>
    );
  }
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators({ getMenu }, dispatch);
}

export default connect(null, mapDispatchToProps)(App);
