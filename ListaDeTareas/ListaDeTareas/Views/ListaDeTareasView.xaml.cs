using ListaDeTareas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDeTareas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaDeTareasView : ContentPage
    {
        public ListaDeTareasView()
        {
            InitializeComponent();
            BindingContext = new ListaDeTareasViewModel(Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as ListaDeTareasViewModel).ActualizarLista();
        }
    }
}