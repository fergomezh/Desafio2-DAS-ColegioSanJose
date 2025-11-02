using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ColegioSanJose.Models.DB;
using ColegioSanJose.Models.ViewModels;

namespace ColegioSanJose.Controllers
{
    public class ExpedienteController : Controller
    {
        private readonly ColegioSanJoseContext _context;

        public ExpedienteController(ColegioSanJoseContext context)
        {
            _context = context;
        }

        // GET: Expediente
        public async Task<IActionResult> Index()
        {
            var expedientes = await _context.Expediente
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .Select(e => new ExpedienteViewModel
                {
                    ExpedienteId = e.ExpedienteId,
                    NombreCompleto = e.Alumno.Nombre + " " + e.Alumno.Apellido,
                    NombreMateria = e.Materia.NombreMateria,
                    NotaFinal = (double)e.NotaFinal,
                    Observaciones = e.Observaciones
                })
                .ToListAsync();

            return View(expedientes);
        }

        // GET: Expediente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .FirstOrDefaultAsync(m => m.ExpedienteId == id);

            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // GET: Expediente/Create
        public IActionResult Create()
        {
            ViewBag.AlumnoId = _context.Alumno
                .Select(a => new SelectListItem
                {
                    Value = a.AlumnoId.ToString(),
                    Text = a.Nombre + " " + a.Apellido // Para enviar el nombre completo
                })
                .ToList();

            ViewBag.MateriaId = new SelectList(_context.Materia, "MateriaId", "NombreMateria");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumnoId,MateriaId,NotaFinal,Observaciones")] Expediente expediente)
        {
            // Remover validaciones de las propiedades de navegación si existen
            ModelState.Remove("Alumno");
            ModelState.Remove("Materia");

            if (ModelState.IsValid)
            {
                _context.Add(expediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores, mostrarlos en consola para debug
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
            }

            ViewBag.AlumnoId = new SelectList(_context.Alumno, "AlumnoId", "Nombre", expediente.AlumnoId);
            ViewBag.MateriaId = new SelectList(_context.Materia, "MateriaId", "NombreMateria", expediente.MateriaId);
            return View(expediente);
        }

        // GET: Expediente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }

            ViewBag.AlumnoId = _context.Alumno
                .Select(a => new SelectListItem
                {
                    Value = a.AlumnoId.ToString(),
                    Text = a.Nombre + " " + a.Apellido
                })
                .ToList();

            ViewBag.MateriaId = new SelectList(_context.Materia, "MateriaId", "NombreMateria", expediente.MateriaId);

            return View(expediente);
        }

        // POST: Expediente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpedienteId,AlumnoId,MateriaId,NotaFinal,Observaciones")] Expediente expediente)
        {
            if (id != expediente.ExpedienteId)
            {
                return NotFound();
            }

            // Remover validaciones de las propiedades de navegacion
            ModelState.Remove("Alumno");
            ModelState.Remove("Materia");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedienteExists(expediente.ExpedienteId))
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
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "AlumnoId", "Nombre", expediente.AlumnoId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "MateriaId", "NombreMateria", expediente.MateriaId);
            return View(expediente);
        }

        // GET: Expediente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .FirstOrDefaultAsync(m => m.ExpedienteId == id);

            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: Expediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expediente = await _context.Expediente.FindAsync(id);
            if (expediente != null)
            {
                _context.Expediente.Remove(expediente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expediente.Any(e => e.ExpedienteId == id);
        }

        public async Task<IActionResult> PromedioPorAlumno()
        {
            var promedios = await _context.Expediente
                .Include(e => e.Alumno)
                .GroupBy(e => new { e.AlumnoId, e.Alumno.Nombre, e.Alumno.Apellido })
                .Select(g => new PromedioAlumnoViewModel
                {
                    AlumnoId = g.Key.AlumnoId,
                    NombreCompleto = g.Key.Nombre + " " + g.Key.Apellido,
                    Promedio = (double)g.Average(e => e.NotaFinal)
                })
                .ToListAsync();

            ViewBag.Labels = promedios.Select(p => p.NombreCompleto).ToArray();
            ViewBag.Data = promedios.Select(p => p.Promedio).ToArray();

            return View(promedios);
        }
    }
}