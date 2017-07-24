using juve.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace juve.Models
{
    public class Comment
    {
        
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Wprowadź komentarz")]
        public string Text { get; set; }
        public string Login { get; set; }
        public DateTime Date { get; set; }
        public int NewsId { get; set; }
        public virtual News News { get; set; }
    }
}