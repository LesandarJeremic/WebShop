using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository
    {
        private WebShopContext wSC = new WebShopContext();

      
        public void Add(Product ob)
        {
            wSC.Products.Add(ob);
            wSC.SaveChanges();
        }
        public void Delete(Product ob)
        {
            wSC.Products.Remove(ob);
            wSC.SaveChanges();
        }
        public Product Get(int id)
        {
            return wSC.Products.Find(id);
        }

        public List<Product> GetAll() {
            
            return wSC.Products.ToList();
             }
        public Product Update(Product obUpdated)
        {
            wSC.Entry(obUpdated).State = System.Data.Entity.EntityState.Modified;
            wSC.SaveChanges();
            return obUpdated;
        }
    }
}
