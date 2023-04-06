using System.Collections.Generic;
using System.Linq;
using pratice_project.Models;

namespace pratice_project.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();
        public ProductService(){
            LoadProducts();
        }
        public Product Find(int id){
            var qr = from p in products where p.Id == id select p;
            return qr.FirstOrDefault();
        }
        public List<Product> Delete(int id){
            AllProducts().Remove(Find(id));
            return AllProducts();
        }
        public List<Product> AllProducts() => products;
        public void LoadProducts(){
            products.Clear();
            products.Add(new Product(){
                Id = 1,
                Name = "Iphone",
                Price = 900,
                Description = " Iphone 10"

            });
            products.Add(new Product(){
                Id = 2,
                Name = "Iphone X",
                Price = 900,
                Description = " Iphone X"

            });
            products.Add(new Product(){
                Id = 3,
                Name = "Nokia",
                Price = 800,
                Description = "Nokia"
            });
        }
    }
}