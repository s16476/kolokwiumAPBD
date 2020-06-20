﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Models
{
    public class Artist_Event
    {

        public int IdEvent { get; set; }

        public int IdArtist { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual Event Event { get; set; }

    }
}
