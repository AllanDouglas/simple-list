using Autofac;
using TheSimpleList.Src.Core.DIContainer;
using System;

namespace TheSimpleList.Src.Modules.DIContaner
{
    class AutofacContainer : IDIContainer
    {
        private readonly IContainer container;

        public AutofacContainer(IContainer container)
        {   
            this.container = container;
        }

        public T Resolve<T>()
        {
            return this.container.Resolve<T>();
        }
    }
}
