using FluentEmailExample.Model;
using FluentEmailExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluentEmailExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService
                ?? throw new ArgumentNullException(nameof(emailService));
        }

        [HttpGet("singleemail")]
        public async Task<IActionResult> SendSingleEmail()
        {
            EmailMetadata emailMetadata = new("john.doe@gmail.com",
                "FluentEmail Test email",
                "This is a test email from FluentEmail.");

            await _emailService.Send(emailMetadata);

            return Ok();
        }

        [HttpGet("razortemplate")]
        public async Task<IActionResult> SendEmailWithRazorTemplate()
        {
            User model = new("John Doe", "john.doe@gmail.com", "Platinum");

            EmailMetadata emailMetadata = new(model.Email,
                "FluentEmail test email with razor template");

            var template = "Dear <b>@Model.Name</b>, </br>" +
            "Thank you for being an esteemed <b>@Model.MemberType</b> member.";

            await _emailService.SendUsingTemplate(emailMetadata, template, model);

            return Ok();
        }

        [HttpGet("liquidtemplate")]
        public async Task<IActionResult> SendEmailWithLiquidTemplate()
        {
            User model = new("Jane Doe", "jane.doe@gmail.com", "Gold");

            EmailMetadata emailMetadata = new(model.Email,
                "FluentEmail test email with liquid template");

            var template = @"Dear <b>{{ Name }}</b>,</br>
        Thank you for being an esteemed <b>{{ MemberType }}</b> member.";

            await _emailService.SendUsingTemplate(emailMetadata, template, model);

            return Ok();
        }


        [HttpGet("razortemplatefromfile")]
        public async Task<IActionResult> SendEmailWithRazorTemplateFromFile()
        {
            User model = new("John Doe", "john.doe@gmail.com", "Platinum");

            EmailMetadata emailMetadata = new(model.Email,
                "FluentEmail test email with razor template file");

            var templateFile = $"{Directory.GetCurrentDirectory()}/MyTemplate.cshtml";

            await _emailService.SendUsingTemplateFromFile(emailMetadata, templateFile, model);

            return Ok();
        }

        [HttpGet("withattachment")]
        public async Task<IActionResult> SendEmailWithAttachment()
        {
            EmailMetadata emailMetadata = new("john.doe@gmail.com",
                "FluentEmail Test email",
                "This is a test email from FluentEmail.",
                $"{Directory.GetCurrentDirectory()}/Test.txt");

            await _emailService.SendWithAttachment(emailMetadata);

            return Ok();
        }

        [HttpGet("multipleemail")]
        public async Task<IActionResult> SendMultipleEmails()
        {
            List<User> users = new()
            {
                new("John Doe","john.doe@gmail.com","Platinum"),
                new("Jane Doe", "jane.doe@gmail.com", "Gold")
            };

            List<EmailMetadata> emailsMetadata = new();

            foreach (var user in users)
            {
                EmailMetadata emailMetadata = new(user.Email,
                    "FluentEmail Test email",
                    "This is a test email from FluentEmail.");

                emailsMetadata.Add(emailMetadata);
            }

            await _emailService.SendMultiple(emailsMetadata);

            return Ok();
        }
    }
}
