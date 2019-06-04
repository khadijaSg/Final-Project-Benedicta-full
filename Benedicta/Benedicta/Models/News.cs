using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Benedicta.Models
{
    public class News
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Photo { get; set; }

        [Column(TypeName ="date")]
        public DateTime DateTime { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [Column(TypeName ="ntext")]
        public string Text { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}