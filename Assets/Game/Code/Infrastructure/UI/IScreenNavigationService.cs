using Infrastructure.DataTransferring;

namespace Infrastructure.UI
{
    public interface IScreenNavigationService
    {
        void Open(ScreenId screenId, IDto data = null, OpenScreenMode mode = OpenScreenMode.Replace);
        void TryBackWithFallback(ScreenId screenId);
    }
}

