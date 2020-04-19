import { GET_ORDERS } from "../types";

export default (state = null, action) => {
  switch (action.type) {
    case GET_ORDERS:
      return action.payload;
    default:
      return state;
  }
};
