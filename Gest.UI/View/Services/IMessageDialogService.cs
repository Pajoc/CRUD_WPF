using System.Threading.Tasks;

namespace Gest.UI.View.Services
{
    public interface IMessageDialogService
    {
        Task ShowInfoDialogAsync(string text);
        Task<MessageDialogResult> ShowOkCancelDialogAsync(string text, string title);
    }
}