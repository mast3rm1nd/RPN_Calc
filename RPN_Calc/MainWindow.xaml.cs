using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MathText;

namespace RPN_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                customCulture.NumberFormat.NumberDecimalSeparator = ".";

                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

                double result = 0.0;
                var rpn = new ReversePolishNotation();
                rpn.Parse(Expression_textBox.Text.Replace(',', '.'));
                result = rpn.Evaluate();

                var output = new StringBuilder();

                output.AppendFormat("Original:   {0}", rpn.OriginalExpression + Environment.NewLine);
                output.AppendFormat("Transition: {0}", rpn.TransitionExpression + Environment.NewLine);
                output.AppendFormat("Postfix:    {0}", rpn.PostfixExpression + Environment.NewLine);
                output.AppendFormat("Result:     {0}", result);

                Results_textBox.Text = output.ToString();
            }
            catch (Exception ex)
            {
                Results_textBox.Text = ex.Message;
            }
        }
    }
}
