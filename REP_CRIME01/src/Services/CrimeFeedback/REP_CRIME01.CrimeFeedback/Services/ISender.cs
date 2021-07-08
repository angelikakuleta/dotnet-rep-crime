using REP_CRIME01.EventBus.Messages;
using System.Threading.Tasks;

namespace REP_CRIME01.CrimeFeedback.Services
{
    public interface ISender
    {
        Task Send(CrimeEventAssignedNotification message);
    }
}
