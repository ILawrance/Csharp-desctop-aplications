using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntSys_Laba_1
{
    public partial class Form1 : Form
    {
        public int etap = 0; //буду вести счет этапов, этап увеличивается после каждого уточняющего вопроса
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)    //соответсвует ответа "Да"
        { 
            switch (etap)  // в зависмости от этапа будет вызываться соответсвующий вопрос
            {             // Qest везде ниже это разные вопросы, а Ans это ответы на них. номер кейса и номер ответа совпадают.
                case 0:
                    etap = Sobytiya.Qest1(richTextBox1, etap);    
                    break;
                case 1:
                    Sobytiya.Ans1(richTextBox1);
                    break;
                case 2:
                    etap = Sobytiya.Qest3(richTextBox1, etap);
                    break;
                case 3:
                    Sobytiya.Ans3x1(richTextBox1);
                    break;
            }
        }
        private void button2_Click(object sender, EventArgs e) // Соответсвует ответу "Нет" 
        {
            switch (etap)
            {
                case 0:
                    this.Close(); 
                    break;
                case 1:
                    etap = Sobytiya.Qest2(richTextBox1, etap);
                    break;
                case 2:
                    Sobytiya.Ans2(richTextBox1);
                    break;
                case 3:
                    Sobytiya.Ans3(richTextBox1);
                    break;
            }
        }
    }
    public static class Sobytiya // класс, в котором храняться вопросы и ответы
    {
        public static int Qest1(RichTextBox richTextBox, int etap)
        {
            richTextBox.Text = "Сгорел ли предохранитель?";
            return ++etap;
        }
        public static int Qest2(RichTextBox richTextBox, int etap)
        {
            richTextBox.Text = "Кабель питания целый?";
            return ++etap;
        }
        public static int Qest3(RichTextBox richTextBox, int etap)
        {
            richTextBox.Text = "Вы разбираетесь в радиоэлектронике?";
            return ++etap;
        }
        public static void Ans1(RichTextBox richTextBox)
        {
            richTextBox.Text = "Тогда выполните замену предохранителя.";
        }
        public static void Ans2(RichTextBox richTextBox)
        {
            richTextBox.Text = "Тогда выполните замену кабеля питания.";
        }
        public static void Ans3(RichTextBox richTextBox)
        {
            richTextBox.Text = "Тогда вызовите мастера.";
        }
        public static void Ans3x1(RichTextBox richTextBox)
        {
            richTextBox.Text = "Тогда выполните ремонт телевизора самостоятельно.";
        }
    }
}
