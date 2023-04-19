using System;
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
    private string _name;

    public void DrawLevel(int level, int basicCost, string bName)
    {
        _level = level;
        _basicCost = basicCost;
        _name = bName;

//        _button.interactable = _balanceController.BalanceCheck(_buildingController.LevelCost(_level, _basicCost));
        
        _buttonText.text = "Поднять уровень\n" + (_level + 1) * _basicCost;
        
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnClick()
    {
        DrawLevel(_level + 1, _basicCost, _name);
        _buildingController.ChangeLevel(_name);
        _balanceController.WithdrawFromBalance(_buildingController.LevelCost(_level, _basicCost));
    }
}
