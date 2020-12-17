using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadgesRepo
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        private int _badgeIdCounter = 0;

        //Badge Create
        public void AddBadgeToDictionary(Badge badge)
        {
            badge.BadgeID = _badgeIdCounter + 1;
            _badgeDictionary.Add(badge.BadgeID, badge);
            _badgeIdCounter++;
        }
        //Read all badges
        public Dictionary<int, Badge> GetAllBadges()
        {
            return _badgeDictionary;
        }
        // Get badge by ID - helper
        public Badge GetBadgeByID(int badgeID)
        {           
            foreach (KeyValuePair<int, Badge> keyValuePair in _badgeDictionary)
            {
                int key = keyValuePair.Key;
                Badge value = keyValuePair.Value;
                if (badgeID == key)
                {
                    return value;
                }                
            }
            return null;
        }
        //Update Badge - List of Doors
        public bool UpdateBadge(int badgeID, List<string> newListOfDoors)
        {
            Badge existingBadge = GetBadgeByID(badgeID);
            if (existingBadge != null)
            {
                existingBadge.ListOfDoors = newListOfDoors;
                return true;
            }
            return false;
        }
        public bool RemoveAllDoors(int badgeID)
        {
            Badge existingBadge = GetBadgeByID(badgeID);
            if (existingBadge != null)
            {
                existingBadge.ListOfDoors.Clear();                
                return true;
            }
            return false;
        }        
    }
}
