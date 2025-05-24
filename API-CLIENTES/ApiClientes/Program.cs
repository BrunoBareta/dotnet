
    using System.Text.Json.Serialization;
    using ApiClientes.Database.Models;
    using ApiClientes.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    namespace ApiClientes
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        //options.JsonSerializerOptions.ReferenceHandler =  ReferenceHandler.Preserve;

                        options.JsonSerializerOptions.WriteIndented = true;

                    });

                // Habilita CORS
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        policy => policy.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());
                });

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddSingleton<ClientesContext>();
                builder.Services.AddScoped<ClientesService>();
                builder.Services.AddScoped<EnderecosService>();


                var app = builder.Build();

                app.UseCors("AllowAll");

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
        }
    }
