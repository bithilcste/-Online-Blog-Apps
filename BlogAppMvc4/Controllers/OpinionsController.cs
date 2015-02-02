using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogAppMvc4.DatabaseContext;
using BlogAppMvc4.Models.Opinion;
using PagedList;
using PagedList.Mvc;
using BlogAppMvc4.Models.User;

namespace BlogAppMvc4.Controllers
{
    public class OpinionsController : Controller
    {
        private MyBlogContext db = new MyBlogContext();
        // GET: /Opinions/

        public ActionResult Index(int? page)
        {
            IPagedList<Opinion> opinion = db.Opinions.ToList().OrderByDescending(s=>s.OpnID).ToPagedList(page ?? 1,3);
            return View(opinion);
        }
        // Two model join at single view
        public ActionResult OpinView(int? page)
        {
            var opinionView = from o in db.Opinions
                            join u in db.Users on o.UserID equals u.UserID
                            orderby u.UserID
                            select new OpinModel { opin = o, regis = u };
            return View(opinionView.ToList().OrderByDescending(s=>s.opin.OpnID).ToPagedList(page ?? 1,3));
        }
        //
        public ActionResult Category(String opn)
        {
            //List<Opinion> catlist = db.Opinions.Where(opin => opin.Category == opn).ToList();
            //return View(catlist);

            var opinionView = from o in db.Opinions
                              join u in db.Users on o.UserID equals u.UserID
                              orderby u.UserID
                              where o.Category==opn
                              select new OpinModel { opin = o, regis = u };
            return View(opinionView);
        }

        public ActionResult Create()
        {
            Opinion op = new Opinion();

            var ts = DateTime.Now;
            op.infodate = ts;

            var em = User.Identity.Name;
            Register register = db.Users.Single(usr => usr.Email == em);
            var usrid = register.UserID;
            op.UserID = usrid;

            //var em = User.Identity.Name;
            //op.Email = em;

            return View(op);

        }
        [HttpPost]
        public ActionResult Create(Opinion opinion)
        {

            if (ModelState.IsValid)
            {
                db.Opinions.Add(opinion);
                db.SaveChanges();
                return RedirectToAction("OpinView");
            }
            return View(opinion);
        }
        public ActionResult SearchIndex(string searchString)
        {
            var opinionView = from o in db.Opinions
                              join u in db.Users on o.UserID equals u.UserID
                              orderby u.UserID
                              select new OpinModel { opin = o, regis = u };

            if(!String.IsNullOrEmpty(searchString))
            {
                opinionView = opinionView.Where(s => s.opin.Title.Contains(searchString));

            }

            return View(opinionView);
        }
    }
}
