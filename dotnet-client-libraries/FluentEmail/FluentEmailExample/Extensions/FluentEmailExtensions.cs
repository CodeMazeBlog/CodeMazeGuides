namespace FluentEmailExample.Extensions
{
    public static class FluentEmailExtensions
    {
        public static void AddFluentEmail(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var emailSettings = configuration.GetSection("EmailSettings");
            var smtpSettings = emailSettings.GetSection("SMTPSetting");

            var defaultFromEmail = emailSettings["DefaultFromEmail"];
            var host = smtpSettings["Host"];
            var port = smtpSettings.GetValue<int>("Port");

            // Swap AddRazorRenderer() for AddLiquidRenderer() to run the liquidtemplate endpoint.
            services.AddFluentEmail(defaultFromEmail)
                .AddSmtpSender(host, port)
                .AddRazorRenderer();
        }
    }
}
