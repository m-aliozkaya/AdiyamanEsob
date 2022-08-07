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

            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>();

            builder.RegisterType<PriceManager>().As<IPriceService>();
            builder.RegisterType<EfPriceDal>().As<IPriceDal>();

            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>();
            builder.RegisterType<EfAnnouncementDal>().As<IAnnouncementDal>();
            
            builder.RegisterType<OrganizationManager>().As<IOrganizationService>();
            builder.RegisterType<EfOrganizationDal>().As<IOrganizationDal>();

            builder.RegisterType<OrganizationMemberManager>().As<IOrganizationMemberService>();
            builder.RegisterType<EfOrganizationMemberDal>().As<IOrganizationMemberDal>();
            
            builder.RegisterType<SettingManager>().As<ISettingService>();
            builder.RegisterType<EfSettingDal>().As<ISettingDal>();
            
            builder.RegisterType<VideoManager>().As<IVideoService>();
            builder.RegisterType<EfVideoDal>().As<IVideoDal>();
            
            builder.RegisterType<LegislationManager>().As<ILegislationService>();
            builder.RegisterType<EfLegislationDal>().As<ILegislationDal>();

            builder.RegisterType<PresidentManager>().As<IPresidentService>();
            builder.RegisterType<EfPresidentDal>().As<IPresidentDal>();
            
            builder.RegisterType<ActivityFieldManager>().As<IActivityFieldService>();
            builder.RegisterType<EfActivityFieldDal>().As<IActivityFieldDal>();
            
            builder.RegisterType<ServiceManager>().As<IServiceService>();
            builder.RegisterType<EfServiceDal>().As<IServiceDal>();
        }
    }
}