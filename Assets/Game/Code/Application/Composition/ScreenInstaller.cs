using System;
using System.Linq;
using System.Reflection;
using Features.HomeScreen;
using Features.StartLevelScreen;
using Infrastructure.UI;
using UnityEngine;
using Zenject;

namespace Application.Composition
{
    public class ScreenInstaller : MonoInstaller
    {
        // Replace with loading and instancing in Addressable
        [SerializeField] private HomeScreenView _homeScreenView;
        [SerializeField] private StartLevelScreenView _startLevelScreenView;
        
        public override void InstallBindings()
        {
            // Авто-биндинг Скринов
            
            // Refactor: тоже убрать за поиск типов по всем assembly с проверкой
            // на интерфейсы IScreenView и IScreenModel
            Container.Bind<HomeScreenModel>().FromNew().AsSingle();
            Container.Bind<StartLevelScreenModel>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenView>().FromInstance(_homeScreenView).AsSingle();
            Container.BindInterfacesAndSelfTo<StartLevelScreenView>().FromInstance(_startLevelScreenView).AsSingle();
            
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var screenAssemblies = allAssemblies
                .Where(a => a.GetName().Name.Contains("Screen"));
            
            var presenterTypes = screenAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new 
                {
                    Type = t,
                    Attribute = t.GetCustomAttribute<RegisterScreenAttribute>()
                })
                .Where(x => x.Attribute != null && typeof(IScreenPresenter).IsAssignableFrom(x.Type));
            
            foreach (var screen in presenterTypes)
            {
                Container.Bind<IScreenPresenter>()
                    .WithId(screen.Attribute.ScreenId)
                    .To(screen.Type)
                    .AsSingle();
            }
            
            // На проде можно добавить аттрибут, чтобы фильтровать авто-биндинг
        }
    }
}
