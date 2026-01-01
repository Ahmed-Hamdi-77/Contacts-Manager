using ServiceContracts;
using Services;
using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using Repositories;
using ContactsManager.Middlewares;
using Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Adding the services to the ioc container
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IPersonsSorterService, PersonsSorterService>();
builder.Services.AddScoped<IPersonsGetterService, PersonsGetterService>();
builder.Services.AddScoped<IPersonsAdderService, PersonsAdderService>();
builder.Services.AddScoped<IPersonsUpdaterService, PersonsUpdaterService>();
builder.Services.AddScoped<IPersonsDeleterService, PersonsDeleterService>();
builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
//Adding the DbContext as a service
builder.Services.AddDbContext<ContactsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnectionString"))
);

//Enabling Identity framework services
builder.Services.AddIdentity<ApplicationUser,ApplicationRole>()
    .AddEntityFrameworkStores<ContactsDbContext>().AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser,ApplicationRole,ContactsDbContext,Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole,ContactsDbContext,Guid>>()
    ;

builder.Services.AddAuthorization(options=>
    options.FallbackPolicy=new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser().Build() //enforces authorization policy(User must be authenticated)
                                            //for all the action methods

);

builder.Services.ConfigureApplicationCookie(options=>
    
        options.LoginPath="/Account/Login"
    );   
    

builder.Services.AddHttpLogging();


var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseExceptionHandlingMiddleware();
}

app.UseHttpLogging();

Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");

app.UseStaticFiles();
app.UseRouting();//Idetifying action method based on the URL
app.UseAuthentication();//Reading Identity cookie
app.UseAuthorization(); //Validate access permissions of the user
app.MapControllers();//Excuting the filter Pipeline(action + filter)


app.Run();
