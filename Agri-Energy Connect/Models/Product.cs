namespace Agri_Energy_Connect.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}
