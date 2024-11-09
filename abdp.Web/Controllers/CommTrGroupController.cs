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
    public class CommTrGroupController : Controller
    {
        private readonly ICommTrGroupService _service;

        public CommTrGroupController(ICommTrGroupService service)
        {
            _service = service;
        }

        // GET: CommTrGroup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            try
            {
                #region SET FILTER
                Expression<Func<CommTrGroupServiceModel, bool>> filter = null;

                if (param.sSearch != null)
                {
                    filter = (
                        o => o.group_desc.Contains(param.sSearch)
                    );
                }
                #endregion SET FILTER

                #region SET SORTING & ORDERING
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                Expression<Func<CommTrGroupServiceModel, string>> ordering = (
                    o => sortColumnIndex == 0 ? o.group_desc : o.group_desc
                );
                var sortDirection = Request["sSortDir_0"]; // ASC / DESC
                #endregion SET SORTING & ORDERING

                List<CommTrGroupServiceModel> lstData = _service.GetList(
                   filter,
                   param.iDisplayLength,
                   param.iDisplayStart,
                   ordering,
                   sortDirection
                );

                List<CommTrGroupServiceModel> lstNew = new List<CommTrGroupServiceModel>();
                CommTrGroupServiceModel itmNew = new CommTrGroupServiceModel();

                itmNew.group_code = 8;
                itmNew.group_desc = "xxx";

                lstNew.Add(itmNew);

                itmNew.group_code = 9;
                itmNew.group_desc = "yyy";

                lstNew.Add(itmNew);

                _service.DoSave(lstNew);

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