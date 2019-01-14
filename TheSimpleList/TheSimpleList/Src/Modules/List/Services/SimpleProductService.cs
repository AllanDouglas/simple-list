using TheSimpleList.Src.Basic.List.Data;
using TheSimpleList.Src.Basic.List.Services;
using TheSimpleList.Src.Basic.Storage.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSimpleList.Src.Modules.List.Services
{

    public class SimpleProductService : IProductService
    {

        private readonly IStorageService<ProductList> storageService;

        public SimpleProductService(IStorageService<ProductList> sotorageService)
        {
            storageService = sotorageService;
        }

        public async Task<List<Product>> List()
        {
            return await Task.Run(
               async () =>
                {

                    var list = await storageService.Get();

                    var itens = list.Select(e => e.Itens).Aggregate(new List<string>(),
                        (prev, actual) =>
                        {
                            prev.AddRange(actual.Select(e => e.Product.Name));
                            return prev;
                        });

                    return itens.Distinct().Select(e => new Product(e)).ToList();
                    
                }
            );
        }
    }


}
