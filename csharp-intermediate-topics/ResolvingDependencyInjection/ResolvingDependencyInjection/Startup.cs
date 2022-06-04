using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ResolvingDependencyInjection
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IStringLocalizer localizer;
     
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Adding Localization to the controllers
            services.AddLocalization();

            services.AddControllers(options =>
            {
                options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(
                    () => this.localizer.GetString("MissingRequestBodyRequiredValue"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.localizer = app.ApplicationServices
                .GetRequiredService<IStringLocalizerFactory>()
                .Create(typeof(SharedResource));



            var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ja") };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("en")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

    }
}
