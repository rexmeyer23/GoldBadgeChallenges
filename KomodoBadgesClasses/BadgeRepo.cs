﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgesClasses
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        //CRUD
        //CREATE - add a new badge to dictionary
        public bool CreateNewBadge(int badgeID, Badge badgeName)
        {
            int badgeList = _badgeDictionary.Count;
            _badgeDictionary.Add(badgeID, badgeName);

            bool addedBadge = _badgeDictionary.Count > badgeList ? true : false;
            return addedBadge;
        }
        //READ -  return list of badges with id numbers and door access
        public Dictionary<int, Badge> ListBadges()
        {
            return _badgeDictionary;
        }
        //UPDATE - updates an exisiting badge
        public bool UpdateDoorAccess(int existingBadge, Badge newBadge)
        {
            Badge oldBadge = RetrieveByID(existingBadge);
            if(oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.Doors = newBadge.Doors;
                oldBadge.BadgeName = newBadge.BadgeName;
                return true;
            }
            return false;
        }
        //DELETE
        public bool DeleteAllDoorsFromBadge(int badgeID, List<string> doors)
        {
            Badge badge = RetrieveByID(badgeID);
            if (badge != null)
            {
                badge.Doors.RemoveAll(doors);
                return true;
            }
            return false;
        }
        //HELPER
        public Badge RetrieveByID(int idNum)
        {
            if (_badgeDictionary.ContainsKey(idNum))
            {
                return _badgeDictionary[idNum];
            }
            return null;
        }
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
        public bool RemoveDoorFromBadge(int badgeID, string oldDoor)
        {
            Badge badge = RetrieveByID(badgeID);
            if(badge != null)
            {
                badge.Doors.Remove(oldDoor);
                return true;
            }
            return false;
        }
    }
}