﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product> //Repositoru Product ucun isletdin https://youtu.be/ow-EHetuNAU
    {  
    }
} //Code refactory