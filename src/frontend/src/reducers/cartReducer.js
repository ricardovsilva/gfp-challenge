import { ADD_TO_CART } from "../types";

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
    default:
      return state;
  }
};
