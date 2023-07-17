namespace FluentEmailExample.Extensions
{
    public static class FluentEmailExtensions
    {
        public static void AddFluentEmail(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var defaultFromEmail = configuration.GetValue<string>("EmailSettings:DefaultFromEmail");
            var host = configuration.GetValue<string>("EmailSettings:SMTPSetting:Host");
            var port = configuration.GetValue<int>("EmailSettings:SMTPSetting:Port");

            services.AddFluentEmail(defaultFromEmail)
                .AddSmtpSender(host, port);
        }
    }
}
