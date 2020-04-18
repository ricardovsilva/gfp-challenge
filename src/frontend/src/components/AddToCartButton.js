import React, { Component } from "react";
import { Button } from "primereact/button";

import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { addToCart, updateDishPanel } from "../actions";

class AddToCartButton extends Component {
  onClick = (event) => {
    updateDishPanel(this.props.dishId, {
      state: {
        clicked: true,
      },
    });

    this.props.addToCart(this.props.dishId);
  };

  render() {
    return (
      <Button
        label={
          !this.props.clicked
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
        disabled={this.props.clicked && !this.props.addMany}
        className={
          this.props.clicked && !this.props.addMany
            ? "p-button-primary"
            : "p-button-success"
        }
        onClick={this.onClick}
        icon={
          this.props.clicked && !this.props.addMany
            ? "pi pi-shopping-cart"
            : undefined
        }
      />
    );
  }
}

function mapStateToProps(state) {
  console.log(state);
  return {
    clicked: state.clicked,
  };
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators({ addToCart }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(AddToCartButton);
