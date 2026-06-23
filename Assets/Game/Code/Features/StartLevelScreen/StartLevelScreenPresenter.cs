using System;
using Gameplay.Domain;
using Infrastructure.DataTransferring;
using Infrastructure.UI;

namespace Features.StartLevelScreen
{
    [RegisterScreen("StartLevelScreen")]
    public class StartLevelScreenPresenter : IScreenPresenter, IDisposable
    {
        private readonly StartLevelScreenModel _model;
        private readonly StartLevelScreenView _view;

        public StartLevelScreenPresenter(StartLevelScreenModel model, StartLevelScreenView view)
        {
            _model = model;
            _view = view;
            _view.BackPressed += OnBackPressed;
            _view.DetailsTierChanged += OnDetailsTierChanged;
            _view.FreeStartButtonPressed += FreeStartRequested;
            _view.CoinsStartButtonPressed += CoinsStartRequested;
            _view.AdsStartButtonPressed += AdsStartRequested;
        }
        
        public void Dispose()
        {
            _view.BackPressed -= OnBackPressed;
            _view.DetailsTierChanged -= OnDetailsTierChanged;
            _view.FreeStartButtonPressed -= FreeStartRequested;
            _view.CoinsStartButtonPressed -= CoinsStartRequested;
            _view.AdsStartButtonPressed -= AdsStartRequested;
        }
        
        public void Open(IDto data = null)
        {
            if (data is not GameLevelStartupData levelData)
                throw new Exception("Level Data is not Valid");
            
            _model.InitializeWithNewLevel(levelData);

            var activationData = _model.GetLevelActivationData();
            var detailsData = _model.GetDetailsData();
            
            _view.Initialize(levelData.Name, detailsData);
            
            if (activationData.IsFree)
                _view.ActivateFreeStartButton();
            else
            {
                _view.ActivateCoinsStartButton(activationData.UnlockCost);
                if (activationData.IsAdPassAvailable)
                    _view.ActivateAdsStartButton();
            }
            
            _view.Open();
        }

        public void Close()
        {
            _view.Close();
        }
        
        private void OnBackPressed()
        {
            var response = _model.RequestBack();
            if (response)
                Close();
        }
        
        private void OnDetailsTierChanged(int tier)
        {
            _model.SetCurrentTier(tier);
        }
        
        private void AdsStartRequested()
        {
            var result = _model.TryStartLevel(ActivationLevelType.Ads);
            if (result)
                Close();
        }

        private void CoinsStartRequested()
        {
            var result = _model.TryStartLevel(ActivationLevelType.Coins);
            if (result)
                Close();
        }

        private void FreeStartRequested()
        {
            var result = _model.TryStartLevel(ActivationLevelType.Free);
            if (result)
                Close();
        }
    }
}