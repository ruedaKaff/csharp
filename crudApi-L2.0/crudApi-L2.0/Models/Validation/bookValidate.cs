using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crudApi_L2._0.Models
{
    [MetadataType(typeof(book.MetaData))]
    public partial class book
    {
        sealed class MetaData
        {
            [Required]
            public string title_book;
        }
    }
}