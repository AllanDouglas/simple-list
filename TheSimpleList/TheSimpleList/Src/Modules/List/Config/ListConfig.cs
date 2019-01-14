using TheSimpleList.Src.Basic.List.Services;
using TheSimpleList.Src.Core.DIContainer;
using TheSimpleList.Src.Core.Modules;
using TheSimpleList.Src.Modules.List.Services;
using TheSimpleList.Src.Modules.List.Views;
using TheSimpleList.Src.Modules.List.ViewModels;

namespace TheSimpleList.Src.Modules.List.Config
{
    class ListConfig : AModule
    {

        internal override void Load(IInjector container)
        {
            container
                .RegisterToSelf<ListViewModel>()
                .RegisteStateLessService<SimpleListService, IListService>()
                .RegisteStateLessService<SimpleProductService, IProductService>();
        }
    }
}
