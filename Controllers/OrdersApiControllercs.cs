using Microsoft.AspNetCore.Mvc;
using manita_dotnet_assignment.Data;
namespace manita_dotnet_assignment.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,TotalAmount,Item,DeliveryDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;  // Set the current date
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(OrdersView));  // Redirect to orders list after adding
            }
            return View(order);
        }

        // GET: Orders/OrdersView
        public async Task<IActionResult> OrdersView(int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.Orders.AsQueryable();

            // Create the paginated list
            var paginatedList = await PaginatedList<Order>.CreateAsync(query, pageIndex, pageSize);

            return View(paginatedList);
        }

        // Other actions (e.g., Details, Edit, Delete) go here...
    }
}
