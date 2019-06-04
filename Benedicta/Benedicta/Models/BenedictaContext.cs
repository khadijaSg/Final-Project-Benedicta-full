using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Benedicta.Models
{
    public class BenedictaContext:DbContext
    {
        public BenedictaContext():base ("BenedictaContext")
        {

        }
        public DbSet<About> About { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactForm> ContactForm { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuUpdate> MenuUpdate { get; set; }
        public DbSet<News> New { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<ReserveTable> ReserveTable { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Tea> Tea { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Welcome> Welcome { get; set; }
        public DbSet<ReserveTableBg> ReserveTableBg { get; set; }
        public DbSet<AboutInfo> AboutInfo { get; set; }
        public DbSet<MenuT1> MenuT1 { get; set; }
        public DbSet<MenuT2> MenuT2 { get; set; }



    }

}