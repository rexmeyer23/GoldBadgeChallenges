using KomodoBadgesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            BadgesDictionary();
            RunMenu();

        }
        public void RunMenu()
        {
            bool runProgram = true;
            while (runProgram)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin,\n" +
                    "What would you like to do?\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        EditBadge();
                        break;
                    case 3:
                        ShowAllBadges();
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;

                }
            }
        }
        //option 1: add a badge
        public void AddBadge()
        {
            Badge newBadge = new Badge();
            Console.WriteLine("Enter the name you want give this badge.");
            newBadge.BadgeName = Console.ReadLine();
            Console.WriteLine("What is the number of the badge?");
            bool enteringBadgeNum = true;
            while (enteringBadgeNum)
            {
                int userInput;
                bool parsedSuccessfully = int.TryParse(Console.ReadLine(), out userInput);
                if (parsedSuccessfully != true)
                {
                    Console.WriteLine("Please enter a valid number");
                }
                else
                {
                    newBadge.BadgeID = userInput;
                    Console.Write("List a door that it needs access to: ");
                    List<string> doors = new List<string>();
                    doors.Add(Console.ReadLine());
                    newBadge.Doors = doors;
                    bool enteringDoor = true;
                    while (enteringDoor)
                    {
                        Console.WriteLine("Any other doors?(y/n)");
                        string decision = Console.ReadLine().ToLower();
                        if (decision == "n" || decision == "no")
                        {
                            Console.WriteLine("Press any key to go back to the main menu...");
                            Console.ReadKey();
                            enteringDoor = false;
                        }
                        else if (decision == "y" || decision == "yes")
                        {
                            Console.Write("List a door that it needs access to: ");
                            doors.Add(Console.ReadLine());
                            newBadge.Doors = doors;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option.");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }
                    _badgeRepo.CreateNewBadge(newBadge);
                    Console.WriteLine($"Congratulations!\n" +
                        $"The badge {newBadge.BadgeName} with an ID of {newBadge.BadgeID} has been created! ");
                    Console.ReadKey();
                    enteringBadgeNum = false;
                }
            }



        }
        //option 2: edit a badge
        public void EditBadge()
        {
            //Dictionary<int, List<string>> badges = new Dictionary<int, List<string>>();
            Console.WriteLine("What is the badge number you want to update?");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            Badge updatingBadge = _badgeRepo.RetrieveByID(badgeID);
            if (updatingBadge != null)
            {
                Console.WriteLine($"{badgeID} has access to doors {string.Join(",", updatingBadge.Doors)}");
                Console.ReadKey();
                bool runningOptions = true;
                while (runningOptions)
                {
                    //List<string> doors = new List<string>();
                    Console.WriteLine("What would you like to do?\n" +
                        "1. Remove a door\n" +
                        "2. Add a door\n" +
                        "3. Remove all doors\n" +
                        "4. Exit");
                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.Write($"{string.Join(",", updatingBadge.Doors)}\n" +
                                $"Which door would you like to remove? ");
                            string removeDoor = Console.ReadLine();
                            Console.WriteLine("Door removed.");
                            _badgeRepo.RemoveDoorFromBadge(badgeID, removeDoor);
                            Console.ReadLine();
                            ShowAllBadges();
                            break;
                        case 2:
                            Console.Write("Which door would you like to add?");
                            string addDoor = Console.ReadLine();
                            Console.WriteLine("Door added.");
                            _badgeRepo.AddDoorToBadge(badgeID, addDoor);
                            Console.ReadLine();
                            ShowAllBadges();
                            break;
                        case 3:
                            Console.WriteLine($"{badgeID} has access to doors {string.Join(", ", updatingBadge.Doors)}\n" +
                                $"Would you like to remove all doors from {badgeID}?(y/n)");
                            bool decision = true;
                            while (decision)
                            {
                                string answer = Console.ReadLine().ToLower();
                                if (answer == "y" || answer == "yes")
                                {
                                    _badgeRepo.DeleteAllDoorsFromBadge(badgeID);
                                    Console.WriteLine($"Doors have all been removed from {badgeID}");
                                    Console.ReadLine();
                                    Console.Clear();
                                    ShowAllBadges();
                                    decision = false;
                                }
                                else if (answer == "n" || answer == "yes")
                                {
                                    Console.WriteLine($"Doors remain in {badgeID}");
                                    Console.ReadLine();
                                    decision = false;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid option.");
                                }
                                runningOptions = false;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Goodbye!");
                            Console.ReadLine();
                            runningOptions = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Badge not found.\n" +
                    "Press any key to exit...");
                Console.ReadKey();

            }

        }
        //option 3: view all badges
        public void ShowAllBadges()
        {
            Dictionary<int, List<string>> badges = _badgeRepo.ListBadges();
            Badge badgeName = new Badge();
            string[] badgeTitles = { "BadgeID", "Door Access", "BadgeName" };
            Console.WriteLine($"{badgeTitles[0],-10}{badgeTitles[1],-10}{badgeTitles[2],10}");
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {

                Console.WriteLine($"{badge.Key,-10}{string.Join(", ", badge.Value)}{badgeName.BadgeName,10}");
                Console.WriteLine("----------------");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }
        public void BadgesDictionary()
        {
            _badgeRepo.CreateNewBadge(new Badge(12345, new List<string> { "A7" }, "Numero Uno"));
            _badgeRepo.CreateNewBadge(new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" }, "Tenacity"));
            _badgeRepo.CreateNewBadge(new Badge(32345, new List<string> { "A4", "A5" }, "A_Bomb"));
        }

    }
}
