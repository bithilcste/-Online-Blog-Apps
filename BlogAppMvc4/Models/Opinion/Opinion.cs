using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogAppMvc4.Models.Opinion
{
    public class Opinion
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OpnID { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [StringLength(10)]
        public String Category { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50)]
        public String Title { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        [DataType(DataType.MultilineText)]
        public String Contents { get; set; }
        public DateTime infodate { get; set; }
      //  public string Email { get; set; }
        public int UserID { get; set; }
    }
}