using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal()); //Burani bos qoymaq olmaz, birden cox usul ola bildiyi ucun bu hansi usulla islediyini belitmeni isdeyir

            foreach (var product in productManager.GetAll()) //yuxarda basqa veri tabaniyla islemey isdiyirsense : https://youtu.be/qBQOqh844Mo?t=10367
            {
                Console.WriteLine(product.ProductName); //burda diyirikki urunlerin hepsini listele ama mene adini ver
            }
        }
    }
}
