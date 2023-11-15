using System.ComponentModel.DataAnnotations;
namespace transformatek_MP.Models
{public class Agent
{
    public string Name_Agent { get; set; }
    public string Famillyname_Agent { get; set; }
    // this is the ID
    [Key]
    public int Id_Agent { get; set; }

    public ICollection<Resultes> Resultes {get;set;}
    public ICollection<Affectation> Affectations {get;set;}

}}