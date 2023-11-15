

using System.ComponentModel.DataAnnotations;

namespace transformatek_MP.DTO
{


    public class AffectionDTO
    {
        public int Admin_ID { get; set; }
        [Required]
        public string Conseigner_ID { get; set; }
        public int Agent_ID { get; set; }
        public string Affectation_ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Point_ID { get; set; }
        [Required]
        public float Lang { get; set; }
        [Required]
        public float Lat { get; set; }
        [Required]
        public int Nb_Repetations { get; set; }
        [Required]
        public string Type_mesure { get; set; }
    }
}