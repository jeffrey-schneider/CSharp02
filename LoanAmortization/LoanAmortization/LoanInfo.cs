using System;

namespace LoanAmortization
{
    public class LoanInfo
    {
        int loanNumber;
        double amount;
        //duration is number of months of the loan
        int duration;
        double interestRate;
        DateTime beginDate;

        public LoanInfo()
        {

        }
        public LoanInfo(int loanNumber, double amount, int duration, double interestRate, DateTime beginDate)
        {
            this.loanNumber = loanNumber;
            this.amount = amount;
            this.duration = duration;
            this.interestRate = interestRate;
            this.beginDate = beginDate;
        }

        public int LoanNumber { get => loanNumber; set => loanNumber = value; }
        public double Amount { get => amount; set => amount = value; }
        public int Duration { get => duration; set => duration = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public DateTime BeginDate { get => beginDate; set => beginDate = value; }
        public DateTime EndDate { get => beginDate.AddMonths(Duration); }

        public Boolean Clear()
        {
            LoanNumber = 0;
            Amount = 0.0;
            Duration = 0;
            InterestRate = 0.0;
            BeginDate = new DateTime(0, 0, 0);
            return true;
        }

        public override string ToString()
        {
            return LoanNumber + " " + Amount + "  " + Duration + " " + InterestRate + " " + BeginDate + " " + EndDate;
        }
    }
}
