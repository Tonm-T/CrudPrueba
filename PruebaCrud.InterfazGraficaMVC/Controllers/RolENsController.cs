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
    public class RolENsController : Controller
    {
        RolBL rolesBL = new RolBL();

        private readonly BDContexto _context;

        public async Task<IActionResult> Index(RolEN Prol = null)
        {
            if (Prol == null)
                Prol = new RolEN();
            if (Prol.top_aux == 0)
                Prol.top_aux = 10;
            else if (Prol.top_aux == -1)
                Prol.top_aux = 0;

            var roles = await rolesBL.ObtenerPorIdAsync(Prol);
            ViewBag.Top = Prol.top_aux;
            return View(rolesBL);
        }

        // GET: RolENs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var roles = await rolesBL.ObtenerPorIdAsync(new RolEN { Id = id });
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
        public async Task<IActionResult> Create(RolBL Prol)
        {
            try
            {
                int result = await rolesBL.CrearAsync(Prol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(Prol);
            }
        }

        // GET: RolENs/Edit/5
        public async Task<IActionResult> Edit(RolEN Pusuario)
        {
            var usuarios = await rolesBL.ObtenerPorIdAsync(Pusuario);
            ViewBag.Error = "";
            return View(usuarios);
        }

        // POST: RolENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RolEN Prol)
        {
            try
            {
                int usuarios = await rolesBL.ModificarAsync(Prol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(Prol);
            }
        }

        // GET: RolENs/Delete/5
        public async Task<IActionResult> Delete(RolEN Prol)
        {
            ViewBag.Error = "";
            var roles = await rolesBL.ObtenerPorIdAsync(Prol);
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, RolEN Prol)
        {
            try
            {
                int result = await rolesBL.EliminarAsync(Prol);
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
