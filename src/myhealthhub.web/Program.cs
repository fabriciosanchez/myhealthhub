using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.Graph;
using myhealthhub.web.Services.Graph;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using myhealthhub.web.Services.Core;
using myhealthhub.web.Services.PatientRepository;
using myhealthhub.web.Services.PhysicianRepository;
using myhealthhub.web.Services.VisitRepository;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApp(options => {
        builder.Configuration.Bind("AzureAd", options);

        options.Prompt = "select_account";

        options.Events.OnTokenValidated = async context => {
            var tokenAcquisition = context.HttpContext.RequestServices
                .GetRequiredService<ITokenAcquisition>();

            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(async (request) => {
                    var token = await tokenAcquisition
                        .GetAccessTokenForUserAsync(GraphConstants.Scopes, user:context.Principal);
                    request.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
                })
            );

            // Get user information from Graph
            var user = await graphClient.Me.Request()
                .Select(u => new {
                    u.DisplayName,
                    u.JobTitle,
                    u.GivenName,
                    u.Mail,
                    //u.UserPrincipalName,
                    //u.MailboxSettings
                })
                .GetAsync();

            context.Principal.AddUserGraphInfo(user);

            // Get the user's photo
            // If the user doesn't have a photo, this throws
            try
            {
                var photo = await graphClient.Me
                    .Photos["48x48"]
                    .Content
                    .Request()
                    .GetAsync();

                context.Principal.AddUserGraphPhoto(photo);
            }
            catch (ServiceException ex)
            {
                if (ex.IsMatch("ErrorItemNotFound") ||
                    ex.IsMatch("ConsumerPhotoIsNotSupported") ||
                    ex.IsMatch("ImageNotFound"))
                {
                    context.Principal.AddUserGraphPhoto(null);
                }
                else
                {
                    throw;
                }
            }
        };

        options.Events.OnAuthenticationFailed = context => {
            var error = WebUtility.UrlEncode(context.Exception.Message);
            context.Response
                .Redirect($"/Home/ErrorWithMessage?message=Authentication+error&debug={error}");
            context.HandleResponse();

            return Task.FromResult(0);
        };

        options.Events.OnRemoteFailure = context => {
            if (context.Failure is OpenIdConnectProtocolException)
            {
                var error = WebUtility.UrlEncode(context.Failure.Message);
                context.Response
                    .Redirect($"/Home/ErrorWithMessage?message=Sign+in+error&debug={error}");
                context.HandleResponse();
            }

            return Task.FromResult(0);
        };
    })
    .EnableTokenAcquisitionToCallDownstreamApi(options => {
        builder.Configuration.Bind("AzureAd", options);
    }, GraphConstants.Scopes)
    .AddMicrosoftGraph(options => {
        options.Scopes = string.Join(' ', GraphConstants.Scopes);
    })
    .AddInMemoryTokenCaches();

//Registering custom services
builder.Services.AddScoped<Http>();
builder.Services.AddScoped<PatientRepository>();
builder.Services.AddScoped<StudyRepository>();
builder.Services.AddScoped<VisitRepository>();

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});
// builder.Services.AddRazorPages()
//     .AddMicrosoftIdentityUI();
builder.Services.AddRazorPages().AddMvcOptions(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddMicrosoftIdentityUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
