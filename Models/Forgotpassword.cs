using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleNote.Models
{
    public class Forgotpassword
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        [StringLength(36)]
        public string Activation { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
    }
}