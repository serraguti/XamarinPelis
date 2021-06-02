using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinPelis.ViewModels;

namespace XamarinPelis.Services
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC() { this.RegisterDependencies(); }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ServicePeliculas>();
            builder.RegisterType<PeliculasViewModel>();
            this.container = builder.Build();
        }

        public PeliculasViewModel PeliculasViewModel
        {
            get
            {
                return this.container.Resolve<PeliculasViewModel>();
            }
        }
    }
}
