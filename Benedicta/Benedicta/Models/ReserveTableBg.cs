using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Benedicta.Models
{
    public class ReserveTableBg
    {
        public int Id { get; set; }

        [StringLength(350)]
        public string Photo { get; set; }
    }
}