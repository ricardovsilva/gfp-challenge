import { ORDER } from "../types";

export default (state = null, action) => {
  switch (action.type) {
    case ORDER:
      return action.payload;
    default:
      return state;
  }
};
