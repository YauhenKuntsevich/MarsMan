using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingConfig
{
    public string Name;
    public int Level;
    public int IncomeDelay;
    public int BasicCost;
    public int BasicIncome;
    public UpgradeConfig Update1;
    public UpgradeConfig Update2;
}
