using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LoanAmortization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime localDate = DateTime.Now;
        public static Borrower borrower = new Borrower();        
        public static LoanInfo loanInfo = new LoanInfo();
        public static ObservableCollection<LoanPayments> theList = new ObservableCollection<LoanPayments>();
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            List<string> listStates = new List<string>
            {
                "AL",
                "NC",
                "TN",
                "SC",
                "GA"
            };

            lstState.ItemsSource = listStates;
            lstState.SelectedIndex = lstState.Items.IndexOf("TN");           
        }

       
        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("\nWPFLoanAmortization\n\nVersion 1.1.0");
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Clear Form Click");

            //loanInfo = null;
            borrower = null;
            foreach(var ctl in containerText.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
            }
            foreach (var ctl in LoanGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
            }
            foreach (var ctl in DisplayGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
            }
            dgSimple.ItemsSource = null;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (borrower != null)
            {
                borrower.FullName = txtName.Text;
                borrower.Address = txtAddress.Text;
                borrower.Address2 = txtAddr2.Text;
                borrower.City = txtCity.Text;
                borrower.State = lstState.SelectedItems[0].ToString();
                borrower.Zipcode = txtZip.Text;
            }
            else
            {
                Borrower borrower = new Borrower
                {
                    FullName = txtName.Text,
                    Address = txtAddress.Text,
                    Address2 = txtAddr2.Text,
                    City = txtCity.Text,
                    State = lstState.SelectedItems[0].ToString(),
                    Zipcode = txtZip.Text
                };
            }

            System.Windows.Forms.MessageBox.Show("Test");
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            int loanNo = rnd.Next();
            double principal;
            int numberOfPayments;
            double annualRate;

                if (!double.TryParse(txtAmount.Text, out  principal))
                {
                    System.Windows.Forms.MessageBox.Show("Error parsing amount");
                    txtAmount.Focus();
                }
                if (!int.TryParse(txtDuration.Text, out  numberOfPayments))
                {
                    System.Windows.Forms.MessageBox.Show("Error parsing duration");
                    txtDuration.Focus();
                }
                if (!double.TryParse(txtInterestRate.Text, out  annualRate))
                {
                    System.Windows.Forms.MessageBox.Show("Error parsing interest rate");
                    txtInterestRate.Focus();
                }

                DateTime parsedDate = datePicker.SelectedDate.Value;

                //If user entered whole number as interest rate, divide it by 100
                if (annualRate >= 1)
                {
                    annualRate /= 100;
                    txtInterestRate.Text = annualRate.ToString();
                }
                double monthlyPayment = calculateMonthlyPayment(principal, numberOfPayments, annualRate);
                double interestPaid = 0.0;
                double principalPaid = 0.0;
                double newBalance = 0.0;

                showPayment.Text = monthlyPayment.ToString();
            
            // Is this a new loan or an update of previous submission?
            if (loanInfo is null)
            {
                LoanInfo loanInfo = new LoanInfo(loanNo, principal, numberOfPayments, annualRate, parsedDate);
            }
            else
            {
                loanInfo.LoanNumber = loanNo;
                loanInfo.Amount = principal;
                loanInfo.Duration = numberOfPayments;
                loanInfo.InterestRate = annualRate;
                loanInfo.BeginDate = parsedDate;
                theList.Clear();                
            }
            
                showAmount.Text = loanInfo.Amount.ToString();
                showDuration.Text = loanInfo.Duration.ToString();
                showRate.Text = loanInfo.InterestRate.ToString();
                showDate.Text = loanInfo.BeginDate.ToString("MM/dd/yyyy");
                showEndDate.Text = loanInfo.EndDate.ToString("MM/dd/yyyy");
                txtEndDate.Text = loanInfo.EndDate.ToString("MM/dd/yyyy");

                for (int counter = 1; counter <= numberOfPayments; counter++)
                {
                    interestPaid = Math.Round((principal * (annualRate / 12)), 2, MidpointRounding.ToEven);
                    principalPaid = Math.Round((monthlyPayment - interestPaid), 2, MidpointRounding.ToEven);
                    newBalance = Math.Round((principal - principalPaid), 2, MidpointRounding.ToEven);

                    theList.Add(new LoanPayments(loanNo, counter, principal, monthlyPayment, interestPaid, principalPaid, newBalance, parsedDate.AddMonths(counter - 1)));

                    principal = newBalance;
                }
                dgSimple.ItemsSource = theList;
            
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            
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
                this.lstState.FontSize = fontDialog.Font.Size;
                this.txtName.FontFamily = (FontFamily)ffc.ConvertFromString(fontDialog.Font.Name);
                this.lstState.FontFamily = (FontFamily)ffc.ConvertFromString(fontDialog.Font.Name);

                if (fontDialog.Font.Bold)
                {
                    txtName.FontWeight = FontWeights.Bold;
                    lstState.FontWeight = FontWeights.Bold;
                }
                else
                {
                    txtName.FontWeight = FontWeights.Normal;
                    lstState.FontWeight = FontWeights.Normal;
                }

                if (fontDialog.Font.Italic)
                {
                    txtName.FontStyle = FontStyles.Italic;
                    lstState.FontStyle = FontStyles.Italic;
                }
                else
                {
                    txtName.FontStyle = FontStyles.Normal;
                    lstState.FontStyle = FontStyles.Normal;
                }
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

        private void PrintForm_Click(object sender, RoutedEventArgs e)
        {                  
            Reciept newWindow = new Reciept();
            newWindow.Show();
        }
    }
}
