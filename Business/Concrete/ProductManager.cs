using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length >2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23) //Veri gelmesse bu saat la baglidi demek
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategryId(int Id)
        {
            return new SuccessDataResult<List<Product>> ( _productDal.GetAll(p=> p.CategoryId == Id ));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=> p.ProductId == productId));        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails());
        }
    }
}
