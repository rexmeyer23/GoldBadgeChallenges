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
                    enteringBadgeNum = false;
                }
            }
            Console.Write("List a door that it needs access to: ");
            List<string> doors = new List<string>();
                Console.ReadLine();
            Console.WriteLine("Any other doors?(y/n)");

        }
        //option 3: view all badges
        public void ShowAllBadges()
        {
            Dictionary<int, List<string>> badges = _badgeRepo.ListBadges();
            string[] badgeTitles = { "BadgeID", "Door Access", "BadgeName" };
            Console.WriteLine($"{badgeTitles[0],-10}{badgeTitles[1],-10}{badgeTitles[2],10}");
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {

                Console.WriteLine($"{badge.Key,-10}{string.Join(", ", badge.Value)}");
                Console.WriteLine("----------------");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        public void BadgesDictionary()
        {
            _badgeRepo.CreateNewBadge(new Badge(12345, new List<string> { "A7" }, "Numero Uno"));
            _badgeRepo.CreateNewBadge(new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" }, "Tenacity"));
            _badgeRepo.CreateNewBadge(new Badge(32345, new List<string> { "A4", "A5" }, "A_Bomb"));
        }

    }
}
