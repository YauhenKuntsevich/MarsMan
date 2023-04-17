using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Button _button;
        
        private BalanceController _balanceController;
        private UpgradeConfig _upgrade;
            
        public void DrawUpgrade(UpgradeConfig upgrade)
        {
            _upgrade = upgrade;

            if (_upgrade.UpdateIs)
            {
                _buttonText.text = _upgrade.Name + "\nкуплено!";
                _button.interactable = false;
            }
            else
            {
                _buttonText.text = _upgrade.Name + "\n" + _upgrade.UpdateCost;
                _button.interactable = _balanceController.BalanceCheck(_upgrade.UpdateCost);
            }
            
            _button.onClick.AddListener(OnClick);
        }
            
        private void OnClick()
        {
            _balanceController.WithdrawFromBalance(_upgrade.UpdateCost);
            _upgrade.UpdateIs = true;
            DrawUpgrade(_upgrade);
        }
    }
}