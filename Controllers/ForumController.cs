using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstCoreSolution.Models;
using FirstCoreSolution.Repos;

namespace FirstCoreSolution.Controllers;

public class ForumController : Controller{
    private IForumRepository repo{get; set;}
    public ForumController(IForumRepository _repo){
        repo=_repo;
    }

    public IActionResult Index(){
        return View(repo.GetPosts("rating"));
    }

    public IActionResult Recent(){
        return View(repo.GetPosts("date"));
    }

    public IActionResult ViewPost(int id){
        var x=repo.FindPost(id);
        if(x!=null)
            x.Answers=repo.GetAnswers(id);
        return View(x);
    }

    public IActionResult Upvote(int id) {
        repo.IncrementPostRating(id);
        return RedirectToAction("Index");
    }

    public IActionResult Downvote(int id) {
        repo.DecrementPostRating(id);
        return RedirectToAction("Index");
    }

    public IActionResult UpvoteInView(int id) {
        repo.IncrementPostRating(id);
        return RedirectToAction("ViewPost", repo.FindPost(id));
    }

    public IActionResult DownvoteInView(int id) {
        repo.DecrementPostRating(id);
        return RedirectToAction("ViewPost", repo.FindPost(id));
    }

    public IActionResult UpvoteAnswer(int id) {
        repo.IncrementAnswerRating(id);
        return RedirectToAction("ViewPost", repo.FindPostByAnswerId(id));
    }

    public IActionResult DownvoteAnswer(int id) {
        repo.DecrementAnswerRating(id);
        return RedirectToAction("ViewPost", repo.FindPostByAnswerId(id));
    }

    [HttpGet]
    public IActionResult AddPost(){
        return View();
    }

    [HttpPost]
    public IActionResult AddPost(Post p){
        if(p.Body==null || p.Heading==null){
            ViewBag.ErrorMessage="Please fill the required fields";
            return View();
        }
        ViewBag.ErrorMessage="";
        repo.AddPost(p);
        return RedirectToAction("Index");
    }

    public IActionResult AddAnswer(int id, string text){
        repo.AddAnswer(id, text);
        return RedirectToAction("ViewPost", repo.FindPost(id));
    }
}