﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ListaDeTareas
{
    public abstract class BaseFodyObservable : INotifyPropertyChanged
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore
    }
}
