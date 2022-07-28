using System;
using UI.Menu;
using UnityEngine;
using Zenject;

namespace General
{
    public class GeneralInstaller : MonoInstaller
    {
        [SerializeField] private Canvas dynamicCanvas;
        [SerializeField] private MenuItem menuItem;
        [SerializeField] private Menu menu;
        
        public override void InstallBindings()
        {
            BindDynamicCanvas();
            BindMenuItemFactory();
            BindMenuFactory();
        }

        private void BindDynamicCanvas()
        {
            Canvas canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(dynamicCanvas);

            Container
                .Bind<Canvas>()
                .FromInstance(canvasInstance)
                .AsSingle();
        }
        
        private void BindMenuItemFactory()
        {
            Container
                .BindFactory<RectTransform, string, Action, MenuItem, MenuItem.Factory>()
                .FromComponentInNewPrefab(menuItem)
                .AsSingle();
        }

        private void BindMenuFactory()
        {
            Container
                .BindFactory<Menu, Menu.Factory>()
                .FromComponentInNewPrefab(menu)
                .AsSingle();
        }
    }
}