using UI.Menu;
using UnityEngine;
using Zenject;

namespace General
{
    public class Bootstrapper : MonoBehaviour
    {
        [Inject]
        private void Construct(Menu.Factory menuFactory)
        {
            menuFactory.Create();
        }
    }
}