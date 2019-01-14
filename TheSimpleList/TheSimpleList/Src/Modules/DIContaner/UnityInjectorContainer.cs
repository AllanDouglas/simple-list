using TheSimpleList.Src.Core.DIContainer;
using Unity;

namespace TheSimpleList.Src.Modules.DIContaner
{
    class UnityInjectorContainer : IDIContainer
    {
        private readonly IUnityContainer injector;

        public UnityInjectorContainer(IUnityContainer injector)
        {
            this.injector = injector;
        }

        public T Resolve<T>()
        {
            return this.injector.Resolve<T>();
        }
    }
}
