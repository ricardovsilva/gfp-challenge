import React, { Component } from "react";

import { AccordionTab } from "primereact/accordion";
import Dish from "./Dish";

class TimeOfDayMenu extends Component {
  render() {
    return (
      <AccordionTab>
        {this.props.dishes
          ? this.props.menu.dishes.map((dish) => <Dish dish={dish} />)
          : null}
      </AccordionTab>
    );
  }
}

export default TimeOfDayMenu;
