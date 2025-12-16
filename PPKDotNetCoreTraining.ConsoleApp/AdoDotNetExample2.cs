using Dapper;
using DotNetTrainingBatch5.shared;
using PPKDotNetCoreTraining.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCoreTraining.ConsoleApp
{
    public class AdoDotNetExample2
    {
        private readonly string _connectionString = "Data Source=.; Initial Catalog=DotNetTrainingBatch5; User ID=sa; Password=sasa@123";
        private readonly AdoDotNetService _AdoDotNetService;

        public AdoDotNetExample2()
        {
            _AdoDotNetService = new AdoDotNetService(_connectionString);
        }

        public void Read()
        {
            string query = $@"SELECT [blogId]
      ,[blogTitle]
      ,[blogAuthor]
      ,[blogContent]
      ,[deleteFlag]
  FROM [dbo].[Tbl_blog] where deleteFlag = 0";

            var dt = _AdoDotNetService.Query(query);


            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("Blog ID: " + row["blogId"]);
                Console.WriteLine("Blog Title: " + row["blogTitle"]);
                Console.WriteLine("Blog Author: " + row["blogAuthor"]);
                Console.WriteLine("Blog Content: " + row["blogContent"]);
                Console.WriteLine("Delete Flag: " + row["deleteFlag"]);
                Console.WriteLine("---------------------------");
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

           var dt = _AdoDotNetService.Query(query, new SqlParameterModel { Name = "@blogId", Value = id });


            DataRow dr = dt.Rows[0];
            Console.WriteLine("Blog ID: " + dr["blogId"]);
            Console.WriteLine("Blog Title: " + dr["blogTitle"]);
            Console.WriteLine("Blog Author: " + dr["blogAuthor"]);
            Console.WriteLine("Blog Content: " + dr["blogContent"]);
            Console.WriteLine("---------------------------");

        }

        public void Create()
        {

            Console.WriteLine("Title :");
            string title = Console.ReadLine();

            Console.WriteLine("Author :");
            string author = Console.ReadLine();

            Console.WriteLine("Content :");
            string content = Console.ReadLine();


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



          var result = _AdoDotNetService.Execute(query,
                new SqlParameterModel("@blogTitle", title),
                new SqlParameterModel( "@blogAuthor", author),
                new SqlParameterModel("@blogContent",  content )
                );
     

            Console.WriteLine(result == 1 ? "Data saved" : "Data saving failed");

          
        }
    }
}
