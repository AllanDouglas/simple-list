using TheSimpleList.Src.Basic.List.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheSimpleList.Src.Basic.List.Services
{
    public interface IProductService
    {

        Task<List<Product>> List();

    }
}
