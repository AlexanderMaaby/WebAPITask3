﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersWebAPI.Models;

namespace MovieCharactersWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchise()
        {
            return await _context.Franchise.ToListAsync();
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            var franchise = await _context.Franchise.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return franchise;
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

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

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            _context.Franchise.Add(franchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // DELETE: api/Franchises/5
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
