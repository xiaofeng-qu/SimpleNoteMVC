using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleNote.Models
{
    public class Rememberme
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        [StringLength(20)]
        public string AuthentificatorOne { get; set; }
        [StringLength(64)]
        public string AuthentificatorTwo { get; set; }
        public DateTime Expires { get; set; }
    }
}