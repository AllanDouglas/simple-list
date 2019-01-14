using System;
using System.Linq;
using System.Threading.Tasks;
using TheSimpleList.Src.Basic.List.Data;
using TheSimpleList.Src.Modules.List.ViewModels;
using Xamarin.Forms;

namespace TheSimpleList.Src.Modules.List.Views
{


    public partial class ListPage : ContentPage
    {

        private readonly ListViewModel model;

        public ListPage(ListViewModel model)
        {
            InitializeComponent();
            this.model = model;
            BindingContext = model;
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Task.Run(model.Save);
        }

        private void AddItem(object sender, System.EventArgs e)
        {
            var input = (sender as Entry);

            if (input.Text == string.Empty) return;

            var text = input.Text.Trim().Split(' ');

            var amount = text.Where(i => i.All(char.IsDigit)).FirstOrDefault() ?? "1";

            var product = String.Join(
                " ",
                text.Where(i => !i.All(char.IsDigit)).ToArray()
            );

            model.AddItem(new Item(new Product(product), int.Parse(amount)));
            input.Text = String.Empty;
            input.Focus();
#pragma warning disable
            model.Save();
#pragma warning restore 
        }

        private void OnToggled(object sender, ToggledEventArgs e)
        {
            if (sender is Switch @switch)
            {
                if (@switch.BindingContext is Item item)
                {
                    @switch.BindingContext = this.model.CheckItem(item, @switch.IsToggled);
#pragma warning disable CS4014
                    model.Save();
#pragma warning restore CS4014
                }
            }
        }


    }
}
