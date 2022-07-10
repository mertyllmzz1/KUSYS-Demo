using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repositories<TEntity>: IRepositories<TEntity> where TEntity : class //Generic yapı class olmalıdır.
    {
        private readonly StudentContext db;
        public Repositories(StudentContext _db)
        {
            db = _db;
        }
        public string Delete(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                db.Remove(GetById(where));
                db.SaveChanges();
                return "İşlem Başarısız";
            }
            catch (Exception)
            {

                return "İşlem Başarısız";
            }
        }

        public IList<TEntity> GetAllList(params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query = db.Set<TEntity>(); // Hangi NESNE gönderildiyse O NESNE'nin veritabanındaki Dataları aktaracak.
            if (include.Any()) // İşlikili Tablo istenmişmi Bakılıyor.
            {
                foreach (var item in include) // İstenilen parametreler Foreach ile alınıyor.
                {
                    query = query.Include(item); // Query Yapımıza Aktarılmasını sağlıyoruz.
                }
            }
            return query.ToList();
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query;
            if (where != null)
            {
                query = db.Set<TEntity>().Where(where);
            }
            else
            {
                query = db.Set<TEntity>();
            }
            if (include.Any()) // İşlikili Tablo istenmişmi Bakılıyor.
            {
                foreach (var item in include) // İstenilen parametreler Foreach ile alınıyor.
                {
                    query = query.Include(item); // Query Yapımıza Aktarılmasını sağlıyoruz.
                }
            }
            return query.FirstOrDefault();
        }

        public string Insert(TEntity entity)
        {

            try
            {
                db.Add(entity);
                db.SaveChanges();
                return "İşlem Başarılı";
            }
            catch (Exception)
            {
                return "İşlem Başarısız";
            }
        }

        public string Update(TEntity entity)
        {
            try
            {
                db.Update(entity);
                db.SaveChanges();
                return "İşlem Başarılı";
            }
            catch (Exception)
            {
                return "İşlem Başarısız";
            }
        }

        //public IList<CoursesAndStudentsMatches> GetListById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        //{
        //    IQueryable<TEntity> query = db.Set<TEntity>(); // Hangi NESNE gönderildiyse O NESNE'nin veritabanındaki Dataları aktaracak.

        //    if (include.Any()) // İşlikili Tablo istenmişmi Bakılıyor.
        //    {
        //        foreach (var item in include) // İstenilen parametreler Foreach ile alınıyor.
        //        {
        //            query = query.Include(item); // Query Yapımıza Aktarılmasını sağlıyoruz.
        //        }
        //    }
        //    return (IList<CoursesAndStudentsMatches>)query.ToList();
        //}

       public List<TEntity> GetListById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query;
            if (where != null)
            {
                query = db.Set<TEntity>().Where(where);
            }
            else
            {
                query = db.Set<TEntity>(); // Hangi NESNE gönderildiyse O NESNE'nin veritabanındaki Dataları aktaracak.

            }

            if (include.Any()) // İşlikili Tablo istenmişmi Bakılıyor.
            {
                foreach (var item in include) // İstenilen parametreler Foreach ile alınıyor.
                {
                    query = query.Include(item); // Query Yapımıza Aktarılmasını sağlıyoruz.
                }
            }
            return (List<TEntity>)query.ToList();
        }

    }
}
