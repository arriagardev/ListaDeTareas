using ListaDeTareas.Helpers;
using ListaDeTareas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDeTareas.Data
{
    public class ListaDeTareasRepository
    {
        private readonly SQLiteAsyncConnection _database;
        public ListaDeTareasRepository()
        {            
            _database = new SQLiteAsyncConnection(DependencyService.Get<IArchivoHelper>().ObtenerRutaLocal("ListaTareaSQLite.db3"));
            _database.CreateTableAsync<TareaItem>().Wait();
        }

        public List<TareaItem> _listaDeTareas = new List<TareaItem>
        {
            new TareaItem { Id = 0, Nombre = "Primera tarea", Completada = true},
            new TareaItem { Id = 1, Nombre = "Segunda tarea"},
            new TareaItem { Id = 2, Nombre = "Tercera tarea"},
        };

        public async Task<List<TareaItem>> ObtenerLista()
        {            
            if ((await _database.Table<TareaItem>().CountAsync() == 0))
            {
                await _database.InsertAllAsync(_listaDeTareas);
            }

            return await _database.Table<TareaItem>().ToListAsync();
        }

        public Task EliminarTarea(TareaItem tareaBorrar)
        {
            return _database.DeleteAsync(tareaBorrar);
        }

        public Task ModificarTareaActivacion(TareaItem tareaModificar)
        {
            tareaModificar.Completada = !tareaModificar.Completada;
            return _database.UpdateAsync(tareaModificar);
        }

        public Task AgregarTarea(TareaItem tareaAgregar)
        {
            return _database.InsertAsync(tareaAgregar);
        }

    }
}
