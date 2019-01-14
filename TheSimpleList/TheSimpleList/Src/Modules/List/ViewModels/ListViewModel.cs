using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TheSimpleList.Src.Basic.List.Data;
using TheSimpleList.Src.Basic.List.Services;
using TheSimpleList.Src.Basic.ViewModel;
using Xamarin.Forms;

namespace TheSimpleList.Src.Modules.List.ViewModels
{
    public class ListViewModel : AViewModel
    {
        #region Properties
        public ICommand RemoveCommand
        {
            get;
            private set;
        }

        public ProductList List
        {
            get
            {
                return _currentList;
            }
            private set
            {
                _currentList = value;
                OnPropertyChanged(nameof(this.List));
            }
        }

        public ObservableCollection<Item> Itens
        {
            get
            {
                var itens = new ObservableCollection<Item>();

                if (List != null)
                {

                    this.List.Itens.Aggregate(itens, (collection, item) =>
                    {
                        collection.Add(item);
                        return collection;
                    });
                }

                return itens;
            }
        }

        #endregion

        #region Fields

        private readonly IListService listService;

        private ProductList _currentList;
        #endregion

        public ListViewModel(ProductList list, IListService listService)
        {

            this.listService = listService;
            this.List = list;


            this.RemoveCommand = new Command<Item>(item =>
            {
                this.List.Itens.Remove(item);
                OnPropertyChanged(nameof(this.Itens));
#pragma warning disable CS4014 
                this.Save();
#pragma warning restore CS4014 
            });

            OnPropertyChanged(nameof(this.Itens));

        }

        internal async Task<bool> Delete()
        {
            return await this.listService.Delete(_currentList);
        }

        public async Task<bool> Save()
        {
            return await this.listService.Save(_currentList);
        }

        public Item CheckItem(Item item, bool isToggled)
        {
            var newItem = new Item(item.Product, item.Amount, isToggled);
            this._currentList.Itens.Add(newItem);
            this.List.Itens.Remove(item);
            return newItem;
        }

        public void AddItem(Item item)
        {
            this.List.Itens.Add(item);
            OnPropertyChanged(nameof(this.Itens));
        }


    }
}
