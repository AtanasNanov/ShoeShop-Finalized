using _11a_ShoeShop_Project.Data;
using _11a_ShoeShop_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11a_ShoeShop_Project.Controller
{
    public class ShoeBusiness
    {
        private ShoeContext shoeContext = new ShoeContext();
        public List<Shoe> GetAll()
        {

            return shoeContext.Shoes.Include("ShoeType").ToList();
        }
        public Shoe Get(int id)
        {
            Shoe find = shoeContext.Shoes.Find(id);
            if (find != null)
            {
                shoeContext.Entry(find).Reference(x => x.ShoeType).Load();
            }
            return find;
        }
        public void Add(Shoe shoe)
        {
            shoeContext.Shoes.Add(shoe);
            shoeContext.SaveChanges();
        }
        public void Update(int id, Shoe shoe)
        {
            Shoe shoe1 = shoeContext.Shoes.Find(id);
            if (shoe1 == null)
            {
                return;
            }
            shoe1.Brand = shoe.Brand;
            shoe1.Description = shoe.Description;
            shoe1.Price = shoe.Price;
            shoe1.ShoeSize = shoe.ShoeSize;
            shoe1.ShoeTypeId = shoe.ShoeTypeId;
            shoeContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Shoe shoe1 = shoeContext.Shoes.Find(id);
            shoeContext.Shoes.Remove(shoe1);
            shoeContext.SaveChanges();
        }
    }
}
