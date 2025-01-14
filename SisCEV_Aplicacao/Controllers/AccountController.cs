﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SisCEV_Aplicacao.Models;
using SisCEV_Aplicacao.Infraestrutura;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SisCEV_Aplicacao.Controllers
{
    public class AccountController : Controller
    {
        // GET: Seguranca/Account
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Login", "Account", new { area = "" });
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Usuario user = UserManager.Find(details.Nome, details.Senha);
                if (user == null)
                {
                    ModelState.AddModelError("", "Nome ou senha inválido(s).");
                }
                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    if (returnUrl == null)
                        returnUrl = "/Cadastros/Produtos";
                    return Redirect(returnUrl);
                }
            }
            return View(details);
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
    }
}