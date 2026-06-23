using System;
using UnityEngine;

namespace Features.HomeScreen
{
    public class HomeScreenView : MonoBehaviour
    {
        // Это простая реализация, которая нужна только для демонстрации флоу

        public Action<int> LevelButtonClicked;

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
            var buttons = GetComponentsInChildren<UnityEngine.UI.Button>();
            if (buttons.Length == 0)
                throw new MissingComponentException("There are no level buttons in the HomeScreenView");
            
            for (var i = 0; i < buttons.Length; i++)
            {
                var num = i; // avoid Closure
                buttons[i].onClick.AddListener(() => OnLevelButtonClicked(num));
            }
        }

        private void OnLevelButtonClicked(int num)
        {
            LevelButtonClicked?.Invoke(num);
        }

        private void OnDestroy()
        {
            var buttons = GetComponentsInChildren<UnityEngine.UI.Button>();
            foreach (var button in buttons)
            {
                button.onClick.RemoveAllListeners();
            }
        }
    }
}