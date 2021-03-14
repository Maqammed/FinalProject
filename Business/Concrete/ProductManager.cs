using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService //* Bir entity manager ozunnen basga heckimi injection edemez
    {
        IProductDal _productDal; //InMemory yerine basqa bir usul isletsen IProductDal'i ona : intelisens edeceyik ona gorede bu Type ilen olusturdugumuz eleman butum komutlari islede bilecey. bidene InMemoryi yazsaydiq basqa usul isledende herseyi deyismeli olacaydiq
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService) //new'lenendeki eleman ovto olaraq usuldaki komutlara sahib olacaq cunki veri usula implemente olub
        {
            _productDal = productDal;  //_productDal'da budeyqe butum komutlar var, teze eleman bun a beraber olacaq
            _categoryService = categoryService;
        }

        //Asagidaki Claim()'dir. bu kodu ileden adamin bulardan birine sahip olmasi lazimdi
        [SecuredOperation("product.add")]

        //ValidationAspect ctor'de type validatorType isdiyor, oda ProductValidator'du https://youtu.be/zdpPm7Q6YE0?t=3108
        [ValidationAspect(typeof(ProductValidator))] //Bu Atrubite'du, metodub basinda(OnBefore) dogrulayir
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), //12.gun
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExists());
            if (result != null)
            {
                return result;
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
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(Product))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)  //exists == var
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //Any == varmI?
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExists()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExists);
            }
            return new SuccessResult();
        }
    }
}
