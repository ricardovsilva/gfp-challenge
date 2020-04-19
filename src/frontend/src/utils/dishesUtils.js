import * as R from "ramda";

export function getDishesGrouped(dishes) {
  if (!dishes || !dishes.length) {
    return [];
  }

  const dishesFrequency = R.countBy((r) => r.id)(dishes);
  const newDishes = Object.entries(dishesFrequency).map(([id, frequency]) => {
    const dish = { ...dishes.find((_) => parseInt(_.id) === parseInt(id)) };
    dish.description = `${dish.description} (x${frequency})`;
    return dish;
  });

  return newDishes;
}
