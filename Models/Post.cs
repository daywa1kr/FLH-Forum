using System.ComponentModel.DataAnnotations;

namespace FirstCoreSolution.Models;

public class Post{
    public int Id{get; set;}

    [Required(ErrorMessage="Please fill the header")]
    public string? Heading{get; set;}
    [Required(ErrorMessage="Please fill the body")]
    public string? Body{get; set;}
    public DateTime Date{get; set;} 
    public int Rating{get; set;}
    public IList<Answer> Answers{get; set;}=null!;
}