using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    class ProgramUI
    {
        private readonly MenuContentRepository _menuRepo = new MenuContentRepository();
        //Method that runs / starts UI part of application
        public void Run()
        {
            SeedContent();
            Menu();
        }
        // Menu Method - should be private to make user run this
        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                //Display User Options to User
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View all Menu Items\n" +
                    "3. Delete Menu Content\n" +
                    "4. Exit");
                //Get User's Input
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateNewContent();
                        //create new content
                        break;
                    case "2":
                        //view all content
                        ShowAllContent();
                        break;
                    case "3":
                        RemoveContentFromList();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4 \n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
            //Evaluate the User's Input - act accordingly
        }
        private void CreateNewContent()
        {
            Console.WriteLine("Your current menu items:");
            ShowAllContent();
            MenuContent content = new MenuContent();
            Console.WriteLine("Please enter the number of the menu item:");
            // may have to get the array number and put in a string?
            string menuNumber = Console.ReadLine();
            content.MenuNumber = menuNumber;
            Console.WriteLine("Please enter the name of the menu item:");
            content.MenuName = Console.ReadLine();
            Console.WriteLine($"Please enter the description of the menu item number {content.MenuNumber}:");
            content.MenuDescription = Console.ReadLine();
            Console.WriteLine($"Please enter the list of ingredients for iten {content.MenuNumber}:");
            content.MenuListOfIngredients = Console.ReadLine();
            Console.WriteLine($"Please enter the menu item price for item {content.MenuNumber}:");
            content.MenuPrice = Console.ReadLine();
            //pass to add method
            _menuRepo.AddContentToDirectory(content);
        }
        private void ShowAllContent()
        {
            Console.Clear();
            List<MenuContent> listOfContent = _menuRepo.GetContents();
            //Display every items contents
            foreach (MenuContent content in listOfContent)
            {
                DisplaySimple(content);
            }
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();
        }
        
        private void RemoveContentFromList()
        {
            Console.WriteLine("Which item would you like to remove?");
            List<MenuContent> contentList = _menuRepo.GetContents();
            int count = 0;
            foreach(var content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.MenuNumber}");
            }
            int targetContentID = int.Parse(Console.ReadLine());
            int correctIndex = targetContentID - 1;
            if (correctIndex >= 0 && correctIndex < contentList.Count)
            {
                MenuContent desiredContent = contentList[correctIndex];
                if (_menuRepo.DeleteExistingContent(desiredContent))
                {
                    Console.WriteLine($"{ desiredContent.MenuNumber} successfully removed!");
                }
                else
                {
                    Console.WriteLine("Sorry, can't perform");
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        private void DisplaySimple(MenuContent content)
        {
            Console.WriteLine($"{content.MenuNumber}\n" +
                $"{content.MenuDescription}\n" +
                $"---------------------------");
        }
        private void SeedContent()
        {
            var menuOne = new MenuContent("1", "Pizza", "Thin crust cheese", "Crust, sauce, cheese", "12");
            var menuTwo = new MenuContent("2", "Salad", "Lettuce salad with vegetables", "lettuce, cucumbers", "10");
            _menuRepo.AddContentToDirectory(menuOne);
            _menuRepo.AddContentToDirectory(menuTwo);
        }
    }
}
