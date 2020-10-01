using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();
        protected readonly List<Badge> _badgeList = new List<Badge>();
        
        public void AddSeedBadgesToDictionary()
        {
            //bring in key and value and add to dictionary
           
            var badgeOne = new Badge(12345, new List<string> { "A7" });// (id, listOfRooms) new List<string> 
            var badgeTwo = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            var badgeThree = new Badge(32345, new List<string> { "A4", "A5" });
            _badgeList.Add(badgeOne);
            _badgeList.Add(badgeTwo);
            _badgeList.Add(badgeThree);
            _dictionary.Add(badgeOne.BadgeID, badgeOne.DoorNames);
            _dictionary.Add(badgeTwo.BadgeID, badgeTwo.DoorNames);
            _dictionary.Add(badgeThree.BadgeID, badgeThree.DoorNames);

        }
        public void AddABadge()
        {
            Console.WriteLine("What is the number on the badge:");
            string badgeNumber = Console.ReadLine();
            Badge badge = new Badge();
            List<string> doorList = new List<string>();
            badge.BadgeID = Int32.Parse(badgeNumber);
            bool continueToAsk = true;
            while (continueToAsk)
            {
                Console.WriteLine("List a door that it needs access to:");
                string doorAccess = Console.ReadLine();
                doorList.Add(doorAccess);

                //create local list, then add to the property
                Console.WriteLine("Any other doors - anwer (y/n)");
                string response = Console.ReadLine();
                if (response == "n")
                {
                    continueToAsk = false;
                    Console.WriteLine("(Return to Main Menu) Press any key to continue");
                    Console.ReadKey();
                }
            }
            badge.DoorNames = doorList;
            _dictionary.Add(badge.BadgeID, badge.DoorNames);
        }

        
        public void DisplayAllBadgesProps()
        {
            //Read all list of doors by badge
            //Key
            //Badge #	Door Access
            //12345   A7
            //22345   A1, A4, B1, B2
            //32345   A4, A5
            Console.WriteLine("Here are the list of badges:");
            Console.WriteLine
               ("{0,-7} {1,-5}","Badge#", "Door Access");
            
            foreach (var value in _dictionary)
            {
                Console.WriteLine(value.Key);
                foreach (var item in value.Value)
                    Console.WriteLine(item);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public Badge GetBadgeByID(int id)
        {
            foreach (Badge singleBadge in _badgeList)
            {
                if (singleBadge.BadgeID == id)
                {
                    return singleBadge;
                }
            }
            return null;
        }
        public void UpdateABadge()
        {
            //#2 Update a badge
            //What is the badge number to update ? 12345
            //12345 has access to doors A5 & A7.
            //What would you like to do?
            //Remove a door
            //Add a door
            //> 1
            //Which door would you like to remove? A5
            //Door removed.
            //12345 has access to door A7.

            Console.WriteLine("What is badge number to update?");
            string badgeNumber = Console.ReadLine();

            //Get the list for the badge
            Console.WriteLine("Badge /*insert badge number */ has access to doors:" + "Put in doors");
            Console.WriteLine($"What would you like to do? \n" +
                "1. Remove a door\n" +
                "2. Add a door \n");
            string response = Console.ReadLine();
            if (response == "1")
            {
                Console.WriteLine("Which door would you like to remove?");
                Console.WriteLine("Remove the door at this point");
                Console.WriteLine("Door Removed");
                Console.WriteLine($"Door:" + "{}" + "has access to" + "{}");
                Console.ReadKey();
            }
            else if (response == "2")
            {
                Console.WriteLine("Which door would you like to add?");
                Console.WriteLine("Add the door at this point");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You've entered an invalid option");
                Console.ReadKey();
            }

        }

        //Dictionaries 
        //Dictionary<int, string> keyAndValue = new Dictionary<int, string>();
        //keyAndValue.Add(7,"Agent");
        //    string valueSeven = keyAndValue[7];
        //Console.WriteLine(valueSeven);
    }
}
