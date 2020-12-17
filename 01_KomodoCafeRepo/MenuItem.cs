using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeRepo
{
    /*If doing this at the complexity of the DevTeams project, I could make meals with various combos of menu items.*/
    public class MenuItem
    {
        public int NumberOfMenuItem { get; set; }
        public string NameOfMenuItem { get; set; }
        public string DescriptionOfMenuItem { get; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>();
        public double PriceOfMenuItem { get; set; }

        public MenuItem(string name, string description, List<string> ingredients, double price)
        {            
            NameOfMenuItem = name;
            DescriptionOfMenuItem = description;
            ListOfIngredients = ingredients;
            PriceOfMenuItem = price;
        }
        public MenuItem()
        {

        }
    }
}
