using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            double a;
            double b;
            double bHatch;
            double c;
            double d;
            double step;
            // забираем из формы значения
            n = Convert.ToInt32(textBox_n.Text);
            a = Convert.ToDouble(textBox_a.Text);
            b = Convert.ToDouble(textBox_b.Text);
            c = Convert.ToDouble(textBox_c.Text);
            d = Convert.ToDouble(textBox_d.Text);
            bHatch = Convert.ToDouble(textBox_bHatch.Text);

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    
                    step = (a + b) / n;
                    for (double x = a; x <= b; x += step)
                    {
                        // наполняем график точками
                        chart1.Series[0].Points.AddXY(x, graphicNumberOne(a, b, x)); 
                    }
                    break;
                case 1:
                    step = (b + c) / n;
                    for (double x = a; x <= c + a; x += step)
                    {
                        chart1.Series[0].Points.AddXY(x, graphicNumberTwo(a,b,c,x));
                    }
                    break;
                case 2:
                    step = (a + b) / n;
                    for (double x = a; x <= b; x += step)
                    {
                        chart1.Series[0].Points.AddXY(x, graphicNumberThree(a, b, c, x));
                    }
                    break;
                case 3:
                    step = ((c+1/a) + c) / n;
                    for (double x = 0; x <= ((c + 1 / a) + c); x += step)
                    {
                        chart1.Series[0].Points.AddXY(x, graphicNumberFour(a, b, c, x));
                    }
                    break;
                case 4:
                    step = (a + b) / n;
                    for (double x = a; x <= b; x += step)
                    {
                        chart1.Series[0].Points.AddXY(x, graphicNumberFive(a, b, c, d, x));
                    }
                    break;
                case 5:
                    step = (a-3*b + a + 3*b) / n;
                    for (double x = a - 3 * b; x <= a + 3 * b; x += step)
                    {
                        chart1.Series[0].Points.AddXY(x, graphicNumberSix(a, b, x));
                    }
                    break;
                case 6:
                    step = 2*b / n;
                    for (double x = 0; x <= 2*b; x += step)
                    {
                        chart1.Series[0].Points.AddXY(x, graphicNumberSeven(a, b, x));
                    }
                    break;
                case 7:
                    step = 2 * a / n;
                    for (double x = 0; x <= 2 * a; x += step)
                    {
                        chart1.Series[0].Points.AddXY(x, graphicNumberSix(a, b, x));
                        chart1.Series[1].Points.AddXY(x, graphicNumberSix(a, bHatch, x));
                    }
                    break;
                default:
                    
                    break;
            }
            
        }

        private double graphicNumberOne(double A, double B, double x)
        {
            double a;
            double b;
            // значение функции
            double fx = 0;
                a = A;
                b = B;
            
                if (x <= a)
                {
                    fx = 0;                  
                }
                if (a <= x && x <= (a + b) / 2)
                {
                    fx = (2 * Math.Pow((x - a), 2)) / Math.Pow((b - a), 2);       
                }
                if ((a + b) / 2 <= x && x <= b)
                {
                   fx = 1 - ((2*Math.Pow((x-b),2))/(Math.Pow((b-a),2)));                  
                }
                if (x >= b)
                {
                    fx = 1; 
                }
                return fx;

        }
        private double graphicNumberTwo(double A, double B, double C, double x)
        {
            double a = A;
            double b = B;
            double c = C;
            double fx = 0;
                if (a < x && x < b)
                {
                    fx = graphicNumberOne(a,b,x);
                }
                if (b <= x && x <= b*c)
                {
                    fx = 1;
                }
                if (c < x && x < c + a)
                {
                    fx = 1 - graphicNumberOne(c, c + b - a, x);
                }
                if (x >= c + a)
                {
                fx = 0;                  
                }
            return fx;
        }
        private double graphicNumberThree(double A, double B, double C, double x)
        {
            double a = A;
            double b = B;
            double c = C;
            double fx = 0;
            if (x <= a)
            {
                fx = 0;
            }
            if (a <= x && x <= c)
            {
                fx = (x - a) / (c - a);
            }
            if (c <= x && x <= b)
            {
                fx = (b - x) / (b - c);
            }
            if (x >= b)
            {
                fx = 0;
            }
            return fx;
        }
        private double graphicNumberFour(double A, double B, double C, double x)
        {
            double a = A;
            double b = B;
            double c = C;
            double fx = 0;
            if (x < c)
            {
                fx = 1;
            }
            if (x > c)
            {
                fx = Math.Pow((1 + a * (Math.Pow((x - c), b))), -1);
            }
            return fx;
        }
        private double graphicNumberFive(double A, double B, double C, double D, double x)
        {
            double a = A;
            double b = B;
            double c = C;
            double d = D;
            double fx = 0;
            if (x <= a)
            {
                fx = 0;
            }
            if (a < x && x < c)
            {
                fx = (x - a) / (c - a);
            }
            if (a == x && x == c)
            {
                fx = 1;
            }
            if (d <= x && x <= b)
            {
                fx = (b - x) / (b - d);
            }
            if (x >= b)
            {
                fx = 0;
            }
            return fx;
        }
        private double graphicNumberSix(double A, double B, double x)
        {
            double a = A;
            double b = B;
            double fx = 0;
            if (x < a - 3 * b)
            {
                fx = 0;
            }
            if (a-3*b < x && x <a + 3 * b)
            {
                fx = Math.Exp(-1 * (Math.Pow((x - a), 2)) / 2 * Math.Pow(b, 2));
            }
            if (x > a + 3 * b)
            {
                fx = 0;
            }
            return fx;
        }
        private double graphicNumberSeven(double A, double B, double x)
        {
            double a = A;
            double b = B;
            return Math.Pow(1 + Math.Exp(-1*(a * (x - b))), -1);
        }
            private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
