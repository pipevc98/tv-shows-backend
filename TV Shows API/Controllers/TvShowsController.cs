using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TV_Shows_API.DataContext;
using TV_Shows_API.Entities;

namespace TV_Shows_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TvShowsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TvShow>> getTvshow()
        {
            var tvShow = _context.TvShows.ToList();
            return Ok(tvShow);
        }

        [HttpPost]
        public IActionResult Post(TvShow tvShow)
        {
            _context.TvShows.Add(tvShow);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getTvshow), new { id = tvShow.Id }, tvShow);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, TvShow tvShow)
        {
            var existingClient = _context.TvShows.AsNoTracking().FirstOrDefault( t => t.Id == id);
            if (existingClient == null)
            {
                return NotFound();
            }


            if (id != tvShow.Id)
            {
                return BadRequest();
            }

            _context.Entry(tvShow).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok();    
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tvShow = _context.TvShows.Find(id);
            if(tvShow == null)
            {
                return NotFound();
            }

            _context.TvShows.Remove(tvShow);
            _context.SaveChanges();

            return Ok();
        }
    }
}
