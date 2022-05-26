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
    public class SongController : ControllerBase
    {
        readonly ISongService _songService;
        private readonly ILogger<SongController> logger;

        public SongController(ISongService songService, ILogger<SongController> logger)
        {
            _songService = songService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetSongs()
        {
            logger.LogInformation("Executin GetSong");
            return Ok(_songService.GetSongs());
        }

        [HttpGet("{id}", Name = "GetSong")]
        public IActionResult GetSong(string id)
        {
            return Ok(_songService.GetSong(id));
        }

        [HttpPost]
        public IActionResult AddSong(Song song)
        {
            _songService.AddSong(song);
            return CreatedAtRoute("GetSong", new { id = song.Id }, song);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSong(string id)
        {
            _songService.DeleteSong(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invalid POST attempt in {nameof(UpdateSong)}");
                return BadRequest(ModelState);
            }
            return Ok(_songService.UpdateSong(song));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSong(string id)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invalid POST attempt in {nameof(UpdateSong)}");
                return BadRequest(ModelState);
            }
            return Ok(_songService.UpdateSong(id));
        }
    }
}
