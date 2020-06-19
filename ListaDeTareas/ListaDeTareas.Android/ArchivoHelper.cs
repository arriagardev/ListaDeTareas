using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ListaDeTareas.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ArchivoHelper))]
namespace ListaDeTareas.Droid
{
    public class ArchivoHelper : IArchivoHelper
    {
        public string ObtenerRutaLocal(string nombreArchivo)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, nombreArchivo);
        }
    }
}