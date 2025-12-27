

using DotNetBatch5.Domain.Features.Blog;
using Microsoft.Identity.Client;

namespace DotNetBatch5.MinimalApi.Endpoints.Blog
{
    public static class BlogServiceEndpoint
    {

        public static void MapBlogServiceEndpoint (this IEndpointRouteBuilder app )
        {
            

            app.MapGet("/blogs", () =>
            {
               BlogService service = new BlogService ();
                var lst = service.GetBlogs();
                return lst;
            }).WithName("GetBlogs")
              .WithOpenApi();

            app.MapGet("/blogs/{id}", (int id) =>
            {
               BlogService service = new BlogService ();

                var item = service.GetBlog(id);
                if (item == null)
                {
                    return Results.BadRequest("No data found");
                }
              
                return Results.Ok(item);

            }).WithName("GetBlogsById")
              .WithOpenApi();

            app.MapPost("/blogs", (TblBlog blog) =>
            {

                BlogService service = new BlogService();

               service.CreateBlog(blog);
                return Results.Ok(blog);
            }).WithName("CreateBlog")
              .WithOpenApi();


            app.MapPut("/blogs/{id}", (int id, TblBlog blog) =>
            {
                BlogService service = new BlogService();


                var item = service.UpdateBlog(id, blog);
                if (item == null)
                {
                    return Results.BadRequest("No data found");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;

            
                return Results.Ok(blog);
            }).WithName("UpdateBlog")
              .WithOpenApi();

            app.MapPatch("/blogs/{id}", (int id, TblBlog blog) =>
            {
                BlogService service = new BlogService();

                var item = service.PatchBlog(id, blog);
                if (item == null)
                {
                    return Results.BadRequest("No data found");
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



                return Results.Ok(blog);
            }).WithName("PatchBlog")
              .WithOpenApi();

            app.MapDelete("/blogs/{id}", (int id) =>
            {
                BlogService service = new BlogService();

                var item = service.DeleteBlog(id);
                if (item == null)
                {
                    return Results.BadRequest("No data found");
                }
              
                return Results.Ok("Deleted");
            }).WithName("DeleteBlog")
              .WithOpenApi();

        }
    }
}
