namespace manita_dotnet_assignment.Data
{
    public class OrderIndexViewModel
    {
        public required IEnumerable<Order> Orders { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
