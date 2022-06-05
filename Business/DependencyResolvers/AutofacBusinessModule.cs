using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<CircularManager>().As<ICircularService>();
            builder.RegisterType<EfCircularDal>().As<ICircularDal>();

            builder.RegisterType<RoomManager>().As<IRoomService>();
            builder.RegisterType<EfRoomDal>().As<IRoomDal>();

            builder.RegisterType<ProjectManager>().As<IProjectService>();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>();
            
            builder.RegisterType<AboutArticleManager>().As<IAboutArticleService>();
            builder.RegisterType<EfAboutArticleDal>().As<IAboutArticleDal>();
        }
    }
}