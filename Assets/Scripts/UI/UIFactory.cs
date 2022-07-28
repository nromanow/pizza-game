using UnityEngine;
using Zenject;

namespace UI
{
    public class UIFactory<TValue> : 
        PlaceholderFactory<TValue> where TValue : Component
    {
        [Inject] private Canvas _root;
        
        public override TValue Create()
        {
            TValue instance = base.Create();
            instance.transform.SetParent(_root.transform, false);
            
            return instance;
        }
    }
    
    public class UIFactory<TParam1, TParam2, TParam3, TValue> : 
        PlaceholderFactory<TParam1, TParam2, TParam3, TValue> where TValue : Component
    {
        [Inject] private Canvas _root;
        
        public override TValue Create(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            TValue instance = base.Create(param1, param2, param3);
            instance.transform.SetParent(_root.transform, false);
            
            return instance;
        }
    }
}