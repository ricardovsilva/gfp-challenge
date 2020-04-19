import React, { Component } from "react";
import { Button } from "primereact/button";

import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { addToCart, updateDishPanel } from "../actions";

class AddToCartButton extends Component {
  onClick = () => {
    this.props.updateDishPanel(this.props.dishId, {
      state: {
        clicked: true,
      },
    });

    this.props.addToCart(this.props.dish);
  };

  render() {
    const { disabled, addMany } = this.props;
    return (
      <Button
        label={
          !disabled
            ? "Order It"
            : this.props.addMany
            ? "Order One More"
            : "Added to Cart"
        }
        style={{
          position: "absolute",
          bottom: 0,
          right: 0,
        }}
        disabled={disabled && !addMany}
        className={
          disabled && !addMany ? "p-button-primary" : "p-button-success"
        }
        onClick={this.onClick}
        icon={disabled && !addMany ? "pi pi-shopping-cart" : undefined}
      />
    );
  }
}

function mapStateToProps(state, props) {
  const { dishId } = props;
  const { addToCartButton } = state;
  const disabled =
    addToCartButton &&
    dishId in addToCartButton &&
    addToCartButton[dishId].state.clicked;

  return {
    disabled,
  };
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators({ addToCart, updateDishPanel }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(AddToCartButton);
