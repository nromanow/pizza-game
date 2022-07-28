using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UI.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private RectTransform root;
        
        private List<MenuItem> _items;
        private MenuItem.Factory _menuItemFactory;

        [Inject]
        private void Construct(MenuItem.Factory menuItemFactory)
        {
            _menuItemFactory = menuItemFactory;

            _items = new List<MenuItem>()
            {
                _menuItemFactory.Create(root, "MainMenu_Play", () => {}),
                _menuItemFactory.Create(root, "MainMenu_Settings", () => {}),
                _menuItemFactory.Create(root, "MainMenu_Credits", () => {})
            };
        }
        
        public class Factory : UIFactory<Menu> {}
    }
}