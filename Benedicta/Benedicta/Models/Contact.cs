using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Benedicta.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [StringLength(150),Required]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [StringLength(350)]
        public string Photo { get; set; }
    }
}