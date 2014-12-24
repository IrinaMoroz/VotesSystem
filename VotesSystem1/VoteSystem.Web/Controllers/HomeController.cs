using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using VoteSystem.Data;
using VoteSystem.Data.DAL;

namespace VoteSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private VoteSystemContext db = new VoteSystemContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Votes.ToList());
        }
    }
}