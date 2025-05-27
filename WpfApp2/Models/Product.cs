using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal RegularPrice { get; set; }
        public Discount Disc { get; set; }
    }
}
