using Microsoft.OpenApi.Models;
using HotelStore.DB;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "test API", Description = "Making the test you love", Version = "v1" });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "test API V1");
   });
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/hotel/{id}", (int id) => HotelDB.GetHotel(id));
app.MapGet("/hotel", () => HotelDB.GetHotels());
app.MapPost("/hotel", (Hotel hotel) => HotelDB.CreateHotel(hotel));
app.MapPut("/hotel", (Hotel hotel) => HotelDB.UpdateHotel(hotel));
app.MapDelete("/hotel/{id}", (int id) => HotelDB.RemoveHotel(id));

app.Run();
