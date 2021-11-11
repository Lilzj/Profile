using ProfileManager.ViewModel;
using System.Threading.Tasks;

namespace ProfileManager.Repository
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
