import { combineReducers } from "redux";
import menuReducer from "./menuReducer";
import orderReducer from "./orderReducer";
import cartReducer from "./cartReducer";
import addToCartButtonReducer from "./addToCartButtonReducer";
import eventsReducer from "./eventsReducer";

const rootReducer = combineReducers({
  menu: menuReducer,
  order: orderReducer,
  cart: cartReducer,
  addToCartButton: addToCartButtonReducer,
  events: eventsReducer,
});

export default rootReducer;
