using kolokwiumAPBD.DTO;
using kolokwiumAPBD.Models;
using kolokwiumAPBD.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Services
{
    public class EfArtistsService : IArtistsService
    {

        private readonly EventDbContext db;

        public EfArtistsService(EventDbContext ctx)
        {
            db = ctx;
        }

        public ArtistInfoDTO getArtistInfo(int id)
        {
            var arts = db.Artists.Include(a => a.Artist_Events).
                ThenInclude(ae => ae.IdEventNavigation).
                Where(a => a.IdArtist == id).SingleOrDefault();
            return new ArtistInfoDTO(arts);
        }

        public RebookDTO rebookArtist(RebookRequest request)
        {
            var arev = db.Artist_Events.Where(ae => ae.IdArtist == request.idArtist && ae.IdEvent == request.idEvent).Include(ae => ae.IdEventNavigation).SingleOrDefault();

            if (request.performanceDate > arev.IdEventNavigation.StartDate && request.performanceDate < arev.IdEventNavigation.EndDate) {

                arev.DateTime = request.performanceDate;
                db.SaveChanges();
            }
            return new RebookDTO
            {
                idArtist = request.idArtist,
                idEvent = request.idEvent,
                performanceDate = request.performanceDate
            };
        }
    }
}
