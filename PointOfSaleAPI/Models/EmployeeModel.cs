namespace PointOfSaleAPI.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? HireDate { get; set; }
        public int ManagerId { get; set; }
        public string? JobTitle { get; set; }
        public virtual ICollection<OrderModel> OrderModels { get; set; }

    }
}
