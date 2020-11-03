using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MouraSolutionsWeb.Data;
using MouraSolutionsWeb.Models;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MouraExpress.Controllers
{
    public class PedidosController : Controller
    {
        private readonly MouraExpressContext _context;


        public PedidosController(MouraExpressContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public IActionResult Index(string option, DateTime? DataInicio, DateTime? DataFinal,//string currentFilter,
                string searchString/*int? pageNumber*/)
        {
            var mouraExpressContext = _context.Pedido
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                    .ThenInclude(p => p.Cliente.Motoboy)
                .Include(p => p.Zona)
                .Include(p => p.statusPedido);

            if (HttpContext.Session.GetString("Usuario") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("Usuario").Trim(' ');
                ViewBag.Role = HttpContext.Session.GetString("Role").Trim(' ');
            }
            else
            {
                return RedirectToAction("Login", "SystemUsers");
            }

            var usuarioLogado = HttpContext.Session.GetString("Usuario").Trim(' ');
            var usuarioLogRole = HttpContext.Session.GetString("Role").Trim(' ');
                     

            var pedidos = from s in _context.Pedido select s;
            
            if (usuarioLogRole != "Admin")
            {

                if (ViewBag.Role == "Motoboy")
                {
                    pedidos = pedidos.OrderByDescending(p => p.DataPedidoRetirada)
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido);

                    pedidos = pedidos.Where(x => x.Cliente.Motoboy.Nome == usuarioLogado);
                    return View(pedidos.ToList());
                }
                else
                {
                    pedidos = pedidos.OrderByDescending(p => p.DataPedidoRetirada)
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido);

                    pedidos = pedidos.Where(s => s.Cliente.Nome == usuarioLogado);
                }
            }
            else if (option == "Nome")
            {
                pedidos = pedidos.OrderByDescending(p => p.DataPedidoRetirada)
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido);

                pedidos = pedidos.Where(x => x.Cliente.Nome == searchString);
                return View(pedidos.ToList());
            }
            else if (option == "Solicitante")
            {
                pedidos = pedidos.OrderByDescending(p => p.DataPedidoRetirada)
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido);

                pedidos = pedidos.Where(x => x.NomeSolicitante == searchString);
                return View(pedidos.ToList());
            }
            else if (option == "Motoboy")
            {
                pedidos = pedidos.OrderByDescending(p => p.DataPedidoRetirada)
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido);

                pedidos = pedidos.Where(x => x.Cliente.Motoboy.Nome == searchString);
                return View(pedidos.ToList());
            }
            else if (option == "Data")
            {
                pedidos = pedidos.OrderByDescending(p => p.DataPedidoRetirada)
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido);

                pedidos = pedidos.Where(x => x.DataPedidoRetirada >= DataInicio && x.DataPedidoRetirada <= DataFinal);
                return View(pedidos.ToList());
            }
            else if (option == "Status")
            {
                pedidos = pedidos.OrderByDescending(p => p.DataPedidoRetirada)
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido);

                pedidos = pedidos.Where(x => x.statusPedido.Status == searchString);
                return View(pedidos.ToList());
            }
            else
            {          
                pedidos = pedidos.OrderByDescending(p => p.DataPedidoRetirada)
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido);
                
                
                return View(pedidos.ToList());         
            }


            

            //where usuarioLogRole != "Admin" & s.Cliente.Nome == "usuarioLogado"

            //if (!String.IsNullOrEmpty(searchString))
            //{

            //    pedidos = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Pedido, StatusPedido>)pedidos.Where(s => s.Cliente.Nome.Contains(searchString));
            //    //|| s.Pedido.Contains(searchString)
            //    //|| s.NomeSolicitante.Contains(searchString));
            //}

            //switch (sortOrder)
            //{
            //    case "Date":
            //        pedidos = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Pedido, StatusPedido>)pedidos.OrderBy(s => s.DataPedidoRetirada);
            //        break;
            //    default:
            //        pedidos = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Pedido, StatusPedido>)pedidos.OrderByDescending(s => s.DataPedidoRetirada);
            //        break;
            //}

            //int pageSize = 4;
            //return View(await PaginatedList<Pedido>.CreateAsync(pedidos.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(pedidos.ToList());
        }

        // GET: Pedidos/Details/5
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

            var pedido = await _context.Pedido
                    .Include(p => p.Pacientes)
                .Include(p => p.Cliente).ThenInclude(p => p.Enderecos)
                        .ThenInclude(p => p.Cliente.Motoboy)
                    .Include(p => p.Zona)
                    .Include(p => p.statusPedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }



            return View(pedido);
        }

        // GET: Pedidos/Create
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

            PopulateClienteDropDownList();
            PopulateZonaId();
            StatusPedidoId();

            return View();
        }

        public void PopulateClienteDropDownList(object selectedCliente1 = null)
        {
            var usuarioCliente = HttpContext.Session.GetString("Usuario").Trim(' ');
            var role = HttpContext.Session.GetString("Role").Trim(' ');

            if (role != "Motoboy")
            {

                var clienteQuery = from c in _context.Cliente
                                   orderby c.Nome
                                   where c.Nome == usuarioCliente
                                   select c;

                ViewBag.ClienteId = new SelectList(clienteQuery.AsNoTracking(), "ClienteId", "Nome", selectedCliente1);
            }
            else
            {
                var clienteQuery = from c in _context.Cliente
                                   orderby c.Nome
                                   select c;

                ViewBag.ClienteId = new SelectList(clienteQuery.AsNoTracking(), "ClienteId", "Nome", selectedCliente1);
            }
        }

        public void PopulateZonaId(object selectedCliente2 = null)
        {
            var clienteQuery = from c in _context.Zona
                               orderby c.ZonaNome
                               select c;

            ViewBag.ZonaId = new SelectList(clienteQuery.AsNoTracking(), "IdZona", "ZonaNome", selectedCliente2);
        }

        public void StatusPedidoId(object selectedCliente3 = null)
        {

            if (ViewBag.Role == "Cliente")
            {
                var clienteQuery = from c in _context.StatusPedido
                                   where c.Status == "Novo"
                                   orderby c.Status
                                   select c;

                ViewBag.statusPedidoId = new SelectList(clienteQuery.AsNoTracking(), "IdStatus", "Status", selectedCliente3);
            }
            else
            {
                var clienteQuery = from c in _context.StatusPedido
                                   orderby c.Status
                                   select c;

                ViewBag.statusPedidoId = new SelectList(clienteQuery.AsNoTracking(), "IdStatus", "Status", selectedCliente3);
            }


        }

        public void StatusPedidoClienteEdita(object selectedClienteEdita = null)
        {
            var clienteQuery = from c in _context.StatusPedido
                               orderby c.Status
                               select c;

            ViewBag.statusPedidoId = new SelectList(clienteQuery.AsNoTracking(), "IdStatus", "Status", selectedClienteEdita);
        }

        public ActionResult PacienteMethod([Bind("Pacientes")] Pedido pedido)
        {
            pedido.Pacientes.Add(new Paciente());
            return PartialView("Pacientes", pedido);
        }

        public ActionResult PacientesChange()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,DataPedidoRetirada,NomeSolicitante,DataRetirada,DataEntrega,statusPedidoId,CEP,Obsercao,ZonaId,Pacientes")] Pedido pedido)
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
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateClienteDropDownList();
            PopulateZonaId();
            StatusPedidoId();

            return View(pedido);
        }

        // GET: Pedidos/Edit/5
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

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            PopulateClienteDropDownList();
            PopulateZonaId();
            StatusPedidoClienteEdita();
 
            return View(pedido);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,DataPedidoRetirada,NomeSolicitante,DataRetirada,DataEntrega,statusPedidoId,CEP,Obsercao,ZonaId,Pacientes")] Pedido pedido)
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

            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   
                    
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
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

            PopulateClienteDropDownList();
            PopulateZonaId();
            StatusPedidoId();

            return View(pedido);
        }

        // GET: Pedidos/Delete/5
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

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Zona)
                .Include(p => p.statusPedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
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

            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.Id == id);
        }



    }


}

