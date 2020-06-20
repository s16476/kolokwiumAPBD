using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Requests
{
    public class RebookRequest
    {
        public int idArtist { get; set; }

        public int idEvent { get; set; }

        public DateTime performanceDate { get; set; }
    }
}
