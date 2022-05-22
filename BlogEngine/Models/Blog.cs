using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogEngine.Models
{
    public class Blog
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(50)]
        public string Title { get; set; }
        [Required,StringLength(50)]
        public string  Author { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedON { get; set; }

        public int LikeCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}