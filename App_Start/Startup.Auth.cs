using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace PRUEBAGILA
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Habilite la aplicación para usar una cookie para almacenar información para el usuario que inició sesión
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/Index")
            });
            // Utilice una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión externo.
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
          
           
        }
    }
}