using System;
using System.Windows.Forms;

namespace SimpleCalculatorGUI
{
    public class CalculatorForm : Form
    {
        private TextBox display;
        private string currentOperator;
        private double firstNumber;

        public CalculatorForm()
        {
            // Window setup
            this.Text = "Simple Calculator";
            this.Width = 300;
            this.Height = 400;

            // Display textbox
            display = new TextBox();
            display.ReadOnly = true;
            display.Dock = DockStyle.Top;
            display.Font = new System.Drawing.Font("Arial", 20);
            this.Controls.Add(display);

            // Buttons panel
            var panel = new TableLayoutPanel();
            panel.RowCount = 4;
            panel.ColumnCount = 4;
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);

            string[] buttons = {
                "7","8","9","/",
                "4","5","6","*",
                "1","2","3","-",
                "0","C","=","+"
            };

            foreach (var text in buttons)
            {
                var btn = new Button();
                btn.Text = text;
                btn.Dock = DockStyle.Fill;
                btn.Font = new System.Drawing.Font("Arial", 16);
                btn.Click += Button_Click;
                panel.Controls.Add(btn);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn.Text == "C")
            {
                display.Text = "";
                firstNumber = 0;
                currentOperator = "";
            }
            else if (btn.Text == "=")
            {
                double secondNumber = double.Parse(display.Text);
                double result = 0;

                switch (currentOperator)
                {
                    case "+": result = firstNumber + secondNumber; break;
                    case "-": result = firstNumber - secondNumber; break;
                    case "*": result = firstNumber * secondNumber; break;
                    case "/": result = secondNumber != 0 ? firstNumber / secondNumber : 0; break;
                }

                display.Text = result.ToString();
                currentOperator = "";
            }
            else if ("+-*/".Contains(btn.Text))
            {
                firstNumber = double.Parse(display.Text);
                currentOperator = btn.Text;
                display.Text = "";
            }
            else
            {
                display.Text += btn.Text;
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new CalculatorForm());
        }
    }
}
