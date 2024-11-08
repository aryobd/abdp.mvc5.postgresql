using abdp.Data.Entities;

using abdp.Service.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace abdp.Service
{
    public class CommTrGroupService : ICommTrGroupService
    {
        private IQueryable<CommTrGroupServiceModel> Query
        {
            get
            {
                PdamEntities dbContext = new PdamEntities();

                // USING NATIVE SQL - DEFINE THE SQL QUERY
                string sqlQuery = @"
                    select
                    a.group_code,
                    a.group_desc
                    
                    from comm.tr_group a
                    ";

                // EXECUTE THE QUERY AND MAP TO THE MODEL
                var qry = dbContext.Database.SqlQuery<CommTrGroupServiceModel>(sqlQuery).AsQueryable();

                return qry;
            }
        }

        public List<CommTrGroupServiceModel> GetList(
            Expression<Func<CommTrGroupServiceModel, bool>> where,
            int take,
            int skip,
            Expression<Func<CommTrGroupServiceModel, string>> sort,
            string sortDirection
        )
        {
            if (sortDirection.Equals("asc"))
            {
                if (where == null)
                    return Query.OrderBy(sort).Skip(skip).Take(take).ToList();
                else
                    return Query.Where(where).OrderBy(sort).Skip(skip).Take(take).ToList();
            }
            else
            {
                if (where == null)
                    return Query.OrderByDescending(sort).Skip(skip).Take(take).ToList();
                else
                    return Query.Where(where).OrderByDescending(sort).Skip(skip).Take(take).ToList();
            }
        }

        public int TotalRows()
        {
            return Query.Count();
        }

        public int TotalRows(Expression<Func<CommTrGroupServiceModel, bool>> where)
        {
            if (where == null)
                return TotalRows();

            return Query.Where(where).Count();
        }

        public int DoSave()
        {
            PdamEntities dbContext = new PdamEntities();
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                dbContext.comm_tr_group.Add(new comm_tr_group
                {
                    group_code = 8,
                    group_desc = "xxx"
                });

                comm_tr_group item1 = new comm_tr_group();
                item1.group_code = 9;
                item1.group_desc = "yyy";
                dbContext.comm_tr_group.Add(item1);

                comm_tr_group item2 = new comm_tr_group();
                item2.group_code = 10;
                item2.group_desc = "zzz";
                dbContext.comm_tr_group.Add(item2);

                dbContext.SaveChanges();

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }

            return 1;
        }
    }
}
