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
    public class JogadoresController : Controller
    {
        private readonly Contexto _context;

        public JogadoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Jogadores
        public async Task<IActionResult> Index()
        {
              return _context.Jogador != null ? 
                          View(await _context.Jogador.ToListAsync()) :
                          Problem("Entity set 'Contexto.Jogador'  is null.");
        }

        // GET: Jogadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // GET: Jogadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,dataCriacao, Imagem")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogador);
                await _context.SaveChangesAsync();
                if (jogador.Imagem != null)
                {
                    await CarregarImagem.Start(jogador.Imagem, $"wwwroot\\imagens\\jogadores\\{jogador.Id}");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogador);
        }

        // GET: Jogadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }
            return View(jogador);
        }

        // POST: Jogadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,dataCriacao, Imagem")] Jogador jogador)
        {
            if (id != jogador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogador);
                    await _context.SaveChangesAsync();
                    if (jogador.Imagem != null)
                    {
                        await CarregarImagem.Start(jogador.Imagem, $"wwwroot\\imagens\\jogadores\\{jogador.Id}");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.Id))
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
            return View(jogador);
        }

        // GET: Jogadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jogador == null)
            {
                return Problem("Entity set 'Contexto.Jogador'  is null.");
            }
            var jogador = await _context.Jogador.FindAsync(id);
            if (jogador != null)
            {
                _context.Jogador.Remove(jogador);
            }
            
            await _context.SaveChangesAsync();
            var caminhoArquivo = $"wwwroot\\imagens\\jogadores\\{id}.png";
            if (System.IO.File.Exists(caminhoArquivo))
            {
                System.IO.File.Delete(caminhoArquivo);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(int id)
        {
          return (_context.Jogador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
