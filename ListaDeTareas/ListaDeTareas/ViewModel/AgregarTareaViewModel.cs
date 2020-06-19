using ListaDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListaDeTareas.ViewModel
{
    class AgregarTareaViewModel : BaseFodyObservable
    {
        public AgregarTareaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Guardar = new Command(AccionGuardar);
            Cancelar = new Command(AccionCancelar);
        }

        private INavigation _navigation;
        public string TituloTarea { get; set; }

        public Command Guardar { get; set; }
        public async void AccionGuardar()
        {
            await App.TareasRepository.AgregarTarea(new TareaItem { Nombre = TituloTarea });
            await _navigation.PopModalAsync();
        }

        public Command Cancelar { get; set; }
        public async void AccionCancelar()
        {
            await _navigation.PopModalAsync();
        }
    }
}
