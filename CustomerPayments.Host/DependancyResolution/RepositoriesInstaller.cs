﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CustomerPayments.Data.Repositories;
using CustomerPayments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerPayments.Host.DependancyResolution
{
    public class RepositoriesInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(GenericRepository<>)).LifestylePerWebRequest());
            container.Register(
                Component.For<CustomerPaymentsContext>().LifestylePerWebRequest());
        }
    }
}