import { ADD_TO_CART_BUTTON } from "../types";

export default (state = {}, action) => {
  console.log("ACTION", action.type);
  switch (action.type) {
    case ADD_TO_CART_BUTTON:
      const { dishId } = action.payload;
      const newState = JSON.parse(JSON.stringify(state));
      newState[dishId] = JSON.parse(JSON.stringify(action.payload.state));
      console.log("f", newState);
      return newState;
    default:
      return state;
  }
};
