using Configs;
using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Button _button;
        
        private BalanceController _balanceController = BalanceController.GetInstance();

        private UpgradeConfig _upgrade;

        public void DrawUpgrade(UpgradeConfig upgrade)
        {
            _upgrade = upgrade;

            if (_upgrade._updateIs)
            {
                _buttonText.text = _upgrade._name + "\nкуплено!";
                _button.interactable = false;
            }
            else
            {
                _buttonText.text = _upgrade._name + "\n" + _upgrade._updateCost;
            }
            
            _button.onClick.AddListener(OnClick);
        }

        private void Update()
        {
            if (!_upgrade._updateIs)
            {
                _button.interactable = _balanceController.BalanceCheck(_upgrade._updateCost);
            }
        }

        private void OnClick()
        {
            _upgrade._updateIs = true;
            _balanceController.WithdrawFromBalance(_upgrade._updateCost);
            DrawUpgrade(_upgrade);
        }
    }
}