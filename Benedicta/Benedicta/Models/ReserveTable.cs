using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Benedicta.Models
{
    public class ReserveTable
    {
        public int Id { get; set; }

        public int Seats { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Phone { get; set; }

        [Column(TypeName ="date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan Time { get; set; }

        [Column(TypeName = "ntext")]
        public string SpecialRequests { get; set; }


    }
}