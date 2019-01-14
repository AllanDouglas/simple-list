using TheSimpleList.Src.Core.DIContainer;
using TheSimpleList.Src.Modules.List.Config;
using TheSimpleList.Src.Modules.Storage.Local.Config;

namespace TheSimpleList.Src.Core.Bundle
{
    public class LocalBundle
    {
        public IDIContainer Load(IInjector injector)
        {
            new ListConfig().Load(injector);
            new LocalStorageConfig().Load(injector);

            return injector.Build();
        }
    }
}
