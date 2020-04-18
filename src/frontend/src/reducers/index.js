import { combineReducers } from "redux";
import menuReducer from "./menuReducer";
import orderReducer from "./orderReducer";
import cartReducer from "./cartReducer";
import submitOrderButtonReducer from "./submitOrderButtonReducer";

const rootReducer = combineReducers({
  menu: menuReducer,
  order: orderReducer,
  cart: cartReducer,
  submitOrderButton: submitOrderButtonReducer,
});

export default rootReducer;
