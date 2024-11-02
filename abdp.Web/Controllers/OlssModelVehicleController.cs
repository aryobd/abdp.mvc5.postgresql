using abdp.Service.IServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace abdp.Web.Controllers
{
    public class OlssModelVehicleController : Controller
    {
        private readonly IOlssModelVehicleService _service;

        public OlssModelVehicleController(
            IOlssModelVehicleService service
        )
        {
            _service = service;
        }

        // GET: OlssModelVehicle
        public ActionResult Index()
        {
            return View();
        }
    }
}