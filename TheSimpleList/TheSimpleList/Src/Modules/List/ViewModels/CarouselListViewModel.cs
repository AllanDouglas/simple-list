using System.Collections.Generic;
using System.Linq;
using TheSimpleList.Src.Basic.List.Data;
using TheSimpleList.Src.Basic.List.Services;
using TheSimpleList.Src.Basic.ViewModel;
using Xamarin.Forms;

namespace TheSimpleList.Src.Modules.List.ViewModels
{
    public class CarouselListViewModel : AViewModel
    {

        public static string LISTS_LOADED_MSG = "LISTS_LOADED";

        #region Properties
        public List<ListViewModel> ListModels { get; private set; }

        public bool IsLoading { get; private set; }
        #endregion

        #region Fields
        private readonly IListService listService;
        #endregion

        public CarouselListViewModel(IListService listService)
        {
            this.listService = listService;
        }

        public void Load()
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                this.IsLoading = true;

                var lists = await listService.List();

                this.ListModels = lists.Select(list => new ListViewModel(list, listService)).ToList();

                if (this.ListModels.Count == 0)
                {
                    this.ListModels = new List<ListViewModel> {
                           new ListViewModel(
                               new ProductList(
                                   System.DateTime.Now,
                                   new List<Item>{ },
                                   name:"Lista Vazia"
                               ),
                               this.listService
                           )
                    };
                }

                this.IsLoading = false;

                MessagingCenter.Send(this, LISTS_LOADED_MSG);
            });

        }

    }
}
