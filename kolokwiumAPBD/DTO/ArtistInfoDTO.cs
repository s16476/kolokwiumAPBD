using kolokwiumAPBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.DTO
{
    public class ArtistInfoDTO
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }

        public List<EventDTO> Events { get; set; }

        public ArtistInfoDTO(Artist artist)
        {
            IdArtist = artist.IdArtist;
            Nickname = artist.Nickname;
            Events = new List<EventDTO>();
            foreach(Artist_Event e in artist.Artist_Events)
            {
                Events.Add(new EventDTO(e.IdEventNavigation));
            }
            Events = Events.OrderBy(o => o.StartDate).ToList();
        }
    }
}
