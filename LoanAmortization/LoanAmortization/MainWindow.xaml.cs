using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoanAmortization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime localDate = DateTime.Now;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("\nWPFLoanAmortization\n\nVersion 1.0.0");
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Clear Form Click");
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Test");
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int loanNo = 123;
            
            List<LoanPayments> theList = new List<LoanPayments>();

            if(!double.TryParse(txtAmount.Text, out double principal))
            {
                System.Windows.Forms.MessageBox.Show("Error parsing amount");
                txtAmount.Focus();
            }
            if (!int.TryParse(txtDuration.Text, out int numberOfPayments))
            {
                System.Windows.Forms.MessageBox.Show("Error parsing duration");
                txtDuration.Focus();
            }
            if (!double.TryParse(txtInterestRate.Text, out double annualRate))
            {
                System.Windows.Forms.MessageBox.Show("Error parsing interest rate");
                txtInterestRate.Focus();
            }

            DateTime parsedDate = datePicker.SelectedDate.Value;
            
            //If user entered whole number as interest rate, divide it by 100
            if(annualRate >= 1)
            {
                annualRate /= 100;
                txtInterestRate.Text = annualRate.ToString();
            }
            double monthlyPayment = calculateMonthlyPayment(principal, numberOfPayments, annualRate);
            double interestPaid = 0.0;
            double principalPaid = 0.0;
            double newBalance = 0.0;

            showPayment.Text = monthlyPayment.ToString();

            LoanInfo loanInfo = new LoanInfo(123, principal, numberOfPayments, annualRate, parsedDate);
            showAmount.Text = loanInfo.Amount.ToString();
            showDuration.Text = loanInfo.Duration.ToString();
            showRate.Text = loanInfo.InterestRate.ToString();
            showDate.Text = loanInfo.BeginDate.ToString("MM/dd/yyyy");
            showEndDate.Text = loanInfo.EndDate.ToString("MM/dd/yyyy");
            txtEndDate.Text = loanInfo.EndDate.ToString("MM/dd/yyyy");
            for (int counter = 1; counter <= numberOfPayments; counter++)
            {
                interestPaid = Math.Round((principal * (annualRate / 12)), 2, MidpointRounding.ToEven);
                principalPaid = Math.Round((monthlyPayment - interestPaid),2,MidpointRounding.ToEven);
                newBalance = Math.Round((principal - principalPaid),2,MidpointRounding.ToEven);

                theList.Add(new LoanPayments(loanNo, counter, principal, monthlyPayment, interestPaid, principalPaid, newBalance, parsedDate.AddMonths(counter - 1)));

                principal = newBalance;
            }
            dgSimple.ItemsSource = theList;

        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }            
            
        }

        private void Font_Update_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog fontDialog = new System.Windows.Forms.FontDialog();
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FontFamilyConverter ffc = new FontFamilyConverter();

                this.txtName.FontSize = fontDialog.Font.Size;
                this.txtName.FontFamily = (FontFamily)ffc.ConvertFromString(fontDialog.Font.Name);

                if (fontDialog.Font.Bold)
                    txtName.FontWeight = FontWeights.Bold;
                else
                    txtName.FontWeight = FontWeights.Normal;

                if (fontDialog.Font.Italic)
                    txtName.FontStyle = FontStyles.Italic;
                else
                    txtName.FontStyle = FontStyles.Normal;
            }

        }

        public static double calculateMonthlyPayment(double loanAmount, int term, double annualRate)
        {
            if(annualRate > 1)
            {
                annualRate /= 100;
            }
            double monthlyRate = annualRate / 12;

            return Math.Round((loanAmount * monthlyRate) / (1 - Math.Pow(1 + monthlyRate, -(term))),2,MidpointRounding.ToEven);
        }
    }
}
