namespace FirstCoreSolution.Models;

public class Answer{
    public int Id{get; set;}
    public string? Body{get; set;}
    public DateTime Date{get; set;} 
    public int Rating{get; set;}
    public Post? Post{get; set;}
    public int PostId{get; set;}
}