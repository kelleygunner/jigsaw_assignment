using Infrastructure.UI;

namespace Application.Navigation
{
    internal interface IScreenProvider
    {
        IScreenPresenter GetTarget(ScreenId screenId);
    }
}