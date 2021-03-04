using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //InMemory yerine basqa bir usul isletsen IProductDal'i ona : intelisens edeceyik ona gorede bu Type ilen olusturdugumuz eleman butum komutlari islede bilecey. bidene InMemoryi yazsaydiq basqa usul isledende herseyi deyismeli olacaydiq

        public ProductManager(IProductDal productDal) //new'lenendeki eleman ovto olaraq usuldaki komutlara sahib olacaq cunki veri usula implemente olub
        {
            _productDal = productDal;  //_productDal'da budeyqe butum komutlar var, teze eleman bun a beraber olacaq
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategryId(int Id)
        {
            return _productDal.GetAll(p=> p.CategoryId == Id );
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
