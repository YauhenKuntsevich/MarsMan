using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private BuildingConfig _buildingConfig;
    private BalanceController _balanceController;
    
    private void OnClick()
    {
        _balanceController.WithdrawFromBalance((_buildingConfig.Level + 1) * _buildingConfig.BasicCost);
    }
}
