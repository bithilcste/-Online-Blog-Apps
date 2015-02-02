using BlogAppMvc4.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogAppMvc4.Models.Opinion
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<MyBlogContext>
    {
        protected override void Seed(MyBlogContext context)
        {
            var opns = new List<Opinion> {
            new Opinion{Category="Movie",
                        Title="Troy",
                        Contents="Hi,This is movie about Great Warriors like Achilies,Hector etc.",
                        infodate=DateTime.Parse("2001-01-11"),
                       // Email="Achilies@gmail.com"
                        UserID=1
                         },
            new Opinion{Category="History",
                        Title="Troy",
                        Contents="Hi,This is movie about Great Warriors like Achilies,Hector etc.",
                        infodate=DateTime.Parse("2001-05-14"),
                     //   Email="Larry@Yahoo.com"
                        UserID=1
                         }
            };
            opns.ForEach(d => context.Opinions.Add(d));
        }
    }
}