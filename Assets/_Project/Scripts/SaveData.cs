namespace TestClicker
{
    [System.Serializable]
    public class SaveData
    {
        public double coinBalance;
        public double coinPerClick;
        public double coinPerSecond;

        public SaveData(double coinBalance, double coinPerClick, double coinPerSecond)
        {
            this.coinBalance = coinBalance;
            this.coinPerClick = coinPerClick;
            this.coinPerSecond = coinPerSecond;
        }

        public static implicit operator string(SaveData saveData)
        {
            return
                $"Balance: {saveData.coinBalance}\nCoin/Click: {saveData.coinPerClick}\nCoin/Sec: {saveData.coinPerSecond}";
        }
    }
}