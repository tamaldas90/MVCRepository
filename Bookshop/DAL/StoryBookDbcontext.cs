using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bookshop.Models;

namespace Bookshop.DAL
{
    public class StoryBookDbcontext : DbContext
    {

        public StoryBookDbcontext()
        {

        }

        public DbSet<StoryBook> Books { get; set; }
    }
}