using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class,IEntity,new() //filtreleyiriy, Class == referans, ientity == Veri tabani tablosu, new()= newlene bilen olsun, IEntity'in ozu islenemmir
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {//altdaki == dispossible patter implementation of c# 
            using (TContext context = new TContext()) //using'in icindeki sey newlenende yaranir bitennen sonra silinir, yeniki anliqdi
            {
                /*1*/
                var addedEntity = context.Entry(entity); //Bu Linqde elediyimiz filterenin yeniki Mes: Id1 == Id1 olanlari tap'in Ef versiyasidi
                /*2*/
                addedEntity.State = EntityState.Added; //Added kimi imkanlari ozu sagliyir.
                /*3*/
                context.SaveChanges(); //1)de Referansi tapir 2)Elave olunacaq sey 3) elave eder (Opsi verilen seyleri gerceklest)
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext()) //asagidaki where LINq'deki lambda(p=>) 'dir
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList(); //Ternary Operatordan isdifade . beledise bu isler == ?, deyilse bu isler == :
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext ())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
