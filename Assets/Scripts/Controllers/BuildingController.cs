using System;
using Configs;
using Controllers;
using TMPro;
using UnityEngine;
using Views;

public sealed class BuildingController : MonoBehaviour
{
   
    private BuildingView _buildingPrefab;
    private readonly BalanceController _balanceController = BalanceController.GetInstance();
    
    private BuildingController() { }
        
    private static BuildingController _instance;
    public static BuildingController GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BuildingController();
        }
        return _instance;
    }

    public int LevelCost(int level, int basicCost)
    {
        return (level + 1) * basicCost;
    }

    public void ChangeLevel(BuildingConfig _buildingConfig)
    {
        _balanceController.WithdrawFromBalance(LevelCost(_buildingConfig.Level, _buildingConfig.BasicCost));
        _buildingConfig.Level++;
    }

    public int IncomeCalculation(BuildingConfig buildingConfig)
    {
        return (int)(buildingConfig.Level * buildingConfig.BasicIncome * (1 + (buildingConfig.Update1.UpdateIs ? buildingConfig.Update1.UpdateIncome : 0) + (buildingConfig.Update2.UpdateIs ? buildingConfig.Update2.UpdateIncome : 0)));
    }

    public void AccrueIncome(BuildingConfig building)
    {
        _balanceController.AddBalance(IncomeCalculation(building));
    }
}