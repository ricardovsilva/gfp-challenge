import "primereact/resources/themes/nova-light/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.css";
import styles from "./components/styles";

import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { getMenu, getOrders } from "./actions";

import Menu from "./components/Menu";
import Cart from "./components/Cart";
import OrderTable from "./components/OrderTable";

class App extends Component {
  componentDidMount = () => {
    this.props.getMenu();
    this.props.getOrders();
  };

  render() {
    return (
      <>
        <div className="p-grid" style={styles.home}>
          <div className="p-col-8">
            <Menu />
          </div>
          <div style={styles.sidebar} className="p-col-4">
            <div style={styles.sidebar.container}>
              <Cart style={styles.cart} />
              <OrderTable />
            </div>
          </div>
        </div>
      </>
    );
  }
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators({ getMenu, getOrders }, dispatch);
}

export default connect(null, mapDispatchToProps)(App);
