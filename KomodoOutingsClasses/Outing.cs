using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsClasses
{
    public enum EventType { Golf, Bowling, Amusement_Park, Concert }
    public class Outing
    {
        public EventType EventType { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime DateOfOuting { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get; set; }
        public Outing() { }
        public Outing (EventType eventType, int numberOfAttendess, DateTime dateOfOuting, decimal costPerPerson, decimal costOfEvent)
        {
            EventType = eventType;
            NumberOfAttendees = numberOfAttendess;
            DateOfOuting = dateOfOuting;
            CostPerPerson = costPerPerson;
            CostOfEvent = costOfEvent;
        }

    }
    
}

