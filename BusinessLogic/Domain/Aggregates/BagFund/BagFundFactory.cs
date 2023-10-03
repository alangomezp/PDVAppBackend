namespace BusinessLogic.Domain.Aggregates
{
    public class BagFundFactory
    {
        public int Hours { get; set; }
        public string MonthPeriod { get; set; }
        public int YearPeriod { get; set; }
        public Guid StudentId { get; set; }

        public BagFundFactory(int hours, string monthPeriod, int yearPeriod, Guid studentId)
        {
            Hours = hours;
            MonthPeriod = monthPeriod;
            YearPeriod = yearPeriod;
            StudentId = studentId;
        }

        public BagFund Create()
        {
            return new BagFund(this);
        }
    }
}