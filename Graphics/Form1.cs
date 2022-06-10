using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics
{
    public partial class Form1 : Form
    {
        private double a, b, c, x, y, h, left_x, right_x, selected_x;

        private void chart_Click(object sender, EventArgs e)
        {

        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            
        }

        private object[] _graphics;

        public Form1()
        {
            _graphics = (new object[] {
                "y = x * a + b",
                "y = a * sin(x * b) + c",
                "y = a * cos(x * b + c)",
                "y = a * tg(x * b) + c",
                "y = a * ctg(x * b + c)",
                "y = b * x^a",
                "y = a^(x + b)",
                "y = ((sin(x) + a * x)/((x – (x)1/2) + 1))b/x"
            });
            
            
            InitializeComponent();
            comboBox1.Items.AddRange(_graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите график");
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели начало отрезка");
            }
            else
            { 
                try { left_x = Convert.ToInt32(textBox1.Text); }
                catch { MessageBox.Show("Введите число а не букву!"); }
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Вы не ввели конец отрезка");
            }
            else
            {
                try { right_x = Convert.ToInt32(textBox2.Text); }
                catch { MessageBox.Show("Введите число а не букву!"); }
            }
            x = left_x;
            h = 0.1;
            if (textBox3.Text != "")
            {
                selected_x = Convert.ToInt32(textBox3.Text);
            }
            else
            {
                selected_x = 100000000000000000;
            }
            
            try
            {
                a = Convert.ToInt32(textBoxA.Text);
                b = Convert.ToInt32(textBoxB.Text);
            } catch 
            {
                MessageBox.Show("Введите число, а не букву");
            }

            

            this.chart.Series[0].Points.Clear();
            this.chart.Series[1].Points.Clear();
            while (x <= right_x)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    y = x * a + b;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    try
                    {
                        c = Convert.ToInt32(textBoxC.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Введите число, а не букву");
                        break;
                    }
                    y = a * Math.Sin(x * b) + c;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    try
                    {
                        c = Convert.ToInt32(textBoxC.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Введите число, а не букву");
                        break;
                    }
                    y = a * Math.Cos(x * b + c);
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    try
                    {
                        c = Convert.ToInt32(textBoxC.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Введите число, а не букву");
                        break;
                    }
                    y = a * Math.Tan(x * b) + c;
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    try
                    {
                        c = Convert.ToInt32(textBoxC.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Введите число, а не букву");
                        break;
                    }
                    y = ((a * (1 / (Math.Tan(x*b+c)))));
                }
                else if (comboBox1.SelectedIndex == 5)
                {
                    y = b * Math.Pow(x, a);
                }
                else if (comboBox1.SelectedIndex == 6)
                {
                    y = Math.Pow(a, x + b);
                }
                else if (comboBox1.SelectedIndex == 7)
                {
                    y = Math.Pow(((Math.Sin(x) + a * x)/((x-Math.Pow(x, 1/2)) + 1)), b/x);
                }
                if (Math.Round(x, 3) == selected_x)
                {
                    this.chart.Series[1].Points.AddXY(x, y);
                }
                else
                {
                    this.chart.Series[0].Points.AddXY(x, y);
                }
                
                
                x += h;
                Console.WriteLine(x);
            }
            
            Console.WriteLine(_graphics[0]);
            
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
