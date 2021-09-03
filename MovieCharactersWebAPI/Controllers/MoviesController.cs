using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersWebAPI.Models;
using MovieCharactersWebAPI.Models.DTO;
using MovieCharactersWebAPI.Models.DTO.CharacterDTO;
using MovieCharactersWebAPI.Models.DTO.MovieDTO;

namespace MovieCharactersWebAPI.Controllers
{
    /// <summary>
    /// Controller class for Movies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        private readonly MovieCharacterDbContext _context;
        // Automapper 
        private readonly IMapper _mapper;

        public MoviesController(MovieCharacterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all the movies in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovie()
        {
            return _mapper.Map<List<MovieDTO>>(await _context.Movie.ToListAsync());
           
        }

        /// <summary>
        /// Get a single movie by movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieDTO>(movie);
        }

        /// <summary>
        /// Update a movie.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieDTOEdit movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            Movie domainMovie = _mapper.Map<Movie>(movie);
            _context.Entry(domainMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Add a movie to the database.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieDTO movie)
        {
            Movie domainMovie = _mapper.Map<Movie>(movie); 
            _context.Movie.Add(domainMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Delete a movie from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
        /// <summary>
        /// Update the characters linked to a single movie. Like when your movie includes Kevin Spacey and you need to do a full recast.
        /// </summary>
        /// <param name="id">The id of the movie that is changing characters.</param>
        /// <param name="characters">The new characters to be added (by character id).</param>
        /// <returns></returns>
        [HttpPut("{id}/Characters")]
        public async Task<IActionResult> UpdateMovieCharacters(int id, List<int> characters) {
            try {

                if (!MovieExists(id))
                {
                    return BadRequest("Movie mismatch ID");
                }
                //Retriving the Movie object we want to update
                Movie movieToUpdate = await _context.Movie
               .Include(c => c.Characters)
               .Where(i => i.Id == id)
               .FirstAsync();

                //The new lists of character
                List<Character> newlistCharacter = new List<Character>();

                //Id in character list sent inn
                foreach (int Id in characters) {
                    //Character object to check for if the character exist 
                    Character existCharacter = await _context.Character.FindAsync(Id);
                    //if it does not - return bad request
                    if (existCharacter == null) {
                        return BadRequest();
                    }
                    //if it exist add it the character to newListCharacter
                    newlistCharacter.Add(existCharacter);
                }
                //Add the new list to the movie objects character column
                movieToUpdate.Characters = newlistCharacter;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error updating data");
            }
            //save the changes to db
            await _context.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Get characters in a movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Characters")]
        public async Task<ActionResult<Character>> GetCharacatersInMovie(int id)
        {
            // Make response object
            List<Character> response = new();
            Movie movie = await _context.Movie.Include(c => c.Characters).Where(m => m.Id == id).FirstOrDefaultAsync();
            if (movie == null)
            {
                return NotFound(response);
            }
            foreach (Character character in movie.Characters)
            {
                response.Add(character);
                character.Movies = null;
            }
            // Map to dto
            return Ok(_mapper.Map<MovieDTO>(response));
        }


    }
}
