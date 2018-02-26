using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C_ENTIDAD;
using C_LOGICA;

namespace C_PRESENTACION.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult VerificarAcceso()
        {
            return View();
        }
        [HttpPost]

        public ActionResult VerificarAcceso(FormCollection frm)
        {
            try
            {
                String txtUsuario = frm["txtUsuario"];
                String txtPassword = frm["txtPassword"];
                Usuario usu = logUsuario.Instancia.VerificarAcceso(txtUsuario, txtPassword);

                Session["usuarito"] = usu;//:v

                return RedirectToAction("Listar", "Menu");

            }
            catch (ApplicationException e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }

            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
            
        }

    }
}