using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge
{
    public class Badge
    {
        public string BadgeID { get; set; }
        //public List<string> DoorNames { get; set; }
        public string DoorAccess { get; set; }

        public Badge() { }
        //public Badge(string badgeID, List<string> doorNames)
        public Badge(string badgeID, string doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;
            //DoorNames = doorNames;
        }
    }
  
}

