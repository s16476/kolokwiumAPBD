﻿using kolokwiumAPBD.DTO;
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
                ThenInclude(ae => ae.Event).
                Where(a => a.IdArtist == id).SingleOrDefault();
            return new ArtistInfoDTO(arts);
        }

        public RebookDTO rebookArtist(int idart, int idev, RebookRequest request)
        {
            var arev = db.Artist_Events.Where(ae => ae.IdArtist == idart && ae.IdEvent == idev).Include(ae => ae.Event).SingleOrDefault();

            if (request.performanceDate > arev.Event.StartDate && request.performanceDate < arev.Event.EndDate) {

                var reb = new Artist_Event
                {
                    IdArtist = request.idArtist,
                    IdEvent = request.idEvent,
                    DateTime = request.performanceDate
                };
                db.Attach(reb);
                db.SaveChanges();
            }

        }
    }
}