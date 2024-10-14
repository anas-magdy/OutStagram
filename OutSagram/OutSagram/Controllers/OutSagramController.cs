using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OutSagram.Models;
namespace OutSagram.Controllers
{
    public class OutSagramController : Controller
    {
        // GET: OutSagram
        DB db = new DB();
        public ActionResult regeregistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult regeregistration(user u)
        {
            if(ModelState.IsValid)
            {
                db.user.Add(u);
                db.SaveChanges();
                return RedirectToAction("profile",u);
            }
            else
            {
                return View(u);
            }
        }

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(logindata lo)
        {
            user s = db.user.Where(n => n.email == lo.email && n.password==lo.password).FirstOrDefault();
            if(s!=null)
            {
                Session.Add("userid", s.Id);
                return RedirectToAction("profile",new {id=s.Id,name=s.userName});
            }
            else
            {
                return View();
            }

        }

        public ActionResult home(int id)
        {
            friendRelation fr = db.friendRelation.Where(n => n.Id == id).FirstOrDefault();
            return View();
        }

        public ActionResult profile(int id,string name)
        {
            List<post> p = db.post.Where(n => n.autherID == id).ToList();
            ViewBag.idss = id;
            ViewBag.nme = name;
            return View(p);
        }
        public ActionResult create(int id)
        {
            ViewBag.st = id;
            return View();
        }

        [HttpPost]
        public ActionResult create(post s,HttpPostedFileBase imagee)
        {
            imagee.SaveAs(Server.MapPath("~/images/" + imagee.FileName));
            ViewBag.na = "~/images/";
            s.photo = imagee.FileName;
            user d = db.user.Where(n=>n.Id==s.autherID).FirstOrDefault();
            db.post.Add(s);
            db.SaveChanges();
            return RedirectToAction("profile",new {id=s.autherID,name=d.userName});
        }


        public ActionResult welcome()
        {
            return View();
        }
    }
}
