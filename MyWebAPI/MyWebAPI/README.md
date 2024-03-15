error: unable to connect to web server

System.InvalidOperationException
  HResult=0x80131509
  Message=Unable to find the required services. Please add all the required services by calling 'IServiceCollection.AddAuthorization' in the application startup code.
  Source=Microsoft.AspNetCore.Authorization.Policy
  StackTrace:
   at Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.VerifyServicesRegistered(IApplicationBuilder app)
   at Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization(IApplicationBuilder app)
   at Program.<Main>$(String[] args) in C:\workspace\.Net-Projects\MyWebAPI\MyWebAPI\Program.cs:line 65
