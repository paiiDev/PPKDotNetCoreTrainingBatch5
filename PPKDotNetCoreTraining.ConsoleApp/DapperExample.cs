using Dapper;
using PPKDotNetCoreTraining.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCoreTraining.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=.; Initial Catalog=DotNetTrainingBatch5; User ID=sa; Password=sasa@123";
        public void Read()
        {
            //using (IDbConnection db = new SqlConnection(_connectionString))
            //{
            //    string query = "select * from tbl_blog where deleteFlag = 0";
            //    var lst = db.Query(query).ToList();
            //    foreach (var item in lst)
            //    {
            //        Console.WriteLine(item.blogId);
            //        Console.WriteLine(item.blogTitle);
            //        Console.WriteLine(item.blogAuthor);
            //        Console.WriteLine(item.blogContent);
            //        Console.WriteLine("----------------");
            //    }

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where deleteFlag = 0";
                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.blogId);
                    Console.WriteLine(item.blogTitle);
                    Console.WriteLine(item.blogAuthor);
                    Console.WriteLine(item.blogContent);
                    Console.WriteLine("----------------");
                }
            }

        }

        public void Create(string title, string author, string content)
        {

            string query = $@"INSERT INTO [dbo].[Tbl_blog]
           ([blogTitle]
           ,[blogAuthor]
           ,[blogContent]
           ,[deleteFlag])
     VALUES
           (@blogTitle
           ,@blogAuthor
           ,@blogContent
           ,0)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    blogTitle = title,
                    blogAuthor = author,
                    blogContent = content,
                });
                Console.WriteLine(result == 1 ? "Data saved" : "Data saving failed");
            }

        }

    }
}
