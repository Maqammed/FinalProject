using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract //Soyut(Abstract) == Mucerred  Somut(Concrate) == Konkret
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategryId(int Id); //kateqori Id'sine gore getir
        List<Product> GetByUnitPrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetails();
    }
}
