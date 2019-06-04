using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Benedicta.Models
{
    public class MenuT2
    {

        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [StringLength(350)]
        public string Photo { get; set; }
    }
}