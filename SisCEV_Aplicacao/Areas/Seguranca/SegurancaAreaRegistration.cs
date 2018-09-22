using System.Web.Mvc;

namespace SisCEV_Aplicacao.Areas.Seguranca
{
    public class SegurancaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Seguranca";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Seguranca_default",
                "Seguranca/{controller}/{action}/{id}",
                new { controller = "Account", action = "Login", id = UrlParameter.Optional }
                //namespaces: new[] { "SisCEV_Aplicacao.Areas.Seguranca.Controllers" }
            );
        }
    }
}