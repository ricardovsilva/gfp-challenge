import { DISH_UPDATE } from "../types";

export default (state = {}, action) => {
  switch (action.type) {
    case DISH_UPDATE:
      const { state, dishId } = action.payload;
      const newState = JSON.parse(JSON.stringify(state));
      newState[dishId] = state;
      return newState;
    default:
      return {};
  }
};
