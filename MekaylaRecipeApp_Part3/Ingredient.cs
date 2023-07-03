namespace MekaylaRecipeApp_Part2
{
    // Class representing an ingredient
    public class Ingredient
    {
        // Properties
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double OriginalQuantity { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            OriginalQuantity = quantity;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Method to scale the quantity of the ingredient
        public void ScaleQuantity(double factor)
        {
            Quantity *= factor;
        }

        // Method to reset the quantity of the ingredient to its original value
        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;
        }

        // Method to convert the ingredient to a string representation
        public override string ToString()
        {
            return $"{Name}: {Quantity} {Unit} ({Calories} calories, {FoodGroup})";
        }
    }
}
