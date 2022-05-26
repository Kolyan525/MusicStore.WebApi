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
    public class GenreController : ControllerBase
    {
        readonly IGenreService _genreService;
        private readonly ILogger<GenreController> logger;

        public GenreController(IGenreService genreService, ILogger<GenreController> logger)
        {
            _genreService = genreService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            logger.LogInformation("Executing GetGenre");
            return Ok(_genreService.GetGenres());
        }

        [HttpGet("{id}", Name = "GetGenre")]
        public IActionResult GetGenre(string id)
        {
            return Ok(_genreService.GetGenre(id));
        }

        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            _genreService.AddGenre(genre);
            return CreatedAtRoute("GetGenre", new { id = genre.Id }, genre);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(string id)
        {
            _genreService.DeleteGenre(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invalid POST attempt in {nameof(UpdateGenre)}");
                return BadRequest(ModelState);
            }
            return Ok(_genreService.UpdateGenre(genre));
        }
    }
}
