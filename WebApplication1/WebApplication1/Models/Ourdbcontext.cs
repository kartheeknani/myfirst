using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Ourdbcontext:DbContext
    {
        public DbSet<useraccount> useraccount { get; set; }
    }
}