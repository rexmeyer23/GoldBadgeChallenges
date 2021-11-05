using KomodoOutingsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsConsole
{
    class ProgramUI
    {
        private readonly OutingRepo _outingRepo = new OutingRepo();

        public void Run()
        {
            OutingList();
            Menu();
        }
        public void Menu()
        {
            bool runningProgram = true;
            while (runningProgram)
            {
                Console.WriteLine("Komodo Outings\n" +
                    "Please select one of the following options:\n" +
                    "1. Display All Outings\n" +
                    "2. Add Outing to List\n" +
                    "3. Calculations\n" +
                    "4. Exit");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        ShowAllOutings();
                        break;
                    case 2:
                        AddOutingToList();
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        runningProgram = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //option 1: display all outings
        private void ShowAllOutings()
        {
            Console.Clear();
            List<Outing> listOutings = _outingRepo.ListOutings();
            foreach (Outing outing in listOutings)
            {
                DisplayOutings(outing);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.Clear();
        }
        private void DisplayOutings(Outing outing)
        {
            Console.WriteLine($"Event Type: {outing.EventType}\n" +
                $"Number of Attendees: {outing.NumberOfAttendees}\n" +
                $"Date: {outing.DateOfOuting: MM/dd/yyyy}\n" +
                $"Total Cost per Person: ${outing.CostPerPerson}\n" +
                $"Total Cost for Event ${outing.CostOfEvent}");
        }
        private void OutingList()
        {
            _outingRepo.CreateOuting(new Outing(EventType.Amusement_Park, 47, new DateTime(2020, 7, 22), 60, 4000));
            _outingRepo.CreateOuting(new Outing(EventType.Concert, 6, new DateTime(2019, 3, 15), 150, 1000));
            _outingRepo.CreateOuting(new Outing(EventType.Golf, 12, new DateTime(2019, 10, 3), 30, 600));
            _outingRepo.CreateOuting(new Outing(EventType.Bowling, 4, new DateTime(2021, 11, 19), 15, 300));
        }
        //option 2: add outing to list
        private void AddOutingToList()
        {
            Outing outing = new Outing();
            Console.WriteLine("Please select the type of event(1-4)\n" + "1. Golf\n" + "2. Bowling\n" + "3. Amusement Park\n" + "4. Concert\n");
            bool runningOption = true;
            while (runningOption)
            {
                string eventType = Console.ReadLine().ToLower();
                switch (eventType)
                {
                    case "1":
                    case "golf":
                        outing.EventType = EventType.Golf;
                        runningOption = false;
                        break;
                    case "2":
                    case "bowling":
                        outing.EventType = EventType.Bowling;
                        runningOption = false;
                        break;
                    case "3":
                    case "amusement park":
                        outing.EventType = EventType.Amusement_Park;
                        runningOption = false;
                        break;
                    case "4":
                    case "concert":
                        outing.EventType = EventType.Concert;
                        runningOption = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }
            Console.Write("Please enter the number of people attending the event: ");
            bool numberOfPeople = true;
            while (numberOfPeople)
            {
                string people = Console.ReadLine();
                try
                {
                    outing.NumberOfAttendees = int.Parse(people);
                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            Console.WriteLine("Please enter the date of the event\n" +
                "Make sure it replicates the format below\n" +
                "MM/DD/YYYY\n" +
                "ex: 03/04/1998");
            bool date = true;
            while (date)
            {
                try
                {
                    outing.DateOfOuting = DateTime.Parse(Console.ReadLine());
                    date = false;
                }
                catch
                {
                    Console.WriteLine("Please enter in correct format. MM/DD/YYYY");

                }
            }
            Console.WriteLine("Please enter the cost per person: ");
            bool cost = true;
            while (cost)
            {
                try
                {
                    outing.CostPerPerson = Convert.ToDecimal(Console.ReadLine());
                    cost = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            Console.WriteLine("Please enter the cost of the event: ");
            bool costEvent = true;
            while (costEvent)
            {
                try
                {
                    outing.CostOfEvent = Convert.ToDecimal(Console.ReadLine());
                    costEvent = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            DisplayOutings(outing);
            Console.WriteLine("You have added a new outing to the list.");
            Console.ReadKey();
            _outingRepo.CreateOuting(outing);
            Console.Clear();
            ShowAllOutings();
        }
    }
}
