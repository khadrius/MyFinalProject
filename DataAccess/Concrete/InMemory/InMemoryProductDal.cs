using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//global değişken
        public InMemoryProductDal()//constructor
        {
            //Oracle, Sql Server, Postgres, MongoDb
            _products = new List<Product> {
             new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitInStock=15},
             new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitPrice=500,UnitInStock=3},
             new Product{ProductId=3,CategoryId=2,ProductName="Telefom",UnitPrice=1500,UnitInStock=2},
             new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitInStock=65},
             new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            /*//foreachli
            Product productToDelete = null;
            
            foreach (var p in _products)
            {
                if(product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }*/
            //LINQ - Language Integrated Query 
            //foreach yap her birine takma isim ver
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // where=İçindeki şarta uyan bütün elemanları bi liste haline getirir ve onu verir
           return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName= product.ProductName;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.CategoryId= product.CategoryId;
            productToUpdate.UnitInStock= product.UnitInStock;
        }
    }
}
