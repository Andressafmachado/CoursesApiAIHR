using Microsoft.OpenApi.Models;
using CourseStore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Courses") ?? "Data Source=Context/Courses.db";
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddSqlite<CourseContext>(connectionString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "Courses API",
         Description = "All AIHR courses",
         Version = "v1" });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
                      });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Courses API V1");
});

app.MapGet("/", () => "Minimal API is running!");

app.MapGet("/courses", (CourseContext db ) => db.Set<Course>().ToList());
app.MapGet("/history", (CourseContext db ) => db.Set<History>().ToList());


app.MapPost("/courses", async (CourseContext db, Course course) =>
{
    await db.Courses.AddAsync(course);
    await db.SaveChangesAsync();
    return Results.Created($"/course/{course.Id}", course);
});

app.MapPost("/history", async (CourseContext db, History history) =>
{
    await db.History.AddAsync(history);
    await db.SaveChangesAsync();
    return Results.Created($"/history/{history.Id}", history);
});

app.MapDelete("/history", (CourseContext db) =>
{
   db.History.RemoveRange(db.History);
   db.SaveChanges();
   return Results.Ok();
});

app.Run();