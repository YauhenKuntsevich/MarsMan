using System;
using UnityEngine.Serialization;

namespace Configs
{
    [Serializable]
    public class UpgradeConfig
    {
        [FormerlySerializedAs("Name")] public string _name;
        [FormerlySerializedAs("UpdateIs")] public bool _updateIs;
        [FormerlySerializedAs("UpdateCost")] public int _updateCost;
        [FormerlySerializedAs("UpdateIncome")] public float _updateIncome;
    }
}