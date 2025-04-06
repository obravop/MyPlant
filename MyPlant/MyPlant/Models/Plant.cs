namespace MyPlant.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? WateringDate { get; set; }
        public string ImageBase64 { get; set; }
        public PlantType PlantType { get; set; }
        public PlantLocation PlantLocation { get; set; }
    }
}
