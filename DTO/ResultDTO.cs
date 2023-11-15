using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ResulteDTO
{
    [Required]
    public int Id_Agent { get; set; }
    [Required]
    public int Id_Affection { get; set; }
    public string Result_Id { get; set; }
    public DateTime Date { get; set; }
    [Required]
    public string Mesuretype { get; set; }
    [Required]
    public string Values { get; set; }
}