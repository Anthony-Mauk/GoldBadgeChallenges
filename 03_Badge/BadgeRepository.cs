using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge
{
    public class BadgeRepository
    {
        //Dictionary<string, List<string>> _dictionary = new Dictionary<string, List<string>>();
        //Create new list of doors by badge
        protected readonly List<Badge> _badgeList = new List<Badge>();
        public bool AddDoorToBadge(Badge badge)
        {
            int startingCount = _badgeList.Count;
            _badgeList.Add(badge);
            bool wasAdded = (_badgeList.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read all list of doors by badge
        public List<Badge> GetBadges()
        {
            return _badgeList; //_dictionary
        }
        //Update list of doors by badge - next when figure out dictionary and list as property...
        //Get Badge by ID
        public Badge GetBadgeByID(string id)
        {
            foreach(Badge singleBadge in _badgeList)
            {
                if(singleBadge.BadgeID.ToLower() == id.ToLower())
                {
                    return singleBadge;
                }
            }
            return null;
        }
        public bool UpdateExistingBadge(string originalBadge, Badge newBadge)
        {
            Badge oldbadge = GetBadgeByID(originalBadge);
            if(oldbadge != null)
            {
                oldbadge.BadgeID = newBadge.BadgeID;
                oldbadge.DoorAccess = newBadge.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteExistingBadge(Badge existingBadge)
        {
            bool deleteResult = _badgeList.Remove(existingBadge);
            return deleteResult;
        }

        //12345 A7
        //22345 A1, A4, B1, B2
        //32345 A4, A5
        //Dictionaries 
        //Dictionary<int, string> keyAndValue = new Dictionary<int, string>();
        //keyAndValue.Add(7,"Agent");
        //    string valueSeven = keyAndValue[7];
        //Console.WriteLine(valueSeven);
    }
}
