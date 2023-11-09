using System.ComponentModel.DataAnnotations;
namespace transformatek_MP.Models
{
    public class  Affectation
    {
        [Key]
        public string? Affectation_ID { get; set; } //id of Affectation
        public Admin Admin { get; set; } 
        public Agent Agent { get; set; } // id of agent

        
        
    }
}