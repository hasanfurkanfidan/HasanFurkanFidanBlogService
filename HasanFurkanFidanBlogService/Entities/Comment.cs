using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidanBlogService.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentMain { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
