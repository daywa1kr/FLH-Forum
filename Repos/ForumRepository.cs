using FirstCoreSolution.Models;
namespace FirstCoreSolution.Repos;

public class ForumRepository : IForumRepository{
    private AppDbContext ctx{get; set;}
    public ForumRepository(AppDbContext _ctx){
        ctx=_ctx;
    } 

    public IList<Post> GetPosts(string order){
        if(order.Equals("rating")){
            List<Post> l=ctx.Posts.OrderBy(m=>m.Rating).ToList();
            l.Reverse();
            return l;
        }
        else{
            List<Post> l=ctx.Posts.OrderBy(m=>m.Date).ToList();
            l.Reverse();
            return l;
        }
    }

    public IList<Answer> GetAnswers(int id){
        List<Answer> answers=ctx.Answers.Where(a=>a.PostId==id).OrderBy(a=>a.Rating).ToList();
        answers.Reverse();
        return answers;
    }

    public Post FindPost(int id){
        return ctx.Posts.Find(id);
    }

    public Answer FindAnswer(int id){
        return ctx.Answers.Find(id);
    }

    public Post FindPostByAnswerId(int id){
        return FindPost(FindAnswer(id).PostId);
    }


    public void AddPost(Post p)
    {
        p.Rating=0;
        p.Date=DateTime.Now;
        ctx.Posts.Add(p);
        ctx.SaveChanges();
    }

    public void AddAnswer(int id, string text)
    {
        ctx.Answers.Add(new Answer{
            PostId=id,
            Body=text,
            Rating=0,
            Date=DateTime.Now
        });
        ctx.SaveChanges();
    }

    public void IncrementPostRating(int id){
        var x=FindPost(id);
        x.Rating+=1;
        ctx.SaveChanges();
    }

    public void DecrementPostRating(int id){
        var x=FindPost(id);
        x.Rating-=1;
        ctx.SaveChanges();
    }

    public void IncrementAnswerRating(int id){
        var x=FindAnswer(id);
        x.Rating+=1;
        ctx.SaveChanges();
    }

    public void DecrementAnswerRating(int id){
        var x=FindAnswer(id);
        x.Rating-=1;
        ctx.SaveChanges();
    }

}