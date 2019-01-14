using TheSimpleList.Src.Core.DIContainer;
using System;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;

namespace TheSimpleList.Src.Modules.DIContaner
{
    class UnityInjector : IInjector
    {

        private readonly IUnityContainer container;

        public UnityInjector()
        {
            try
            {
                this.container = new UnityContainer();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

        }


        public IDIContainer Build()
        {
            CommonServiceLocator
                .ServiceLocator
                .SetLocatorProvider(() => new UnityServiceLocator(this.container));

            var injector = new UnityInjectorContainer(this.container);

            this.container.RegisterInstance<IDIContainer>(injector);

            return injector;
        }

        public IInjector RegistePage<T>() where T : Page
        {
            container.RegisterType<T>();
            return this;
        }

        public IInjector RegisterToSelf<T>()
        {
            container.RegisterType<T>();
            return this;
        }

        public IInjector RegisteStateFullService<T, H>() where T : H
        {
            container.RegisterSingleton<H, T>();
            return this;
        }

        public IInjector RegisteStateLessService<T, H>() where T : H
        {
            container.RegisterType<H, T>();
            return this;
        }
    }
}
