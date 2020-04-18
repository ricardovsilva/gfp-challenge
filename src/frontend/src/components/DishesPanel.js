import React from "react";

import Dish from "./Dish";

export default function DishesPanel(props) {
  return (
    <>
      {props.dishes
        ? props.dishes.map((dish) => <Dish dish={dish} key={dish.id} />)
        : null}
    </>
  );
}
