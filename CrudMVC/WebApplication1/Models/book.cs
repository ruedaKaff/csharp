//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        public int id_book { get; set; }
        public string name_author { get; set; }
        public string name_publisher { get; set; }
        public string title_book { get; set; }
        public string genre_book { get; set; }
        public Nullable<double> price_book { get; set; }
    }
}
