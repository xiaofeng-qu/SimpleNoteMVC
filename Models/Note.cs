using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SimpleNote.Models
{
    public class Note
    {
        public int Id { get; set; }
        
        [AllowHtml]
        public string Content { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}