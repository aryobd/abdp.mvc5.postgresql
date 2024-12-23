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

                #region 1
                // USING VIRTUAL OBJECT IN ENTITIES (SEE ENTITIES - ACTUALLY REMARKS ALL VIRTUAL OBJECT) 
                var qry1 = dbContext.comm_tr_group.Select(
                    o => new CommTrGroupServiceModel
                    {
                        group_code = o.GroupCode,
                        group_desc = o.GroupDesc
                    }
                );

                return qry1;
                #endregion 1

                /*
                #region 3
                // USING NATIVE SQL - DEFINE THE SQL QUERY
                string sqlQuery = @"
                    select
                    a.group_code,
                    a.group_desc
                    
                    from comm.tr_group a
                    ";

                // EXECUTE THE QUERY AND MAP TO THE MODEL
                var qry3 = dbContext.Database.SqlQuery<CommTrGroupServiceModel>(sqlQuery).AsQueryable();

                return qry3;
                #endregion 3
                */
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

        public int DoSave(List<CommTrGroupServiceModel> lst)
        {
            using (var context = new PdamEntities())
            {
                var test = context.comm_tr_group.FirstOrDefault();
                Console.WriteLine(test?.GroupDesc ?? "No Data");
            }

            PdamEntities dbContext = new PdamEntities();
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                dbContext.comm_tr_group.Add(new comm_tr_group
                {
                    GroupCode = 8,
                    GroupDesc = "xxx"
                });

                comm_tr_group item1 = new comm_tr_group();
                item1.GroupCode = 9;
                item1.GroupDesc = "yyy";
                dbContext.comm_tr_group.Add(item1);

                var debugItem = dbContext.comm_tr_group.ToList(); // LIHAT PROPERTI YANG DIISI

                dbContext.SaveChanges();

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                Console.WriteLine(ex.Message);
            }

            return 1;
        }
    }
}
