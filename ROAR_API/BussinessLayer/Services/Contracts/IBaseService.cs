using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Contracts
{
    public interface IBaseService <T> where T:class
    {
        Task<bool> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(Guid id);

        Task<T> GetById(Guid id);

        Task<IEnumerable<T>> GetAllEntities(int page,int quantityPerPage);

        

    }
}
