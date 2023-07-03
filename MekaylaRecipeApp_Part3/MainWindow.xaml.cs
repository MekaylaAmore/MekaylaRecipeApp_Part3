using MekaylaRecipeApp_Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MekaylaRecipeApp_Part3
{
        public partial class MainWindow : Window
        {
            private List<Recipe> recipes; // List of recipes

            public MainWindow()
            {
                InitializeComponent();

                // Initialize the recipes list (load from a data source or create dummy data)
                recipes = new List<Recipe>
            {
                // Add some sample recipes
                new Recipe("Pasta Carbonara"),
                new Recipe("Chicken Curry"),
                new Recipe("Chocolate Cake")
            };

                // Set the data context for the recipe list
                recipeListBox.ItemsSource = recipes;
            }

            private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e)
            {
                // Get the filter values from the UI
                string ingredientFilter = ingredientTextBox.Text;
                string foodGroupFilter = foodGroupComboBox.SelectedItem as string;
                double maxCaloriesFilter;
                bool hasMaxCaloriesFilter = double.TryParse(maxCaloriesTextBox.Text, out maxCaloriesFilter);

                // Apply the filters to the recipes list
                var filteredRecipes = recipes.Where(recipe =>
                    (string.IsNullOrEmpty(ingredientFilter) || recipe.Ingredients.Any(ingredient => ingredient.Name.ToLower().Contains(ingredientFilter.ToLower()))) &&
                    (string.IsNullOrEmpty(foodGroupFilter) || recipe.Ingredients.Any(ingredient => ingredient.FoodGroup == foodGroupFilter)) &&
                    (!hasMaxCaloriesFilter || recipe.CalculateTotalCalories() <= maxCaloriesFilter)
                ).ToList();

                // Update the recipe list with the filtered results
                recipeListBox.ItemsSource = filteredRecipes;
            }

            private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
            {
                // Clear the filter values and reset the recipe list
                ingredientTextBox.Clear();
                foodGroupComboBox.SelectedItem = null;
                maxCaloriesTextBox.Clear();

                recipeListBox.ItemsSource = recipes;
            }

            private void RecipeListBox_SelectionChanged(object sender, RoutedEventArgs e)
            {
                // Update the details view based on the selected recipe
                Recipe selectedRecipe = recipeListBox.SelectedItem as Recipe;
                if (selectedRecipe != null)
                {
                    recipeNameTextBlock.Text = selectedRecipe.Name;
                    ingredientsListBox.ItemsSource = selectedRecipe.Ingredients;
                    stepsListBox.ItemsSource = selectedRecipe.Steps;
                }
            }

            private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
            {
                // Open a new window or dialog for adding a recipe
                // Implement the logic to add a new recipe to the recipes list and refresh the recipe list view
            }

            private void DeleteRecipeButton_Click(object sender, RoutedEventArgs e)
            {
                // Get the selected recipe
                Recipe selectedRecipe = recipeListBox.SelectedItem as Recipe;

                // Remove the selected recipe from the recipes list
                if (selectedRecipe != null)
                {
                    recipes.Remove(selectedRecipe);

                    // Clear the details view
                    recipeNameTextBlock.Text = string.Empty;
                    ingredientsListBox.ItemsSource = null;
                    stepsListBox.ItemsSource = null;
                }

                // Refresh the recipe list view
                recipeListBox.ItemsSource = recipes;
            }
        }
    }
