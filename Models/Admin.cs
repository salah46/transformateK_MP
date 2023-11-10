using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace transformatek_MP.Models
{

    public class Admin
    {
        [Key]
        public int? Admin_ID { get; set; } // id of admin 
        public string Name_Admin { get; set; }
        public string Famillyname_Admin { get; set; }

       public ICollection<Affectation> Affectations {get;set;} 
    }
}