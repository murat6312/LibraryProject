using Autofac;
using AutoMapper;
using DataAcces.Context;
using DataAcces.Repositorys;

namespace Core.IOC
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            SetProfile(builder);
            builder.RegisterType<LibraryContext>().As<LibraryContext>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        }

        private void SetProfile(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assembly);
            });

            var mapper = config.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();
        }

    }
}
