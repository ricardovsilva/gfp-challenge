import React, { Component } from "react";
import { Card } from "primereact/card";
import { Panel } from "primereact/panel";
import { connect } from "react-redux";
import * as R from "ramda";

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
  if (!state.cart) {
    return;
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
  };

  return cart;
}

export default connect(mapStateToProps)(Cart);
