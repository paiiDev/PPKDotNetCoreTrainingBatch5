using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCoreTraining.ConsoleApp
{
    public class AdoDotNet
    {
        private readonly string _connectionString = "Data Source=.; Initial Catalog=DotNetTrainingBatch5; User ID=sa; Password=sasa@123";
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


           
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd2 = new SqlCommand(query, connection);
            cmd2.Parameters.AddWithValue("@blogTitle", title);
            cmd2.Parameters.AddWithValue("@blogAuthor", author);
            cmd2.Parameters.AddWithValue("@blogContent", content);

            int result = cmd2.ExecuteNonQuery();

            Console.WriteLine(result == 1 ? "Data saved" : "Data saving failed");

            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);

            connection.Close();
        }

        public void Read()
        {
           
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Connection opening");
            connection.Open();
            Console.WriteLine("Connection opened");

            string query = @"SELECT [blogId]
                  ,[blogTitle]
                  ,[blogAuthor]
                  ,[blogContent]
                  ,[deleteFlag]
              FROM [dbo].[Tbl_blog]
            ";

            SqlCommand cmd = new SqlCommand(query, connection);


            //sqldatareader reader = cmd.executereader();

            //while (reader.read())
            //{
            //    console.writeline("blog id: " + reader["blogid"]);
            //    console.writeline("blog title: " + reader["blogtitle"]);
            //    console.writeline("blog author: " + reader["blogauthor"]);
            //    console.writeline("blog content: " + reader["blogcontnet"]);
            //    console.writeline("delete flag: " + reader["deleteflag"]);
            //    console.writeline("---------------------------");
            //}




            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

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
            string id = Console.ReadLine();

            string query = $@"SELECT [blogId]
      ,[blogTitle]
      ,[blogAuthor]
      ,[blogContent]
      ,[deleteFlag]
  FROM [dbo].[Tbl_blog] where blogId = @blogId";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogId", id);
            SqlDataAdapter  adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("Data not found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine("Blog ID: " + dr["blogId"]);
            Console.WriteLine("Blog Title: " + dr["blogTitle"]);
            Console.WriteLine("Blog Author: " + dr["blogAuthor"]);
            Console.WriteLine("Blog Content: " + dr["blogContent"]);
            Console.WriteLine("---------------------------");


            connection.Close();
        }

        public void Update()
        {
            Console.WriteLine("Blog id :");
            string id = Console.ReadLine();

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



            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogId", id);
            cmd.Parameters.AddWithValue("@blogTitle", title);
            cmd.Parameters.AddWithValue("@blogAuthor", author);
            cmd.Parameters.AddWithValue("@blogContent", content);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result == 1 ? "Data updated" : "Data updating failed");

            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);

            connection.Close();
        }

        public void Delete()
        {
            Console.WriteLine("Enter blog id to delete :");
            string id = Console.ReadLine();

            


            string query = $@"DELETE FROM [dbo].[Tbl_blog]
      WHERE blogId = @blogId";



            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogId", id);
           

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result == 1 ? "Data deleted" : "Data deletetion failed");

            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);

            connection.Close();
        }
    }
}
