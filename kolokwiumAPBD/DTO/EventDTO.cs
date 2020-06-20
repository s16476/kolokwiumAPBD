using kolokwiumAPBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.DTO
{
    public class EventDTO
    {
        public int IdEvent { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public EventDTO(Event e)
        {
            IdEvent = e.IdEvent;
            Name = e.Name;
            StartDate = e.StartDate;
            EndDate = e.EndDate;
        }
    }
}
