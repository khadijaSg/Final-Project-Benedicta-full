using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Benedicta.Models
{
    public class Property
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Photo { get; set; }
        
        [Column(TypeName ="ntext")]
        public string Text { get; set; }
    }
}