using System;
using Infrastructure.UI;
using Zenject;

namespace Application.Navigation
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class ScreenProviderFromContainer : IScreenProvider
    {
        private readonly DiContainer _container;

        public ScreenProviderFromContainer(DiContainer container)
        {
            _container = container;
        }
        public IScreenPresenter GetTarget(ScreenId screenId)
        {
            var target = _container.ResolveId<IScreenPresenter>(screenId.Id);
            if (target == null)
                throw new NullReferenceException();
            return target;
        }
    }
}