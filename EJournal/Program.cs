using EJournal;
using EJournal.Table;
using System;

int id = 1;
ApplicationContext context = new ApplicationContext();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/api/LogIn/{login}&{password}",(string login, string password) =>
{
    string WebPage="";
    context.Prepod.FirstOrDefault(u => u.Login == login && u.Password == password);
    if (context != null) 
    {
        WebPage = "PrepodsPage";
    }
    else 
    {
        context.Student.FirstOrDefault(u => u.Login == login && u.Password == password);
    }
    
    if (context != null)
    {
        WebPage = "StudentsPage";
    }
    return Results.Json(context);
});

app.Run();
