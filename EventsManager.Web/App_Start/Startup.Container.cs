using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.SignalR;
using EventsManager.Web.Data;
using EventsManager.Web.Domain.Entities;
using EventsManager.Web.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;

namespace EventsManager.Web
{
    public partial class Startup
    {
        public static void ConfigureContainer(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).AsImplementedInterfaces();
            builder.RegisterHubs(Assembly.GetExecutingAssembly());
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterFilterProvider();

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            builder.Register(c => new ApplicationUserStore(c.Resolve<ApplicationDbContext>()))
                .As<IUserStore<ApplicationUser>>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ApplicationRoleStore(c.Resolve<ApplicationDbContext>()))
                .As<IRoleStore<ApplicationRole>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext()).As<IOwinContext>();

            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));
            GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}
