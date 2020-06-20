using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwiumAPBD.DTO;
using kolokwiumAPBD.Requests;
using kolokwiumAPBD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwiumAPBD.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistsService artistsService;

        public ArtistsController(IArtistsService service)
        {
            artistsService = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetArtistInfo(int id)
        {
            return Ok(artistsService.getArtistInfo(id));
        }

        [Route("events")]
        [HttpPut]
        public IActionResult GetArtistInfo(RebookRequest request)
        {
            return Ok(artistsService.rebookArtist(request));
        }



    }
}