using TheSimpleList.Src.Basic.List.Data;
using TheSimpleList.Src.Basic.List.Services;
using TheSimpleList.Src.Basic.Storage.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheSimpleList.Src.Modules.List.Services
{
    public class LocalListService : IListService
    {

        private readonly IStorageService<ProductList> storageService;

        public LocalListService(IStorageService<ProductList> sotorageService)
        {
            this.storageService = sotorageService;
        }

        public Task<bool> Delete(ProductList list)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductList> Find(DateTime date)
        {
            return await Task.Run(() =>
            {
                return new ProductList(
                    DateTime.Now,
                    new List<Item>()
                    {
                          new Item(new Product("Arroz"), 1),
                          new Item(new Product("Feijão"), 1),
                          new Item(new Product("Batata"), 1),
                    }
               );

            });
        }

        public async Task<List<ProductList>> List()
        {
            return await Task.Run(() =>
            {
                return new List<ProductList>()
                {
                   new ProductList(
                       DateTime.Now,
                       new List<Item>()
                       {
                              new Item(new Product("Arroz"), 1),
                              new Item(new Product("Feijão"), 1),
                              new Item(new Product("Batata"), 1),
                       }
                   )
                };

            });
        }

        public async Task<bool> Save(ProductList list)
        {
            return await this.storageService.Save(list);
        }
    }
}
