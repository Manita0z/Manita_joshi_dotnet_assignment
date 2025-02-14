using manita_dotnet_assignment.Data;

namespace manita_dotnet_assignment.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }
    }
}
