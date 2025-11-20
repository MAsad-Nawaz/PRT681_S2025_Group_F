// -----------------------------------------------------------------------
// <copyright file="AccountType.cs" company="Visionary Computer Solutions">
// © 2014 Visionary Computer Solutions Pvt. Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace SPARS.Common
{
    using System;
    using System.Data;
    using SSS.BizLayer;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IDBEntity
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        bool GetList(string criteria, string fields, ref DataTable data, string orderby = "");

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        bool GetViewList(string criteria, string fields, ref DataTable data, string orderby = "");

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        int GetMax();

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        bool GetObjectFromQuery(string query);

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        bool GetObject();

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        Result SaveNew();

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        bool Modify();

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        Result Delete();
    }
}
