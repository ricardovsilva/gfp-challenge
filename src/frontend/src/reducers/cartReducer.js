import { ADD_TO_CART } from "../types";

export default (state, action) => {
  switch (action.type) {
    case ADD_TO_CART:
      const newState = { ...state };
      newState.dishesIds = [...state.dishesIds];
      newState.dishesIds.push(action.dishId);
      return newState;
    default:
      return {
        dishesIds: [],
      };
  }
};
