using System;
using System.Windows;

namespace LoanAmortization
{
    /// <summary>
    /// Interaction logic for Reciept.xaml
    /// </summary>
    public partial class Reciept : Window
    {
        public Reciept()
        {
            InitializeComponent();
            if (MainWindow.borrower != null)
            {
                addressBox.Text = MainWindow.borrower.FullName + Environment.NewLine +
                    MainWindow.borrower.Address + Environment.NewLine +
                    MainWindow.borrower.Address2 + Environment.NewLine +
                    MainWindow.borrower.City + " " + MainWindow.borrower.State + " " + MainWindow.borrower.Zipcode;

                showAmount.Text = MainWindow.loanInfo.Amount.ToString();
                showDuration.Text = MainWindow.loanInfo.Duration.ToString();
                showRate.Text = MainWindow.loanInfo.InterestRate.ToString();
                showDate.Text = MainWindow.loanInfo.BeginDate.ToString("MM/dd/yyyy");
                showEndDate.Text = MainWindow.loanInfo.EndDate.ToString("MM/dd/yyyy");
            }

            if(MainWindow.theList != null)
            {
                dgReciept.ItemsSource = MainWindow.theList;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
