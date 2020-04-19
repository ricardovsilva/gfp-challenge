import { ADD_TO_CART, ORDER_SUBMITED } from "../types";

export default (
  state = {
    dishes: [],
  },
  action
) => {
  switch (action.type) {
    case ADD_TO_CART:
      const newState = { ...state };
      newState.dishes = [...state.dishes];
      newState.dishes.push(action.dish);
      return newState;
    case ORDER_SUBMITED:
      return {
        dishes: [],
      };
    default:
      return state;
  }
};
