using System;
using Gameplay.Domain;
using Infrastructure.UI;
using UnityEngine;

namespace Features.StartLevelScreen
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class StartLevelScreenModel
    {
        private readonly IScreenNavigationService _navigationService;
        
        // Вынести в конфиг
        private readonly string[] _detailsLevels = new[] { "5x5", "6x6", "10x10", "12x12", "20x20" };

        private GameLevelStartupData _currentGameLevel;
        private int _currentDetailTier;
        
        public StartLevelScreenModel(IScreenNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        internal bool RequestBack()
        {
            _navigationService.TryBackWithFallback(ScreenId.HomeScreen);
            return true;
        }

        internal void InitializeWithNewLevel(GameLevelStartupData levelData)
        {
            _currentGameLevel = levelData;
            _currentDetailTier = 0;
        }

        internal DetailsLevelWidgetData GetDetailsData()
        {
            var capIndex = _currentGameLevel.LevelOfDetailsCap;
            var defaultTier = _currentGameLevel.DefaultDetailsLevel;
            var level = _detailsLevels.AsSpan(0,capIndex).ToArray();
            var data = new DetailsLevelWidgetData(defaultTier, level);
            return data;
        }

        internal void SetCurrentTier(int tier)
        {
            _currentDetailTier = tier;
        }

        internal bool TryStartLevel(ActivationLevelType activationLevelType)
        {
            //Validate
            // if (!Validated)
            // return false;
            
            _currentGameLevel.SetLevelOfDetails(_currentDetailTier);
            _currentGameLevel.Build();
            Clean();
            Debug.Log($"Running Level for {activationLevelType}...");
            
            // Instead of running level we are leaving onto HomeScreen
            _navigationService.Open(ScreenId.HomeScreen, mode: OpenScreenMode.Replace);
            return true;
        }

        internal LevelActivationData GetLevelActivationData()
        {
            if (_currentGameLevel == null)
                throw new Exception("Using Level data before Initialization is prohibited");
            
            var activationData = new LevelActivationData(_currentGameLevel.UnlockCost, 
                _currentGameLevel.IsAdsAvailable /* && _adsService.HasRewardedAd*/);
            return activationData;
        }
        
        private void Clean()
        {
            // _gameplayFlowController.RunLevel(_currentGameLevel);
            _currentGameLevel = null;
            
            // ссылка на _currentGameLevel остается только у gameplayController
            // чтобы при завершении уровня ссылка не залипла и GC мог собрать
            // в случае необходимости
        }
    }
}