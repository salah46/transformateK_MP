using System.ComponentModel.DataAnnotations;
namespace transformatek_MP.Models
{
    public class Resultes
    {
        //this is the ID
        [Key]
         public int Result_Id { get; set; }
        public string Mesuretype { get; set; }
        public string Values { get; set; } //convert to json??
        public Agent Agent { get; set; }
        public Affectation Affectation { get; set; }
        public DateTime Date { get; set; }

    }
}