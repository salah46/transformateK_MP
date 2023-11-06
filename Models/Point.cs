using System.ComponentModel.DataAnnotations;
namespace transformatek_MP.Models
{
    public class Point
    {
        [Key]
        public string? Point_ID { get; set; } //Id of Point
        public float Lat { get; set; }
        public float Lang { get; set; }

        public string Affectation_ID { get; set; }//Foreign key prop
        public Affectation Affectation { get; set; }

    }
}