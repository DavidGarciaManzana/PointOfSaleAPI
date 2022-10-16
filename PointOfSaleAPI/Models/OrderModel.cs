namespace PointOfSaleAPI.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public int SalesManId { get; set; }
        public DateTime OrderDate { get; set; }
        public int GrandTotal { get; set; }
        public virtual CustomerModel CustomerModels { get; set; }
        public virtual EmployeeModel EmployeeModels { get; set; }
        public virtual ICollection<OrderItemModel> OrderItemModels { get; set; }
    }
}
