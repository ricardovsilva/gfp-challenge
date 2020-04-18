import axios from "axios";

import { API_BASE_URL } from "../config";
import { MENU, ADD_TO_CART, DISH_UPDATE } from "../types";

export function getMenu() {
  const request = axios({
    method: "get",
    url: `${API_BASE_URL}/menu/1`,
    headers: {
      "Access-Control-Allow-Origin": "*",
    },
  }).then((response) => response.data);

  return {
    type: MENU,
    payload: request,
  };
}

export function addToCart(dishId) {
  return {
    type: ADD_TO_CART,
    dishId,
  };
}

export function updateDishPanel(dishId, state) {
  return {
    type: DISH_UPDATE,
    payload: {
      dishId,
      state,
    },
  };
}
