using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{ //Public == Herkese acik, yeniki bu Class'a diger katmanlarda ulasa bilsin. Class'larin default arxasi 'Internal' dir, buda sadece oldugu project yeniki Entities islede biler. Butum project'lerin islede bilmesi ucun 'Public' etmet lazimdir..
    public class Product:IEntity 
    {
        public int ProducrId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } // Short == Int'in daha kicik formasi
        public decimal UnitPrice { get; set; } //Decimal == para birimi
        public int ProductId { get; set; }























        //public List<Product> SingleOrDefault(object p)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Product> SingleOrDefault(Func<object, object> p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
