using eCommerce.InfraStructure;
using eCommerce.Core;
using eCommerce.API.Middleware;
using eCommerce.Core.Mapper;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;

namespace eCommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddInfrastructure();
            builder.Services.AddCore();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
            // FluentValidations
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddEndpointsApiExplorer();
            //Add Swagger
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyHeader();
                });
            });
            var app = builder.Build();
            app.UseExceptionHandlingMiddleware();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT API token");
                });
            };
            app.UseCors();
            app.MapControllers();

            app.Run();
        }
    }
}
