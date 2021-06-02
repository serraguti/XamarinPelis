using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinPelis.Base;
using XamarinPelis.Models;
using XamarinPelis.Services;

namespace XamarinPelis.ViewModels
{
    public class PeliculasViewModel: ViewModelBase
    {
        ServicePeliculas ServicePeliculas;

        public PeliculasViewModel(ServicePeliculas servicePeliculas)
        {
            this.ServicePeliculas = servicePeliculas;
            Task.Run(async () =>
            {
                List<Pelicula> pelis = 
                await this.ServicePeliculas.GetPeliculasAsync();
                this.Peliculas = new ObservableCollection<Pelicula>(pelis);
            });
        }

        private ObservableCollection<Pelicula> _Peliculas;
        public ObservableCollection<Pelicula> Peliculas {
            get { return this._Peliculas; }
            set
            {
                this._Peliculas = value;
                OnPropertyChanged("Peliculas");
            }
        }
    }
}
