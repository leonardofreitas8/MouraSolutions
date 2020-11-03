using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MouraSolutionsWeb.Data;
using MouraSolutionsWeb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MouraExpress.Controllers
{
    public class StatusPedidosController : Controller
    {
        private readonly MouraExpressContext _context;

        public StatusPedidosController(MouraExpressContext context)
        {
            _context = context;
        }

        // GET: StatusPedidos
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

            return View(await _context.StatusPedido.ToListAsync());
        }

        // GET: StatusPedidos/Details/5
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

            var statusPedido = await _context.StatusPedido
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusPedido == null)
            {
                return NotFound();
            }

            return View(statusPedido);
        }

        // GET: StatusPedidos/Create
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

        // POST: StatusPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatus,Status,Descricao")] StatusPedido statusPedido)
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
                _context.Add(statusPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusPedido);
        }

        // GET: StatusPedidos/Edit/5
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

            var statusPedido = await _context.StatusPedido.FindAsync(id);
            if (statusPedido == null)
            {
                return NotFound();
            }
            return View(statusPedido);
        }

        // POST: StatusPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatus,Status,Descricao")] StatusPedido statusPedido)
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

            if (id != statusPedido.IdStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusPedidoExists(statusPedido.IdStatus))
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
            return View(statusPedido);
        }

        // GET: StatusPedidos/Delete/5
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

            var statusPedido = await _context.StatusPedido
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusPedido == null)
            {
                return NotFound();
            }

            return View(statusPedido);
        }

        // POST: StatusPedidos/Delete/5
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

            var statusPedido = await _context.StatusPedido.FindAsync(id);
            _context.StatusPedido.Remove(statusPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusPedidoExists(int id)
        {
            return _context.StatusPedido.Any(e => e.IdStatus == id);
        }
    }
}
