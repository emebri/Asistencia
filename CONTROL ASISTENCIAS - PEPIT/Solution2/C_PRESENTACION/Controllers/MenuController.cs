using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C_ENTIDAD;
using C_LOGICA;

namespace C_PRESENTACION.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult CerrarSesion()
        {
            Session.Remove("usuarito");
            return RedirectToAction("VerificarAcceso", "Login");
        }

        public ActionResult Index()
        {
            Usuario u = (Usuario)Session["usuarito"];
            ViewBag.mensaje = u.trabajador.nombre + " " + u.trabajador.apellidos;
            //ViewBag.usuario = u.trabajador.nombre + " " + u.trabajador.apellidos ;
            return View();
        }
       
        public ActionResult Listar()
        {
            try
            {
                List<Trabajador> lista = logTrabajador.Instancia.ListarTrabajador();
                return View(lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message});
            }
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            try
            {
                List<TipoTrabajador> listaTT = logTipoTrabajador.Instancia.ListarTipoTrabajador(true);
                var lsTipoTrabajador = new SelectList(listaTT, "idTipoTrabajador", "nombreTipo");
                ViewBag.ListaTT = lsTipoTrabajador;

                List<Facultad> listaF = logFacultad.Instancia.ListarFacultad(true);
                var lsFacultad = new SelectList(listaF, "idFacultad", "nombreFacultad");
                ViewBag.ListaF = lsFacultad;

                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult Nuevo(Trabajador t)
        {
            try
            {
                Boolean inserto = logTrabajador.Instancia.InsertarTrabajador(t);
                if (inserto)
                {
                    return RedirectToAction("Listar");
                }
                else { return View(t); }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message });
            }
        }

    }
}