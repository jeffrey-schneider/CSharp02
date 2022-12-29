using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAmortization
{
    class LoanInfo
    {
        readonly int loanNumber;
        double amount;
        //duration is number of months of the loan
        int duration;
        double interestRate;
        DateTime beginDate;

        public LoanInfo(int loanNumber, double amount, int duration, double interestRate, DateTime beginDate)
        {
            this.loanNumber = loanNumber;
            this.amount = amount;
            this.duration = duration;
            this.interestRate = interestRate;
            this.beginDate = beginDate;
        }

        public int LoanNumber { get => loanNumber; }
        public double Amount { get => amount; set => amount = value; }
        public int Duration { get => duration; set => duration = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public DateTime BeginDate { get => beginDate; set => beginDate = value; }
        public DateTime EndDate { get => beginDate.AddMonths(Duration); }

        public override string ToString()
        {
            return LoanNumber + " " + Amount + "  " + Duration + " " + InterestRate + " " + BeginDate + " " + EndDate;
        }
    }
}
