import React, { Component } from "react";
import { Button } from "primereact/button";

import { submitOrder, emitOrderSent } from "../actions";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import styles from "./styles";

class SubmitOrderButton extends Component {
  state = {
    clicked: false,
    sendingOrder: false,
  };

  onClick = () => {
    this.props.submitOrder(this.props.dishes);
    this.setState({ sendingOrder: true });
  };

  componentDidUpdate = () => {
    if (!this.props.dishes.length && this.state.sendingOrder) {
      this.props.emitOrderSent();
      this.setState({ sendingOrder: false });
    }
  };

  render() {
    return (
      <Button
        label={
          this.state.sendingOrder
            ? "Sending"
            : this.state.clicked
            ? "Order Saved"
            : "Send Order"
        }
        style={styles.submitOrderButton}
        disabled={this.state.clicked}
        className={this.state.clicked ? "p-button-primary" : "p-button-success"}
        onClick={this.onClick}
        icon={this.state.sendingOrder ? "pi pi-spin pi-spinner" : "pi pi-check"}
      />
    );
  }
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators({ submitOrder, emitOrderSent }, dispatch);
}

function mapStateToProps(state) {
  return state.cart;
}

export default connect(mapStateToProps, mapDispatchToProps)(SubmitOrderButton);
