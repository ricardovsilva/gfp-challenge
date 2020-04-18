import { MENU } from "../types";
import { MORNING, NIGHT } from "../constants";

const getDishes = (timeOfDay, dishes) =>
  dishes.filter((dish) => dish.timeOfDay === timeOfDay);

export default (state = {}, action) => {
  switch (action.type) {
    case MENU:
      const newState = action.payload;
      newState.morningDishes = getDishes(MORNING, newState.dishes);
      newState.nightDishes = getDishes(NIGHT, newState.dishes);
      return newState;
    default:
      return state;
  }
};
