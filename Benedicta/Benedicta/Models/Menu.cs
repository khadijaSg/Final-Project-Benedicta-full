using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Benedicta.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName ="ntext")]
        public string Ingredients { get; set; }

        [Column(TypeName ="money")]
        public decimal Price { get; set; }

        [StringLength(350)]
        public string Photo { get; set; }
    }
}