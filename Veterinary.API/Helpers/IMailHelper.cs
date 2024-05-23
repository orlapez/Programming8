using Veterinary.Shared.Responses;

public interface IMailHelper
{
    Response SendMail(string toName, string toEmail, string subject, string body);
}

