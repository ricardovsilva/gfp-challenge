import React, { Component } from "react";
import { Card } from "primereact/card";
import { TabView, TabPanel } from "primereact/tabview";
import { connect } from "react-redux";

import DishesPanel from "./DishesPanel";

class Menu extends Component {
  state = {
    activeIndex: 0,
  };

  render() {
    return (
      <Card
        title="Menu"
        style={{
          position: "relative",
        }}
      >
        <TabView
          activeIndex={this.state.activeIndex}
          onTabChange={(e) => this.setState({ activeIndex: e.index })}
          style={{
            paddingBottom: 60,
          }}
        >
          <TabPanel header="Morning" enabled>
            <DishesPanel dishes={this.props.morningDishes} />
          </TabPanel>
          <TabPanel header="Night" enabled>
            <DishesPanel dishes={this.props.nightDishes} />
          </TabPanel>
        </TabView>
      </Card>
    );
  }
}

function mapStateToProps(state) {
  return state.menu;
}

export default connect(mapStateToProps)(Menu);
