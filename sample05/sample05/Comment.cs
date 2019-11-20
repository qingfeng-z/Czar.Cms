#region license

// <copyright company="ZAN LLC" file="Comment.cs">
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
    public class Comment
    {
        /// <summary>
        /// Gets or sets the row_id.
        /// </summary>
        public long Row_id { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public long ContentId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;
    }
}