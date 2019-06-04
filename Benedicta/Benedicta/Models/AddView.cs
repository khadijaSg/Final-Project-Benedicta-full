using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benedicta.Models
{
    public class AddView
    {
        public List<About> Abouts { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<ContactForm> ContactForms { get; set; }
        public List<Menu> Menus { get; set; }
        public List<MenuUpdate> MenuUpdates { get; set; }
        public List<News> News { get; set; }
        public List<Property> Properties { get; set; }
        public List<ReserveTable> ReserveTables { get; set; }
        public List<Service> Services { get; set; }
        public List<Setting> Settings { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Tea> Teas { get; set; }
        public List<User> Users { get; set; }
        public List<Welcome> Welcomes { get; set; }
        public List<ReserveTableBg> ReserveTableBgs { get; set; }
        public List<AboutInfo> AboutInfos { get; set; }
        public List<MenuT2> MenuT2 { get; set; }
        public List<MenuT1> MenuT1 { get; internal set; }
    }
}