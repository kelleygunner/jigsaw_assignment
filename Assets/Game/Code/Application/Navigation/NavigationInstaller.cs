using Zenject;

namespace Application.Navigation
{
    public class NavigationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScreenProviderFromContainer>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScreenNavigationService>().AsSingle();
        }
    }
}