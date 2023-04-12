using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgrade
{
    public bool BalanceCheck(); //Проверка баланса для покупки
    public void ReduceBalance(); //Списать с баланса стоимость улучшения
    public void UpgradeBuilding(); //Обновить доход здания 
}
