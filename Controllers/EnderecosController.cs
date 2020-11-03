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
    public class EnderecosController : Controller
    {
        private readonly MouraExpressContext _context;

        public EnderecosController(MouraExpressContext context)
        {
            _context = context;
        }

        // GET: Enderecos
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

            var mouraExpressContext = _context.Endereco.Include(e => e.Cliente);
            return View(await mouraExpressContext.ToListAsync());
        }

        // GET: Enderecos/Details/5
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

            var endereco = await _context.Endereco
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.IdEndereco == id);

            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Enderecos/Create
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

            PopulateClienteDropDown();
            //ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            return View();
        }

        public void PopulateClienteDropDown(object selectedCliente1 = null)
        {
            var clienteQuery = from c in _context.Cliente
                               orderby c.Nome
                               select c;

            ViewBag.ClienteID = new SelectList(clienteQuery.AsNoTracking(), "ClienteId", "Nome", selectedCliente1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEndereco,Tipo_Endereco,Rua,Numero,Bairro,Cidade,CEP,Complemento,Zona_Setor,UF,Nome_Contato,Telefone_Comercial,Telefone_Celular,Telefone_Recado,Email,Status,Obs,Data_Registro,ClienteID")] Endereco endereco)
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
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", endereco.ClienteID);
            return View(endereco);
        }

        // GET: Enderecos/Edit/5
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

            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", endereco.ClienteID);
            return View(endereco);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEndereco,Tipo_Endereco,Rua,Numero,Bairro,Cidade,CEP,Complemento,Zona_Setor,UF,Nome_Contato,Telefone_Comercial,Telefone_Celular,Telefone_Recado,Email,Status,Obs,Data_Registro,ClienteID")] Endereco endereco)
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

            if (id != endereco.IdEndereco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.IdEndereco))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", endereco.ClienteID);
            return View(endereco);
        }

        // GET: Enderecos/Delete/5
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

            var endereco = await _context.Endereco
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.IdEndereco == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Enderecos/Delete/5
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

            var endereco = await _context.Endereco.FindAsync(id);
            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
            return _context.Endereco.Any(e => e.IdEndereco == id);
        }
    }
}
