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

            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<EfContactDal>().As<IContactDal>();

            builder.RegisterType<MailManager>().As<IMailService>();
           
            builder.RegisterType<RoomManager>().As<IRoomService>();
            builder.RegisterType<EfRoomDal>().As<IRoomDal>();

            builder.RegisterType<ProjectManager>().As<IProjectService>();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>();
            
            builder.RegisterType<AboutArticleManager>().As<IAboutArticleService>();
            builder.RegisterType<EfAboutArticleDal>().As<IAboutArticleDal>();

            builder.RegisterType<FaqManager>().As<IFaqService>();
            builder.RegisterType<EfFaqDal>().As<IFaqDal>();

            builder.RegisterType<NewsManager>().As<INewsService>();
            builder.RegisterType<EfNewsDal>().As<INewsDal>();
        
			builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>();
			builder.RegisterType<EfAnnouncementDal>().As<IAnnouncementDal>();
		
			builder.RegisterType<OrganizationManager>().As<IOrganizationService>();
			builder.RegisterType<EfOrganizationDal>().As<IOrganizationDal>();
		
			builder.RegisterType<OrganizationManager>().As<IOrganizationService>();
			builder.RegisterType<EfOrganizationDal>().As<IOrganizationDal>();
		}
    }
}