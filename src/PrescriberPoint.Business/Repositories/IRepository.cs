using PrescriberPoint.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrescriberPoint.Business.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> Get(string name);

        Task<IEnumerable<T>> GetAll();

        Task<bool> Add(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(int id);

    }
}