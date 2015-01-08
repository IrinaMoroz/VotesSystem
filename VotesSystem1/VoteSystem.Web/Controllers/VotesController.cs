using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VoteSystem.Data;
using VoteSystem.Data.DAL;
using VoteSystem.Data.Models;

namespace VoteSystem.Web.Controllers
{
    public class VotesController : Controller
    {
        private VoteSystemContext db = new VoteSystemContext();

        // GET: Votes
        public ActionResult Index()
        {
           
            return View(db.Votes.ToList());
        }

        // GET: Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            VoteModel vm = new VoteModel();
            vm.Categories = db.Categories.ToList<Category>();
            return View(vm);
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = 
            "ID,Name,Description,IsPrivate,EmailRecipient,DateFinish,CategoryID")] Vote vote, string[] questions)
        {
            try
            {            
                if (ModelState.IsValid)
                {
                    Console.WriteLine(questions);
                    vote.LastModifiedDate = DateTime.Now;
                    vote.Category = db.Categories.Find(vote.CategoryID);                    
                    db.Votes.Add(vote);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(vote);
        }

        // GET: Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }

            return View(new VoteModel(vote, db.Categories.ToList<Category>()));
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,IsPrivate,EmailRecipient,DateFinish,CategoryID")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                vote.LastModifiedDate = DateTime.Now;
                vote.Category = GetCategoryById(vote.CategoryID); 
                db.Entry(vote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vote);
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vote vote = db.Votes.Find(id);
            db.Votes.Remove(vote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private Category GetCategoryById(int selectedCategoryID)
        {
            var category = from d in db.Categories
                                 where d.ID == selectedCategoryID
                                   select d;
            if (category == null)
                throw new ArgumentException("category not found");

            return category.ToList<Category>()[0];
             
        } 
    }
}
