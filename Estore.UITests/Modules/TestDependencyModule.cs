using Autofac;
using System.Reflection;
using TechTalk.SpecFlow;
using UITests.Context;

namespace UITests.Modules
{
    public class TestDependencyModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DataContext>()
                .SingleInstance()
                .AsSelf();

            var assembly = Assembly.GetExecutingAssembly();

            var featureTypes = assembly
                .GetTypes()
                .Where(type => type
                    .GetCustomAttributes<BindingAttribute>()
                    .Any())
                .ToArray();

            builder
                .RegisterTypes(featureTypes)
                .SingleInstance()
                .AsSelf();            
        }
    }
}