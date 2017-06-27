using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using juve.Models;

namespace juve.ViewModels
{
    public class ArticleViewModel
    {
        public int NewsId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleImage { get; set; }
        public string ArticleHeader { get; set; }
        public string ArticleText { get; set; }
        [Display(Name = "Nowy komentarz:")]
        [Required(ErrorMessage = "Wprowadź komentarz")]
        public string CommentText { get; set; }
        [Display(Name = "Komentarze:")]
        public ICollection<Comment> Comments { get; set; }

    }
}