using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_3_Pochinen
{
    public partial class Form1 : Form
    {
        Pryamoygolnik Prglnk1 = new Pryamoygolnik();
        Pryamoygolnik Prglnk2 = new Pryamoygolnik();
        Pryamoygolnik Prglnk3 = new Pryamoygolnik();
        Pryamoygolnik Prglnk4 = new Pryamoygolnik(8, 8);
        public int SwitchedId = 0;
        public Form1()
        {
            InitializeComponent();
        }
        double dlina;
        double shirina;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    textBox1.Text = "Error. Write all numbers";
                    textBox2.Text = "Errpr. Write all numbers";
                }
                else
                {
                    dlina = Convert.ToDouble(textBox1.Text);
                    shirina = Convert.ToDouble(textBox2.Text);
                    Prglnk1.SetDlina(dlina);
                    Prglnk1.SetShirina(shirina);
                }
            }
            else if (radioButton2.Checked)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    textBox1.Text = "Error. Write all numbers";
                    textBox2.Text = "Errpr. Write all numbers";
                }
                else
                {
                    dlina = Convert.ToDouble(textBox1.Text);
                    shirina = Convert.ToDouble(textBox2.Text);
                    Prglnk2.SetDlina(dlina);
                    Prglnk2.SetShirina(shirina);
                }

            }
            else if (radioButton3.Checked)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    textBox1.Text = "Error. Write all numbers";
                    textBox2.Text = "Errpr. Write all numbers";
                }
                else
                {
                    dlina = Convert.ToDouble(textBox1.Text);
                    shirina = Convert.ToDouble(textBox2.Text);
                    Prglnk3.SetDlina(dlina);
                    Prglnk3.SetShirina(shirina);
                }
            }
            else if (radioButton4.Checked)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    textBox1.Text = "Error. Write all numbers";
                    textBox2.Text = "Errpr. Write all numbers";
                }
                else
                {
                    dlina = Convert.ToDouble(textBox1.Text);
                    shirina = Convert.ToDouble(textBox2.Text);
                    Prglnk4.SetDlina(dlina);
                    Prglnk4.SetShirina(shirina);
                }
            }
            else
            {
                textBox1.Text = "Внимание! Выберите объект! ";
                textBox2.Text = "Внимание! Выберите объект! ";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = Convert.ToString(Prglnk1.Diagonal());
                textBox2.Text = Convert.ToString(Prglnk1.Squer());
            }
            else if (radioButton2.Checked)
            {
                textBox1.Text = Convert.ToString(Prglnk2.Diagonal());
                textBox2.Text = Convert.ToString(Prglnk2.Squer());
            }
            else if (radioButton3.Checked)
            {
                textBox1.Text = Convert.ToString(Prglnk3.Diagonal());
                textBox2.Text = Convert.ToString(Prglnk3.Squer());
            }
            else if (radioButton4.Checked)
            {
                textBox1.Text = Convert.ToString(Prglnk4.Diagonal());
                textBox2.Text = Convert.ToString(Prglnk4.Squer());
            }
            else
            {
                textBox1.Text = "Внимание! Объект не выбран! Выберите объект ";
                textBox2.Text = "Внимание! Объект не выбран! Выберите объект ";
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SwitchedId = 1;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SwitchedId = 2;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SwitchedId = 3;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SwitchedId = 4;
        }
    }
    class Pryamoygolnik
    {
        public Pryamoygolnik()
        {
        }
        public Pryamoygolnik(double dlin, double shir)
        {
            this.dlin = dlin;
            this.shir = shir;
        }
        private double dlin;
        private double shir;

        public void SetDlina(double dlin)
        {
            if (dlin < 0)
            {
                dlin = -dlin;
                if (dlin <= 7)
                {
                    this.dlin = 7;
                    return;
                }
                else if (dlin >= 10)
                {
                    this.dlin = 10;
                    return;
                }
                else
                {
                    this.dlin = dlin;
                    return;
                }
            }
            else if (dlin >= 0)
            {

                if (dlin <= 7)
                {
                    this.dlin = 7;
                    return;
                }
                if (dlin >= 10)
                {
                    this.dlin = 10;
                    return;
                }
                this.dlin = dlin;
                return;
            }
        }
        public void SetShirina(double shir)
        {
            if (shir < 0)
            {
                this.shir = -shir;
            }
            else
            {
                this.shir = shir;
            }
        }
        public double GetD()
        {
            return dlin;
        }
        public double GetS()
        {
            return shir;
        }
        public double Diagonal()
        {
            double ans = Math.Sqrt(dlin * dlin + shir * shir);
            return ans;
        }
        public double Squer()
        {
            double ans = dlin * shir;
            return ans;
        }
    }
}