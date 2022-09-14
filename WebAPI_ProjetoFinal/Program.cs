using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Service;
using WebAPI_ProjetoFinal.Infra.Data.Repository;
using WebAPI_ProjetoFinal.Infra.Data;
using WebAPI_ProjetoFinal.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<GeneralExceptionFilter>();
}
);

builder.Services.AddScoped<ICityEventService, CityEventService>();
builder.Services.AddScoped<ICityEventRepository, CityEventRepository>();
builder.Services.AddScoped<IConnectionDataBase, ConnectionDataBase>();
builder.Services.AddScoped<IEventReservationService, EventReservationService>();
builder.Services.AddScoped<IEventReservationRepository, EventReservationRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
