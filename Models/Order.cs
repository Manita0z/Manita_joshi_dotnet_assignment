using System;

namespace manita_dotnet_assignment.Data
{
    public class Order
    {
        public int OrderId { get; set; }

        public required string CustomerName { get; set; }  // Customer's name (required)
        public decimal TotalAmount { get; set; }            // Total amount for the order

        public required string Item { get; set; }           // List of items in the order (required)

        public DateTime? DeliveryDate { get; set; }          // Delivery date for the order

        public DateTime OrderDate { get; set; } = DateTime.Now; // Default current date
    }
}
