using ArbetsprovAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var items = new List<Item>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/getallitems", () =>
{
    return items;
});

app.MapGet("/getItem/{itemCode}", (string itemCode) =>
{
    try
    {
        var item = items.Find(x => x.ItemCode == itemCode);
        if (item == null)
        {
            return Results.NotFound("No item with such Item Code");
        }
        return Results.Ok(item);
    }
    catch (Exception)
    {
        return Results.BadRequest("Failed");
    }
});

app.MapPost("/getItem/{itemCode}/increase", (string itemCode, int? amount) =>
{
    Item? item;
    try
    {
        item = items.Find(x => x.ItemCode == itemCode);
        if (item == null)
        {
            return Results.NotFound("No item with such Item Code");
        }
        item.IncreaseAmount(amount.GetValueOrDefault());
        return Results.Ok(item);
    }
    catch (Exception)
    {
        return Results.BadRequest("Failed");
    }
});
app.MapPost("/getItem/{itemCode}/decrease", (string itemCode, int? amount) =>
{
    Item? item;
    try
    {
        item = items.Find(x => x.ItemCode == itemCode);
        if (item == null)
        {
            return Results.NotFound("No item with such Item Code");
        }
        item.DecreaseAmount(amount.GetValueOrDefault());
        return Results.Ok(item);
    }
    catch (Exception)
    {
        return Results.BadRequest("Failed");
    }
});

app.MapPost("", (Item item) =>
{
    if (item.Name.Length == 0)
    {
        return Results.BadRequest("Item must have a name!");
    }
    if (item.ItemCode.Length > 0 && item.ItemCode.Length != 5)
    {
        return Results.BadRequest("Item Code must be 5 characters");
    }
    if (item.ItemCode.Length == 0)
    {
        item.ItemCode = item.ItemCodeGenerator(5);
    }
    items.Add(item);
    return Results.Ok(item);
});



app.Run();

