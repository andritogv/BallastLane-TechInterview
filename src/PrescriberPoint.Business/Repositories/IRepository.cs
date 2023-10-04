using PrescriberPoint.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrescriberPoint.Business.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        Task<int> Add(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}