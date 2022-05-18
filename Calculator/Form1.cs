using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public char[] operation_symb = new char[] { '+', '-', '÷', '×' };
        public Calculator()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            CalculateExpression("0 + 0");
            
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button pressed_button = (Button)sender;

            if (OutputResult.Text == "0" && IsDigit(pressed_button.Text))
            {
                OutputResult.Text = "";
            }
            if (OutputResult.Text.Length > 0 && operation_symb.Contains(OutputResult.Text[^1]))
            {
                if (IsDigit(pressed_button.Text))
                {
                    OutputResult.Text += pressed_button.Text;
                }
            }
            else
            {
                OutputResult.Text += pressed_button.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OutputResult.Text != "0")
            {
                string result = OutputResult.Text.Substring(0, OutputResult.Text.Length-1);
                OutputResult.Text = result;
            }
            else if (OutputResult.Text.Length == 0)
            {
                OutputResult.Text = "0";
            }
        }
        private bool IsDigit(string str)
        {
            double num;
            bool isDigit = double.TryParse(str, out num);
            return isDigit;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            OutputResult.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string expression = OutputResult.Text.Replace('×', '*').Replace('÷', '/').Replace(',', '.');

            double result = CalculateExpression(expression);

            OutputResult.Text = result.ToString();
        }
        private double CalculateExpression(string expression)
        {
            try
            {
                return CSharpScript.EvaluateAsync<double>(expression).Result;
            }
            catch
            {
                return 0.0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OutputResult.Text = Convert.ToString(Math.Pow(Convert.ToDouble(OutputResult.Text), 2));
            }
            catch
            {
                OutputResult.Text = OutputResult.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OutputResult.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(OutputResult.Text)));
            }
            catch
            {
                OutputResult.Text = OutputResult.Text;
            }
        }
    }
}
