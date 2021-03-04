using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{ //Context == veri tabani (Db) ile Oz class lasirimizi birlesdirmek
    public class NorthwindContext:DbContext //DbContext Entityframework'dan otomatik olaraq gelir
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Bunu etmek ucun DbContextin icindeki OnConfiguring Metodunun onune (Voidden once) visual yazmaq lazimdir. Yeniki isleden adam ozu override ede bilsin, isdediyi kimi usdune yaza, doldura bilsin..
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true"); //burda sisteme hansi veri tabaninnan verileri alacaqini bildiririk ve asagidada neyin ne oldugunu bildiririy..
        }
        public DbSet<Product> Products { get; set; }//Burda DbSet == bizim class, Products == veri tabanindaki eyni seydi deyirik sisteme https://youtu.be/ow-EHetuNAU?t=6156
        public DbSet<Category> Categories { get; set; } //Bizim classin adi, icindeki propartylerin adlari basga olarsa bunu coxumunu youtubede tapa bilersen, adi: Custom Mapping Yapalım  https://www.udemy.com/course/c-sharp-programlama-kursu/ 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
