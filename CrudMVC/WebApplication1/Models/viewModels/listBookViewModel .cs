using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.viewModels
{
    public class listBookViewModel
    {
        public int id_book { get; set; }
        public string name_author { get; set; }
        public string name_publisher { get; set; }
        [Required]
        public string title_book { get; set; }
        public string genre_book { get; set; }
        public float price_book { get; set; }


        
    }
        
}