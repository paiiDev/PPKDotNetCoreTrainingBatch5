using Dapper;
using PPKDotNetCoreTraining.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        public void Edit()
        {
            Console.Write("Enter ID: ");
            string string_id = Console.ReadLine();
            int id = int.Parse(string_id);
            
           

            string query = $@"SELECT [blogId]
      ,[blogTitle]
      ,[blogAuthor]
      ,[blogContent]
      ,[deleteFlag]
  FROM [dbo].[Tbl_blog] where blogId = @blogId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
              var item = db.Query<BlogDataModel>(query, new BlogDataModel { blogId = id }).FirstOrDefault();


                if(item is null)
                {
                    Console.WriteLine("Data not found");
                    return;
                }

                Console.WriteLine("Blog ID: " + item.blogId);
                Console.WriteLine("Blog ID: " + item.blogTitle);
                Console.WriteLine("Blog ID: " + item.blogAuthor);
                Console.WriteLine("Blog ID: " + item.blogContent);
                Console.WriteLine("---------------------------");
            }
        }

        public void Update()
        {
            Console.WriteLine("Blog id :");
            string string_id = Console.ReadLine();
            int id = int.Parse(string_id);

            Console.WriteLine("Title :");
            string title = Console.ReadLine();

            Console.WriteLine("Author :");
            string author = Console.ReadLine();

            Console.WriteLine("Content :");
            string content = Console.ReadLine();


            string query = $@"UPDATE [dbo].[Tbl_blog]
   SET [blogTitle] = @blogTitle
      ,[blogAuthor] = @blogAuthor
      ,[blogContent] = @blogContent
      ,[deleteFlag] = 0
 WHERE blogId = @blogId";

            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    blogId = id,
                    blogTitle = title,
                    blogAuthor = author,
                    blogContent = content
                });

                Console.WriteLine( result == 1 ? "Data updated": "Data updating failed");


            }

        }

        public void Delete()
        {
            Console.WriteLine("Blog id :");
            string string_id = Console.ReadLine();
            int id = int.Parse(string_id);


            string query = $@"DELETE FROM [dbo].[Tbl_blog]
      WHERE blogId = @blogId";

            using(IDbConnection db =new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    blogId = id
                });

                Console.WriteLine(result == 1 ? "Data deleted" : "Data deleting failed");
            }

        }
    }
}
