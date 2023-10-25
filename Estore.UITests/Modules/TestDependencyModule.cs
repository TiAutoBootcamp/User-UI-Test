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
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<ProductSteps>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<UserSteps>()
                .SingleInstance()
                .AsSelf();

            builder.RegisterType<AdminSteps>()
                .SingleInstance()
                .AsSelf();

            builder.RegisterType<ProductStepsAssertions>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<LoginStepsAssertions>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<CreateUserStepsAssertions>()
                .SingleInstance()
                .AsSelf();            

            builder
                .RegisterType<CommonStepsAssertions>()
                .SingleInstance()
                .AsSelf(); 

            builder
                .RegisterType<CommonSteps>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<Transformations>()
                .SingleInstance()
                .AsSelf();
        }
    }
}
