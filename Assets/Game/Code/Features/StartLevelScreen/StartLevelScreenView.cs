using System;
using Infrastructure.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.StartLevelScreen
{
    public class StartLevelScreenView : MonoBehaviour, IScreenView
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _freeStartButton;
        [SerializeField] private Button _coinsStartButton;
        [SerializeField] private Button _adsStartButton;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _activateCostText;
        [SerializeField] private DetailsLevelWidget _detailsLevelWidget;
        [SerializeField] private PreviewPatternView _previewPatternView;

        public event Action BackPressed;
        public event Action<int> DetailsTierChanged;
        public event Action FreeStartButtonPressed;
        public event Action CoinsStartButtonPressed;
        public event Action AdsStartButtonPressed;

        public void Initialize(string id, DetailsLevelWidgetData detailsLevelWidgetData)
        {
            _detailsLevelWidget.Init(detailsLevelWidgetData);
            _titleText.text = id;
            
            _freeStartButton.gameObject.SetActive(false);
            _coinsStartButton.gameObject.SetActive(false);
            _adsStartButton.gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void Start()
        {
            // Buttons
            _backButton.onClick.AddListener(OnBackPressed);
            _freeStartButton.onClick.AddListener(()=>FreeStartButtonPressed?.Invoke());
            _coinsStartButton.onClick.AddListener(()=>CoinsStartButtonPressed?.Invoke());
            _adsStartButton.onClick.AddListener(()=>AdsStartButtonPressed?.Invoke());
            
            _detailsLevelWidget.TierSelect += OnDetailsLevelChanged;
            OnDetailsLevelChanged(_detailsLevelWidget.SelectedTier);
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(OnBackPressed);
            _freeStartButton.onClick.RemoveAllListeners();
            _coinsStartButton.onClick.RemoveAllListeners();
            _adsStartButton.onClick.RemoveAllListeners();
            
            _detailsLevelWidget.TierSelect -= OnDetailsLevelChanged;
        }

        private void OnBackPressed()
        {
            BackPressed?.Invoke();
        }

        private void OnDetailsLevelChanged(int tier)
        {
            _previewPatternView.Setup(tier);
            DetailsTierChanged?.Invoke(tier);
        }

        public void ActivateFreeStartButton()
        {
            _freeStartButton.gameObject.SetActive(true);
        }

        public void ActivateCoinsStartButton(int cost)
        {
            _coinsStartButton.gameObject.SetActive(true);
            _activateCostText.text = $"Unlock: {cost}";
        }

        public void ActivateAdsStartButton()
        {
            _adsStartButton.gameObject.SetActive(true);
        }
    }
}