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
    internal class EFcore
    {
        public void read()
        {
            AppDbContext db = new AppDbContext();
           var lst =  db.Blogs.Where(x => x.deleteFlag == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.blogId);
                Console.WriteLine(item.blogTitle);
                Console.WriteLine(item.blogAuthor);
                Console.WriteLine(item.blogContent);
                Console.WriteLine("----------------");
            }
        }

        public void Create(string title, string author, string content)
        {
            BlogDataModel blog = new BlogDataModel
            {
                blogTitle = title,
                blogAuthor = author,
                blogContent = content,
                deleteFlag = false
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            var result = db.SaveChanges();


            Console.WriteLine(result == 1 ? "Data saved" : "Data saving failed");
            }

        public void Edit()
        {
            Console.Write("Enter ID: ");
            string string_id = Console.ReadLine();
            int id = int.Parse(string_id);

            AppDbContext db = new AppDbContext();
            var item = db.Blogs.FirstOrDefault( x => x.blogId == id);
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
        }

        
    }

