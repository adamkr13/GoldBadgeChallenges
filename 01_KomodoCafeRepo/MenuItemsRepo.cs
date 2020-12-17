using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeRepo
{
    public class MenuItemsRepo
    {
        private readonly List<MenuItem> _menuItems = new List<MenuItem>();
        private int _numberOfMenuItemCounter = 0;

        //Create Menu Item
        public void AddItemToMenu(MenuItem menuItem)
        {
            menuItem.NumberOfMenuItem = _numberOfMenuItemCounter + 1;
            _menuItems.Add(menuItem);
            _numberOfMenuItemCounter++;
        }

        //Read Menu Items
        public List<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }
        //Read full menu item by number
        //Helper
        public  MenuItem GetMenuItemByNumber(int number)
        {
            foreach (MenuItem menuItem in _menuItems)
            {
                if (menuItem.NumberOfMenuItem == number)
                {
                    return menuItem;
                }                
            }
            return null;
        }
        //Delete Menu Items
        public bool RemoveMenuItem (int menuItemNumber)
        {
            MenuItem menuItem = GetMenuItemByNumber(menuItemNumber);
            if (_menuItems.Remove(menuItem))
            {
                return true;
            }
            return false;
        }
    }
}
