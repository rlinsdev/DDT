# The .NET Developer Toolkit

## Definition
* Dependency Injection is a pattern
* "ASP.NET Core supports the dependency injection (DI) software design pattern, which is a technique for achieving Inversion of Control (IoC) between classes and their dependencies."


## Extra tools
<!-- * Postman
* DBeaver -->


## Commands
```Bash
$ dotnet --version
#
# 2. Dependency Injection
$ dotnet new webapi -minimal -n DiApi
$ dotnet new webapi -minimal -n UserApi
# cd DiApi
$ dotnet watch
$ dotnet run
#
# 4. User Secrets
# Secrete storate
$ dotnet user-secrets init
$ dotnet user-secrets set "Password" "ususu"
# Path C:\Users\username\AppData\Roaming\Microsoft\UserSecrets\DDT-US_6f6f9190-95e9-4a80-9597-068cff308a02
# $ dotnet dev-certs https --trust
$ dotnet new console -n CommandConfig
$ dotnet add package Microsoft.Extensions.Hosting
$ dotnet user-secrets init
$ dotnet user-secrets set "Password" "user secrets password"
# C:\Users\username\AppData\Roaming\Microsoft\UserSecrets\DDT-CONSOLE_796f707c-506f-45f0-a9f2-a0530e4d1e6c
# 
# 5. Serializer
$ dotnet new console -n Serializer
```

## Links:
* [Course](https://www.youtube.com/watch?v=Rqz9XiSqH3E)
* [.NET Developer Toolkit](https://lesjackson.net/course/dotnet-developer-toolkit)
* [Dependency injection in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0)
* [ASP.Net Middleware](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0)
