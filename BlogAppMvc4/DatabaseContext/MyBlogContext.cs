using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BlogAppMvc4.Models.User;
using BlogAppMvc4.Models.Opinion;

namespace BlogAppMvc4.DatabaseContext
{
    public class MyBlogContext : DbContext
    {
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Register> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}