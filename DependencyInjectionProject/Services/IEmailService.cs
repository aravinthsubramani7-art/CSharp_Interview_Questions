namespace DependencyInjectionProject.Services
{
    public interface IEmailService
    {
        string SendEmail(string to, string subject, string body);
    }
}