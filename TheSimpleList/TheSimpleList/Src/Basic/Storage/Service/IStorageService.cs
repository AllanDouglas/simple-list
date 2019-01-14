using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheSimpleList.Src.Basic.Storage.Service
{
    public interface IStorageService<T>
    {
        Task<List<T>> Get();

        Task<bool> Save(T obj);

        Task<bool> Delete(T obj);

    }
}
