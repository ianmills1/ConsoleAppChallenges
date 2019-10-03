using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Repository
{

    public enum EventCategory {  Golf = 1, Bowling, Amusement_Park, Concert}
    public class Outing
    {
        public Outing()
        {

        }

        public Outing(EventCategory category, int numberAttended, DateTime eventDate, decimal totalCostEvent)
        {
            Category = category;
            NumberAttended = numberAttended;
            EventDate = eventDate;
            TotalCostEvent = totalCostEvent;
            TotalCostPerPerson = (totalCostEvent / numberAttended);
        }

        public EventCategory Category { get; set; }
        public int NumberAttended { get; set; }
        public DateTime EventDate { get; set; }
        public decimal TotalCostPerPerson { get; set; }
        public decimal TotalCostEvent { get; set; }
    }
}