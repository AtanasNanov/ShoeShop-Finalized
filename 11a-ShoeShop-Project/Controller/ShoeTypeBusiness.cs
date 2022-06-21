using _11a_ShoeShop_Project.Data;
using _11a_ShoeShop_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11a_ShoeShop_Project.Controller
{
    class ShoeTypeBusiness
    {
        private ShoeContext shoeTypeContext = new ShoeContext();
        public List<ShoeType> GetAllTypes()
        {
            return shoeTypeContext.ShoeTypes.ToList();
        }
        public string GetType(int id)
        {
            return shoeTypeContext.ShoeTypes.Find(id).Name;
        }
    }
}
