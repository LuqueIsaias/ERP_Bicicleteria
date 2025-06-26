using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERP_Bicicleteria.Data;
using ERP_Bicicleteria.Models;
using ERP_Bicicleteria.Services;


namespace ERP_Bicicleteria.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderDetailService _orderDetailService; //Servicio inyectado para manejar detalles de la orden

        // Constructor que inyecta el contexto y el servicio de detalles de la orden
        public OrdersController(ApplicationDbContext context, OrderDetailService orderDetailService) 
        {
            _context = context;
            _orderDetailService = orderDetailService;
        }
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Order.Include(o => o.Client).Include(o => o.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            // Cargar listas para dropdowns (empleados, clientes y productos)
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Name"); // Muestra el nombre del cliente
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName"); // Muestra el nombre del empleado
            ViewData["ProductList"] = new SelectList(_context.Products, "Id", "Name"); // Para los detalles

            return View(new OrderViewModel { OrderDate = DateTime.Today }); // Fecha predeterminada: hoy
        }


        // POST: Orders/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Crear la orden principal
                var order = new Order
                {
                    EmployeeId = model.EmployeeId,
                    ClientId = model.ClientId,
                    OrderDate = model.OrderDate
                };

                _context.Order.Add(order);
                await _context.SaveChangesAsync(); // Guardar para obtener el OrderId

                // Añadir detalles usando el servicio
                _orderDetailService.AddOrderDetails(order, model.OrderDetails);
                await _context.SaveChangesAsync(); // Guardar detalles

                return RedirectToAction(nameof(Index));
            }

            // Si hay errores, recargar dropdowns
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Name", model.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", model.EmployeeId);
            ViewData["ProductList"] = new SelectList(_context.Products, "Id", "Name");
            return View(model);
        }



        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientId", order.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", order.EmployeeId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,EmployeeId,ClientId,OrderDate")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            foreach (var key in ModelState.Keys)
            {
                foreach (var error in ModelState[key].Errors)
                {
                    Console.WriteLine($"Error en {key}: {error.ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientId", order.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", order.EmployeeId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
