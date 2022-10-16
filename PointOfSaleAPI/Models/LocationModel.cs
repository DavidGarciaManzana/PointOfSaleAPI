namespace PointOfSaleAPI.Models
{
    public class LocationModel
    {
        public int LocationId { get; set; }
        public string? Address { get; set; }
        public int? PostalCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int CountryId { get; set; }
        public virtual ICollection<WarehouseModel> WarehouseModels { get; set; }
        public virtual CountryModel CountryModels { get; set; }

    }
}
