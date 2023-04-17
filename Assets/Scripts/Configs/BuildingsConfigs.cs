using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = nameof(BuildingsConfigs))]
    public class BuildingsConfigs : ScriptableObject
    {
        public BuildingConfig[] Buildings => _buildings;
        
        [SerializeField] private BuildingConfig[] _buildings;
    }
}