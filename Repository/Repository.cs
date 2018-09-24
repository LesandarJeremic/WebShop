using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository
    {
        private WebShopContext wSC = new WebShopContext();
        public void AddList(List<Product> prod)
        {
            wSC.Products.AddRange(prod);
            wSC.SaveChanges();
        }
      
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

        public void WriteJsonToFile()
        {
            List<Product> list = new List<Product>();
            list = GetAll();
            string json = JsonConvert.SerializeObject(list);
            var dir = @"C:\JsonWebShop";  

            if (!Directory.Exists(dir))  
                Directory.CreateDirectory(dir);

            File.WriteAllText(dir + @"\" + "WebShop.json", json);
        }

        public List<Product> Deserialize()
        {
            string jsonString = File.ReadAllText(@"C:\JsonWebShop" + @"\" + "WebShop.json");
            List<Product> list = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            return list;
        }
    }
}
