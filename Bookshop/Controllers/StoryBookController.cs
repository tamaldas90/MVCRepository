using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Bookshop.DAL;
using Bookshop.Models;


namespace Bookshop.Controllers
{
    public class StoryBookController : Controller
    {    



    private IBookRepository _bookRepository;
          public StoryBookController()
       {
          this._bookRepository = new BookRepository(new StoryBookDbcontext());
        }
        //
        // GET: /StoryBook/

        public ActionResult Index()
        {
            var books = from book in _bookRepository.GetBooks()
                        select book;
            
            return View(books);
        }

        public ViewResult Details(int id)
        {
            StoryBook student = _bookRepository.GetBookByID(id);
            return View(student);
        }


        public ActionResult Create()
        {
            return View(new StoryBook());
        }
        [HttpPost]
        public ActionResult Create(StoryBook book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.InsertBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                  "Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }

        /*public ActionResult Edit(int id)
        {
            StoryBook book = _bookRepository.GetBookByID(id);

            return View(book);
        }
        [HttpPost]*/
        public ActionResult Edit(StoryBook book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.UpdateBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, " +
                  "and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, " +
                  "and if the problem persists see your system administrator.";
            }
            StoryBook book = _bookRepository.GetBookByID(id);
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                StoryBook book = _bookRepository.GetBookByID(id);
                _bookRepository.DeleteBook(id);
                _bookRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }



    }
}
