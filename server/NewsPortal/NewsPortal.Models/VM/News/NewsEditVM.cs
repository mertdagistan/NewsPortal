using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.VM.News
{
    public class NewsEditVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title must be less than 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(175, ErrorMessage = "Description must be less than 175 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }

        public DateTime PublishAt { get; set; }
        [Required(ErrorMessage = "Author is required")]
        [StringLength(255, ErrorMessage = "Image must be less than 255 characters")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public int AuthorID { get; set; }
    }
}
