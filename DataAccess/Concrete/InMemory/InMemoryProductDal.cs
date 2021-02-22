using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal //DAL == Data Access List, yeniki Veri erisim kodlari
    {
        List<Product> _products; //_bunnan olub classin icinde olanlarda "Global" deyilir..
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product {ProducrId = 1,CategoryId=1,ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
            new Product {ProducrId = 2,CategoryId=1,ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
            new Product {ProducrId = 3,CategoryId=2,ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
            new Product {ProducrId = 4,CategoryId=2,ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
            new Product {ProducrId = 5,CategoryId=2,ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product) //LINQ = language integrated query
        {
            //Product productToDelete = null; // = null; --hata vermemesi icin bele yazdim ama ; qoyub buraxmaq lazimdi

            //foreach (var p in _products)
            //{
            //    if (product.ProducrId == p.ProducrId)
            //    {
            //        productToDelete = p;
            //    }

            //}      ASAGIDA BUNUN BIR SETIRLIK ASAN YOLU. LINQ

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProducrId); //()'in icindekine lambda diyilir

            _products.Remove(productToDelete); //ama SingleOrDefault @ cavab gelmeli yapilarda islemez, bu Cok vaxt Id temalarinda isledilir
        }

        public List<Product> GetAll()
        {
            return _products; //return == döndürmek. Burda diyirki Product listesindeki herseyi dondur
        }

        public void Update(Product product)  //productToUpdate == guncellenecek urun
        {  //Gonderdiyim urun id'sine sahip lsitedeki urunu tap
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProducrId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategry(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            //where () icindeki sart uyan butum elemanlari yeni liste halina getirib onu d:ondurur
        }
    }
}
