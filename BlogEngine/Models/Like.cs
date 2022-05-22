using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogEngine.Models
{
    public class Like
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int BlogID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public DateTime LikedON { get; set; }
    }
}