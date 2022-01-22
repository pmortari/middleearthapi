using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MiddleEarthAPI.Data;
using MiddleEarthAPI.Data.Repositories;
using MiddleEarthAPI.Data.Repositories.Interfaces;
using MiddleEarthAPI.Resources;
using MiddleEarthAPI.Resources.Extensions;
using MiddleEarthAPI.Services;
using MiddleEarthAPI.Services.Interfaces;
using System;
using System.IO;
using System.Reflection;

namespace MiddleEarthAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            SwaggerDocumentInfoSetup(services);

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new DateConverter());
                });

            services.AddDbContext<MiddleEarthDataContext>(options => options.UseInMemoryDatabase("MiddleEarthData"));
            services.AddScoped<IDataContextService, DataContextService>();
            services.AddScoped<IDataContextRepository, DataContextRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.Configure<Settings>(Configuration.GetSection("Settings"));
        }

        public void Configure(IApplicationBuilder application)
        {
            SwaggerSetup(application);

            LoadInMemoryData(application);

            if (_environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application.UseHttpsRedirection();

            application.UseRouting();

            application.UseAuthorization();

            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void LoadInMemoryData(IApplicationBuilder application)
        {
            var scope = application.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider.GetService<IDataContextService>();
            service.LoadInMemoryData();
        }

        private static void SwaggerDocumentInfoSetup(IServiceCollection services)
        {
            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MiddleEarthAPI",
                    Version = "v1",
                    Description = "The Middle Earth delivered to you as an API.",
                    Contact = new OpenApiContact
                    {
                        Email = "pmortari@gmail.com",
                        Name = "Phillip Mortari",
                        Url = new Uri("https://github.com/pmortari", UriKind.Absolute)
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under Apache License 2.0",
                        Url = new Uri("http://www.apache.org/licenses/", UriKind.Absolute)
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                p.IncludeXmlComments(xmlPath);

                p.CustomSchemaIds(x => x.FullName);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void SwaggerSetup(IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiddleEarthAPI v1"));
        }
    }
}