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

        //[HttpPost]
        public ActionResult AjaxHandler2(DataTableRequest param)
        {
            try
            {
                #region FILTERING
                Expression<Func<CommTrClassServiceModel, bool>> filter = null;

                // GLOBAL SEARCH
                if (!string.IsNullOrEmpty(param.Search?.Value))
                {
                    var searchValue = param.Search.Value;

                    filter = o =>
                        o.group_desc.Contains(searchValue)
                        ||
                        o.class_code.Contains(searchValue)
                        ||
                        o.class_desc.Contains(searchValue);
                }
                #endregion FILTERING

                #region SORTING
                string sortColumn = "class_code"; // Default sorting column
                string sortDirection = "asc";    // Default sorting direction

                if (param.Order != null && param.Order.Any())
                {
                    var sortOrder = param.Order.First();
                    sortColumn = param.Columns[sortOrder.Column].Data;

                    sortDirection = sortOrder.Dir;
                }
                #endregion SORTING

                #region DATA FETCHING
                // FETCH THE FILTERED AND SORTED DATA
                //var lstData = _service.GetList(
                //    filter, // filter
                //    param.Length, // take
                //    param.Start, // skip
                //    sortDirection // orderBy
                //);

                // CALCULATE TOTAL RECORDS AND FILTERED RECORDS
                var totalRecords = _service.TotalRows();
                var totalFilteredRecords = _service.TotalRows(filter);
                #endregion DATA FETCHING

                #region RETURN JSON
                //return Json(new
                //{
                //    draw = param.Draw,
                //    recordsTotal = totalRecords,
                //    recordsFiltered = totalFilteredRecords,
                //    data = lstData // Format sesuai dengan DataTables modern
                //});
                #endregion RETURN JSON

                return Json(new
                {
                    error = "An error occurred while processing your request.",
                    details = "ex.Message"
                });
            }
            catch (Exception ex)
            {
                // LOG ERROR (OPTIONAL)
                return Json(new
                {
                    error = "An error occurred while processing your request.",
                    details = ex.Message
                });
            }
        }
    }
}
