import React, { Component } from "react";
import { Card } from "primereact/card";
import { Panel } from "primereact/panel";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { MORNING, NIGHT } from "../constants";

import { resetOrderSentEvent } from "../actions";
import SubmitOrderButton from "./SubmitOrderButton";

import CartDishDescription from "./CartDishDescription";

import style from "./styles";

class Cart extends Component {
  state = {};
  componentDidUpdate() {
    if (this.props.events.orderSent) {
      setTimeout(() => {
        this.props.resetOrderSentEvent();
      }, 3000);
    }
  }

  render() {
    return (
      <div style={style.cart.container}>
        <Card title="Cart" style={style.cart.card}>
          {this.props.showOrderSentMessage ? (
            <h1 style={style.disabledText}>
              Thank you! Our Master Chefs received your order :)
            </h1>
          ) : !this.props.haveDishes ? (
            <h1 style={style.disabledText}>
              Welcome to El Restauranto, add products to cart to submit an order
            </h1>
          ) : null}
          <div style={style.cart.dishes}>
            {this.props.showMorningDishes ? (
              <Panel header="Morning Dishes" style={style.cart.timesOfDay}>
                <CartDishDescription dishes={this.props.morningDishes} />
              </Panel>
            ) : null}
            {this.props.showNightDishes ? (
              <Panel header="Night Dishes" style={style.cart.timesOfDay}>
                <CartDishDescription dishes={this.props.nightDishes} />
              </Panel>
            ) : null}

            <SubmitOrderButton disabled={!this.props.haveDishes} />
          </div>
        </Card>
      </div>
    );
  }
}

function mapStateToProps(state) {
  const { events } = state;
  if (!state.cart) {
    return { events };
  }
  const getDishes = (timeOfDay) => {
    const dishes = state.cart.dishes
      .filter((dish) => dish.timeOfDay === timeOfDay)
      .map((dish) => ({ ...dish }));

    return dishes;
  };

  const morningDishes = getDishes(MORNING);
  const nightDishes = getDishes(NIGHT);
  const haveDishes = morningDishes.length + nightDishes.length > 0;

  const cart = {
    morningDishes: morningDishes,
    nightDishes: nightDishes,
    showMorningDishes: morningDishes && morningDishes.length,
    showNightDishes: nightDishes && nightDishes.length,
    events,
    showOrderSentMessage: events.orderSent,
    haveDishes,
  };

  return cart;
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators({ resetOrderSentEvent }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(Cart);
