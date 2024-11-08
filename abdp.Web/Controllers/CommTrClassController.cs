using abdp.Service;
using abdp.Service.Models;

using abdp.Web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace abdp.Web.Controllers
{
    public class CommTrClassController : Controller
    {
        private readonly ICommTrClassService _service;

        public CommTrClassController(ICommTrClassService service)
        {
            _service = service;
        }

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            try
            {
                #region SET FILTER
                Expression<Func<CommTrClassServiceModel, bool>> filter = null;

                if (param.sSearch != null)
                {
                    filter = (
                        o => o.group_desc.Contains(param.sSearch)
                             ||
                             o.class_code.Contains(param.sSearch)
                             ||
                             o.class_desc.Contains(param.sSearch)
                    );
                }
                #endregion SET FILTER

                #region SET SORTING & ORDERING
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                Expression<Func<CommTrClassServiceModel, string>> ordering = (
                    o => sortColumnIndex == 0 ? o.class_code :
                         sortColumnIndex == 1 ? o.class_desc :
                         o.group_desc
                );
                var sortDirection = Request["sSortDir_0"]; // ASC / DESC
                #endregion SET SORTING & ORDERING

                List<CommTrClassServiceModel> lstData = _service.GetList(
                   filter,
                   param.iDisplayLength,
                   param.iDisplayStart,
                   ordering,
                   sortDirection
               );

                _service.DoSave();

                return Json(new
                    {
                        param.sEcho,
                        iTotalRecords = _service.TotalRows(),
                        iTotalDisplayRecords = _service.TotalRows(filter),
                        aaData = lstData
                    },
                    JsonRequestBehavior.AllowGet
                );
            }
            catch (Exception ex)
            {
                return View("Error" + "/n" + ex.Message);
            }
        }
    }
}