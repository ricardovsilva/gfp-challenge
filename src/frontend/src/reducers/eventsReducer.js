import { ORDER_SENT, RESET_ORDER_SENT_EVENT } from "../types";

export default (state = {}, action) => {
  let newState;
  switch (action.type) {
    case ORDER_SENT:
      newState = { ...state };
      newState.orderSent = true;
      return newState;
    case RESET_ORDER_SENT_EVENT:
      newState = { ...state };
      newState.orderSent = false;
      return newState;
    default:
      return state;
  }
};
