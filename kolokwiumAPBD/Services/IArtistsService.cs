using kolokwiumAPBD.DTO;
using kolokwiumAPBD.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Services
{
    public interface IArtistsService
    {

        public ArtistInfoDTO getArtistInfo(int id);

        public RebookDTO rebookArtist(int idart, int idev, RebookRequest request);
    }
}
