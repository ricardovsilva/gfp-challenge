import React, { Component } from "react";
import { Card } from "primereact/card";
import { Panel } from "primereact/panel";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { MORNING, NIGHT } from "../constants";

import { resetOrderSentEvent } from "../actions";
import SubmitOrderButton from "./SubmitOrderButton";
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
      <div
        style={{
          position: "relative",
        }}
      >
        <Card title="Cart" style={style.cart.card}>
          {this.props.showOrderSentMessage ? (
            <h1>Thank you! Our Master Chefs received your order :)</h1>
          ) : null}
          <div>
            {this.props.showMorningDishes ? (
              <Panel header="Morning Dishes" style={style.cart.timesOfDay}>
                {this.props.morningDishes.map((dish) => (
                  <p key={dish.id}>{dish.description}</p>
                ))}
              </Panel>
            ) : null}
            {this.props.showNightDishes ? (
              <Panel header="Night Dishes" style={style.cart.timesOfDay}>
                {this.props.nightDishes.map((dish) => (
                  <p key={dish.id}>{dish.description}</p>
                ))}
              </Panel>
            ) : null}
            <SubmitOrderButton />
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

  const cart = {
    morningDishes: morningDishes,
    nightDishes: nightDishes,
    showMorningDishes: morningDishes && morningDishes.length,
    showNightDishes: nightDishes && nightDishes.length,
    events,
    showOrderSentMessage: events.orderSent,
  };

  return cart;
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators({ resetOrderSentEvent }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(Cart);
