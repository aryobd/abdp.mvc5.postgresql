using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace abdp.Web.Models
{
    public class DataTableRequest
    {
        /// <summary>
        /// Request sequence number sent by DataTable, must be returned in the response.
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// Index of the first record to be returned (used for paging).
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Number of records to be returned (used for paging).
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Search value entered in the search box.
        /// </summary>
        public Search Search { get; set; }

        /// <summary>
        /// List of columns in the table.
        /// </summary>
        public List<Column> Columns { get; set; }

        /// <summary>
        /// List of sorting instructions.
        /// </summary>
        public List<Order> Order { get; set; }
    }

    public class Search
    {
        /// <summary>
        /// Search text.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Indicates if the search is regex-based.
        /// </summary>
        public bool Regex { get; set; }
    }

    public class Column
    {
        /// <summary>
        /// Column data source name.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Column name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if this column is searchable.
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// Indicates if this column is sortable.
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// Search value for this column.
        /// </summary>
        public Search Search { get; set; }
    }

    public class Order
    {
        /// <summary>
        /// Column index for sorting.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Sorting direction (asc or desc).
        /// </summary>
        public string Dir { get; set; }
    }
}
