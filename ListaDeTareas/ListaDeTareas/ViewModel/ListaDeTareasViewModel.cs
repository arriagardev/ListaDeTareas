using ListaDeTareas.Models;
using ListaDeTareas.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDeTareas.ViewModel
{
    public class ListaDeTareasViewModel : BaseFodyObservable
    {

        public ListaDeTareasViewModel(INavigation navigation)
        {
            _navigation = navigation;

            // ListaAgrupada = ObtenerListaAgrupada();
            ObtenerListaAgrupada().ContinueWith(t =>
            {
                ListaAgrupada = t.Result;
            });
            Eliminar = new Command<TareaItem>(AccionEliminar);
            Completada = new Command<TareaItem>(AccionCompletada);
            AgregarTarea = new Command(AccionAgregar);
        }

        private INavigation _navigation;
        public ILookup<string, TareaItem> ListaAgrupada { get; set; }
        public Command<TareaItem> Eliminar { get; set;  }
        public Command<TareaItem> Completada { get; set; }
        public Command AgregarTarea { get; set; }
        public string Titulo => "Mi Lista de Tareas";

        public List<TareaItem> _listaDeTareas = new List<TareaItem>
        {
            new TareaItem { Id = 0, Nombre = "Primera tarea", Completada = true},
            new TareaItem { Id = 1, Nombre = "Segunda tarea"},
            new TareaItem { Id = 2, Nombre = "Tercera tarea"},
        };        

        private async Task<ILookup<string, TareaItem>> ObtenerListaAgrupada()
        {
            return (await App.TareasRepository.ObtenerLista())
                .OrderBy(t => t.Completada)
                .ToLookup(t => t.Completada ? "Completada" : "Activa");
        }

        public async void AccionEliminar(TareaItem tareaEliminar)
        {
            // Eliminar item the la lista
            await App.TareasRepository.EliminarTarea(tareaEliminar);
            // Actualizar listado de tareas
            ListaAgrupada = await ObtenerListaAgrupada();
        }

        public async void AccionCompletada(TareaItem tareaCompletar)
        {
            // Modificar propiedad Completada
            await App.TareasRepository.ModificarTareaActivacion(tareaCompletar);
            // Actualizar listado de tareas
            ListaAgrupada = await ObtenerListaAgrupada();
        }

        public async void AccionAgregar()
        {
            await _navigation.PushModalAsync(new AgregarTarea());
        }

        public async Task ActualizarLista()
        {
            ListaAgrupada = await ObtenerListaAgrupada();
        }
    }
}
