using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour, IUpgrade //Класс кнопки поднятия уровня
{
    public bool BalanceCheck()
    {
        return BuildingController.LevelCost() <= Balance.Money;
    }

    public void ReduceBalance()
    {
        Balance.Money -= BuildingController.LevelCost();
    }

    public void UpgradeBuilding()
    {
        Building.Level += 1;
    }
}
