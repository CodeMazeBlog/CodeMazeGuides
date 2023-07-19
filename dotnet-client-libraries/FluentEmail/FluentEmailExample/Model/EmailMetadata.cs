namespace FluentEmailExample.Model
{
    public class EmailMetadata
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string? Body { get; set; }
        public string? AttachmentPath { get; set; }

        public EmailMetadata(string toAddress, string subject, string? body = "",
            string? attachmentPath = "")
        {
            ToAddress = toAddress;
            Subject = subject;
            Body = body;
            AttachmentPath = attachmentPath;
        }
    }
}
