using _04_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Console
{
    internal class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();

        public ProgramUI()
        {

        }

        public void Run()
        {
            _outingRepo.SeedList();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Please enter the number of the menu item you would like to see: \n" +
                    "1. Display All Outings\n" +
                    "2. Add Outing to List\n" +
                    "3. See Event Costs\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        DisplayAllOutings();
                        break;
                    case "2":
                        AddOutingToList();
                        break;
                    case "3":
                        EventCosts();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }

        public void DisplayAllOutings()
        {
            List<Outing> outingList = _outingRepo.GetOutingList();

            foreach (Outing outing in outingList)
            {
                Console.WriteLine($"Event type: {outing.Category}, Number attended: {outing.NumberAttended}, Event date: {outing.EventDate}, Total cost: {outing.TotalCostEvent}, Cost per person: {outing.TotalCostPerPerson}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void AddOutingToList()
        {
            Console.WriteLine("Enter the number of the event type: \n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            string categoryAsString = Console.ReadLine();
            int categoryAsInt = int.Parse(categoryAsString);
            EventCategory category = (EventCategory)categoryAsInt;
            Console.Clear();

            Console.WriteLine("How many people attended?\n");
            string numberAttendedAsString = Console.ReadLine();
            int numberAttended = int.Parse(numberAttendedAsString);
            Console.Clear();

            Console.WriteLine("When was the event held (mm/dd/yyyy)?\n");
            string eventDateAsString = Console.ReadLine();
            DateTime eventDate = DateTime.Parse(eventDateAsString);
            Console.Clear();

            Console.WriteLine("What was the total cost of the event?\n");
            string totalCostEventAsString = Console.ReadLine();
            decimal totalCostEvent = decimal.Parse(totalCostEventAsString);
            Console.Clear();

            Outing outing = new Outing(category, numberAttended, eventDate, totalCostEvent);
            _outingRepo.AddToList(outing);
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
        }

        public void EventCosts()
        {
            Console.WriteLine("Enter the number of the costs you would like to see: \n" +
                "1. Combined cost of all outings\n" +
                "2. Outing cost by type\n" +
                "3. Return to menu\n");

            string userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    CombinedCostsAllEvents();
                    break;
                case "2":
                    CombinedCostByType();
                    break;
                case "3":
                    break;
            }
        }

        public void CombinedCostsAllEvents()
        {
            List<Outing> outingList = _outingRepo.GetOutingList();

            decimal cost = outingList.Sum(outing => outing.TotalCostEvent);
           
            Console.WriteLine($"The combined total cost is {cost}\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void CombinedCostByType()
        {
            Console.WriteLine("Enter the number of the outing type you would like to see the cost of: \n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");

            string userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    CombinedCostByCategory((EventCategory)int.Parse(userInput));
                    break;
                case "2":
                    CombinedCostByCategory((EventCategory)int.Parse(userInput));
                    break;
                case "3":
                    CombinedCostByCategory((EventCategory)int.Parse(userInput));
                    break;
                case "4":
                    CombinedCostByCategory((EventCategory)int.Parse(userInput));
                    break;
            }
        }

        public void CombinedCostByCategory(EventCategory eventType)
        {
            List<Outing> _outingList = _outingRepo.GetOutingList();

            decimal sum = _outingList.Sum(outings =>
            {
                if (outings.Category == eventType)
                {
                    return outings.TotalCostEvent;
                }
                else { return 0; }
            });
            Console.WriteLine(sum);
        }
    }
}