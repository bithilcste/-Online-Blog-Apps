using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogAppMvc4.Models.Opinion;
using BlogAppMvc4.DatabaseContext;
using BlogAppMvc4.Models.User;

namespace BlogAppMvc4.Controllers
{
    public class CommentsController : Controller
    {
        private MyBlogContext db = new MyBlogContext();
        // GET: /Comments/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Reply()
        {
            return PartialView("_Reply", new BlogAppMvc4.Models.Opinion.Comment());
        }


        [HttpPost]
        [ActionName("ReplyView")]
        public ActionResult Reply(Comment comment, int id)
        {
            comment.OpnID = id;
            var ts = DateTime.Now;
            comment.infodate = ts;
            //var em = User.Identity.Name;
            //comment.Email = em;

            var em = User.Identity.Name;
            Register register = db.Users.Single(usr => usr.Email == em);
            var usrid = register.UserID;
            comment.UserID = usrid;

            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("ReplyView", "Comments");
            }
            return View("_Reply", comment);
        }

        public ActionResult ReplyView(int id)
        {
            
            ReplyView replyView = new ReplyView();
            replyView.opinionView = (from o in db.Opinions.Where(o => o.OpnID == id) select o).ToList();
            replyView.commentView = (from c in db.Comments.Where(c => c.OpnID == id) select c).ToList();
            replyView.opinModelView = (from o in db.Opinions
                                       join u in db.Users on o.UserID equals u.UserID
                                       orderby u.UserID
                                       where o.OpnID==id
                                       select new OpinModel { opin = o, regis = u }).ToList();

            replyView.comtModelView = (from c in db.Comments
                                       join u in db.Users on c.UserID equals u.UserID
                                       orderby c.infodate
                                       where  c.OpnID == id
                                       select new ComtModel { comt = c, regis = u });

            replyView.createComment = new BlogAppMvc4.Models.Opinion.Comment();
            return View(replyView);
        }      
    }
}
