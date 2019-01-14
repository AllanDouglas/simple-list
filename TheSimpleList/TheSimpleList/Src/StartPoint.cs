using TheSimpleList.Src.Core.Bundle;
using TheSimpleList.Src.Core.DIContainer;
using TheSimpleList.Src.Modules.DIContaner;
using TheSimpleList.Src.Modules.List.Views;
using Xamarin.Forms;

namespace TheSimpleList.Src
{
    public class StartPoint
    {
        private readonly Application app;
        private readonly LocalBundle bundle;
        private readonly IDIContainer container;

        public StartPoint(Application app)
        {

            this.app = app;
            this.bundle = new LocalBundle();
            this.container = this.bundle.Load(new UnityInjector());
        }

        public void Start()
        {
            this.app.MainPage = new NavigationPage(this.container.Resolve<CarouselListPage>());
        }

    }
}
