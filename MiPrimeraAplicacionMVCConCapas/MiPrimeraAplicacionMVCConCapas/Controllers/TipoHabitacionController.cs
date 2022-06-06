using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaNegocio;

namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class TipoHabitacionController : Controller
    {



        // GET: TipoHabitacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult VistaPruebaInicio()
        {
            return View();
        }

        public string cadena()
        {
            return "123";
        }

        public int numero()
        {
            return 10;
        }


        //[{"id":1,"nombre":"simple","descripcion":"Solo para uno"},{"id":1,"nombre":"doble","descripcion":"Para dos"}]
        public JsonResult Lista()
        {
            TipoHabitacionBLL obj = new TipoHabitacionBLL();
            return Json(obj.listarTipoHabitacion(),JsonRequestBehavior.AllowGet);
        }

    }
}