using System;
using System.Collections.Generic;
using System.Text;

namespace TheSimpleList.Src.Core.DIContainer
{
    public interface IDIContainer
    {
        T Resolve<T>();
    }
}
