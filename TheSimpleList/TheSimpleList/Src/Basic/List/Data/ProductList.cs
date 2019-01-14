using System;
using System.Collections.Generic;

namespace TheSimpleList.Src.Basic.List.Data
{
    public class ProductList
    {
        public string Id { get; }

        public DateTime UsedIn { get; }

        public List<Item> Itens { get; }

        public string Name { get; }

        public ProductList(DateTime usedIn, List<Item> itens, string id = null, string name = "")
        {
            Id = id;
            UsedIn = usedIn;
            Itens = itens;
            Name = name ?? "Lista sem nome";
        }
    }
}
