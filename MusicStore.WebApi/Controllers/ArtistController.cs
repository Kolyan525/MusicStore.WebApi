using MusicStore.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        readonly IArtistService _artistService;
        private readonly ILogger<ArtistController> logger;

        public ArtistController(IArtistService artistService, ILogger<ArtistController> logger)
        {
            _artistService = artistService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetArtists()
        {
            logger.LogInformation("Executin GetArtist");
            return Ok(_artistService.GetArtists());
        }

        [HttpGet("{id}", Name = "GetArtist")]
        public IActionResult GetArtist(string id)
        {
            return Ok(_artistService.GetArtist(id));
        }

        [HttpPost]
        public IActionResult AddArtist(Artist artist)
        {
            _artistService.AddArtist(artist);
            return CreatedAtRoute("GetArtist", new { id = artist.Id }, artist);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArtist(string id)
        {
            _artistService.DeleteArtist(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateArtist(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invalid POST attempt in {nameof(UpdateArtist)}");
                return BadRequest(ModelState);
            }
            return Ok(_artistService.UpdateArtist(artist));
        }
    }
}
