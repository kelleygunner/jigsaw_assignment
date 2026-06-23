using System;
using Infrastructure.DataTransferring;
using Infrastructure.UI;

namespace Features.HomeScreen
{
    [RegisterScreen("HomeScreen")]
    public class HomeScreenPresenter : IScreenPresenter, IDisposable
    {
        private readonly HomeScreenModel _model;
        private readonly HomeScreenView _view;

        public HomeScreenPresenter(HomeScreenModel model, HomeScreenView view)
        {
            _model = model;
            _view = view;
            _view.LevelButtonClicked += RequestLevelStart;
        }
        
        public void Open(IDto data = null)
        {
            _view.Open();
        }

        public void Close()
        {
            _view.Close();
        }

        private void RequestLevelStart(int levelNumber)
        {
            var response = _model.RequestOpenRegularLevel(levelNumber);
            if (response)
                Close();
        }

        
        public void Dispose()
        {
            // TODO: диспоуз не вызывается из Zenject из-за особенностей биндинга.
            // TODO: добавить ручной дизпоуз
            _view.LevelButtonClicked -= RequestLevelStart;
        }
    }
}