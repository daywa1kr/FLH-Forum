using FirstCoreSolution.Models;
namespace FirstCoreSolution.Repos;

public interface IForumRepository{
    public IList<Post> GetPosts(string order);
    public IList<Answer> GetAnswers(int id);
    public Post FindPost(int id);
    public Answer FindAnswer(int id);
    public Post FindPostByAnswerId(int id);
    public void AddPost(Post p);
    public void AddAnswer(int id, string text);
    public void IncrementPostRating(int id);
    public void DecrementPostRating(int id);
    public void IncrementAnswerRating(int id);
    public void DecrementAnswerRating(int id);
}