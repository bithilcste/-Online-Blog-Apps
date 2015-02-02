using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAppMvc4.Models.Opinion
{
    public class ReplyView
    {
        public IEnumerable<Opinion> opinionView { get; set; }
        public IEnumerable<Comment> commentView { get; set; }
        public IEnumerable<OpinModel> opinModelView { get; set; }
        public IEnumerable<ComtModel> comtModelView { get; set; }
        public Comment createComment { get; set; }
    }
}