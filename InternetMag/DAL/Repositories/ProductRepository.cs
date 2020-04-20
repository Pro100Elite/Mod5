using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository
    {
        string path = @"I:\project\Mod5\InternetMag\DAL\db.txt";


        public List<Product> products = new List<Product>();

        public IEnumerable<Product> GetProducts()
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var product = line.Split(',');

                    int id;
                    int.TryParse(string.Join("", product[0].Where(c => char.IsDigit(c))), out id);

                    int category;
                    int.TryParse(string.Join("", product[1].Where(c => char.IsDigit(c))), out category);

                    Regex regex = new Regex("Name =");
                    string name = regex.Replace(product[2], string.Empty);

                    products.Add(new Product { 
                       Id = id, 
                       categoryId = category, 
                       Name = name, 
                       Price = 1.1f });
                }
            }

            return products;
        }
    }
}
