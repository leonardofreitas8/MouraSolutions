using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MouraExpress.Controllers;
using MouraSolutionsWeb.Data;
using MouraSolutionsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouraSolutionsWeb.Controllers
{
    public class PacientesController : Controller
    {
        private readonly MouraExpressContext _context;

        public PacientesController(MouraExpressContext context)
        {
            _context = context;
        }

        // GET: Pacientes
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

            var mouraExpressContext = _context.Paciente.Include(p => p.pedido);
            return View(await mouraExpressContext.ToListAsync());

        }

        public void StatusProtId(object selectedStatusProt = null)
        {
            var protocoloStatusQuery = from p in _context.StatusProtocolo
                                       orderby p.Status
                                       select p;

            ViewBag.statusProtocolo = new SelectList(protocoloStatusQuery.AsNoTracking(), "IdStatus", "Status", selectedStatusProt);
        }



        // GET: Pacientes/Details/5
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

            var paciente = await _context.Paciente
                .Include(p => p.pedido).ThenInclude(p => p.Pacientes)/*.ThenInclude(pr => pr.statusProtocolo)*/
                .FirstOrDefaultAsync(m => m.IdPaciente == id);



            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);

        }

        // GET: Pacientes/Create
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

            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id");
            StatusProtId();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,NomePaciente,Protocolo,ConfMoto,ConfClinica,ConfEscritorio,Tma,Obs,statusProtocolo,PedidoId")] Paciente paciente)
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
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", paciente.PedidoId);
            StatusProtId();
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
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

            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }


            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", paciente.PedidoId);
            StatusProtId();

            return View(paciente);
        }



        [HttpPost]
        public ActionResult SalvaAlteraPaciente(List<Paciente> pacientes)
        {
            //StatusProtId();
            if (pacientes.Count() != 0)
            {
                int countEntradaRealizada = 0;
                              

                foreach (Paciente pac in pacientes)
                {
                    Paciente paciente = _context.Paciente.Find(pac.IdPaciente);
                    //paciente.NomePaciente = pac.NomePaciente;
                    paciente.Protocolo = pac.Protocolo;
                    paciente.ConfMoto = pac.ConfMoto;
                    paciente.ConfClinica = pac.ConfClinica;
                    paciente.ConfEscritorio = pac.ConfEscritorio;
                    paciente.Obs = pac.Obs;

                    if (paciente.Protocolo == paciente.ConfMoto)
                    {
                        paciente.ConfEscritorio = "Retirada realizada";
                        countEntradaRealizada ++;
                    }

                }
                
                _context.SaveChanges();                

                int qtdPac = 0;                

                foreach (Paciente paci in pacientes)
                {
                    if (pacientes.Count() > 0)
                    {
                        qtdPac++;
                    }
                }

                if(countEntradaRealizada == qtdPac)
                {
              
                    
                }
                
            }

            return RedirectToAction("Index", "Pedidos");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,NomePaciente,Protocolo,ConfMoto,ConfClinica,ConfEscritorio,Tma,Obs,statusProtocolo,PedidoId")] Paciente paciente, List<Paciente> pacientes)
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

            if (id != paciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {

                    _context.Update(paciente);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.IdPaciente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction("Details", "Pedidos", new { id = id});/*RedirectToAction(nameof(Index));*/

                return RedirectToAction("Details", new RouteValueDictionary(
                                  new { Pacientes = _context.Paciente, action = "Details", id = id }));
            }

            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", paciente.PedidoId);
            StatusProtId();
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
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

            var paciente = await _context.Paciente
                .Include(p => p.pedido)
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
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

            var paciente = await _context.Paciente.FindAsync(id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.IdPaciente == id);
        }


    }
}

