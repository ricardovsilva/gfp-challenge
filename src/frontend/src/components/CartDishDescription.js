import React, { Component } from "react";
import * as R from "ramda";
import style from "./styles";

import { getDishesGrouped } from "../utils/dishesUtils";

export default class CartDishDescription extends Component {
  render() {
    const groupedDishes = getDishesGrouped(this.props.dishes);
    return (
      <>
        {groupedDishes.map((dish) => (
          <p key={dish.id}>{dish.description}</p>
        ))}
      </>
    );
  }
}
