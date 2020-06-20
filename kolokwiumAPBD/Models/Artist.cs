using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Models
{
    public partial class Artist
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<Artist_Event> Artist_Events { get; set; }


    }
}
