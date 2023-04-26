using Models;

namespace Controllers
{
    public sealed class BalanceController
    {
        private BalanceController() { }
        
        private static BalanceController _instance;

        public static BalanceController GetInstance()
        {
            if (_instance != null) return _instance;
            _instance = new BalanceController();
            return _instance;
        }

        public static void AddBalance(int income)
        {
            BalanceModel.Money += income;
        }

        public void WithdrawFromBalance(int amount)
        {
            if (BalanceCheck(amount))
            {
                BalanceModel.Money -= amount;
            }
        }
        
        public bool BalanceCheck(int amount)
        {
            return amount <= BalanceModel.Money;
        }
    }
}
