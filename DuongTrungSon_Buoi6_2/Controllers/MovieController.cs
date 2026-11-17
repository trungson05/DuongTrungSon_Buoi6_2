
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DuongTrungSon_Buoi6_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class MovieController : Controller
{
    private readonly DuongTrungSon_Buoi6_2Context _context;

    public MovieController(DuongTrungSon_Buoi6_2Context context)
    {
        _context = context;
    }

    // GET: MOVIES
    public async Task<IActionResult> Index()    
    {
        var listMovie = await (from m in _context.Movie
                               join g in _context.Genre on m.GenreId equals g.GenreId
                               select new MovieViewModel
                               {
                                   Id = m.Id,

                                   Title = m.Title,
                                   ReleseDate = m.ReleseDate,
                                   Price = m.Price,
                                   GenreName = g.GenreName,
                               }
            ).ToListAsync();
        return View(listMovie);
    }

    // GET: MOVIES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        var genre = await _context.Genre.FirstOrDefaultAsync(g => g.GenreId == movie.GenreId);
        ViewBag.GenreName = genre?.GenreName;

        return View(movie);
    }

    // GET: MOVIES/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.GenreId = new SelectList(_context.Genre, "GenreId", "GenreName");
        return View();
    }

    // POST: MOVIES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleseDate,Price,GenreId,Genre")] Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.GenreId = new SelectList(_context.Genre, "GenreId", "GenreName",movie.GenreId);
        return View(movie);
    }

    // GET: MOVIES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        ViewBag.GenreId = new SelectList(_context.Genre, "GenreId", "GenreName", movie.GenreId);
        return View(movie);
    }

    // POST: MOVIES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,ReleseDate,Price,GenreId,Genre")] Movie movie)
    {
        if (id != movie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: MOVIES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        var genre = await _context.Genre.FirstOrDefaultAsync(g => g.GenreId == movie.GenreId);
        ViewBag.GenreName = genre?.GenreName;
        return View(movie);
    }

    // POST: MOVIES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var movie = await _context.Movie.FindAsync(id);
        if (movie != null)
        {
            _context.Movie.Remove(movie);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int? id)
    {
        return _context.Movie.Any(e => e.Id == id);
    }
}
