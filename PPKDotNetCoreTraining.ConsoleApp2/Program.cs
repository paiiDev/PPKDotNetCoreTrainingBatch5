

using Newtonsoft.Json;

var blog = new BlogModel
{
    Id = 1,
    Title = "Introduction to C# 12",
    Author = "PPK",
    Content = "C# 12 introduces several new features including primary constructors, list patterns, and more."
};

//var jsonStr = JsonConvert.SerializeObject(blog);
var jsonStr = blog.toJson();
Console.WriteLine(jsonStr);
Console.Read();

string jsonStr2 = """{"Id": 1,"Title": "Introduction to C# 12","Author": "PPK","Content": "C# 12 introduces several new features including primary constructors, list patterns, and more."}""";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);
Console.WriteLine(blog2.Title);

public class BlogModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
}

public static class Extensions
{
    public static string toJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }
}