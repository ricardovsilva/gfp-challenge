import React, { Component } from "react";
import { Card } from "primereact/card";
import { Panel } from "primereact/panel";
import { connect } from "react-redux";

import { MORNING, NIGHT } from "../constants";

import SubmitOrderButton from "./SubmitOrderButton";
import style from "./styles";

class Cart extends Component {
  render() {
    return (
      <div
        style={{
          position: "relative",
        }}
      >
        <Card title="Cart" style={style.cart.card}>
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
  if (state.menu.dishes) {
    const dishesIds = state.cart.dishesIds;
    const getDishes = (timeOfDay) =>
      state.menu.dishes.filter(
        (dish) => dishesIds.includes(dish.id) && dish.timeOfDay === timeOfDay
      );

    const morningDishes = getDishes(MORNING);
    const nightDishes = getDishes(NIGHT);

    const cart = {
      morningDishes: morningDishes,
      nightDishes: nightDishes,
      showMorningDishes: morningDishes.length,
      showNightDishes: nightDishes.length,
    };

    return cart;
  } else {
    return {
      morningDishes: [],
      nightDishes: [],
      morningDishesDisplay: "visible",
      nightDishesDisplay: "visible",
    };
  }
}

export default connect(mapStateToProps)(Cart);
