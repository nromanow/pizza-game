using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Menu
{
    public class MenuItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemLabel;
        [SerializeField] private Button itemButton;

        private Action _onItemClicked;

        [Inject]
        private void Construct(RectTransform root, string locKey, Action targetAction)
        {
            transform.SetParent(root); 
            itemButton.onClick.AddListener(() => _onItemClicked?.Invoke());
            
            SetLabelText(locKey);
            SetButtonTargetAction(targetAction);
        }

        public void SetLabelText(string localizationKey, int? value = null)
        {
            string format = LocalizationManager.GetTranslation(localizationKey);
            itemLabel.text = string.Format(format, value);
        }

        public void SetButtonTargetAction(Action targetAction)
        {
            _onItemClicked = targetAction;
        }
        
        public class Factory : PlaceholderFactory<RectTransform, string, Action, MenuItem> {}
    }
}