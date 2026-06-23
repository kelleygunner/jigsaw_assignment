using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.StartLevelScreen
{
    public class DetailsLevelTier : MonoBehaviour
    {
        [SerializeField] private Button _selectButton;
        [SerializeField] private GameObject _selectionMarker;
        [SerializeField] private TextMeshProUGUI _tierText;
        private Action<DetailsLevelTier> _onLevelSelected;
        public void Setup(string tierName, 
            bool isSelected, 
            Action<DetailsLevelTier> selectHandler)
        {
            gameObject.SetActive(true);
            _selectionMarker.gameObject.SetActive(false);
            _onLevelSelected = selectHandler;
            _tierText.text = tierName;
            if (isSelected)
                Select();
            else
                Unselect();
        }

        private void Start()
        {
            _selectButton.onClick.AddListener(() =>
            {
                _onLevelSelected?.Invoke(this);
            });
        }

        private void OnDestroy()
        {
            _selectButton.onClick.RemoveAllListeners();
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Select()
        {
            _selectionMarker.gameObject.SetActive(true);
        }

        public void Unselect()
        {
            _selectionMarker.gameObject.SetActive(false);
        }
    }
}