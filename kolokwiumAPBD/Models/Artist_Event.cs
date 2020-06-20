using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Models
{
    public partial class Artist_Event
    {

        public int IdEvent { get; set; }

        public int IdArtist { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Artist IdArtistNavigation { get; set; }

        public virtual Event IdEventNavigation { get; set; }

    }
}
