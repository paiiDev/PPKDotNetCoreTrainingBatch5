using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/birds", () =>
{
    string folderPath = "Data/Birds/Birds.json";
    var jsonStr =  File.ReadAllText(folderPath);
    var reult =  JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr);
    return Results.Ok(reult.Tbl_Bird);
})
.WithName("GetBirds")
.WithOpenApi();


app.MapGet("/birds/{id}", (int id) =>
{
    string folderPath = "Data/Birds/Birds.json";
    var jsonStr = File.ReadAllText(folderPath);

    var reult = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr);

    var item = reult.Tbl_Bird.FirstOrDefault(x => x.Id == id);

    if ( item is null)
    {
        return Results.BadRequest("No data found");
    }
    return Results.Ok(item);
})
.WithName("GetBird")
.WithOpenApi();


app.MapPost("/birds", (BirdModel BirdRequest) =>
{
    string folderPath = "Data/Birds/Birds.json";
    var jsonStr = File.ReadAllText(folderPath);

    var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr);

    BirdRequest.Id = result.Tbl_Bird.Count == 0 ? 1 : result.Tbl_Bird.Max(x => x.Id) + 1;

    result.Tbl_Bird.Add(BirdRequest);

    var updatedJsonStr = JsonConvert.SerializeObject(result, Formatting.Indented);

    File.WriteAllText(folderPath, updatedJsonStr);

    return Results.Ok(BirdRequest);
})
.WithName("CreateBird")
.WithOpenApi();

app.MapPut("/birds/{id}", (int id, BirdModel BirdRequest) =>
{
    string folderPath = "Data/Birds/Birds.json";
    var jsonStr = File.ReadAllText(folderPath);

    var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr);

    var item = result.Tbl_Bird.Where(x => x.Id == id);
    if(item is null)
    {
        return Results.BadRequest("No data found");
    }

    var index = result.Tbl_Bird.FindIndex(x => x.Id == id);

    if (index != -1)
    {
        result.Tbl_Bird[index] = new BirdModel
        {
            Id = id,
            BirdMyanmarName = BirdRequest.BirdMyanmarName,
            BirdEnglishName = BirdRequest.BirdEnglishName,
            Description = BirdRequest.Description,
            ImagePath = BirdRequest.ImagePath
        };
    }
     var updatedJsonStr = JsonConvert.SerializeObject(result, Formatting.Indented);

    File.WriteAllText(folderPath, updatedJsonStr);

    return Results.Ok(BirdRequest);
})


    .WithName("PutBird")
.WithOpenApi();

    app.MapPatch("/birds/{id}", (int id, BirdModel BirdRequest) =>
    {
        string folderPath = "Data/Birds/Birds.json";
        var jsonStr = File.ReadAllText(folderPath);

        var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr);

        var item = result.Tbl_Bird.FirstOrDefault(x => x.Id == id);
        if (item is null)
        {
            return Results.BadRequest("No data found");
        }

        var index = result.Tbl_Bird.FindIndex(x => x.Id == id);

        if (index != -1)
        {
            var existingBirds = result.Tbl_Bird[index];

            var BirdMyanmarNameStr = string.IsNullOrEmpty(BirdRequest.BirdMyanmarName) ? existingBirds.BirdMyanmarName : BirdRequest.BirdMyanmarName;
            var BirdEnglishNameStr = string.IsNullOrEmpty(BirdRequest.BirdEnglishName) ? existingBirds.BirdEnglishName : BirdRequest.BirdEnglishName;
            var DescriptionStr = string.IsNullOrEmpty(BirdRequest.Description) ? existingBirds.Description : BirdRequest.Description;
            var ImagePathStr = string.IsNullOrEmpty(BirdRequest.ImagePath) ? existingBirds.ImagePath : BirdRequest.ImagePath;

            result.Tbl_Bird[index] = new BirdModel
            {
                Id = id,
                BirdMyanmarName = BirdMyanmarNameStr,
                BirdEnglishName = BirdEnglishNameStr,
                Description = DescriptionStr,
                ImagePath = ImagePathStr
            };
        }

        var updatedJsonStr = JsonConvert.SerializeObject(result, Formatting.Indented);

        File.WriteAllText(folderPath, updatedJsonStr);

        return Results.Ok(BirdRequest);
    })
.WithName("PatchBird")
.WithOpenApi();


app.MapDelete("/birds/{id}", (int id) =>
{
    string folderPath = "Data/Birds/Birds.json";
    var jsonStr = File.ReadAllText(folderPath);

    var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr);

   var item = result.Tbl_Bird.FirstOrDefault(x => x.Id == id);

    if(item is null)
    {
        return Results.BadRequest("No data found");
    }

    result.Tbl_Bird.Remove(item);

    var updatedJsonStr = JsonConvert.SerializeObject(result, Formatting.Indented);

    File.WriteAllText(folderPath, updatedJsonStr);

    return Results.Ok(item);
});




    


app.Run();


public class BirdResponseModel
{
    public List<BirdModel> Tbl_Bird { get; set; }
}

public class BirdModel
{
    public int Id { get; set; }
    public string BirdMyanmarName { get; set; }
    public string BirdEnglishName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}
