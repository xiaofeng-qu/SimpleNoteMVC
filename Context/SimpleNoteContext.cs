using SimpleNote.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleNote.Context
{
    public class SimpleNoteContext : DbContext
    {
        public SimpleNoteContext():base()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Forgotpassword> Forgotpassword { get; set; }
        public DbSet<Rememberme> Rememberme { get; set; }
    }
}