using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _03_Badge
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();
        protected readonly List<Badge> _badgeList = new List<Badge>();

        public void AddSeedBadgesToDictionary()
        {
            //bring in key and value and add to dictionary
            var badgeOne = new Badge(12345, new List<string> { "A7" });
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
            Console.WriteLine("Here are the list of badges:");
            Console.WriteLine
               ("{0,-7} {1,-5}", "Badge#", "Door Access");
            
            foreach (var value in _dictionary)
            {
                string output = "";
                foreach (var item in value.Value)
                {
                    output += item + ", ";
                }
                Console.WriteLine("{0, -7} {1, -5}",
                    value.Key, output);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void UpdateABadge()
        {
            Console.Clear();
            DisplayAllBadgesProps();

            List<string> doorListToUpdate = new List<string>();

            string output = "";
            Console.WriteLine("What is badge number to update?");
            int badgeIDInput = Int32.Parse(Console.ReadLine());

            if (_dictionary.ContainsKey(badgeIDInput))
            {

                foreach (var value in _dictionary)
                {
                    if (value.Key == badgeIDInput)
                    {
                        foreach (var item in value.Value)
                        {
                            output += item + ", ";
                        }
                        Console.WriteLine("{0,-7} {1,-5}", "Badge#", "Door Access");
                        Console.WriteLine("{0, -7} {1, -5}",
                            value.Key, output);
                    }

                }
                //output += badgeIDInput;
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("      1. Remove a door");
                Console.WriteLine("      2. Add a door");

                string response = Console.ReadLine();
                if (response == "1")
                {
                    Console.WriteLine("Which door would you like to remove?");
                    string doorToRemove = Console.ReadLine();
                    //set new list to dictionary list
                    foreach (var kvp in _dictionary)
                    {
                        if (kvp.Key == badgeIDInput)
                        {
                            List<string> doors = _dictionary[badgeIDInput];
                            doors.Remove(doorToRemove);
                        }

                    }

                    // Console.WriteLine($"Door:" + "{}" + "has access to" + "{}");
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();
                }
                else if (response == "2")
                {
                    Console.WriteLine("Which door would you like to add?");
                    string doorToAdd = Console.ReadLine();

                    //set new list to dictionary list
                    foreach (var kvp in _dictionary)
                    {
                        if (kvp.Key == badgeIDInput)
                        {
                            List<string> doors = _dictionary[badgeIDInput];
                            doors.Add(doorToAdd);
                            //change to int before adding to dictionary
                           // _dictionary.Add(doors, doorToAdd);
                        }

                    }
                    //Console.WriteLine($"Door:" + "{}" + "has access to" + "{}");
                    //Console.ReadKey();

                   //Console.WriteLine("Add the door to the current list");
                    //Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You've entered an invalid option");
                    Console.ReadKey();

                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

            }
        }
    }
}
