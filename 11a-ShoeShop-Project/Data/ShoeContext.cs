using _11a_ShoeShop_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11a_ShoeShop_Project.Data
{
    public class ShoeContext : DbContext
    {
        public ShoeContext():base("name=ShoeContext")
        {

        }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeType> ShoeTypes { get; set; }
    }
}
