using Infrastructure.DataTransferring;

namespace Infrastructure.UI
{
    public interface IScreenPresenter
    {
        void Open(IDto data = null);
        void Close();
    }
}