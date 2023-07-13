using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication1.Models.viewModels
{
    public class bookViewModel

    {
            
        public int id_book { get; set; }
        [Required]
        [Display(Name = "Autor del libro: ")]
        public string name_author { get; set; }
        [Required]
        [Display(Name = "Nombre de el publicador: ")]
        public string name_publisher { get; set; }

        [Required]
        [Display(Name = "Nombre del libro: ")]
        public string title_book { get; set; }
        [Required]
        [Display(Name = "Genero del libro: ")]
        public string genre_book { get; set; }

        [Required]
        [Display(Name = "Precio en dolares: ")]
        public float price_book { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de prueba: ")]
        public DateTime creationDate { get; set; }



    }
}