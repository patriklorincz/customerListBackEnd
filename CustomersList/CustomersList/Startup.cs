using CustomersList.Models;
using CustomersList.Models.Dto;
using CustomersList.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace CustomersList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().AddFluentValidation().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IValidator<CustomerDto>, CustomerDtoValidator>();
            services.AddTransient<IValidator<AddressDto>, AddressDtoValidator>();

            services.AddDbContext<CustomersListContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("CustomersDatabase")));

            services.AddScoped<ICustomerService, CustomerService>();

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            //corsBuilder.AllowAnyOrigin(); // For anyone access.
            corsBuilder.WithOrigins("http://localhost:4200"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("SiteCorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
