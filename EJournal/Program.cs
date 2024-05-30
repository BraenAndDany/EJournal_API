using EJournal;
using EJournal.Table;
using System;
using Microsoft.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

ApplicationContext context = new ApplicationContext();
var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod();
        });
});
var app = builder.Build();
app.MapGet("/api/LogIn/{login}&{password}", (string login, string password) =>
{
    string WebPage="";
    
    if (context.Prepod.FirstOrDefault(u => u.Login == login && u.Password == password) != null) 
    {
        WebPage = "PrepodsPage";
    }
    if (context.Student.FirstOrDefault(u => u.Login == login && u.Password == password) != null)
    {
        WebPage = "StudentsPage";
    }
    return Results.Text(WebPage);
});
app.MapGet("/api/Loading/PrepodsInfo/0/{info}", (string info) =>
{
    return Results.Json(context.Prepod.FirstOrDefault(u => u.Login == info));
});
app.MapGet("/api/Loading/PrepodsInfo/1/{info}", (int info) =>
{
    var SubPrep = context.SubPrep.Where(u => u.IDPrep == info);
    var Sub =SubPrep.Include(u => u.Sub);
    return Results.Json(Sub.ToList());
});
app.UseCors(MyAllowSpecificOrigins);
app.Run();
