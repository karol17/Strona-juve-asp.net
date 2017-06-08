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
        public string Text { get; set; }
        public LoginViewModel User { get; set; }
        public News news { get; set; }
    }
}