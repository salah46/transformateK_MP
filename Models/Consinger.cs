using System.ComponentModel.DataAnnotations;
namespace transformatek_MP.Models
{
    public class Consigner
    {
        [Key]
        public string? Consigner_ID { get; set; } //ID
        public string Type_mesure { get; set; }
        public int Nb_Repetations { get; set; }

        public int Affectation_ID { get; set; }//Foreign key prop
        public Affectation Affectation { get; set; } //ID




    }
}