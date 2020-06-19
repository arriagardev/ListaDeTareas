using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeTareas.Models
{
    public class TareaItem : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Completada { get; set; }
    }
}
