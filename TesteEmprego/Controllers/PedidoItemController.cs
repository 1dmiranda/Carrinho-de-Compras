using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteEmprego.Data;
using TesteEmprego.Models;

namespace TesteEmprego.Controllers
{
    public class PedidoItemController : Controller
    {
        private readonly BDContext _context;

        public PedidoItemController(BDContext context)
        {
            _context = context;
        }

        // GET: PedidoItem
        public async Task<IActionResult> Index()
        {
            var bDContext = _context.PedidosItens.Include(p => p.Pedido).Include(p => p.Produto);
            return View(await bDContext.ToListAsync());
        }

        // GET: PedidoItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidosItens
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .SingleOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }

        // GET: PedidoItem/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id");
            return View();
        }

        // POST: PedidoItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,PedidoId")] PedidoItem pedidoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoItem.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", pedidoItem.ProdutoId);
            return View(pedidoItem);
        }

        // GET: PedidoItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidosItens.SingleOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoItem.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", pedidoItem.ProdutoId);
            return View(pedidoItem);
        }

        // POST: PedidoItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,PedidoId")] PedidoItem pedidoItem)
        {
            if (id != pedidoItem.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoItemExists(pedidoItem.PedidoId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoItem.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", pedidoItem.ProdutoId);
            return View(pedidoItem);
        }

        // GET: PedidoItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidosItens
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .SingleOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }

        // POST: PedidoItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoItem = await _context.PedidosItens.SingleOrDefaultAsync(m => m.PedidoId == id);
            _context.PedidosItens.Remove(pedidoItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoItemExists(int id)
        {
            return _context.PedidosItens.Any(e => e.PedidoId == id);
        }
    }
}
