import axios from "axios";

import { API_BASE_URL } from "../config";
import { MENU, ADD_TO_CART, ADD_TO_CART_BUTTON, SUBMIT_ORDER } from "../types";
import { MORNING, NIGHT } from "../constants";

export function getMenu() {
  const request = axios({
    method: "get",
    url: `${API_BASE_URL}/menu/1`,
  }).then((response) => response.data);

  return {
    type: MENU,
    payload: request,
  };
}

export function addToCart(dish) {
  return {
    type: ADD_TO_CART,
    dish,
  };
}

export function updateDishPanel(dishId, state) {
  return {
    type: ADD_TO_CART_BUTTON,
    payload: {
      dishId,
      state,
    },
  };
}

export function submitOrder(dishes) {
  const timesOfDay = [...new Set(dishes.map((_) => _.timeOfDay))];
  const requests = [];

  timesOfDay.forEach((timeOfDay) => {
    const dishesTypes = dishes
      .filter((_) => _.timeOfDay === timeOfDay)
      .map((_) => _.dishType);

    const request = axios({
      method: "POST",
      url: `${API_BASE_URL}/order`,
      headers: {
        "Content-Type": "application/json",
      },
      data: {
        dishesTypes: dishesTypes,
        timeOfDay: timeOfDay === MORNING ? "morning" : "night",
      },
    });

    requests.push(request);
  });

  return {
    type: SUBMIT_ORDER,
    payload: requests,
  };
}
