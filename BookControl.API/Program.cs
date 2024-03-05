using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Configuration;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BookControlContext>(options => options
                .UseSqlServer(builder.Configuration
                .GetConnectionString("DataBase")));

builder.Services.AddAutoMapper(typeof(BookProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);
builder.Services.AddAutoMapper(typeof(BookLoanProfile).Assembly);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IBookLoanService, BookLoanService>();
builder.Services.AddScoped<IBookLoanRepository, BookLoanRepository>();

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