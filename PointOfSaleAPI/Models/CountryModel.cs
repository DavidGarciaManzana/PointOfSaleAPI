namespace PointOfSaleAPI.Models
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public virtual ICollection<LocationModel> LocationModels { get; set; }
    
}
}
