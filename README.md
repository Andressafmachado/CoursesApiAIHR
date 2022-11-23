# CoursesApiAIHR

after clone the repo:
run $dotnet restore
to run $ dotnet run

swagger: http://localhost:5197/swagger/index.html or http://localhost:7116/swagger/index.html;

This is a Minimal API using EntityFramework and SQLite,
build to connect with front end available here



# usefull commands to restart the database
$dotnet ef migrations add InitialCreate
$ dotnet ef database update


# Concerns:
This is a simple API build for a POC,
there is no security layer, no authentication,
improvements before going to production:
- move the endpoints from the program
- create a service for the logic (move the calculation from the front)
- property SelectedCourses should be type IEnumerable<Course>
  


