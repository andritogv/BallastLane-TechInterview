using PrescriberPoint.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrescriberPoint.Business.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> Get(string name);

        Task<IEnumerable<T>> GetAll();

        Task<int> Add(T entity);

        void Update(T entity);

        Task<int> Delete(int id);

    }
}