import axios from "axios";

import { API_BASE_URL } from "../config";
import {
  MENU,
  ADD_TO_CART,
  ADD_TO_CART_BUTTON,
  ORDER_SUBMITED,
  ORDER_SENT,
  RESET_ORDER_SENT_EVENT,
  GET_ORDERS,
} from "../types";
import { MORNING } from "../constants";

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
    type: ORDER_SUBMITED,
    payload: Promise.all(requests),
  };
}

export function getOrders() {
  const response = axios
    .get(`${API_BASE_URL}/order`)
    .then((response) => response.data)
    .then((data) =>
      data.map((order) => ({ id: order.id, dishes: order.dishes }))
    );

  return {
    type: GET_ORDERS,
    payload: response,
  };
}

export function emitOrderSent() {
  return {
    type: ORDER_SENT,
  };
}

export function resetOrderSentEvent() {
  return {
    type: RESET_ORDER_SENT_EVENT,
  };
}
