using System;
using System.Collections.Generic;
using Infrastructure.DataTransferring;
using Infrastructure.UI;

namespace Application.Navigation
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class ScreenNavigationService : IScreenNavigationService
    {
        private readonly IScreenProvider _screenProvider;
        private readonly Stack<ScreenId> _screenStack = new ();

        public ScreenNavigationService(IScreenProvider screenProvider)
        {
            _screenProvider = screenProvider;
        }
        
        public void Open(ScreenId screenId, IDto data = null, OpenScreenMode mode = OpenScreenMode.Replace)
        {
            switch (mode)
            {
                case OpenScreenMode.Additive : 
                    _screenStack.Push(screenId);
                    break;
                case OpenScreenMode.Replace:
                default:
                {
                    _screenStack.Clear();
                    _screenStack.Push(screenId);
                }
                    break;
            }
            
            var screenTarget = _screenProvider.GetTarget(screenId);
            if (screenTarget == null)
                throw new NullReferenceException();
            screenTarget.Open(data);
        }

        public void TryBackWithFallback(ScreenId screenId)
        {
            if (_screenStack.Count > 1)
            {
                _screenStack.Pop(); //Remove current
                var screen = _screenStack.Pop(); //Remove and re-open previous
                Open(screen);
                return;
            }

            Open(screenId, mode: OpenScreenMode.Replace);
        }
    }
}