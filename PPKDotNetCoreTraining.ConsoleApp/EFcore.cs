using System;
using System.Collections.Generic;
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
    }
}
