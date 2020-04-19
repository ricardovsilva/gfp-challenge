import { getDishesGrouped } from "../../src/utils/dishesUtils";

describe("dishesUtils", () => {
  describe("getDishesGrouped", () => {
    describe("without any dish", () => {
      it("returns an empty array", () => {
        expect(getDishesGrouped([])).toStrictEqual([]);
      });
    });

    describe("with multiple dishes", () => {
      describe("but no one repeated", () => {
        let dishes;
        beforeAll(() => {
          dishes = [
            {
              id: 1,
              description: "Eggs",
            },
            {
              id: 2,
              description: "Coffee",
            },
          ];
        });

        it("adds (x1) to end of description of each dish", () => {
          getDishesGrouped(dishes).forEach((dish, index) => {
            expect(dish.description).toBe(`${dishes[index].description} (x1)`);
          });
        });
      });

      describe("with 3 repeated", () => {
        let result;
        beforeAll(() => {
          const dishes = [
            { id: 2, description: "Coffee" },
            { id: 2, description: "Coffee" },
            { id: 2, description: "Coffee" },
          ];

          result = getDishesGrouped(dishes);
        });

        it("returns only one element", () => {
          expect(result).toHaveLength(1);
        });

        it("adds (x3) to end of description", () => {
          expect(result[0].description).toBe("Coffee (x3)");
        });
      });
    });
  });
});
