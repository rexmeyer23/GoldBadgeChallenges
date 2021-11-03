using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgesClasses
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public  List<string> Doors { get; set; }
        public string BadgeName { get; set; }
        public Badge() { }
        public Badge (int badgeID, List<string> doors, string badgeName)
        {
            BadgeID = badgeID;
            Doors = doors;
            BadgeName = badgeName;
        }

    }
}
