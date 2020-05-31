using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Double num, temp, conv;
        string oper = "", other = "";
        bool OperasiAktif = false, CekTitik = false, CekHasil = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void btnOper_Click(object sender, EventArgs e)
        {
            CekTitik = false;
            Button btn = (Button)sender;

            if (OperasiAktif == false)
                btnHasil.PerformClick();

            oper = btn.Text;
            label1.Text = num + " " + oper + " ";
            OperasiAktif = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (OperasiAktif == true || CekHasil == true)
            {
                textBox1.Clear();
                CekHasil = false;
            }

            OperasiAktif = false;
            Button btn = (Button)sender;

            if (textBox1.Text == "0")
                textBox1.Clear();

            textBox1.Text += btn.Text;

            if (textBox1.Text != "0")
                label1.Text += btn.Text;
        }

        private void buttonTitik_Click(object sender, EventArgs e)
        {
            if (OperasiAktif)
                textBox1.Clear();

            OperasiAktif = false;
            Button btn = (Button)sender;

            if (textBox1.Text == "0")
                textBox1.Clear();

            if (CekTitik == false)
            {
                textBox1.Text += btn.Text;
                CekTitik = true;
            }
        }

        private void btnHasil_Click(object sender, EventArgs e)
        {
            switch (oper)
            {
                case "+":
                    textBox1.Text = (num + Double.Parse(textBox1.Text)).ToString();
                    break;

                case "-":
                    textBox1.Text = (num - Double.Parse(textBox1.Text)).ToString();
                    break;

                case "X":
                    textBox1.Text = (num * Double.Parse(textBox1.Text)).ToString();
                    break;

                case ":":
                    textBox1.Text = (num / Double.Parse(textBox1.Text)).ToString();
                    break;

                default:
                    break;
            }
            num = Double.Parse(textBox1.Text);
            label1.Text = "";
            oper = "";
            CekHasil = true;
        }

        private void buttonClr_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0";
            label1.Text = "";
            oper = "";
            num = 0;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            int text = textBox1.Text.Length;
            int lbl = label1.Text.Length;
            if (text != 1)
                textBox1.Text = textBox1.Text.Remove(text - 1);
            if (textBox1.Text != "0" && CekHasil != true)
                label1.Text = label1.Text.Remove(lbl - 1);
            if (text == 1 || textBox1.Text=="-" || CekHasil == true)
                textBox1.Text = "0";
        }

        private void buttonOther_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            other = button.Text;

            switch (other)
            {
                case "-/+":
                    temp = Double.Parse(textBox1.Text);
                    textBox1.Text = (temp * -1).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + textBox1.Text;
                    break;

                case "x²":
                    temp = Double.Parse(textBox1.Text);
                    textBox1.Text = (temp * temp).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + temp + "²";
                    break;

                case "¹/x":
                    temp = Double.Parse(textBox1.Text);
                    textBox1.Text = (1 / temp).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + "¹/" + temp;
                    break;

                case "%":
                    temp = Double.Parse(textBox1.Text);
                    textBox1.Text = (temp / 100).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + temp + "%";
                    break;

                case "√":
                    temp = Double.Parse(textBox1.Text);
                    textBox1.Text = Math.Sqrt(temp).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + "√" + temp;
                    break;

                case "|x|":
                    temp = Double.Parse(textBox1.Text);
                    if (temp < 0)
                        textBox1.Text = (temp*-1).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + "|" + temp + "|";
                    break;

                case "n!":
                    temp = Double.Parse(textBox1.Text);
                    double fact = 1;
                    for (Double i = 1; i <= temp; i++)
                    {
                        fact = fact * i;
                    }
                    textBox1.Text = fact.ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + temp + "!";
                    break;

                case "sin":
                    temp = Double.Parse(textBox1.Text);
                    conv = temp * (Math.PI) / 180;
                    textBox1.Text = Math.Sin(conv).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + "sin(" + temp + ")";
                    break;

                case "cos":
                    temp = Double.Parse(textBox1.Text);
                    conv = temp * (Math.PI) / 180;
                    textBox1.Text = Math.Cos(conv).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + "cos(" + temp + ")";
                    break;

                case "tan":
                    temp = Double.Parse(textBox1.Text);
                    conv = temp * (Math.PI) / 180;
                    textBox1.Text = Math.Tan(conv).ToString();
                    if (num == 0)
                        label1.Text = textBox1.Text;
                    else
                        label1.Text = num + " " + oper + " " + "tan(" + temp + ")";
                    break;

                default:
                    break;
            }
        }
    }
}