using System;
using System.Collections.Generic;
using System.Linq;

namespace MekaylaRecipeApp_Part2
{
    // Class representing a recipe
    public class Recipe
    {
        // Properties
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        // Constructor
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>(); // Initialize the ingredient list
            Steps = new List<string>(); // Initialize the steps list
        }

        // Method to add ingredients to the recipe
        public void AddIngredients(int numberOfIngredients)
        {
            for (int i = 0; i < numberOfIngredients; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of {name}:");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the unit of measurement for {quantity} {name}:");
                string unit = Console.ReadLine();

                Console.WriteLine($"Enter the number of calories for {quantity} {name}:");
                double calories = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the food group for {name}:");
                string foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
                Ingredients.Add(ingredient);
            }
        }

        // Method to add steps to the recipe
        public void AddSteps(int numberOfSteps)
        {
            for (int i = 0; i < numberOfSteps; i++)
            {
                Console.WriteLine($"Enter the description of step #{i + 1}:");
                Steps.Add(Console.ReadLine());
            }
        }

        // Method to print the recipe
        public void PrintRecipe()
        {
            Console.WriteLine("********************");
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("********************");

            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }
            Console.WriteLine("");

            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        // Method to calculate the total calories of the recipe
        public double CalculateTotalCalories()
        {
            double totalCalories = Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
            return totalCalories;
        }

        // Method to scale the recipe
        public void ScaleRecipe(double factor)
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ScaleQuantity(factor);
            }
        }

        // Method to reset the quantities of the ingredients
        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        // Method to clear the recipe
        public void ClearRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
        }
    }
}