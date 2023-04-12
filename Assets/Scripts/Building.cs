using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Building : MonoBehaviour
{
    internal static int Level { get; set; } //Уровень здания
    public int Income => BuildingController.IncomeCalculation(); //Доход здания на данный момент
    
    private int IncomeDelay { get; } //Время, необходимое для заполнения шкалы дохода
    internal static int BasicCost { get; set; } //Базовая стоимость здания
    public static int BasicIncome { get; set; } //Базовый доход здания
    private string Name { get; } //Название здания

    internal static List<UpgradeController> _upgrades = new List<UpgradeController>();
    private readonly BuildingController _buildingController;

    public Building(string name, int incomeDelay, int basicCost, int basicIncome)
    {
        Name = name;
        IncomeDelay = incomeDelay;
        BasicCost = basicCost;
        BasicIncome = basicIncome;
    }
}