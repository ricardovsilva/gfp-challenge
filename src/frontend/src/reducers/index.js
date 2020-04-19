import { combineReducers } from "redux";
import menuReducer from "./menuReducer";
import orderReducer from "./orderReducer";
import cartReducer from "./cartReducer";
import addToCartButtonReducer from "./addToCartButtonReducer";

const rootReducer = combineReducers({
  menu: menuReducer,
  order: orderReducer,
  cart: cartReducer,
  addToCartButton: addToCartButtonReducer,
});

export default rootReducer;
