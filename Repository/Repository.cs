using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public int GetLastJsonIndex()
        {
            string jsonString = File.ReadAllText(@"C:\JsonWebShop" + @"\" + "WebShop.json");
            JArray rss = JArray.Parse(jsonString);
            var maxId=0;
            for (int i = 0; i < rss.Count; i++)
            {
                if ((int)rss[i]["Id"] > maxId) maxId = (int)rss[i]["Id"];
            }
            return maxId + 1;
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

        public void CreateJson(Product prod)
        {
            string jsonString = File.ReadAllText(@"C:\JsonWebShop" + @"\" + "WebShop.json");
            JArray rss = JArray.Parse(jsonString);
            string json = JsonConvert.SerializeObject(prod);
            JObject product = JObject.Parse(json);
            rss.Add(product);
            jsonString = rss.ToString(Formatting.None);
            var dir = @"C:\JsonWebShop";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(dir + @"\" + "WebShop.json", jsonString);


        }

        public void DeleteJsonOne(Product product)
        {
            

            string jsonString = File.ReadAllText(@"C:\JsonWebShop" + @"\" + "WebShop.json");
           JArray rss = JArray.Parse(jsonString);
            for (int i = 0; i < rss.Count; i++)
            {


                if ((int)rss[i]["Id"] == product.Id) {
                    rss[i].Remove();
                }
            }
            jsonString= rss.ToString(Formatting.None);
            var dir = @"C:\JsonWebShop";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(dir + @"\" + "WebShop.json", jsonString);

        }

        public void UpdateJsonOne(Product prod)
        {
            string jsonString = File.ReadAllText(@"C:\JsonWebShop" + @"\" + "WebShop.json");
            JArray rss = JArray.Parse(jsonString);
            string json = JsonConvert.SerializeObject(prod);
            JObject product = JObject.Parse(json);
        
       
            for (int i = 0; i < rss.Count(); i++)
            {
                if ((int)rss[i]["Id"] == prod.Id)
                {
                    rss[i]["Name"]=prod.Name;
                    rss[i]["Category"] = prod.Category;
                    rss[i]["Description"] = prod.Description;
                    rss[i]["Supplier"] = prod.Supplier;
                    rss[i]["Producer"] = prod.Producer;
                    rss[i]["Price"] = prod.Producer;

                }

            }
            jsonString = rss.ToString(Formatting.None);
            var dir = @"C:\JsonWebShop";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(dir + @"\" + "WebShop.json", jsonString);


        }
    }
}
