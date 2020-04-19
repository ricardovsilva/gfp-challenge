import { ADD_TO_CART_BUTTON } from "../types";

export default (state = {}, action) => {
  switch (action.type) {
    case ADD_TO_CART_BUTTON:
      const { dishId } = action.payload;
      const newState = JSON.parse(JSON.stringify(state));
      newState[dishId] = JSON.parse(JSON.stringify(action.payload.state));
      return newState;
    default:
      return state;
  }
};
