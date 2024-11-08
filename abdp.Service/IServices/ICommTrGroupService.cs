using abdp.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace abdp.Service
{
    public interface ICommTrGroupService
    {
        List<CommTrGroupServiceModel> GetList(
            Expression<Func<CommTrGroupServiceModel, bool>> where,
            int take,
            int skip,
            Expression<Func<CommTrGroupServiceModel, string>> sort,
            string sortDirection
        );

        int TotalRows();
        int TotalRows(Expression<Func<CommTrGroupServiceModel, bool>> where);

        int DoSave();
    }
}
