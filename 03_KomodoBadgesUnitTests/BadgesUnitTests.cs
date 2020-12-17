using _03_KomodoBadgesRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_KomodoBadgesUnitTests
{
    [TestClass]
    public class BadgesUnitTests
    {
        private BadgeRepo _badgeDictionary;
        private Badge _entry1;
        private Badge _entry2;

        [TestInitialize]
        public void BadgesTestsArrange()
        {
            _badgeDictionary = new BadgeRepo();
            _entry1 = new Badge(new List<string>() { "Hodoor", "The Doors of Durin", "The Silver Door" });
            _entry2 = new Badge(new List<string>() { "The Forgotten Door", "A Wind in the Door", "The Door into Summer" });
            
            _badgeDictionary.AddBadgeToDictionary(_entry1);
            _badgeDictionary.AddBadgeToDictionary(_entry2);
        }
        [TestMethod]
        public void TestForAddingBadge()
        {
            var entry3 = new Badge(new List<string>() { "Hodoor" });
            int initail =_badgeDictionary.GetAllBadges().Count;

            _badgeDictionary.AddBadgeToDictionary(entry3);

            int final = _badgeDictionary.GetAllBadges().Count;
            Assert.AreNotEqual(initail, final);
        }
        [TestMethod]
        public void TestGetAllBadges()
        {
            var dictionaryFromRepo = _badgeDictionary.GetAllBadges();
            Assert.IsNotNull(dictionaryFromRepo);
        }
        [TestMethod]
        public void TestGetBadgeByID()
        {
            Badge badgeByID = _badgeDictionary.GetBadgeByID(1);
            Assert.AreEqual(badgeByID, _entry1);
            
        }
        [TestMethod]
        public void TestUpdateBadge()
        {
            var newDoors = new List<string>();
            newDoors.Add("The Forgotten Door");
            newDoors.Add("Hodoor");

            bool updateResult = _badgeDictionary.UpdateBadge(1, newDoors);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void TestRemoveAllDoors()
        {
            int starting = _badgeDictionary.GetBadgeByID(1).ListOfDoors.Count;

            _badgeDictionary.RemoveAllDoors(1);

            int ending = _badgeDictionary.GetBadgeByID(1).ListOfDoors.Count;
            Assert.AreEqual(0, ending);
            Assert.AreNotEqual(starting, ending);
        }
    }
}
