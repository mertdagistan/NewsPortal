using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.VM.News
{
    public class NewsInfoVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public DateTime PublishAt { get; set; }
        public string Image { get; set; }

        public string Author { get; set; }

        public int AuthorID { get; set; }
    }
}
