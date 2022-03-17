using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using AutoMapper;
using Business;
using Business.Abstracts;
using Business.Services;
using Data.Abstracts;
using Data.Concretes;
using Entity.Configurations;
using Entity.Models;
using Entity.ModelsDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebApi
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(MappingProfile));


            //services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            //if you don't want to change the global settings, for one action only it's like this:
            //return Json(obj, new JsonSerializerOptions { PropertyNamingPolicy = null });

            services.AddDbContext<FirstDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerFirst"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("WebApi");
                });
            });

            services.AddDbContext<SecondDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerSecond"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("WebApi");
                });
            });

            services.AddScoped<IUnitOfWorkFirstDb, UnitOfWorkFirstDb>();
            services.AddScoped<IUnitOfWorkSecondDb, UnitOfWorkSecondDb>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();




            services.AddIdentity<CustomUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                
            }).AddEntityFrameworkStores<FirstDbContext>().AddDefaultTokenProviders();

            services.Configure<CustomTokenOption>(Configuration.GetSection("TokenOption"));//appsettings.json'tan alıyor. (options pattern)

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                var tokenOptions = Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience[0],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                    

                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Multitenancy Token Based Auth Project",
                    Description = "Multitenancy Token Based Auth Project",
                    TermsOfService = new Uri("https://fatih-uysal.com"),
                    Contact = new OpenApiContact
                    {
                        Email = "fuysal87@gmail.com",
                        Name = "Fatih UYSAL",
                        Url = new Uri("https://fatih-uysal.com")
                    },
                    License = new OpenApiLicense { Name = "Fatih UYSAL Licence", Url = new Uri("https://fatih-uysal.com") }

                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    new string[] {}
                        }
                    });
            });


            //Dto'da DataAnnotations ModelState'de hata varsa Ekrana modelimizin içinde yazdırmak için kullanılır.
            services.AddMvc().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    var response = Response<NoContentResult>.Fail(400, errors);

                    return new BadRequestObjectResult(response);
                };
            });




            //services.AddCors(options =>
            //     options.AddDefaultPolicy(builder =>
            //     builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            services.AddCors(options => options.AddPolicy("myclients", builder =>
            builder.WithOrigins("https://localhost:1453", "http://localhost:1453").AllowAnyMethod().AllowAnyHeader()));
            //todo
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api V1"); });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    // using static System.Net.Mime.MediaTypeNames;
                    context.Response.ContentType = "application/json";// Text.Plain;
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;
                        var errors = new List<string>();
                        errors.Add(string.Concat(ex.Message, " ", ex.InnerException));
                        var response = Response<NoContentResult>.Fail(context.Response.StatusCode, errors);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }

                    //await context.Response.WriteAsync("An exception was thrown.");

                    //var exceptionHandlerPathFeature =
                    //    context.Features.Get<IExceptionHandlerPathFeature>();

                    //if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                    //{
                    //    await context.Response.WriteAsync(" The file was not found.");
                    //}

                    //if (exceptionHandlerPathFeature?.Path == "/")
                    //{
                    //    await context.Response.WriteAsync(" Page: Home.");
                    //}
                });
            });


            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader());
            app.UseCors("myclients");
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });





        }
    }
}
