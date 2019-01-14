using TheSimpleList.Src.Core.DIContainer;

namespace TheSimpleList.Src.Core.Modules
{
    abstract class AModule
    {

        internal abstract void Load(IInjector container);

    }
}
