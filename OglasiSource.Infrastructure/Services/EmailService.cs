using OglasiSource.Core.Interfaces;


namespace OglasiSource.Infrastructure.Services
{
    public class EmailService : IEmailService
    {

        //private readonly IConfiguration _config;

        //public EmailService(IConfiguration config)
        //{
        //    _config = config;
        //}

        //public async Task<bool> SendEmailAsync(string toMail, string toName, EmailType emailType, object dynamicTemplateData, string? fromMail = null, string? fromName = null, string? subject = null)
        //{
        //    var sendGridClient = new SendGridClient(_config["SendGrid:ApiKey"]);
        //    var sendGridMessage = new SendGridMessage();
        //    if (fromMail == null && fromName == null) sendGridMessage.SetFrom(_config["CarrierAssistEmail:Email"], _config["CarrierAssistEmail:Name"]);
        //    sendGridMessage.AddTo(toMail, toName);
        //    sendGridMessage.SetTemplateId(_config[$"EmailTemplateId:{emailType.ToString()}"]);
        //    sendGridMessage.SetTemplateData(dynamicTemplateData);
        //    if (subject != null) sendGridMessage.SetSubject(subject);
        //    var response = await sendGridClient.SendEmailAsync(sendGridMessage);
        //    return response.IsSuccessStatusCode;

        //}


    }

}