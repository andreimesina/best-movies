using BestMovies.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BestMovies.Repositories.MovieCompanyRepository;
using BestMovies.Repositories.CompanyRepository;
using BestMovies.Repositories.GenreRepository;
using BestMovies.Repositories.MovieGenreRepository;
using BestMovies.Repositories.MovieRepository;
using BestMovies.Repositories.MovieActorRepository;
using BestMovies.Repositories.ActorRepository;

namespace ProiectMDS
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IMovieRepository, MovieRepository>();

            services.AddTransient<IMovieGenreRepository, MovieGenreRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();

            services.AddTransient<IMovieActorRepository, MovieActorRepository>();
            services.AddTransient<IActorRepository, ActorRepository>();

            services.AddTransient<IMovieCompanyRepository, MovieCompanyRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
        }

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

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin()
                                         .AllowAnyMethod()
                                         .AllowAnyHeader()
                                         .AllowCredentials());
            app.UseMvc();
        }

    }
}
