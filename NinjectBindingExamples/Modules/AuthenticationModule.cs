using System;
using System.Security.Principal;
using System.ServiceModel;
using System.Web;
using Ninject.Modules;

namespace NinjectBindingExamples.Modules
{
    public class AuthenticationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPrincipal>()
              .ToMethod(context =>
              {
                  // Get the web user
                  if (HttpContext.Current != null)
                  {
                      var identity = HttpContext.Current.User.Identity;
                      return new GenericPrincipal(identity, new string[] { });
                  }

                  // Get the service user
                  if (ServiceSecurityContext.Current != null)
                  {
                      var identity = ServiceSecurityContext.Current.WindowsIdentity;
                      return new GenericPrincipal(identity, new string[] { });
                  }

                  // Get the local windows user
                  var windowsIdentity = WindowsIdentity.GetCurrent();
                  if(windowsIdentity == null)
                      throw new ApplicationException("Unable to determine user identity");

                  var principal = new WindowsPrincipal(windowsIdentity);
                  return principal;
              });
        }
    }
}