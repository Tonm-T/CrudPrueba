using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.AccesoADatos;
using PruebaCrud.EntidadDeNegocio;
using PruebaCrud.LogicaDeNegocio;

namespace PruebaCrud.InterfazGraficaMVC.Controllers
{
    public class UsuariosENsController : Controller
    {
        UsuariosBL usuariosBL = new UsuariosBL();

        private readonly BDContexto _context;

        public async Task<IActionResult> Index(UsuariosEN Pusuario = null)
        {
            if (Pusuario == null)
                Pusuario = new UsuariosEN();
            if (Pusuario.top_aux == 0)
                Pusuario.top_aux = 10;
            else if (Pusuario.top_aux == -1)
                Pusuario.top_aux = 0;

            var usuarios = await usuariosBL.ObtenerPorIdAsync(Pusuario);
            ViewBag.Top = Pusuario.top_aux;
            return View(usuarios);
        }

        // GET: RolENs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var usuarios = await usuariosBL.ObtenerPorIdAsync(new UsuariosEN { Id = id });
            return View();
        }

        // GET: RolENs/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: RolENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuariosBL Pusuario)
        {
            try
            {
                int result = await usuariosBL.CrearAsync(Pusuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(Pusuario);
            }
        }

        // GET: RolENs/Edit/5
        public async Task<IActionResult> Edit(UsuariosEN Pusuario)
        {
            var usuarios = await usuariosBL.ObtenerPorIdAsync(Pusuario);
            ViewBag.Error = "";
            return View(usuarios);
        }

        // POST: RolENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuariosEN Pusuario)
        {
            try
            {
                int usuarios = await usuariosBL.ModificarAsync(Pusuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(Pusuario);
            }
        }

        // GET: RolENs/Delete/5
        public async Task<IActionResult> Delete(UsuariosEN Pusuario)
        {
            ViewBag.Error = "";
            var usuarios = await usuariosBL.ObtenerPorIdAsync(Pusuario);
            return View(usuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, UsuariosEN Pusuario)
        {
            try
            {
                int result = await usuariosBL.EliminarAsync(Pusuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
