#region license

// <copyright company="ZAN LLC" file="Program.cs">
//   Copyright (c)2019 ZAN ALL RIGHTS RESERVED.
// </copyright>

#endregion

namespace sample05
{
    #region region

    using System;

    #endregion

    /// <summary>
    /// Dapper 相关练习.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = new TestService();

            // test.Insert();
            // test.BatchInsert();
            // test.Del();
            // test.BatchDel();
            // test.Update();
            // test.BatchUpdate();
            test.Select();
            Console.ReadLine();
        }
    }
}