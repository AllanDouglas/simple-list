using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheSimpleList.Src.Basic.List.Data;
using TheSimpleList.Src.Basic.Storage.Service;

namespace TheSimpleList.Src.Modules.Storage.Services
{
    public class LocalStorageService : IStorageService<ProductList>
    {
        protected readonly string path;

        public LocalStorageService()
        {
            this.path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local.db");
        }

        public async Task<List<ProductList>> Get()
        {
            return await Task.Run(

                 () =>
                 {
                     try
                     {
                         List<ProductList> list = new List<ProductList>();

                         using (var db = new LiteDatabase(this.path))
                         {
                             list = db.GetCollection<BsonDocument>("lists")
                             .FindAll()
                             .Select(doc =>
                             {
                                 var itens = doc["itens"]
                                     .AsArray
                                     .Select(e =>
                                        new Item(
                                            new Product(e.AsDocument["product"]),
                                                e.AsDocument["amount"],
                                                e.AsDocument["check"]
                                        )).ToList();

                                 return new ProductList(
                                     doc["dateTime"].AsDateTime,
                                     itens,
                                     doc["_id"].AsString
                                 );

                             }).ToList();

                         }

                         return list;
                     }
                     catch (Exception)
                     {
                         return new List<ProductList>();
                     }

                 }

             );
        }

        public async Task<bool> Delete(ProductList obj)
        {
            return await Task.Run(
                () =>
                {
                    try
                    {
                        var path = Path.Combine(Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), "local.db"
                        );

                        using (var db = new LiteDatabase(this.path))
                        {

                            var collection = db.GetCollection<BsonDocument>("lists");
                            
                            collection.Delete(new BsonValue(obj.Id));

                        }

                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
            );
        }

        public async Task<bool> Save(ProductList obj)
        {
            return await Task.Run(
                () =>
                {
                    try
                    {
                        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "local.db");
                        using (var db = new LiteDatabase(this.path))
                        {

                            var collection = db.GetCollection<BsonDocument>("lists");
                            BsonDocument document;

                            document =
                            collection.FindById(
                                new BsonValue(new ObjectId(obj.Id ?? ObjectId.Empty.ToString())))
                                ?? new BsonDocument();

                            document["dateTime"] = obj.UsedIn;

                            document["itens"] = new BsonArray(
                                obj.Itens.Select(i =>
                                {
                                    var doc = new BsonDocument
                                    {
                                        ["product"] = i.Product.Name,
                                        ["amount"] = i.Amount,
                                        ["check"] = i.Checked
                                    };

                                    return doc;
                                }));

                            collection.Upsert(document);
                        }

                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }

                }

            );

        }
    }
}
