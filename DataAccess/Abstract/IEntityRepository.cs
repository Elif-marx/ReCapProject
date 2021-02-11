using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{                                 //generic constraint T ye kısıtlama gelir class=referans tip olabilir ve new()newlenebilir olmalı
    public interface IEntityRepository<T>where T:class , IEntity, new()                                 //çünkü IEntity newlenemez
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);

    }
}
