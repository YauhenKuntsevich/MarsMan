using System;
using Configs;
using Controllers;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private Button _button;

    private BalanceController _balanceController = BalanceController.GetInstance();
    private BuildingController _buildingController = BuildingController.GetInstance();
    private int _level;
    private int _basicCost;
    private BuildingConfig _buildingConfig;

    public void DrawLevel(BuildingConfig buildingConfig)
    {
        _buildingConfig = buildingConfig;
        _level = buildingConfig.Level;
        _basicCost = buildingConfig.BasicCost;
        
        _buttonText.text = "Поднять уровень\n" + (_level + 1) * _basicCost;
        
        _button.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        _button.interactable = _balanceController.BalanceCheck(_buildingController.LevelCost(_level, _basicCost));
    }

    private void OnClick()
    {
        DrawLevel(_buildingConfig);
        _buildingController.ChangeLevel(_buildingConfig);
    }
}
