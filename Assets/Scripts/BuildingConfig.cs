using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingConfig
{
    public string Name;
    public int Level;
    public int BasicCost;
    public int BasicIncome;
    public UpdateConfig Update1;
    public UpdateConfig Update2;
    public bool Update2Is;
    public int Update2Cost;
    public int Update2Income;
}
