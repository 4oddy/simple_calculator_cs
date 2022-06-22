using System.Data;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public char[] operation_symb = new char[] { '+', '-', '÷', '×' };

        DataTable dt = new DataTable();

        public Calculator()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            
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
            if (OutputResult.Text.Length == 0)
            {
                OutputResult.Text = "0";
            }
        }
        private bool IsDigit(string str)
        {
            bool isDigit = double.TryParse(str, out _);
            return isDigit;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            OutputResult.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string expression = OutputResult.Text.Replace('×', '*').Replace('÷', '/').Replace(',', '.');

            object result = CalculateExpression(expression);

            OutputResult.Text = result.ToString();
        }
        private object CalculateExpression(string expression)
        {
            try
            {
                object result = dt.Compute(expression, null);
                return result;
            }
            catch
            {
                return 0;
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
