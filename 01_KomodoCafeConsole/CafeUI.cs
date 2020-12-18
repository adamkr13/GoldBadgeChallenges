using _00_ValidationMethods;
using _01_KomodoCafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeConsole
{
    public class CafeUI
    {
        private MenuItemsRepo _menuItemsRepo = new MenuItemsRepo();

        public void Run()
        {
            PoppySeedData();
            while (UIMenu())
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void PoppySeedData()
        {
            var nothingBurger = new MenuItem("Nothing Burger", "This item is completely lacking in any substance.", new List<string>() { "air - a bunch or nothing" }, 0.99);
            var panGalacticGargleBlaster = new MenuItem("Pan Galactic Gargle Blaster", "Its effects are similar to 'having your brains smashed out by a slice of lemon wrapped round a large gold brick.'", new List<string>() { "one bottle of Ol' Janx Spirit", "one measure of water from the seas of Santraginus V", "three cubes of Arcturan Mega-gin", "four litres of Fallian marsh gas", "a measure of Qualactin Hypermint extract", "the tooth of an Algolian Suntiger", "a sprinkle of Zamphuor", "an olive" }, 9.99);
            var doublemeatMedley = new MenuItem("Doublemeat Medley", "This item defies description.", new List<string>() { "a pure beefy patty above the mid-bun", "a slice of processed chicken product below the mid-bun", "pickles", "the secret ingredient." }, 5.99);
            var dryWhiteToast = new MenuItem("Dry White Toast", "This is just dry white toast.", new List<string>() { "No butter or jam - just dry toast." }, 1.98);
            var soylentGreen = new MenuItem("Soylent Green", "Soylent Green is people", new List<string>() { "people" }, 19.73);
            var escargot = new MenuItem("Escargot", "Slippery little suckers.", new List<string>() { "snails", "butter", "salt." }, 44.99);
            _menuItemsRepo.AddItemToMenu(nothingBurger);
            _menuItemsRepo.AddItemToMenu(panGalacticGargleBlaster);
            _menuItemsRepo.AddItemToMenu(doublemeatMedley);
            _menuItemsRepo.AddItemToMenu(dryWhiteToast);
            _menuItemsRepo.AddItemToMenu(soylentGreen);
            _menuItemsRepo.AddItemToMenu(escargot);            
        }
        private bool UIMenu()
        {
            Console.Clear();
            Console.WriteLine("Komodo Cafe Menu Management Application\n\n" +
                "Please select an option\n\n" +
                "1. View all menu items\n" +
                "2. Add a new menu item\n" +
                "3. View a menu item by number\n" +
                "4. Remove a menu item\n" +
                "0. Exit\n");

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayAllMenuItems();
                    break;
                case "2":
                    AddMenuItem();
                    break;
                case "3":
                    DisplayMenuItemByNumber();
                    break;
                case "4":
                    RemoveMenuItem();
                    break;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Please enter a valid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            return true;
        }

        private void DisplayAllMenuItems()
        {
            Console.Clear();
            var allMenuItems = _menuItemsRepo.GetMenuItems();

            Console.WriteLine("\nNumber:  Name:");
            foreach (var menuItem in allMenuItems)
            {
                DisplayMenuItem(menuItem);
            }
            Console.WriteLine();
        }

        private void DisplayMenuItem(MenuItem menuItem)
        {
            Console.WriteLine($"    {menuItem.NumberOfMenuItem}:   {menuItem.NameOfMenuItem}");
        }

        private void AddMenuItem()
        {
            Console.Clear();
            DisplayAllMenuItems();
            Console.WriteLine("Enter the name of the menu item to add.");
            string itemName = Console.ReadLine();

            Console.WriteLine("Enter the description of the menu item.");
            string itemDescription = Console.ReadLine();

            Console.WriteLine("Enter the ingredients of the menu item separated by commas.");
            List<string> itemIngredients = Console.ReadLine().Split(',').ToList();

            Console.WriteLine("Enter the price of the menu item.");
            string doubleAsString = Validation.DoubleFromStringValidation();
            double itemPrice = double.Parse(doubleAsString);

            MenuItem newMenuItem = new MenuItem(itemName, itemDescription, itemIngredients, itemPrice);
            _menuItemsRepo.AddItemToMenu(newMenuItem);
        }

        private void DisplayMenuItemByNumber()
        {
            Console.Clear();
            DisplayAllMenuItems();
            Console.WriteLine("Enter the number of the menu item to display.");
            string intAsString = Validation.IntFromStringValidation();
            int menuItemNumber = int.Parse(intAsString);
            MenuItem menuItem = _menuItemsRepo.GetMenuItemByNumber(menuItemNumber);
            if (menuItem == null)
            {
                Console.WriteLine("That is not an existing menu item.\n\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                DisplayMenuItemByNumber();
            }
            else
            {
                Console.WriteLine($"\nNumber: {menuItem.NumberOfMenuItem}\n" +
                $"Name: {menuItem.NameOfMenuItem}\n" +
                $"Description: {menuItem.DescriptionOfMenuItem}\n" +
                $"Price: ${menuItem.PriceOfMenuItem}");
                Console.Write("Ingredients: ");
                DisplayIngredients(menuItem);
                Console.WriteLine();
            }
        }

        private void RemoveMenuItem()
        {
            Console.Clear();
            DisplayAllMenuItems();
            Console.WriteLine("Enter the number of the menu item to remove\n");
            string intAsString = Validation.IntFromStringValidation();
            int menuItemNumber = int.Parse(intAsString);
            var menuItemToRemove = _menuItemsRepo.GetMenuItemByNumber(menuItemNumber);
            Console.Clear();

            if (_menuItemsRepo.RemoveMenuItem(menuItemNumber))
            {
                Console.WriteLine($"\n{menuItemToRemove.NameOfMenuItem} was successfully removed from the menu.");
            }
            else
            {
                Console.WriteLine("\nThe menu item could not be removed.\n\n" +
                    "Press any key to continue.");
                Console.ReadKey();
                UIMenu();
            }
        }
        //Display Ingredients Helper Method
        public void DisplayIngredients(MenuItem menuItem)
        {
            foreach (var ingredient in menuItem.ListOfIngredients)
            {
                Console.Write($"{ingredient}, ");
            }
            Console.WriteLine();
        }
    }
}
