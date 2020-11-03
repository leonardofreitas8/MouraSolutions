using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MouraSolutionsWeb.Data;
using MouraSolutionsWeb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MouraSolutionsWeb.Controllers
{
    public class MotoboysController : Controller
    {
        private readonly MouraExpressContext _context;

        public MotoboysController(MouraExpressContext context)
        {
            _context = context;
        }

        // GET: Motoboys
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

            var mouraExpressContext = _context.Motoboy.Include(m => m.Zona);
            return View(await mouraExpressContext.ToListAsync());
        }

        // GET: Motoboys/Details/5
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

            var motoboy = await _context.Motoboy
                .Include(m => m.Zona)
                .FirstOrDefaultAsync(m => m.MotoboyId == id);
            if (motoboy == null)
            {
                return NotFound();
            }

            return View(motoboy);
        }

        // GET: Motoboys/Create
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

            PopulateZonaId();
            //ViewData["ZonaId"] = new SelectList(_context.Zona, "IdZona", "IdZona");

            return View();
        }

        // POST: Motoboys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotoboyId,Nome,Sobrenome,TeelefoneFixo,TeelefoneCelular,Veiculo,Placa,DataEntrada,DataSaida,Status,ZonaId")] Motoboy motoboy)
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
                _context.Add(motoboy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateZonaId();
            //ViewData["ZonaId"] = new SelectList(_context.Zona, "IdZona", "IdZona", motoboy.ZonaId);
            return View(motoboy);
        }

        // GET: Motoboys/Edit/5
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

            var motoboy = await _context.Motoboy.FindAsync(id);
            if (motoboy == null)
            {
                return NotFound();
            }
            PopulateZonaId();
            //ViewData["ZonaId"] = new SelectList(_context.Zona, "IdZona", "IdZona", motoboy.ZonaId);
            return View(motoboy);
        }

        // POST: Motoboys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotoboyId,Nome,Sobrenome,TeelefoneFixo,TeelefoneCelular,Veiculo,Placa,DataEntrada,DataSaida,Status,ZonaId")] Motoboy motoboy)
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

            if (id != motoboy.MotoboyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motoboy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoboyExists(motoboy.MotoboyId))
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
            PopulateZonaId();
            //ViewData["ZonaId"] = new SelectList(_context.Zona, "IdZona", "IdZona", motoboy.ZonaId);
            return View(motoboy);
        }

        // GET: Motoboys/Delete/5
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

            var motoboy = await _context.Motoboy
                .Include(m => m.Zona)
                .FirstOrDefaultAsync(m => m.MotoboyId == id);
            if (motoboy == null)
            {
                return NotFound();
            }

            return View(motoboy);
        }

        // POST: Motoboys/Delete/5
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

            var motoboy = await _context.Motoboy.FindAsync(id);
            _context.Motoboy.Remove(motoboy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoboyExists(int id)
        {
            return _context.Motoboy.Any(e => e.MotoboyId == id);
        }

        public void PopulateZonaId(object selectedCliente2 = null)
        {
            var clienteQuery = from c in _context.Zona
                               orderby c.ZonaNome
                               select c;

            ViewBag.ZonaId = new SelectList(clienteQuery.AsNoTracking(), "IdZona", "ZonaNome", selectedCliente2);
        }
    }
}
