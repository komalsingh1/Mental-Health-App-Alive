using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mental.Health.Adapter;
using Mental.Health.Core;
using Mental.Health.Service;
using Mental.Health.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Mental.Health.Web
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
            services.AddTransient<IMentalHealthTestComponent, MentalHealthTestComponent>();
            services.AddTransient<IMentalHealthTestService, MentalHealthTestService>();
            services.AddTransient<IMentalHealthTestAdapter, MentalHealthTestAdapter>();
            services.AddTransient<IUserRegistrationService, UserRegistrationService>();
            services.AddTransient<IUserRegistrationComponent, UserRegistrationComponent>();
            services.AddTransient<IUserRegistrationAdapter, UserRegistrationAdapter>();
            services.AddTransient<IUserAnalyzingService, UserAnalyzingService>();
            services.AddTransient<IUserAnalyzingComponent, UserAnalyzingComponent>();
            services.AddTransient<IUserAnalyzingAdapter, Adapter.UserAnalyzingAdapter>();
            services.AddSingleton<IQuestionsManager, QuestionsManager>();
            services.AddSingleton<IUserReportsManager, UserReportsManager>();
            services.AddSingleton<IUsersManager, UsersManager>();
            services.AddSingleton<IResultContentsManager, ResultContentsManager>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options => options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseCustomExceptionHandler();
            app.UseMvc();
        }
    }
}
