using Infrastructure.UI;
using UnityEngine;
using Zenject;

namespace Application.Startup
{
    public class AppBootstrap : MonoBehaviour
    {
        private IScreenNavigationService _screenNavigationService;

        [Inject]
        public void Construct(IScreenNavigationService screenNavigationService)
        {
            _screenNavigationService = screenNavigationService;
        }

        private void Start()
        {
            var startFlowType = StartFlowType.Regular; // To be implemented later
            
            // Refactor with Factory and flow implementation
            switch (startFlowType)
            {
                default:
                    _screenNavigationService.Open(ScreenId.HomeScreen);
                    break;
            }
            
        }
    }

    public enum StartFlowType
    {
        Regular,
        Ftue,
        DeepLink
    }
}