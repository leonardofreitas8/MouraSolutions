using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MouraSolutionsWeb.Data;
using MouraSolutionsWeb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MouraSolutionsWeb.Controllers
{
    public class ZonasController : Controller
    {
        private readonly MouraExpressContext _context;

        public ZonasController(MouraExpressContext context)
        {
            _context = context;
        }

        // GET: Zonas
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            return View(await _context.Zona.ToListAsync());
        }

        // GET: Zonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zona
                .FirstOrDefaultAsync(m => m.IdZona == id);
            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // GET: Zonas/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            return View();
        }

        // POST: Zonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZona,ZonaNome,BairrosAtendidos,FaixaCeps")] Zona zona)
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            if (ModelState.IsValid)
            {
                _context.Add(zona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zona);
        }

        // GET: Zonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zona.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }
            return View(zona);
        }

        // POST: Zonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZona,ZonaNome,BairrosAtendidos,FaixaCeps")] Zona zona)
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            if (id != zona.IdZona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonaExists(zona.IdZona))
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
            return View(zona);
        }

        // GET: Zonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zona
                .FirstOrDefaultAsync(m => m.IdZona == id);
            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            var zona = await _context.Zona.FindAsync(id);
            _context.Zona.Remove(zona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonaExists(int id)
        {
            return _context.Zona.Any(e => e.IdZona == id);
        }
    }
}
