namespace manita_dotnet_assignment.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            // Check if database is created
            if (context.Database.EnsureCreated())
            {
                // Check if there are any orders already in the database
                if (!context.Orders.Any())
                {
                    // Seed Orders
                    context.Orders.AddRange(
                        new Order
                        {
                            OrderDate = DateTime.Now.AddDays(-5),
                            CustomerName = "John Doe",
                            TotalAmount = 150.75m,
                            Item = "Laptop"  // Add a value for the Item property
                        },
                        new Order
                        {
                            OrderDate = DateTime.Now.AddDays(-3),
                            CustomerName = "Jane Smith",
                            TotalAmount = 200.00m,
                            Item = "Smartphone"  // Add a value for the Item property
                        },
                        new Order
                        {
                            OrderDate = DateTime.Now.AddDays(-1),
                            CustomerName = "Alice Johnson",
                            TotalAmount = 300.50m,
                            Item = "Headphones"  // Add a value for the Item property
                        }
                    );

                    // Save changes to the database
                    context.SaveChanges();
                }
            }
        }
    }
}
