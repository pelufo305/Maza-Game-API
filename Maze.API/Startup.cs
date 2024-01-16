
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Maze.Application.CQRS.CommandHandler;
using Maze.Domain.Model;
using Maze.Application.CQRS.QueryHandler;
using Maze.Infrasetructure.Repositories;
using Maze.Domain.Repository;
using Maze.Application.Singleton;
using NSwag.Generation.Processors;


namespace Maze.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddSwaggerDocument(document =>
            {
                document.DocumentName = "My Api";
                document.PostProcess = d =>
                {
                    d.Info.Title = "Maze API";
                    d.Info.Description = "API created by Jhonatan Gonzalez";
                };
                document.OperationProcessors.Add(new ApiVersionProcessor { IncludedVersions = new[] { "1.0" } });
            });

            services.AddDbContext<Maze.Infrasetructure.Base.PersistenceContext>(opt =>
            {
                opt.UseInMemoryDatabase("Maze");
            });

            services.AddControllers(mvcOpts =>
            {
            });
          
            services.AddMediatR(typeof(CreateNewMazeHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(MazePostRequest).GetTypeInfo().Assembly);
          
            services.AddMediatR(typeof(OperationPlayerHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GameStartRequest).GetTypeInfo().Assembly);
           
            services.AddMediatR(typeof(StartGameHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GamePostRequest).GetTypeInfo().Assembly);
          
            services.AddMediatR(typeof(GetMazeHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(MazeDefinitionRequest).GetTypeInfo().Assembly);


            services.AddMediatR(typeof(GetGameHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(MazeDefinitionGameRequest).GetTypeInfo().Assembly);


            services.AddSingleton<ISingletonGame, SingletonGame>();



            services.AddTransient<IGameRepository, GameRepository>();
        }


            public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }


                app.UseHttpsRedirection();
                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                app.UseOpenApi();
                app.UseSwaggerUi3();

            }
        }
 }

