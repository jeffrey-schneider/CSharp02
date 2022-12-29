using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAmortization
{
    class LoanPayments
    {
        int loanNumber;         //Link to the overall loan information object.
        int paymentNumber;
        double begBalance;
        double totalPayment;
        double interestPayment;
        double principalPayment;
        double endBalance;
        DateTime paymentDate;

        public LoanPayments(int loanNumber, int paymentNumber)
        {
            this.loanNumber = loanNumber;
            this.paymentNumber = paymentNumber;
        }

        public LoanPayments(int loanNumber, int paymentNumber, double amount, DateTime paymentDate)
        {
            this.loanNumber = loanNumber;
            this.paymentNumber = paymentNumber;
            this.totalPayment = amount;
            this.paymentDate = paymentDate;
        }

        public LoanPayments(int loanNumber, int paymentNumber, double begBalance, double totalPayment, double interestPayment, 
            double principalPayment, double endBalance, DateTime paymentDate)
        {
            this.loanNumber = loanNumber;
            this.paymentNumber = paymentNumber;
            this.begBalance = begBalance;
            this.totalPayment = totalPayment;
            this.interestPayment = interestPayment;
            this.principalPayment = principalPayment;
            this.endBalance = endBalance;
            this.paymentDate = paymentDate;
            if(begBalance < totalPayment)
            {
                TotalPayment = BegBalance;
                InterestPayment = 0.0;
                EndBalance = BegBalance - TotalPayment;
            }
        }

        public int LoanNumber { get => loanNumber;  }
        public int PaymentNumber { get => paymentNumber;  }
        public double BegBalance { get => begBalance; set => begBalance = value; }
        public double TotalPayment { get => totalPayment; set => totalPayment = value; }
        public double InterestPayment { get => interestPayment; set => interestPayment = value; }
        public double PrincipalPayment { get => principalPayment; set => principalPayment = value; }
        public double EndBalance { get => endBalance; set => endBalance = value; }
        public DateTime PaymentDate { get => paymentDate;  }

        public override string ToString()
        {
            return LoanNumber + " " + PaymentNumber + " " + BegBalance + " " + TotalPayment + " " + InterestPayment + " " + 
                PrincipalPayment + " " + EndBalance + " " + PaymentDate.ToString("MM/dd/yyy");
        }
    }
}
