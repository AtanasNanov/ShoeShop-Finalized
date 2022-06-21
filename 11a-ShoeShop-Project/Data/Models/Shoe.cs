using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11a_ShoeShop_Project.Data.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ShoeSize { get; set; }
        public int ShoeTypeId { get; set; }
        public ShoeType ShoeType { get; set; }
    }
}
