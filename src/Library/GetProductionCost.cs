using Full_GRASP_And_SOLID.Library;
/* Esta clase está basada en el principio S de SOLID (SRP: Responsabilidad única), creamos una clase
que vamos a utilizar únicamente para calcular el costo de la producción de la receta. */
namespace Full_GRASP_And_SOLID
{
    public class RecipeCostCalculator
    {
        public double CalculateProductionCost(Recipe recipe)
        {
            double ingredientCost = CalculateIngredientCost(recipe);
            double equipmentCost = CalculateEquipmentCost(recipe);

            return ingredientCost + equipmentCost;
        }

        private double CalculateIngredientCost(Recipe recipe)
        {
            double totalIngredientCost = 0;

            foreach (Step step in recipe.Steps)
            {
                double stepIngredientCost = step.Input.UnitCost * step.Quantity;
                totalIngredientCost += stepIngredientCost;
            }

            return totalIngredientCost;
        }

        private double CalculateEquipmentCost(Recipe recipe)
        {
            double totalEquipmentCost = 0;

            foreach (Step step in recipe.Steps)
            {
                double stepEquipmentCost = (step.Time / 60.0) * step.Equipment.HourlyCost;
                totalEquipmentCost += stepEquipmentCost;
            }

            return totalEquipmentCost;
        }
    }
}   