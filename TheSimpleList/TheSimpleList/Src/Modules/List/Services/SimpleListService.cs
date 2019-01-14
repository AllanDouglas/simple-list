using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheSimpleList.Src.Basic.List.Data;
using System.Linq;
using TheSimpleList.Src.Basic.Storage.Service;
using TheSimpleList.Src.Basic.List.Services;

namespace TheSimpleList.Src.Modules.List.Services
{
    public class SimpleListService : IListService
    {

        private readonly IStorageService<ProductList> storageService;

        public SimpleListService(IStorageService<ProductList> sotorageService)
        {
            this.storageService = sotorageService;
        }

        public async Task<bool> Delete(ProductList list)
        {
            return await this.storageService.Delete(list);
        }

        public async Task<ProductList> Find(DateTime date)
        {
            return (await this.storageService.Get()).First(
                l => l.UsedIn == date
            );
        }

        public async Task<List<ProductList>> List()
        {
            return await this.storageService.Get();
        }

        public async Task<bool> Save(ProductList list)
        {
            return await this.storageService.Save(list);
        }
    }
}
