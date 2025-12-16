using Dapper;
using PPKDotNetCoreTraining.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCoreTraining.ConsoleApp
{
    public class DapperExample2
    {
        private readonly DotNetTrainingBatch5.shared.DapperServicee _dapperServicee;
        public DapperExample2()
        {
            _dapperServicee = new DotNetTrainingBatch5.shared.DapperServicee("Data Source=.; Initial Catalog=DotNetTrainingBatch5; User ID=sa; Password=sasa@123");
        }
        public void Read()
        {
            string query = "select * from tbl_blog where deleteFlag = 0";
            var lst = _dapperServicee.Query<Models.BlogDataModel>(query);
            foreach (var item in lst)
            {
                Console.WriteLine(item.blogId);
                Console.WriteLine(item.blogTitle);
                Console.WriteLine(item.blogAuthor);
                Console.WriteLine(item.blogContent);
                Console.WriteLine("----------------");
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

           
                var item = _dapperServicee.QueryFirstOrDefault<BlogDataModel>(query, new BlogDataModel { blogId = id });


                if (item is null)
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

          
                int result = _dapperServicee.Execute(query, new BlogDataModel
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
