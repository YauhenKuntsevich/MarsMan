using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private UpgradeConfig _upgradeConfig;
    
    private UpgradeController() { }
        
    private static UpgradeController _instance;
    public static UpgradeController GetInstance()
    {
        if (_instance == null)
        {
            _instance = new UpgradeController();
        }
        return _instance;
    }
    
    private void BuyUpgrade()
    {
        
    }
}
