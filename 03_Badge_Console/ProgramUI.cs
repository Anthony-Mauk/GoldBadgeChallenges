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
        private readonly BadgeRepository _badgeRepo = new BadgeRepository(); // gives access to methods

        public void Run()
        {
            _badgeRepo.AddSeedBadgesToDictionary();  //seed inital dictionary and badge assignment
            RunMenu();  //Run the UI menu
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
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
                        _badgeRepo.AddABadge();
                        break;
                    case "2":
                        _badgeRepo.UpdateABadge();
                        break;
                    case "3":
                        _badgeRepo.DisplayAllBadgesProps();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4. \n" +
                            "Press any key to continue......");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
