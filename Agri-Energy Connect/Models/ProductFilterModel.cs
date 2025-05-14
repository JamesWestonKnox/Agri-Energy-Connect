namespace Agri_Energy_Connect.Models
{
    public class ProductFilterModel
    {
        public List<Product> Products { get; set; } = new();
        public string SelectedCategory { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<string> Categories { get; set; } = new List<string>
        {
            "Solar energy", "Wind energy", "Bio energy", "Electric machinery", "Sustainable farming materials"
        };
    }
}
