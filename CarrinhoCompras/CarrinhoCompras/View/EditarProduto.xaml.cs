using CarrinhoCompras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarrinhoCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarProduto : ContentPage
    {
        public EditarProduto()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {

                Produto p = new Produto
                {
                    id = ((Produto) BindingContext).id,
                    descricao = txt_descricao.Text,
                    quantidade = Convert.ToDouble(txt_quantidade.Text),
                    preco = Convert.ToDouble(txt_preco.Text),
                };

                await App.Database.Update(p);

                await DisplayAlert("Sucesso!", "Produto Editado", "Ok");

                await Navigation.PushAsync(new Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ops!", ex.Message, "Ok");
            }
        }
    }
}