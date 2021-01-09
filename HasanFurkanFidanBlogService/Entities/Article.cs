using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidanBlogService.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public string MainContent { get; set; }
        public string ImageUrl { get; set; }
        public int ViewCount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
