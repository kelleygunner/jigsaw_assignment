using Gameplay.Domain;
using Infrastructure.UI;

namespace Features.HomeScreen
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HomeScreenModel
    {
        private readonly IScreenNavigationService _navigationService;

        public HomeScreenModel(IScreenNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        // Now it's just an order number, but will use level provider in production
        public bool RequestOpenRegularLevel(int number)
        {
            // Get level id from provider
            // Сейчас просто генерируем каждый раз случайны уровень
            // В продакшене будем брать из конфига
            var id = $"level_{number}";
            var data = new GameLevelStartupData(id);
            
            _navigationService.Open(ScreenId.StartLevelScreen, data, OpenScreenMode.Additive);
            return true;
        }
    }
}
