using _00_ValidationMethods;
using _03_KomodoBadgesRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadgesConsole
{
    class BadgesUI
    {
        private BadgeRepo _badgeDictionary = new BadgeRepo();

        public void Run()
        {
            SeedData();
            while (Menu())
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Goodbye!\n" +
                "Press any key to exit...");
            Console.ReadKey();
        }
        private void SeedData()
        {
            var alexanderKey = new Badge(new List<string>() { "The Forgotten Door" });
            var robertHeinlein = new Badge(new List<string>() { "The Door into Summer" });
            var georgeMartin = new Badge(new List<string>() { "Hodoor" });
            var madelineLengle = new Badge(new List<string>() { "A Wind in the Door" });
            var epicFantasy = new Badge(new List<string>() { "Hodoor", "The Doors of Durin", "The Silver Door" });
            var scienceFiction = new Badge(new List<string>() { "The Forgotten Door", "A Wind in the Door", "The Door into Summer" });
            _badgeDictionary.AddBadgeToDictionary(alexanderKey);
            _badgeDictionary.AddBadgeToDictionary(robertHeinlein);
            _badgeDictionary.AddBadgeToDictionary(georgeMartin);
            _badgeDictionary.AddBadgeToDictionary(madelineLengle);
            _badgeDictionary.AddBadgeToDictionary(epicFantasy);
            _badgeDictionary.AddBadgeToDictionary(scienceFiction);
        }
        private bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin. What would you like to do?\n\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all badges\n" +
                "4. Remove all door access from a badge\n" +
                "5. Show one badge\n" +
                "0. Exit\n\n");

            switch (Console.ReadLine())
            {
                case "1":
                    AddBadge();
                    break;
                case "2":
                    UpdateTheBadge();
                    break;
                case "3":
                    FlashAllBadges();
                    break;
                case "4":
                    RemoveAllDoors();
                    break;
                case "5":
                    FlashOneBadge();
                    break;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
            return true;
        }
        private void FlashAllBadges()
        {
            Console.Clear();
            var allBadges = _badgeDictionary.GetAllBadges();
            Console.WriteLine("BadgeID\t\tAccess Doors");

            foreach (KeyValuePair<int, Badge> keyValuePair in allBadges)
            {
                int key = keyValuePair.Key;
                Badge value = keyValuePair.Value;
                Console.Write($"\n{key}\t\t");
                foreach (string door in value.ListOfDoors)
                {
                    Console.Write($"{door}, ");
                }
            }
            Console.WriteLine("\n");
        }
        private void FlashOneBadge()
        {
            Badge badge = ReturnOneBadge();

            if (badge == null)
            {
                Console.WriteLine("That is not an existing badge.\n\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                FlashOneBadge();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("BadgeID\t\tAccess Doors");
                Console.Write($"\n{badge.BadgeID}\t\t");

                foreach (string door in badge.ListOfDoors)
                {
                    Console.Write($"{door}, ");
                }
                Console.WriteLine("\n");
            }
        }

        private void AddBadge()
        {
            FlashAllBadges();
            Console.WriteLine("Please enter all of the doors that the new badge will have access to\n" +
                "separated by a comma and with no added spaces between doors\n" +
                "Example: (Door1,The Red Door,Door2,Door3...)\n");
            List<string> listOfDoors = Console.ReadLine().Split(',').ToList();

            Badge badge = new Badge(listOfDoors);
            _badgeDictionary.AddBadgeToDictionary(badge);
        }

        //UpdateBadge not completed
        private void UpdateTheBadge()
        {
            Badge badge = ReturnOneBadge();
            Console.Clear();
            FlashAllBadges();
            Console.WriteLine($"Please enter all of the doors that Badge # {badge.BadgeID} will have access to\n(including those that the badge currently has access to)\n" +
                "separated by a comma and with no added spaces between doors\n" +
                "Example: (Door1,The Red Door,Door2,Door3...)\n");
            List<string> newListOfDoors = Console.ReadLine().Split(',').ToList();

            _badgeDictionary.UpdateBadge(badge.BadgeID, newListOfDoors);
        }
        private void RemoveAllDoors()
        {
            FlashAllBadges();
            Console.WriteLine("Enter the badge number from which to remove all door access:");
            string intAsString = Validation.IntFromStringValidation();
            int badgeID = int.Parse(intAsString);
            _badgeDictionary.RemoveAllDoors(badgeID);
        }
        private Badge ReturnOneBadge()
        {
            FlashAllBadges();
            Console.WriteLine("Enter the badge number you would like to view/update");
            string intAsString = Validation.IntFromStringValidation();
            int badgeID = int.Parse(intAsString);
            return _badgeDictionary.GetBadgeByID(badgeID);
        }
    }
}
