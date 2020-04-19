import React, { Component } from "react";
import { connect } from "react-redux";
import { Card } from "primereact/card";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { MORNING } from "../constants";

import { getDishesGrouped } from "../utils/dishesUtils";
import style from "./styles";

class OrderTable extends Component {
  render() {
    return this.props.show ? (
      <div style={style.orderTable.container}>
        <Card title="Latest Orders">
          <div style={style.orderTable}>
            <DataTable value={this.props.orders}>
              <Column field="id" header="ID" />
              <Column field="dishes" header="Dishes" />
              <Column field="timeOfDay" header="Time Of Day" />
            </DataTable>
          </div>
        </Card>
      </div>
    ) : null;
  }
}

function mapStateToProps(state) {
  if (state.orders) {
    const { orders } = state;
    const dataToShow = orders.map((order) => {
      return {
        id: order.id,
        dishes: getDishesGrouped(order.dishes)
          .map((dish) => dish.description)
          .join(", "),
        timeOfDay: order.dishes[0].timeOfDay === MORNING ? "morning" : "night",
      };
    });

    dataToShow.sort((a, b) => b.id - a.id);

    return {
      orders: dataToShow,
      show: state.orders && state.orders.length,
    };
  }
  return {};
}

export default connect(mapStateToProps)(OrderTable);
