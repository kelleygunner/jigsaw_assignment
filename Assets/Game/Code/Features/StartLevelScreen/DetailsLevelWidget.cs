using System;
using UnityEngine;

namespace Features.StartLevelScreen
{
    // На самом деле можно было сделать через toggles, но тут у нас больше контроля.
    public class DetailsLevelWidget : MonoBehaviour
    {
        [SerializeField] private DetailsLevelTier[] _tiers;
        
        public event Action<int> TierSelect;
        private int _currentTier;
        public int SelectedTier => _currentTier;

        public void Init(DetailsLevelWidgetData data)
        {
            // Validate data
            if (data.Tiers.Count < 1 || data.Tiers.Count > _tiers.Length)
                throw new Exception("Not enough tiers for all levels of Details");

            // Disable tiers beyond the range
            for (var i = data.Tiers.Count - 1; i < _tiers.Length; i++)
            {
                _tiers[i].Disable();
            }
            
            for (var i = 0; i < data.Tiers.Count; i++)
            {
                _tiers[i].Setup(data.Tiers[i], i == data.DefaultTier, OnTierSelected);
            }
            
            TierSelect?.Invoke(data.DefaultTier);
            _currentTier = data.DefaultTier;
        }

        private void OnTierSelected(DetailsLevelTier tier)
        {
            var index = -1;
            for (var i = 0; i < _tiers.Length; i++)
            {
                if (_tiers[i] != tier) 
                    continue;
                index = i;
                break;
            }
            if (index < 0)
                throw new Exception("No tier selected");
            _tiers[_currentTier].Unselect();
            _currentTier = index;
            _tiers[_currentTier].Select();
            TierSelect?.Invoke(_currentTier);
        }
    }
}