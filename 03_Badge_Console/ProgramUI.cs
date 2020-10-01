using _03_Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Console
{
    class ProgramUI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                //create a new badge
                //update doors on an existing badge
                //delete all doors from an existing badge
                //show a list with all badge number and door access

                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                    "1) Add a badge \n" +
                    "2) Edit a badge \n" +
                    "3) List all Badges\n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Case 1");
                        AddABadge();
                        break;
                    case "2":
                        Console.WriteLine("Case 2");
                        UpdateABadge();
                        break;
                    case "3":
                        Console.WriteLine("Case 3");
                        ReadAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue......");
                        Console.ReadKey();
                        break;
                }
            }

        }
        public void AddABadge()
        {
            Console.WriteLine("What is the number on the badge:");
            string badgeNumber = Console.ReadLine();

            bool continueToAsk = true;
            while (continueToAsk)
            {
                Console.WriteLine("List a door that it needs access to:");
                string doorAccess = Console.ReadLine();

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
        }
        public void UpdateABadge()
        {
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
        public void ReadAllBadges()
        {
            Console.WriteLine("Here are the list of badges:");
            Console.WriteLine("Badge#" + "Door Access");
            Console.WriteLine("Need to list the Badge and Door Access HERE");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void SeedContent()
        {
            var badgeOne = new Badge("12345", "A7");// (id, listOfRooms) new List<string> 
            var badgeTwo = new Badge("22345", "A1");
            var badgeThree = new Badge("32345", "A4");
            _badgeRepo.AddDoorToBadge(badgeOne);
            _badgeRepo.AddDoorToBadge(badgeTwo);
            _badgeRepo.AddDoorToBadge(badgeThree);

            //var badgeOne = new Dictionary
            //dictionary["12345"] = new List<string> { "A7" };
            //dictionary["22345"] = new List<string> { "A1", "A4", "B1", "B2" };
            //dictionary["32345"] = new List<string> { "A4", "A5" };
            //

        }
    }
}
