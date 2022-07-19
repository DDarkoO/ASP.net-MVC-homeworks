using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DOMAIN.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public Burger Burger { get; set; }
        public string Location { get; set; }
    }
}
