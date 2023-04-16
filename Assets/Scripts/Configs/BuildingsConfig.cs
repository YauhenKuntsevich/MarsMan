using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = nameof(BuildingsConfigs))]
public class BuildingsConfigs : ScriptableObject
{
    public BuildingConfig[] Buildings => _buildings;
        
    [SerializeField] private BuildingConfig[] _buildings;
}
