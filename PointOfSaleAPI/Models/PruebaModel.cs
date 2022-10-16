namespace PointOfSaleAPI.Models
{
    public class PruebaModel
    {
        public PruebaModel(string name, string status)
        {
            Name = name;
            Status = status;
        }

        public string Name { get; set; }
        public string Status { get; set; }
    }
}
