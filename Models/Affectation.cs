using System.ComponentModel.DataAnnotations;
namespace transformatek_MP.Models
{
    public class  Affectation
    {
        [Key]
        public string? Affectation_ID { get; set; } //id of Affectation
        public Admin Admin { get; set; } 
        public Agent Agent { get; set; } // id of agent
        public string Point_ID { get; set; } //Foreign key prop
        public Point Point { get; set; } //id of point
        public string Consigner_ID { get; set; }//Foreign key prop
        public Consigner Consigner { get; set; } // id of Consigner

        
        
    }
}