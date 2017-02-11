using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using AutoMapper;
using CustomerPayments.Data.Mappers;

namespace CustomerPayments.Host.DependancyResolution
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMapper>().UsingFactoryMethod(
                () => AutoMapperFactory.Create()));
        }
    }
}