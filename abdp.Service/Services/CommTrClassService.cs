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
    public class CommTrClassService : ICommTrClassService
    {
        private IQueryable<CommTrClassServiceModel> Query
        {
            get
            {
                PdamEntities dbContext = new PdamEntities();

                // USING NATIVE SQL - DEFINE THE SQL QUERY
                string sqlQuery = @"
                    select
                    a.group_code,
                    a.class_code,
                    a.class_desc,
                    a.meter_size_code,
                    
                    b.group_desc
                    
                    from comm.tr_class a
                    
                    join comm.tr_group b
                    on a.group_code = b.group_code
                    ";

                // EXECUTE THE QUERY AND MAP TO THE MODEL
                var qry = dbContext.Database.SqlQuery<CommTrClassServiceModel>(sqlQuery).AsQueryable();

                return qry;
            }
        }

        public List<CommTrClassServiceModel> GetList(
            Expression<Func<CommTrClassServiceModel, bool>> where,
            int take,
            int skip,
            Expression<Func<CommTrClassServiceModel, string>> sort,
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

        public int TotalRows(Expression<Func<CommTrClassServiceModel, bool>> where)
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
                dbContext.comm_tr_class.Add(new comm_tr_class
                {
                    group_code = 6,
                    class_code = "xxx",
                    class_desc = "xxx",
                    meter_size_code = 0
                });

                comm_tr_class item1 = new comm_tr_class();
                item1.group_code = 6;
                item1.class_code = "yyy";
                item1.class_desc = "yyy";
                item1.meter_size_code = 0;
                dbContext.comm_tr_class.Add(item1);

                comm_tr_class item2 = new comm_tr_class();
                item1.group_code = 6;
                item2.class_code = "zzz";
                item2.class_desc = "zzz";
                item1.meter_size_code = 0;
                dbContext.comm_tr_class.Add(item2);

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
