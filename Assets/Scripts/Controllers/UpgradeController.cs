using Configs;

namespace Controllers
{
    public class UpgradeController
    {
        private UpgradeConfig _upgradeConfig;
    
        private UpgradeController() { }
        
        private static UpgradeController _instance;
        public static UpgradeController GetInstance()
        {
            if (_instance != null) return _instance;
            _instance = new UpgradeController();
            return _instance;
        }
    }
}
