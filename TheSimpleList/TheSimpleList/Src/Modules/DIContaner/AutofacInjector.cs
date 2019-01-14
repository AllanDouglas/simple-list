using Autofac;
using TheSimpleList.Src.Core.DIContainer;
using System;
using Xamarin.Forms;

namespace TheSimpleList.Src.Modules.DIContaner
{
    class AutofacInjector : IInjector
    {
        private readonly ContainerBuilder container;

        public AutofacInjector()
        {
            try
            {
                container = new ContainerBuilder();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

        }

        public IDIContainer Build()
        {
            try
            {
                return new AutofacContainer(this.container.Build());
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return null;

        }

        public IInjector RegistePage<T>() where T : Page
        {
            container.RegisterType<T>();
            return this;
        }

        public IInjector RegisterToSelf<T>()
        {
            throw new NotImplementedException();
        }

        public IInjector RegisteStateFullService<T, H>() where T : H
        {
            container.RegisterType<T>().As<H>();
            return this;
        }

        public IInjector RegisteStateLessService<T, H>() where T : H
        {
            container.RegisterType<T>().As<H>().SingleInstance();
            return this;
        }

    }
}
