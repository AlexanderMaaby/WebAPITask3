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

namespace MovieCharactersWebAPI.Controllers
{
    /// <summary>
    /// Controller class for Franchises.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly MovieCharacterDbContext _context;
        // Automapper 
        private readonly IMapper _mapper;

        public FranchisesController(MovieCharacterDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Franchises in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchise()
        {
            return _mapper.Map<List<FranchiseDTO>>(await _context.Franchise.ToListAsync());
        }

        /// <summary>
        /// Gets a single Franchise from the database.
        /// </summary>
        /// <param name="id">The Id of the requested franchise.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            var franchise = await _context.Franchise.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }
            return _mapper.Map<FranchiseDTO>(franchise);
        }

        /// <summary>
        /// Gets all the movies from the given franchise.
        /// </summary>
        /// <param name="id">The id of the franchise movies should be returned from.</param>
        /// <returns></returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesInFranchise(int id)
        {
            Franchise franchise = await _context.Franchise.Include(f => f.Movies).Where(f => f.Id == id).FirstOrDefaultAsync();
            List<MovieDTO> movies = _mapper.Map<List<MovieDTO>>(franchise.Movies);

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        /// <summary>
        /// Get all the characters belonging to a single franchise.
        /// </summary>
        /// <param name="id">The Id of the franchise characters should be returned from.</param>
        /// <returns></returns>
        [HttpGet("{id}/Characters")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetFranchiseCharacters(int id)
        {
            var characters = await _context.Franchise
                .Where(f => f.Id == id)
                .SelectMany(f => f.Movies)
                .SelectMany(m => m.Characters)
                .Distinct()
                .ToListAsync();

            if (characters == null)
            {
                return NotFound();
            }
            List<CharacterDTO> charactersReturn = _mapper.Map<List<CharacterDTO>>(characters);

            return Ok(charactersReturn);
        }

        /// <summary>
        /// Update a franchise in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseDTOEdit franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }
            Franchise domainFranchise = _mapper.Map<Franchise>(franchise);
            _context.Entry(franchise).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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
        /// Add a franchise to the database.
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseDTOCreate franchise)
        {
            Franchise domainFranchise = _mapper.Map<Franchise>(franchise);
            _context.Franchise.Add(domainFranchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = domainFranchise.Id }, _mapper.Map<FranchiseDTO>(domainFranchise));
        }

        /// <summary>
        /// Delete a franchise from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchise.Remove(franchise);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        private bool FranchiseExists(int id)
        {
            return _context.Franchise.Any(e => e.Id == id);
        }

        /// <summary>
        /// Update all the movies in a given franchise. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movies"></param>
        /// <returns></returns>
        //Nick said that this should be a get - we get error 
        //and we disagree, because a put is an update right? =)
        [HttpPut("{id}/Movies")]
        public async Task<IActionResult> UpdateMoviesFranchise(int id, List<int> movies)
        {
            if (!FranchiseExists(id))
            {
                return BadRequest();
            }

            //Getting the franchise with id from request
            Franchise franchise = await _context.Franchise
                .Include(f => f.Movies)
                .Where(i => i.Id == id)
                .FirstAsync();

            //Making a new list of movies for adding to the Movies collection for Franchise
            List<Movie> newListMovies = new List<Movie>();

            //Looping through the list of movie id's
            foreach (int tempId in movies)
            {

                //Getting the movie with the movie id
                Movie movieExist = await _context.Movie.FindAsync(tempId);

                //if the movie dont exist - return BadRequest
                if (movieExist == null) {
                    return BadRequest();
                }
                //Changing the franchise id for the movie
                movieExist.FranchiseId = id;
                //adding the the movie to the newMovieList
                newListMovies.Add(movieExist);
            }

            //Adding the new movielist to the collection of movies for franchise 
            franchise.Movies = newListMovies;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
