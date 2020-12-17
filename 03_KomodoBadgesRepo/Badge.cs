using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadgesRepo
{
    public class Badge
    {
        public int BadgeID { get; set; }

        public List<string> ListOfDoors { get; set; } = new List<string>();

        public Badge (List<string> listOfDoors)
        {            
            ListOfDoors = listOfDoors;
        }
        public Badge()
        {

        }
    }
}
