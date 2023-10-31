﻿using Autofac;
using CoreAdditional.Providers;
using CoreAdditional.Utils;
using Estore.Clients.Clients;
using Estore.Core.HTTP;
using Microsoft.Extensions.Configuration;

namespace CoreAdditional.Modules
{
    public class CoreAdditionalDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterHttpClientAndConfiguration(builder);

            builder
                .RegisterType<HtpClientCustom>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<UserClient>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<WalletClient>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<CatalogClient>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<WarehouseClient>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<OrderClient>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<UserServiceProvider>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<CatalogServiceProvider>()
                .SingleInstance()
                .AsSelf();

            builder
               .RegisterType<UserRequestGenerator>()
               .AsSelf();

            builder
                .RegisterType<CatalogRequestGenerator>()
                .AsSelf();

            builder
                .RegisterType<TokenManager>()
                .SingleInstance()
                .AsSelf();           
        }

        private void RegisterHttpClientAndConfiguration(ContainerBuilder builder)
        {
            var httpClient = new HttpClient();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            builder.RegisterInstance(httpClient).As<HttpClient>();
            builder.RegisterInstance(configuration).As<IConfiguration>();
        }
    }
}