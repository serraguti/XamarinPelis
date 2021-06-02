using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
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

        private Pelicula _PeliculaSeleccionada;
        public Pelicula PeliculaSeleccionada
        {
            get { return this._PeliculaSeleccionada; }
            set
            {
                this._PeliculaSeleccionada = value;
                OnPropertyChanged("PeliculaSeleccionada");
            }
        }

        public Command MostrarDetalles
        {
            get
            {
                return new Command(async() =>
                {
                    await Application.Current.MainPage.DisplayAlert
                    ("Alert", "Peli " + this.PeliculaSeleccionada.Titulo
                    , "OK");
                });
            }
        }

        public Command BorrarCache
        {
            get
            {
                return new Command(async() => {
                    Barrel.Current.EmptyAll();
                    await Application.Current.MainPage.DisplayAlert
                    ("Alert", "Cache borrado", "OK");
                });
            }
        }

        public Command CargarPeliculas
        {
            get
            {
                return new Command(async() => {
                    List<Pelicula> pelis =
                    await this.ServicePeliculas.GetPeliculasAsync();
                    this.Peliculas =
                    new ObservableCollection<Pelicula>(pelis);
                });
            }
        }
    }
}
