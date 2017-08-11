using SimpleNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleNote.ViewModels
{
    public class NoteFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Note Note { get; set; }
    }
}