#region license

// <copyright company="ZAN LLC" file="Content.cs">
//   Copyright (c)2019 ZAN ALL RIGHTS RESERVED.
// </copyright>

#endregion

namespace sample05
{
    #region region

    using System;

    #endregion

    /// <summary>
    ///     The content.
    /// </summary>
    public class Content
    {
        /// <summary>
        /// Gets or sets the cnt.
        /// </summary>
        public string Cnt { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        public DateTime LastUpdate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the row_id.
        /// </summary>
        public long Row_id { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}