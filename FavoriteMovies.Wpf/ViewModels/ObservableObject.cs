﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using FavoriteMovies.Wpf.Annotations;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class ObservableObject:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}