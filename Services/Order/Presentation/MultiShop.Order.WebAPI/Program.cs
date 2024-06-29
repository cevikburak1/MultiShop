using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandler;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);


builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();


builder.Services.AddScoped<GetOrderDetailHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
