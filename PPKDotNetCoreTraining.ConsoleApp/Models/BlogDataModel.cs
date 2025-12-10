using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPKDotNetCoreTraining.ConsoleApp.Models
{
    public class BlogDapperDataModel
    {
        public int blogId { get; set; }
        public string blogTitle { get; set; }
        public string blogAuthor { get; set; }
        public string blogContent { get; set; }
    }

    [Table("Tbl_blog")]
    public class BlogDataModel
    {
      
        [Column("blogId")]
        [Key]
        public int blogId { get; set; }

        [Column("blogTitle")]

        public string blogTitle { get; set; }

        [Column("blogAuthor")]

        public string blogAuthor { get; set; }

        [Column("blogContent")]

        public string blogContent { get; set; }

        public bool deleteFlag {  get; set; }
    }
}
