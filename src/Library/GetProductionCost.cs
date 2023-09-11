using Full_GRASP_And_SOLID.Library;
/* Esta clase está basada en el principio S de SOLID (SRP: Responsabilidad única), creamos una clase
que vamos a utilizar únicamente para calcular el costo de la producción de la receta. */
namespace Full_GRASP_And_SOLID{
    public class CostCalc{
        public double CalcCost(Recipe recipe){
            double IngredientCost = CalcIngredientCost(recipe);
            double EquipmentCost = CalcEquipmentCost(recipe);

            return IngredientCost + EquipmentCost;
        }
        private double CalcIngredientCost(Recipe recipe){
            double IngredientCost = 0;
            foreach(Step step in recipe.Steps){
                IngredientCost += step.Input.UnitCost * step.Quantity;
            }
            return IngredientCost;
        }
        private double CalcEquipmentCost(Recipe recipe){
            double EquipmentCost = 0;
            foreach(Step step in recipe.Steps){
                EquipmentCost += (step.Time / 60.0) * step.Equipment.HourlyCost;
            }
            return EquipmentCost;
        }
    }
}