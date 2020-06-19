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
    public partial class AgregarTarea : ContentPage
    {
        public AgregarTarea()
        {
            InitializeComponent();
            BindingContext = new AgregarTareaViewModel(Navigation);
        }
    }
}