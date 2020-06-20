using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumAPBD.Models
{
    public class EventDbContext : DbContext
    {

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Organiser> Organisers { get; set; }

        public DbSet<Artist_Event> Artist_Events { get; set; }

        public DbSet<Event_Organiser> Event_Organisers { get; set; }

        public EventDbContext() { }
        public EventDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(a => a.IdArtist).HasName("Artist_pk");
                entity.HasMany(e => e.Artist_Events).WithOne().IsRequired();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(a => a.IdEvent).HasName("Event_pk");
                entity.HasMany(e => e.Artist_Events).WithOne().IsRequired();
                entity.HasMany(e => e.Event_Organisers).WithOne().IsRequired();

            });

            modelBuilder.Entity<Organiser>(entity =>
            {
                entity.HasKey(a => a.IdOrganiser).HasName("Organiser_pk");
                entity.HasMany(e => e.Event_Organisers).WithOne().IsRequired();
            });


            modelBuilder.Entity<Artist_Event>(entity =>
            {
                entity.HasKey(ae => new { ae.IdArtist, ae.IdEvent }).HasName("Artist_Event_pk");

                entity.HasOne(d => d.IdArtistNavigation).WithMany(e => e.Artist_Events).HasForeignKey(e => e.IdArtist).IsRequired();

                entity.HasOne(d => d.IdEventNavigation).WithMany(e => e.Artist_Events).HasForeignKey(e => e.IdEvent).IsRequired();

            });

            modelBuilder.Entity<Event_Organiser>(entity =>
            {
                entity.HasKey(eo => new { eo.IdEvent, eo.IdOrganiser });

                entity.HasOne(e => e.IdEventNavigation).WithMany(e => e.Event_Organisers).HasForeignKey(e => e.IdEvent).IsRequired();

                entity.HasOne(e => e.IdOrganiserNavigation).WithMany(e => e.Event_Organisers).HasForeignKey(e => e.IdOrganiser).IsRequired();

            });





               

            modelBuilder.Entity<Artist>()
                .Property(a => a.Nickname)
                .HasMaxLength(30);

            modelBuilder.Entity<Event>()
                .Property(e => e.Name)
                .HasMaxLength(30);

            modelBuilder.Entity<Organiser>()
                .Property(a => a.Name)
                .HasMaxLength(30);


            var artists = new List<Artist>();
            var ar1 = new Artist
            {
                IdArtist = 1,
                Nickname = "Slash"
            };
            artists.Add(ar1);
            var ar2 = new Artist
            {
                IdArtist = 2,
                Nickname = "Axel"
            };
            artists.Add(ar2);
            var ar3 = new Artist
            {
                IdArtist = 3,
                Nickname = "Bruno"
            };
            artists.Add(ar3);
            var ar4 = new Artist
            {
                IdArtist = 4,
                Nickname = "Mick"
            };
            artists.Add(ar4);


            var events = new List<Event>();
            var ev1 = new Event
            {
                IdEvent = 1,
                StartDate = new DateTime(2020, 7, 11, 18, 0, 0),
                EndDate = new DateTime(2020, 7, 11, 23, 0, 0),
                Name = "Wieczor muzyczny WWa"
            };
            events.Add(ev1);
            var ev2 = new Event
            {
                IdEvent = 2,
                StartDate = new DateTime(2020, 7, 23, 18, 0, 0),
                EndDate = new DateTime(2020, 7, 23, 23, 30, 0),
                Name = "Go Rock"
            };
            events.Add(ev2);
            var ev3 = new Event
            {
                IdEvent = 3,
                StartDate = new DateTime(2020, 8, 5, 15, 0, 0),
                EndDate = new DateTime(2020, 8, 6, 23, 0, 0),
                Name = "Warsaw Festival"
            };
            events.Add(ev3);

            var organisers = new List<Organiser>();
            var org1 = new Organiser
            {
                IdOrganiser = 1,
                Name = "Evenea"
            };
            organisers.Add(org1);
            var org2 = new Organiser
            {
                IdOrganiser = 2,
                Name = "GoLIve"
            };
            organisers.Add(org2);

            var aes = new List<Artist_Event>();
            var ae1 = new Artist_Event
            {
                IdArtist = 1,
                IdEvent = 1,
                DateTime = new DateTime(2020, 7, 11, 18, 0, 0)
            };
            aes.Add(ae1);
            var ae2 = new Artist_Event
            {
                IdArtist = 2,
                IdEvent = 1,
                DateTime = new DateTime(2020, 7, 11, 20, 0, 0)
            };
            aes.Add(ae2);
            var ae3 = new Artist_Event
            {
                IdArtist = 2,
                IdEvent = 2,
                DateTime = new DateTime(2020, 7, 23, 18, 0, 0)
            };
            aes.Add(ae3);
            var ae4 = new Artist_Event
            {
                IdArtist = 3,
                IdEvent = 2,
                DateTime = new DateTime(2020, 7, 23, 20, 0, 0)
            };
            aes.Add(ae4);
            var ae5 = new Artist_Event
            {
                IdArtist = 4,
                IdEvent = 3,
                DateTime = new DateTime(2020, 8, 5, 15, 0, 0)
            };
            aes.Add(ae5);
            var ae6 = new Artist_Event
            {
                IdArtist = 3,
                IdEvent = 3,
                DateTime = new DateTime(2020, 8, 5, 19, 0, 0)
            };
            aes.Add(ae6);

            var eos = new List<Event_Organiser>();
            var eo1 = new Event_Organiser
            {
                IdEvent = 1,
                IdOrganiser = 1
            };
            eos.Add(eo1);
            var eo2 = new Event_Organiser
            {
                IdEvent = 2,
                IdOrganiser = 1
            };
            eos.Add(eo2);
            var eo3 = new Event_Organiser
            {
                IdEvent = 3,
                IdOrganiser = 2
            };


            modelBuilder.Entity<Artist>().HasData(artists);
            modelBuilder.Entity<Artist_Event>().HasData(aes);
            modelBuilder.Entity<Event>().HasData(events);
            modelBuilder.Entity<Event_Organiser>().HasData(eos);
            modelBuilder.Entity<Organiser>().HasData(organisers);

        }



        }
}
