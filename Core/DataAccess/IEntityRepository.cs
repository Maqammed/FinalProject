
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{//generic constraint == generik kisit
    public interface IEntityRepository<T> where T:class,IEntity,new() //Vereceyimiz tip class==referans olmalidir ve ya IEntity/Bunun implemente etdiyi seyler + newlene bilecey sey, IEntity newlenemmediyi ucun bunu isledemmiriy referansini dasiyanlari islediriy
    {       // T == ne tip versey onu isletsin bizden imennmi tip isdemesin
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //bunu adi Expression'dir
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity); 
        void Update(T entity);
        void Delete(T entity);
    }
}
