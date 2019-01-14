using TheSimpleList.Src.Basic.List.Data;
using TheSimpleList.Src.Basic.Storage.Service;
using TheSimpleList.Src.Core.DIContainer;
using TheSimpleList.Src.Core.Modules;
using TheSimpleList.Src.Modules.Storage.Services;

namespace TheSimpleList.Src.Modules.Storage.Local.Config
{
    class LocalStorageConfig : AModule
    {
        internal override void Load(IInjector container)
        {
            container.RegisteStateLessService<LocalStorageService, IStorageService<ProductList>>();
        }
    }
}
