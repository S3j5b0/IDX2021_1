namespace mongoExample.Models
{
    public class EconomicModel
    {
        public int WeeklyPrice;
        public int savedFromLastWeek;
        public int yearlySpending;

        public EconomicModel(int weekprice = 0, int savedfromlastweek = 0,int yearlyspending = 0)
        {
            this.WeeklyPrice = weekprice;
            this.savedFromLastWeek = savedfromlastweek;
            this.yearlySpending = yearlyspending;
        }
    }
}