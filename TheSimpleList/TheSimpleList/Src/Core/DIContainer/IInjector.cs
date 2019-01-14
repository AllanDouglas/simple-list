using Xamarin.Forms;

namespace TheSimpleList.Src.Core.DIContainer
{
    public interface IInjector
    {

        IDIContainer Build();

        IInjector RegisteStateLessService<T, H>() where T : H;

        IInjector RegisteStateFullService<T, H>() where T : H;

        IInjector RegisterToSelf<T>();

        IInjector RegistePage<T>() where T : Page;
    }
}
