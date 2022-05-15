using Microsoft.AspNetCore.Mvc;
using StockAPITest;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStockMemoryRepository, StockMemoryRepository>();
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


//Gets all items
app.MapGet("/item", (IStockMemoryRepository stockMemoryRepository) => stockMemoryRepository.GetItems()).WithName("GetAll");
//Gets one item specified by item code
app.MapGet("/item/{itemCode}", (IStockMemoryRepository stockMemoryRepository, string itemCode) => GetItemByCode(itemCode, stockMemoryRepository)).WithName("GetByCode");
//Changes amount of items manually or by increasing / decreasing by one
app.MapPut("/item/{itemCode}/changeAmount", (IStockMemoryRepository stockMemoryRepository, string itemCode, int? amount) => ChangeStockAmount(stockMemoryRepository, itemCode, amount)).WithName("ChangeStockAmount");
app.MapPut("/item/{itemCode}/decreaseAmountByOne", (IStockMemoryRepository stockMemoryRepository, string itemCode) => ChangeStockAmount(stockMemoryRepository, itemCode, -1)).WithName("DecreaseStockByOne");
app.MapPut("/item/{itemCode}/increaseAmountByOne", (IStockMemoryRepository stockMemoryRepository, string itemCode) => ChangeStockAmount(stockMemoryRepository, itemCode, 1)).WithName("IncreaseStockByOne");
//Adds item to stock
app.MapPost("/item", (IStockMemoryRepository stockMemoryRepository, Item item, bool? autoGenerateCode) => AddItemToStock(stockMemoryRepository, item, autoGenerateCode)).WithName("AddItem");


//Methods
IResult GetItemByCode(string itemCode, IStockMemoryRepository stockMemoryRepository)
{
    try
    {
        var item = stockMemoryRepository.FindItemByItemCode(itemCode);
        if (item == null)
        {
            return Results.BadRequest("No item with such Item Code");
        }
        return Results.Ok(item);
    }
    catch (Exception)
    {
        return Results.BadRequest("Failed");
    }
}
IResult AddItemToStock(IStockMemoryRepository stockMemoryRepository, Item item, bool? autoGenerateCode)
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
        item.SetItemCode(item.ItemCodeGenerator(5));
    }
    stockMemoryRepository.AddItem(item);
    return Results.Ok(item);
}
IResult ChangeStockAmount(IStockMemoryRepository stockMemoryRepository, string itemCode, int? amount)
{
    Item? item;
    try
    {
        item = stockMemoryRepository.FindItemByItemCode(itemCode);
        if (item == null)
        {
            return Results.BadRequest("No item with such Item Code");
        }
        item.ChangeAmount(amount.GetValueOrDefault());
        return Results.Ok(item);
    }
    catch (Exception)
    {
        return Results.BadRequest("Failed");
    }
}
app.Run();

