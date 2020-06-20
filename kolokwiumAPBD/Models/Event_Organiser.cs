using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Models
{
    public class Event_Organiser
    {
        public int IdEvent { get; set; }

        public int IdOrganiser { get; set; }

        public Event Event { get; set; }

        public Organiser Organiser { get; set; }

    }
}
