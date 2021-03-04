using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        { 
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var cat in categoryManager.GetAll())
            {
                Console.WriteLine(cat.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);

            }
        }

            /* ProductManager productManager = new ProductManager(new EfProductDal()); //Burani bos qoymaq olmaz, birden cox usul ola bildiyi ucun bu hansi usulla islediyini belitmeni isdeyir

                  foreach (var product in productManager.GetAll()) //yuxarda basqa veri tabaniyla islemey isdiyirsense : https://youtu.be/qBQOqh844Mo?t=10367
                  {
                      Console.WriteLine(product.ProductName); //burda diyirikki urunlerin hepsini listele ama mene adini ver
                  } */

            //ProductManager productManager = new ProductManager(new EfProductDal());

            //foreach (var product in productManager.GetAllByCategryId(2))
            //{
            //    Console.WriteLine(product.ProductName);
            //}

    }
}
