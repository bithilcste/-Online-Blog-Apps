using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogAppMvc4.Models.Opinion
{
    public class Comment
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CmtID { get; set; }
        public int OpnID { get; set; }
        public int UserID { get; set; }
        public DateTime infodate { get; set; }
     //   public string Email { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        [DataType(DataType.MultilineText)]
        public String Contents { get; set; }
    }
}