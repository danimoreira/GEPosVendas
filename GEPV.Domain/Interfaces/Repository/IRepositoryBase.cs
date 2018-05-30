using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj, bool? saveChanges = true);

        void Delete(TEntity obj, bool? saveChanges = true);

        void Dispose();

        TEntity GetById(int id);

        List<TEntity> List();

        void SaveChanges();

        void Update(TEntity obj, bool? saveChanges = true);

        bool Exists(int id);

        void Delete(int id);

    }
}
