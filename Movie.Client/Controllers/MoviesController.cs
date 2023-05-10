using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movie.Client.ApiService;
using Movie.Client.Data;
using Movie.Client.Models;

namespace Movie.Client.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieApiService movieApiService;

        public MoviesController(IMovieApiService movieApiService)
        {
            this.movieApiService = movieApiService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            LogTokenAndCliams();
            var list = await movieApiService.GetMovies();
            return View(list);
        }

        public async Task LogTokenAndCliams()
        {
            var idnetityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token : {idnetityToken}");

            foreach(var cliams in User.Claims)
            {
                Debug.WriteLine($"cliam type : {cliams.Type} - claim value : {cliams.Value}");

            }
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var movieModel = await _context.MovieModel
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (movieModel == null)
            //{
            //    return NotFound();
            //}

            //return View(movieModel);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Genre,ReleaseDate,Owner")] MovieModel movieModel)
        {
            return View();
            //if (ModelState.IsValid)
            //{
            //    _context.Add(movieModel);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(movieModel);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var movieModel = await _context.MovieModel.FindAsync(id);
            //if (movieModel == null)
            //{
            //    return NotFound();
            //}
            //return View(movieModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,ReleaseDate,Owner")] MovieModel movieModel)
        {
            return View();
            //if (id != movieModel.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(movieModel);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MovieModelExists(movieModel.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(movieModel);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var movieModel = await _context.MovieModel
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (movieModel == null)
            //{
            //    return NotFound();
            //}

            //return View(movieModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return View();
            //var movieModel = await _context.MovieModel.FindAsync(id);
            //_context.MovieModel.Remove(movieModel);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool MovieModelExists(int id)
        {
            return true;
        }
    }
}
