namespace DependencyInjectionProject.Services
{
    public class EmailService : IEmailService
    {
        public string SendEmail(string to, string subject, string body)
        {
            return $"Email send to {to} with subject '{subject}'";
        }
    }
}