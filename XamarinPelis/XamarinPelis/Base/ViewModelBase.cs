﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinPelis.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this,
                 new PropertyChangedEventArgs(propertyName));
        }
    }
}
