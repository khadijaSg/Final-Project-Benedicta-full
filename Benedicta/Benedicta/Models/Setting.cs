using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Benedicta.Models
{
    public class Setting
    {
        public int Id { get; set; }

        [StringLength(350)]
        public string Logo { get; set; }

        [StringLength(350)]
        public string Facebook { get; set; }

        [StringLength(350)]
        public string Instagram { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(350)]
        public string NavbarPhoto { get; set; }

        [StringLength(250)]
        public string Adress { get; set; }

        [StringLength(350)]
        public string Map { get; set; }
    }
}