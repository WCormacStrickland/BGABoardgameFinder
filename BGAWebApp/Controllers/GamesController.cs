#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BGAWebApp.Data;
using BGAWebApp.Models;

namespace BGAWebApp.Controllers
{
    public class GamesController : Controller
    {

        private readonly BGAWebAppContext _context;

        public GamesController(BGAWebAppContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index(string numPlayers, string numQuality)
        {
            var games = from m in _context.Game
                         select m;

            ViewBag.numPlayers = numPlayers;

            if (!String.IsNullOrEmpty(numPlayers))
            {
                if (numQuality == "support")
                {
                    games = games.Where(s => s.SupportCount!.Contains(numPlayers) || s.RecommendCount!.Contains(numPlayers) || s.BestCount!.Contains(numPlayers)).OrderByDescending(game => game.Rating);
/*                    ViewBag.SupportGames = games.Where(s => s.SupportCount!.Contains(numPlayers));
                    ViewBag.RecommendGames = games.Where(s => s.RecommendCount!.Contains(numPlayers));
                    ViewBag.BestGames = games.Where(s => s.BestCount!.Contains(numPlayers));*/
                }
                else if (numQuality == "recommend")
                {
                    games = games.Where(s => s.RecommendCount!.Contains(numPlayers) || s.BestCount!.Contains(numPlayers)).OrderByDescending(game => game.Rating);
/*                    ViewBag.RecommendGames = games.Where(s => s.RecommendCount!.Contains(numPlayers));
                    ViewBag.BestGames = games.Where(s => s.BestCount!.Contains(numPlayers));*/
                }
                else if (numQuality == "best")
                {
                    games = games.Where(s => s.BestCount!.Contains(numPlayers)).OrderByDescending(game => game.Rating);
/*                    ViewBag.BestGames = games.Where(s => s.BestCount!.Contains(numPlayers));*/
                }
            }

            return View(await games.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Rating,RecommendCount,BestCount,SupportCount,Link")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Rating,RecommendCount,BestCount,SupportCount,Link")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
