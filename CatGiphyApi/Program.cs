using CatGiphyApi.ExternalClients;
using CatGiphyApi.Data;
using CatGiphyApi.Services;

var builder = WebApplication.CreateBuilder(args);

//politica de cors para que permita conectar con el front en react
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Registramos el cliente HTTP para consumir la API externa de cat facts
builder.Services.AddHttpClient<CatFactClient>();
// Registramos el cliente HTTP para consumir la API externa de los gifs
builder.Services.AddHttpClient<GiphyClient>();
//Configuracion de base de datos de mongo
builder.Services.Configure<MongoSettings>(
builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<SearchHistoryService>();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();

