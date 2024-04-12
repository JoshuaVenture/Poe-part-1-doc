using System;

namespace RecipeApp
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    class Step
    {
        public string Description { get; set; }
    }

    class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;

        public Recipe()
        {
            ingredients = new Ingredient[0];
            steps = new Step[0];
        }

        public void AddIngredient(string name, double quantity, string unit)
        {
            Ingredient newIngredient = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            Array.Resize(ref ingredients, ingredients.Length + 1);
            ingredients[ingredients.Length - 1] = newIngredient;
        }

        public void AddStep(string description)
        {
            Step newStep = new Step { Description = description };
            Array.Resize(ref steps, steps.Length + 1);
            steps[steps.Length - 1] = newStep;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Reset quantities to original values - Currently not implemented
            // You can implement this if needed based on your requirements
        }

        public void ClearRecipe()
        {
            ingredients = new Ingredient[0];
            steps = new Step[0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add ingredient");
                Console.WriteLine("2. Add step");
                Console.WriteLine("3. Display recipe");
                Console.WriteLine("4. Scale recipe");
                Console.WriteLine("5. Reset quantities (not implemented)");
                Console.WriteLine("6. Clear recipe");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter ingredient name: ");
                        string ingredientName = Console.ReadLine();
                        Console.Write("Enter quantity: ");
                        if (!double.TryParse(Console.ReadLine(), out double quantity))
                        {
                            Console.WriteLine("Invalid quantity. Please enter a valid number.");
                            continue;
                        }
                        Console.Write("Enter unit: ");
                        string unit = Console.ReadLine();
                        recipe.AddIngredient(ingredientName, quantity, unit);
                        break;
                    case 2:
                        Console.Write("Enter step description: ");
                        string stepDescription = Console.ReadLine();
                        recipe.AddStep(stepDescription);
                        break;
                    case 3:
                        recipe.DisplayRecipe();
                        break;
                    case 4:
                        Console.Write("Enter scaling factor: ");
                        if (!double.TryParse(Console.ReadLine(), out double factor))
                        {
                            Console.WriteLine("Invalid factor. Please enter a valid number.");
                            continue;
                        }
                        recipe.ScaleRecipe(factor);
                        break;
                    case 5:
                        // This option is not implemented in the Recipe class
                        Console.WriteLine("Resetting quantities is not implemented.");
                        break;
                    case 6:
                        recipe.ClearRecipe();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

