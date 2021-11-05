using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgesClasses
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        
        //CRUD
        //CREATE - add a new badge to dictionary
        public bool CreateNewBadge(Badge badge)
        {
            int badgeList = _badgeDictionary.Count;
            _badgeDictionary.Add(badge.BadgeID, badge.Doors);

            bool addedBadge = _badgeDictionary.Count > badgeList ? true : false;
            return addedBadge;
        }
        //READ -  return list of badges with id numbers and door access
        public Dictionary<int, List<string>> ListBadges()
        {
            return _badgeDictionary;
        }
        //UPDATE - updates an exisiting badge
        public bool AddDoorToBadge(int badgeID, string newDoor)
        {
            Badge badge = RetrieveByID(badgeID);
            if (badge != null)
            {
                badge.Doors.Add(newDoor);
                return true;
            }
            return false;
        }
        //DELETE - deletes all doors in a badge
        public bool DeleteAllDoorsFromBadge(int badgeID)
        {
            Badge badge = RetrieveByID(badgeID);
            if (badge!= null)
            {
                badge.Doors.Clear();
                return true;
            }
            return false;
        }
        //removes a single door from a badge
        public bool RemoveDoorFromBadge(int badgeID, string oldDoor)
        {
            Badge badge = RetrieveByID(badgeID);
            if (badge != null)
            {
                badge.Doors.Remove(oldDoor);
                return true;
            }
            return false;
        }
        //HELPER
        public Badge RetrieveByID(int idNum)
        {
            if (_badgeDictionary.ContainsKey(idNum))
            {
                Badge badge = new Badge();
                badge.Doors = _badgeDictionary[idNum];
                return badge;
            }
            return null;
        }
       
       
    }
}
