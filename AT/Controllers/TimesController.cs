using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AT.Models;
using AT.Services;

namespace AT.Controllers
{
    public class TimesController : Controller
    {
        private readonly Contexto _context;

        public TimesController(Contexto context)
        {
            _context = context;
        }

        // GET: Times
        public async Task<IActionResult> Index()
        {
              return _context.Time != null ? 
                          View(await _context.Time.ToListAsync()) :
                          Problem("Entity set 'Contexto.Time'  is null.");
        }

        // GET: Times/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Time == null)
            {
                return NotFound();
            }

            var time = await _context.Time
                .FirstOrDefaultAsync(m => m.Id == id);
            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        // GET: Times/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Times/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,dataCriacao, Imagem")] Time time)
        {
            if (ModelState.IsValid)
            {
                _context.Add(time);
                await _context.SaveChangesAsync();
                if (time.Imagem != null)
                {
                  await CarregarImagem.Start(time.Imagem, $"wwwroot\\imagens\\times\\{time.Id}");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(time);
        }

        // GET: Times/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Time == null)
            {
                return NotFound();
            }

            var time = await _context.Time.FindAsync(id);
            if (time == null)
            {
                return NotFound();
            }
            return View(time);
        }

        // POST: Times/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,dataCriacao, Imagem")] Time time)
        {
            if (id != time.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(time);
                    await _context.SaveChangesAsync();
                    if (time.Imagem != null)
                    {
                        await CarregarImagem.Start(time.Imagem, $"wwwroot\\imagens\\times\\{time.Id}");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeExists(time.Id))
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
            return View(time);
        }

        // GET: Times/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Time == null)
            {
                return NotFound();
            }

            var time = await _context.Time
                .FirstOrDefaultAsync(m => m.Id == id);
            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Time == null)
            {
                return Problem("Entity set 'Contexto.Time'  is null.");
            }
            var time = await _context.Time.FindAsync(id);
            if (time != null)
            {
                _context.Time.Remove(time);
            }
            
            await _context.SaveChangesAsync();

            var caminhoArquivo = $"wwwroot\\imagens\\times\\{id}.png";
            if (System.IO.File.Exists(caminhoArquivo))
            {
                System.IO.File.Delete(caminhoArquivo);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TimeExists(int id)
        {
          return (_context.Time?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
