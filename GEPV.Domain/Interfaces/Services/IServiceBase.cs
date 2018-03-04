using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Delete(TEntity obj);

        void Dispose();

        TEntity GetById(int id);

        List<TEntity> List();

        void Update(TEntity obj);

        bool Exists(int id);

        void Delete(int id);
    }
}
