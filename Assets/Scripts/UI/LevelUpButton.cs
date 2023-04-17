using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _levelText;

    private BalanceController _balanceController;
    private BuildingController _buildingController;
    private int _level;
    private int _basicCost;
    private string _name;
    
    public void DrawLevel(int level, int basicCost, string name)
    {
        _level = level;
        _basicCost = basicCost;
        _name = name;

        _button.interactable = _balanceController.BalanceCheck(_buildingController.LevelCost(_level, _basicCost));
        
        _buttonText.text = "Поднять уровень\n" + (_level + 1) * _basicCost;
        
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnClick()
    {
        DrawLevel(_level + 1, _basicCost, _name);
        _balanceController.WithdrawFromBalance(_buildingController.LevelCost(_level, _basicCost));
        _buildingController.ChangeLevel(_name);
    }
}
