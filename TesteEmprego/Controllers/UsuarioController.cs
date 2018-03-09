using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteEmprego.Data;

namespace TesteEmprego.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly BDContext _context;

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                listaDeUsuarios.Add(usuario);
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();

            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = listaDeUsuarios.FirstOrDefault(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id, Nome, Cpf, email")] Usuario usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    //Atualizar produto encontrado na lista
                    var usuarioTemp = listaDeUsuarios.FirstOrDefault(c => c.Id == id);
                    if (usuarioTemp != null)
                    {
                        usuarioTemp.Cpf = usuario.Cpf;
                        usuarioTemp.Nome = usuario.Nome;
                        usuarioTemp.email = usuario.email;
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = listaDeUsuarios.FirstOrDefault(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var usuario
                    = listaDeUsuarios.FirstOrDefault(m => m.Id == id);
                listaDeUsuarios.Remove(usuario);

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}