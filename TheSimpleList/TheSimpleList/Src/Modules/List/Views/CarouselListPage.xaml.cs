using System.Linq;
using TheSimpleList.Src.Modules.List.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheSimpleList.Src.Modules.List.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselListPage : CarouselPage
    {
        private CarouselListViewModel model;

        public CarouselListPage(CarouselListViewModel model)
        {
            InitializeComponent();

            this.model = model;

            this.BindingContext = this.model;

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<CarouselListViewModel>(
                this, CarouselListViewModel.LISTS_LOADED_MSG, (sender) =>
            {

                var listModels = model.ListModels.Select(c => new ListPage(c)).ToList();

                foreach (var page in listModels)
                {

                    try
                    {
                        Children.Add(page);
                    }
                    catch (System.Exception e)
                    {

                        throw;
                    }
                }

                this.CurrentPage = this.Children.Last();

                this.OnChildrenReordered();
            });

            model.Load();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            this.model.ListModels.Where((m) => (m.Itens.Count == 0)).Select(m => m.Delete());

            MessagingCenter.Unsubscribe<CarouselListViewModel>(this, CarouselListViewModel.LISTS_LOADED_MSG);
        }
    }
}