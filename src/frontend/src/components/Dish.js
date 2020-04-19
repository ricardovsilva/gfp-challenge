import React from "react";
import { Panel } from "primereact/panel";
import AddToCartButton from "./AddToCartButton";

export default function Dish(props) {
  return (
    <>
      <Panel
        header={props.dish.description}
        style={{
          marginBottom: "10px",
        }}
      >
        <div className="p-grid">
          <div
            className="p-col-4"
            style={{
              background: `url(/images/${props.dish.description}.jpg) no-repeat`,
              backgroundSize: "cover",
              height: "196px",
              marginTop: "10px",
              marginBottom: "5px",
            }}
          ></div>
          <div
            className="p-col-8"
            style={{
              position: "relative",
            }}
          >
            <div>
              Lorem, ipsum dolor sit amet consectetur adipisicing elit. Rem,
              doloremque? Ratione velit soluta facere illum inventore veritatis
              qui deleniti voluptate, sit nisi sequi eius fugiat officia quas,
              tempore blanditiis minus!
            </div>
            <AddToCartButton
              dishId={props.dish.id}
              dish={props.dish}
              addMany={props.dish.canBeOrderedMultipleTimes}
            />
          </div>
        </div>
      </Panel>
    </>
  );
}
