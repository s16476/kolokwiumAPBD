using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Models
{
    public class Organiser
    {
        [Key]
        public int IdOrganiser { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Event_Organiser> Event_Organisers { get; set; }
    }
}
