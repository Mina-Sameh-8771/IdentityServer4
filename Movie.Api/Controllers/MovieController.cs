using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.Api.Model;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("ClientIdPoicy")]
    public class MovieController : ControllerBase
    {

        private static List<MovieModel> movieList = new List<MovieModel>
        {
            new MovieModel
            {
                Genre = "s",
                Id = 1,
                Owner = "te",
                ReleaseDate = DateTime.Now,
                Title = "first"
            },
            new MovieModel
            {
                Genre = "s",
                Id = 2,
                Owner = "te",
                ReleaseDate = DateTime.Now,
                Title = "second"
            }
        };

        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<MovieModel> Get()
        {
            return movieList;
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public MovieModel Get(int id)
        {
            return movieList.Where(w => w.Id == id).FirstOrDefault();
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] MovieModel value)
        {
            movieList.Add(value);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            movieList.Remove(movieList.Where(w => w.Id == id).FirstOrDefault());
        }
    }
}
