using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace BMICalc
{

    public partial class MainWindow : Window
    {
        public string targfile = "./bmi.xml";
        public class Customer
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string phoneNumber { get; set; }
            public int heightInches { get; set; }
            public int weightLbs { get; set; }
            public int custBMI { get; set; }
            public string statusTitle { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Part 1 (Clear, Exit)
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            xFirstNameBox.Text = "";
            xLastNameBox.Text = "";
            xPhoneBox.Text = "";
            xHeightInchesBox.Text = "";
            xWeightLbsBox.Text = "";
            xBMIMessage.Text = "Message:";
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion


        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer customerTest = new Customer();
            customerTest.firstName = xFirstNameBox.Text;
            customerTest.lastName = xLastNameBox.Text;
            customerTest.phoneNumber = xPhoneBox.Text;
            int currWeight = 0;
            int currHeight = 0;
            Int32.TryParse(xWeightLbsBox.Text, out currWeight);
            Int32.TryParse(xHeightInchesBox.Text, out currHeight);
            customerTest.weightLbs = currWeight;
            customerTest.heightInches = currHeight;
            int bmi;
            string bmiString;

            string infoMsgCaption = "Info";
            MessageBoxResult infoMsgBox;
            if (customerTest.firstName == "" || customerTest.lastName == "" || customerTest.phoneNumber == "" || customerTest.heightInches == 0 || customerTest.weightLbs == 0)
            {
                string infoMsgString = "Error";
                infoMsgBox = MessageBox.Show(infoMsgString, infoMsgCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                bmi = 703 * customerTest.weightLbs / (customerTest.heightInches * customerTest.heightInches);
                customerTest.custBMI = bmi;
                string infoMsgString = "They are " + customerTest.firstName + " " + customerTest.lastName + ".Their # is " + customerTest.phoneNumber + ". They are " + customerTest.heightInches + " inches tall. They weigh " + customerTest.weightLbs + " pounds. Their BMI is " + customerTest.custBMI + ".";
                infoMsgBox = MessageBox.Show(infoMsgString, infoMsgCaption, MessageBoxButton.OK, MessageBoxImage.Information);
                xYourBMIResults.Text = Convert.ToString(bmi);
                if (!File.Exists(targfile))
                {
                    using (StreamWriter sw = File.CreateText(targfile))
                    {
                        sw.Write("<?xml version='1.0' encoding='utf-8'?>\n<Customers></Customers>");
                    }
                }
                if (bmi < 18.5)
                {
                    bmiString = "you are underweight.";
                    customerTest.statusTitle = "Underweight";
                    xBMIMessage.Text = bmiString;
                    string[] allLines = File.ReadAllLines(targfile);
                    if (allLines.Length > 0)
                    {
                        string lastLine = allLines.Last();
                        if (lastLine.Length >= 2)
                        {
                            lastLine = lastLine.Remove(lastLine.Length - 12);
                        }
                        allLines[allLines.Length - 1] = lastLine;
                    }

                    File.WriteAllLines(targfile, allLines);
                    using (StreamWriter sw = File.AppendText(targfile))
                    {
                        sw.Write("<Customer>\n<FirstName>" + customerTest.firstName + "</FirstName>\n<LastName>" + customerTest.lastName + "</LastName>\n<PhoneNumber>" + customerTest.phoneNumber + "</PhoneNumber>\n<HeightInches>" + customerTest.heightInches + "</HeightInches>\n<WeightPounds>" + customerTest.weightLbs + "</WeightPounds>\n<CustomerBMI>" + customerTest.custBMI + "</CustomerBMI>\n<Status>" + customerTest.statusTitle + "</Status>\n</Customer>\n</Customers>");
                    }
                }
                if (bmi < 24.9)
                {
                    bmiString = "normal body weight.";
                    customerTest.statusTitle = "Normal";
                    xBMIMessage.Text = bmiString;
                    string[] allLines = File.ReadAllLines(targfile);
                    if (allLines.Length > 0)
                    {
                        string lastLine = allLines.Last();
                        if (lastLine.Length >= 2)
                        {
                            lastLine = lastLine.Remove(lastLine.Length - 12);
                        }
                        allLines[allLines.Length - 1] = lastLine;
                    }

                    File.WriteAllLines(targfile, allLines);
                    using (StreamWriter sw = File.AppendText(targfile))
                    {
                        sw.Write("<Customer>\n<FirstName>" + customerTest.firstName + "</FirstName>\n<LastName>" + customerTest.lastName + "</LastName>\n<PhoneNumber>" + customerTest.phoneNumber + "</PhoneNumber>\n<HeightInches>" + customerTest.heightInches + "</HeightInches>\n<WeightPounds>" + customerTest.weightLbs + "</WeightPounds>\n<CustomerBMI>" + customerTest.custBMI + "</CustomerBMI>\n<Status>" + customerTest.statusTitle + "</Status>\n</Customer>\n</Customers>");
                    }
                }
                if (bmi < 29.9)
                {
                    bmiString = "you are overweight.";
                    customerTest.statusTitle = "Overweight";
                    xBMIMessage.Text = bmiString;
                    string[] allLines = File.ReadAllLines(targfile);
                    if (allLines.Length > 0)
                    {
                        string lastLine = allLines.Last();
                        if (lastLine.Length >= 2)
                        {
                            lastLine = lastLine.Remove(lastLine.Length - 12);
                        }
                        allLines[allLines.Length - 1] = lastLine;
                    }

                    File.WriteAllLines(targfile, allLines);
                    using (StreamWriter sw = File.AppendText(targfile))
                    {
                        sw.Write("<Customer>\n<FirstName>" + customerTest.firstName + "</FirstName>\n<LastName>" + customerTest.lastName + "</LastName>\n<PhoneNumber>" + customerTest.phoneNumber + "</PhoneNumber>\n<HeightInches>" + customerTest.heightInches + "</HeightInches>\n<WeightPounds>" + customerTest.weightLbs + "</WeightPounds>\n<CustomerBMI>" + customerTest.custBMI + "</CustomerBMI>\n<Status>" + customerTest.statusTitle + "</Status>\n</Customer>\n</Customers>");
                    }
                }
                else
                {
                    bmiString = "you are obese.";
                    customerTest.statusTitle = "Obese";
                    xBMIMessage.Text = bmiString;
                    string[] allLines = File.ReadAllLines(targfile);
                    if (allLines.Length > 0)
                    {
                        string lastLine = allLines.Last();
                        if (lastLine.Length >= 2)
                        {
                            lastLine = lastLine.Remove(lastLine.Length - 12);
                        }
                        allLines[allLines.Length - 1] = lastLine;
                    }

                    File.WriteAllLines(targfile, allLines);
                    using (StreamWriter sw = File.AppendText(targfile))
                    {
                        sw.Write("<Customer>\n<FirstName>" + customerTest.firstName + "</FirstName>\n<LastName>" + customerTest.lastName + "</LastName>\n<PhoneNumber>" + customerTest.phoneNumber + "</PhoneNumber>\n<HeightInches>" + customerTest.heightInches + "</HeightInches>\n<WeightPounds>" + customerTest.weightLbs + "</WeightPounds>\n<CustomerBMI>" + customerTest.custBMI + "</CustomerBMI>\n<Status>" + customerTest.statusTitle + "</Status>\n</Customer>\n</Customers>");
                    }
                }
                OnLoadStats();
            }
        }
        private void OnLoadStats()
        {
            if (!File.Exists(targfile))
            {
                using (StreamWriter sw = File.CreateText(targfile))
                {
                    sw.Write("<?xml version='1.0' encoding='utf-8'?>\n<Customers></Customers>");
                }
            }
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(@targfile);
                xDataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            }
            catch
            {
            }
        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            OnLoadStats();
        }
    }
}