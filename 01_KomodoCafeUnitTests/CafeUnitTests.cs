using _01_KomodoCafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_KomodoCafeUnitTests
{
    [TestClass]
    public class CafeUnitTests
    {
        private MenuItemsRepo _repo;
        private MenuItem menuItem1;
        private MenuItem menuItem2;

        [TestInitialize]
        public void CafeTestsArrange()
        {
            _repo = new MenuItemsRepo();
            menuItem1 = new MenuItem("Doublemeat Medley", "This item defies description.", new List<string>() { "a pure beefy patty above the mid-bun, a slice of processed chicken product below the mid-bun, pickles, and the secret ingredient." }, 5.99);
            menuItem2 = new MenuItem("Pan Galactic Gargle Blaster", "Its effects are similar to 'having your brains smashed out by a slice of lemon wrapped round a large gold brick.'", new List<string>() { "one bottle of Ol' Janx Spirit, one measure of water from the seas of Santraginus V, three cubes of Arcturan Mega-gin, four litres of Fallian marsh gas, a measure of Qualactin Hypermint extract, the tooth of an Algolian Suntiger, a sprinkle of Zamphuor, an olive" }, 9.99);
            _repo.AddItemToMenu(menuItem1);
            _repo.AddItemToMenu(menuItem2);
        }

        //Create Menu Item method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            MenuItem menuItem = new MenuItem();
            menuItem.NameOfMenuItem = "Doublemeat Medley";
            MenuItemsRepo repository = new MenuItemsRepo();

            repository.AddItemToMenu(menuItem);
            MenuItem menuItemFromList = repository.GetMenuItemByNumber(1);

            Assert.IsNotNull(menuItemFromList);
        }

        [TestMethod]
        public void GetMenuItems_ShouldReturnMenuItems()
        {
            List<MenuItem> listFromRepo = _repo.GetMenuItems();
            Assert.IsNotNull(listFromRepo);
        }

        [TestMethod]
        public void TestGetMenuItemByID()
        {
            MenuItem menuItemByID = _repo.GetMenuItemByNumber(menuItem1.NumberOfMenuItem);
            bool itemNamesAreEqual = menuItem1.NameOfMenuItem == menuItemByID.NameOfMenuItem;
            Assert.IsTrue(itemNamesAreEqual);
        }
        [TestMethod]
        public void TestRemoveMenuItem()
        {
            bool deleteResult = _repo.RemoveMenuItem(menuItem1.NumberOfMenuItem);
            Assert.IsTrue(deleteResult);
        }
    }
}
