import React, { Component } from "react";
import { Button } from "primereact/button";

import styles from "./styles";

class SubmitOrderButton extends Component {
  state = {
    clicked: false,
    sendingOrder: false,
  };

  onClick = () => {
    this.setState({ sendingOrder: true, clicked: true });

    setTimeout(() => {
      this.setState({ sendingOrder: false });
      setTimeout(() => {
        this.setState({ clicked: false });
      }, 1000);
    }, 3000);
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

export default SubmitOrderButton;
