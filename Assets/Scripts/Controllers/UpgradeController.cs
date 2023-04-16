using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public UpgradeController(int upgradeCost, int upgradeIncome)
    {
        UpgradeCost = upgradeCost;
        UpgradeIncome = upgradeIncome;
    }

    public int UpgradeCost { get; set; } //Стоимость улучшения
    public int UpgradeIncome { get; set; } //Бафф от улучшения

    public bool UpgradeIs { get; set; } = false;
}
