using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Models
{
    public partial class Event_Organiser
    {
        public int IdEvent { get; set; }

        public int IdOrganiser { get; set; }

        public virtual Event IdEventNavigation { get; set; }

        public virtual Organiser IdOrganiserNavigation { get; set; }

    }
}
