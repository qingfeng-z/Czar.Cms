#region license

// <copyright company="ZAN LLC" file="TestService.cs">
//   Copyright (c)2019 ZAN ALL RIGHTS RESERVED.
// </copyright>

#endregion

namespace sample05
{
    #region region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Dapper;

    using MySql.Data.MySqlClient;

    #endregion

    /// <summary>
    ///     The test service.
    /// </summary>
    public class TestService
    {
        private readonly string mySqlConn =
            "server=localhost;port=3306;database=sample05;user=root;password=123456;charset=utf8";
        /// <summary>
        /// 单挑插入.
        /// </summary>
        public void Insert()
        {
            var content = new Content { Title = "c#", Cnt = ".net.....", Status = 1 };
            using (var db =
                new MySqlConnection(this.mySqlConn))
            {
                var sql =
                    @"INSERT INTO Content (title, cnt, status, created, lastUpdate) VALUES (@title,@cnt,@status,@created,@lastUpdate)";
                var result = db.Execute(sql, content);
                Console.WriteLine($"Insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 批量新增.
        /// </summary>
        public void BatchInsert()
        {
            var contents = new List<Content>
                               {
                                   new Content { Title = "c#", Cnt = ".net.....", Status = 1 },
                                   new Content { Title = "java", Cnt = "JVM虚拟机讲解", Status = 1 }
                               };
            using (var db =
                new MySqlConnection(this.mySqlConn))
            {
                var sql =
                    @"INSERT INTO Content (title, cnt, status, created, lastUpdate) VALUES (@title,@cnt,@status,@created,@lastUpdate)";
                var result = db.Execute(sql, contents);
                Console.WriteLine($"BatchInsert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 单挑删除.
        /// </summary>
        public void Del()
        {
            var content = new Content { Row_id = 1 };
            using (var db =
                new MySqlConnection(this.mySqlConn))
            {
                var sql = @"Delete FROM CONTENT WHERE row_id = @row_id";
                var result = db.Execute(sql, content);
                Console.WriteLine($"Del：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 批量删除.
        /// </summary>
        public void BatchDel()
        {
            var contents = new List<Content>
                               {
                                   new Content { Row_id = 7 },
                                   new Content { Row_id = 8 }
                               };
            using (var db =
                new MySqlConnection(this.mySqlConn))
            {
                var sql = @"Delete FROM CONTENT WHERE row_id = @row_id";
                var result = db.Execute(sql, contents);
                Console.WriteLine($"BatchDel：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 单挑更新.
        /// </summary>
        public void Update()
        {
            var content = new Content { Row_id = 9, Title = "c# mvc", Cnt = " mvc详述" };
            using (var db =
                new MySqlConnection(this.mySqlConn))
            {
                var sql = @"UPDATE CONTENT SET title=@title , cnt = @cnt, lastUpdate = @lastUpdate  WHERE row_id = @row_id";
                var result = db.Execute(sql, content);
                Console.WriteLine($"Update：更新了{result}条数据！");
            }
        }

        /// <summary>
        /// 批量更新.
        /// </summary>
        public void BatchUpdate()
        {
            var contents = new List<Content>
                               {
                                   new Content { Row_id = 9, Title = "c# mvc", Cnt = " mvc详述" },
                                   new Content { Row_id = 10, Title = "java进阶", Cnt = " jra" }
                               };
            using (var db =
                new MySqlConnection(this.mySqlConn))
            {
                var sql = @"UPDATE CONTENT SET title=@title , cnt = @cnt, lastUpdate = @lastUpdate  WHERE row_id = @row_id";
                var result = db.Execute(sql, contents);
                Console.WriteLine($"BatchUpdate：更新了{result}条数据！");
            }
        }

        /// <summary>
        /// 查询.
        /// </summary>
        public void Select()
        {
            using (var db =
                new MySqlConnection(this.mySqlConn))
            {
                var sql = @"SELECT * FROM CONTENT";
                var result1 = db.Query<Content>(sql).ToList();
                Console.WriteLine($"Select：查询{result1.Count}条数据！");

                sql = $@"SELECT * FROM CONTENT WHERE row_id = {12}";
                var result2 = db.Query<Content>(sql).FirstOrDefault();
                Console.WriteLine($"Select：查询row_id = {result2?.Row_id} 的数据！");

                sql = @"SELECT * FROM CONTENT WHERE row_id in @row_ids";
                var result3 = db.Query<Content>(sql, new { row_ids = new[] { 11, 12 } }).ToList();
                Console.WriteLine($"Select：查询{result3.Count}条数据！");

                // 关联查询 创建新的一个类 ContentWithComment
                sql = @"SELECT * FROM CONTENT WHERE row_id = @row_id;
                        SELECT * FROM COMMENT WHERE contentId = @row_id;";
                var result4 = db.QueryMultiple(sql, new { row_id = 11 });
                var content = result4.ReadFirstOrDefault<ContentWithComment>();
                content.Comments = result4.Read<Comment>();
                Console.WriteLine($"Select：查询row_id = {content.Row_id} 的内容有 {content.Comments?.Count()} 条评论");
            }
        }
    }
}