using SimpleNote.Context;
using SimpleNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleNote.Controllers
{
    public class NoteController : Controller
    {
        private SimpleNoteContext _context;

        public NoteController()
        {
            _context = new SimpleNoteContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            int userId;
            if(Session["userId"] != null)
            {
                userId = Convert.ToInt32(Session["userId"].ToString());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            List<Note> notes = _context.Notes.Where(n => n.UserId == userId).OrderByDescending(n => n.ModifiedDate).ToList();
            return View(notes);
        }

        [HttpPost]
        public ActionResult Update(string note, int id)
        {
            if (id == 0)
            {
                Note newNote = new Note();
                newNote.CategoryId = 1;
                newNote.Content = note;
                newNote.ModifiedDate = DateTime.Now;
                newNote.UserId = Convert.ToInt32(Session["userId"].ToString());
                _context.Notes.Add(newNote);
            }
            else
            {
                var noteInDb = _context.Notes.Where(n => n.Id == id).SingleOrDefault();
                noteInDb.Content = note;
                noteInDb.ModifiedDate = DateTime.Now;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public void Delete(int id)
        {
            var note = _context.Notes.Where(n => n.Id == id).SingleOrDefault();
            _context.Notes.Remove(note);
            _context.SaveChanges();          
        }
    }
}