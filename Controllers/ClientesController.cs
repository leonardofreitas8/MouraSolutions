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
    public class ClientesController : Controller
    {
        private readonly MouraExpressContext _context;

        public ClientesController(MouraExpressContext context)
        {
            _context = context;
        }


        // GET: Clientes
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


            //var viewModel = new ClienteIndexData();
            //viewModel.Clientes = await _context.Clientes
            //    .Include(i => i.Pedidos)
            //    .ThenInclude(p => p.Pacientes)
            //    .OrderBy(i => i.Nome)
            //    .ToListAsync();

            //---------------
            var mouraExpressContext = _context.Cliente
                            .Include(s => s.Enderecos)
                            .Include(p => p.Pedidos)
                                .ThenInclude(p => p.Pacientes)
                            .Include(c => c.Motoboy);

            //var mouraExpressContext = from s in _context.Cliente select s;

            //if (ViewBag.Role != "Admin")
            //{
            //    mouraExpressContext = mouraExpressContext                    
            //        .Include(p => p.Pedidos).ThenInclude(p => p.Pacientes)
            //    .Include(c => c.Motoboy).Where(s => s.Pedidos);

            //    mouraExpressContext = mouraExpressContext.Where(s => s.)
            //}



            //mouraExpressContext = from c in _context.StatusPedido
            //                      orderby c.Status != "Cancelado"
            //                      select c;

            return View(await mouraExpressContext.ToListAsync());

            //return View(viewModel);
        }

        // GET: Clientes/Details/5
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

            var cliente = await _context.Cliente.Include(s => s.Enderecos)
                .Include(s => s.Pedidos).ThenInclude(p => p.Pacientes)
                .Include(c => c.Motoboy)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
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

            //Criar combobox
            //ViewData["MotoboyId"] = new SelectList(_context.Motoboys, "MotoboyId", "MotoboyId");
            PopulateMotoboyDropDownList();

            return View();
        }

        public void PopulateMotoboyDropDownList(object selectedCliente = null)
        {
            var clienteQuery = from c in _context.Motoboy
                               orderby c.Nome
                               select c;

            ViewBag.MotoboyId = new SelectList(clienteQuery.AsNoTracking(), "MotoboyId", "Nome", selectedCliente);
        }

        public void PopulateProtocoloDropDownList(object selectedProtocolo = null)
        {
            var clienteQuery = from c in _context.StatusProtocolo
                               orderby c.Status
                               select c;

            ViewBag.MotoboyId = new SelectList(clienteQuery.AsNoTracking(), "IdStatus", "Status", selectedProtocolo);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nome,Telefone,DataCadastro,PerfilCliente,CPF,CNPJ,MotoboyId")] Cliente cliente)
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
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateMotoboyDropDownList();
            //ViewData["MotoboyId"] = new SelectList(_context.Motoboy, "MotoboyId", "MotoboyId", cliente.MotoboyId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
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

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            PopulateMotoboyDropDownList();
            //ViewData["MotoboyId"] = new SelectList(_context.Motoboy, "MotoboyId", "MotoboyId", cliente.MotoboyId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,Telefone,DataCadastro,PerfilCliente,CPF,CNPJ,MotoboyId")] Cliente cliente)
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

            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            PopulateMotoboyDropDownList();
            //ViewData["MotoboyId"] = new SelectList(_context.Motoboy, "MotoboyId", "MotoboyId", cliente.MotoboyId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
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

            var cliente = await _context.Cliente
                .Include(c => c.Motoboy)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
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

            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }

        //public string DecoderQRCode()
        //{

        //    var barcodeReader = new BarcodeReader();

        //    // create an in memory bitmap
        //    var barcodeBitmap = (Bitmap)Bitmap.FromFile(@"C:\Users\Leo Miguel\Desktop\qrimage.bmp");

        //    // decode the barcode from the in memory bitmap
        //    var barcodeResult = barcodeReader.Decode(barcodeBitmap);

        //    // output results to console
        //    //Console.WriteLine($"Decoded barcode text: {barcodeResult?.Text}");
        //    //Console.WriteLine($"Barcode format: {barcodeResult?.BarcodeFormat}");

        //    return barcodeResult?.Text;
        //}

    }
}
