using TheSimpleList.Src.Basic.List.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheSimpleList.Src.Basic.List.Services

{
    public interface IListService
    {
        Task<List<ProductList>> List();

        Task<bool> Save(ProductList list);

        Task<ProductList> Find(DateTime date);

        Task<bool> Delete(ProductList list);
    }
}
