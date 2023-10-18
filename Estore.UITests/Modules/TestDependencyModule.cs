using Autofac;
using Estore.UITests.StepDefinitions;
using Estore.UITests.StepDefinitions.Assertions;
using Estore.UITests.StepDefinitions.Base;
using UITests.Context;

namespace UITests.Modules
{
    public class TestDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DataContext>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<NavigationSteps>()
                .AsSelf();

            builder
                .RegisterType<ProductSteps>()
                .AsSelf();

            builder
                .RegisterType<UserSteps>()
                .AsSelf();

            builder
                .RegisterType<ProductStepsAssertions>()
                .AsSelf();

            builder
                .RegisterType<CommonSteps>()
                .AsSelf();

            builder
                .RegisterType<Transformations>()
                .AsSelf();
        }
    }
}
