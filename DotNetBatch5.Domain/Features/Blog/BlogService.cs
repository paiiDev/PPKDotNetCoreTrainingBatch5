using DotNetTrainingBatch5.database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch5.Domain.Features.Blog
{
    public class BlogService
    {
        private readonly AppDbContext _db = new AppDbContext();

        public List<TblBlog> GetBlogs()
        {
            var model = _db.TblBlogs.AsNoTracking().ToList();

             return model;
        }

        public TblBlog CreateBlog(TblBlog blog)
        {
            _db.TblBlogs.Add(blog);
            _db.SaveChanges();
            return blog;
        }

        public TblBlog GetBlog(int id)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            
            _db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public TblBlog UpdateBlog(int id,TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return null;
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return blog;
        }
        public TblBlog PatchBlog(int id, TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return item;
        }

        public bool? DeleteBlog(int id)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return false;
            }
            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();
            return result > 0;
        }
    }


//    app.MapGet("/blogs", () =>
//            {
//                AppDbContext db = new AppDbContext();
//    var model = db.TblBlogs.AsNoTracking().ToList();

//                return Results.Ok(model);

//            }).WithName("GetBlogs")
//              .WithOpenApi();

//app.MapGet("/blogs/{id}", (int id) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
//    if (item == null)
//    {
//        return Results.BadRequest("No data found");
//    }
//    db.Entry(item).State = EntityState.Modified;
//    return Results.Ok(item);

//}).WithName("GetBlogsById")
//  .WithOpenApi();

//app.MapPost("/blogs", (TblBlog blog) =>
//{

//    AppDbContext db = new AppDbContext();
//    db.TblBlogs.Add(blog);
//    db.SaveChanges();
//    return Results.Ok(blog);
//}).WithName("CreateBlog")
//  .WithOpenApi();


//app.MapPut("/blogs/{id}", (int id, TblBlog blog) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
//    if (item == null)
//    {
//        return Results.BadRequest("No data found");
//    }
//    item.BlogTitle = blog.BlogTitle;
//    item.BlogAuthor = blog.BlogAuthor;
//    item.BlogContent = blog.BlogContent;

//    db.Entry(item).State = EntityState.Modified;
//    db.SaveChanges();
//    return Results.Ok(blog);
//}).WithName("UpdateBlog")
//  .WithOpenApi();

//app.MapPatch("/blogs/{id}", (int id, TblBlog blog) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
//    if (item == null)
//    {
//        return Results.BadRequest("No data found");
//    }
//    if (!string.IsNullOrEmpty(blog.BlogTitle))
//    {
//        item.BlogTitle = blog.BlogTitle;

//    }
//    if (!string.IsNullOrEmpty(blog.BlogAuthor))
//    {
//        item.BlogAuthor = blog.BlogAuthor;

//    }
//    if (!string.IsNullOrEmpty(blog.BlogContent))
//    {
//        item.BlogContent = blog.BlogContent;

//    }



//    db.Entry(item).State = EntityState.Modified;
//    db.SaveChanges();
//    return Results.Ok(blog);
//}).WithName("PatchBlog")
//  .WithOpenApi();

//app.MapDelete("/blogs/{id}", (int id) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
//    if (item == null)
//    {
//        return Results.BadRequest("No data found");
//    }
//    db.Entry(item).State = EntityState.Deleted;
//    db.SaveChanges();
//    return Results.Ok("Deleted");
//}).WithName("DeleteBlog")
//  .WithOpenApi();

}
