using Microsoft.AspNetCore.Mvc;
using manita_dotnet_assignment.Data;
using Microsoft.EntityFrameworkCore;  // Make sure this is included for async methods
using System.Linq;
using System.Threading.Tasks;

namespace manita_dotnet_assignment.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Returns a paginated list of orders
        public async Task<IActionResult> OrdersView(int pageIndex = 1)
        {
            const int pageSize = 10; // Number of items per page

            // Ensure pageIndex is not less than 1
            pageIndex = pageIndex < 1 ? 1 : pageIndex;

            var ordersQuery = _context.Orders.AsQueryable();

            // Get the paginated list asynchronously
            var paginatedOrders = await PaginatedList<Order>.CreateAsync(ordersQuery, pageIndex, pageSize);

            // Handle case where there are no orders
            if (!paginatedOrders.Any())
            {
                ViewBag.Message = "No orders found.";
            }

            // Handle case where pageIndex exceeds total pages
            if (pageIndex > paginatedOrders.TotalPages)
            {
                return RedirectToAction("OrdersView", new { pageIndex = paginatedOrders.TotalPages });
            }

            // Pass the paginated list to the view
            return View(paginatedOrders);
        }
    }
}
