using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IntSysLaba3V2
{
    public partial class Form1 : Form
    {
        public void Off()
        {
            button1.Visible = false;
            button2.Visible = false;
        }
        // Экземпляры класса, представляющие из себя все вопросы и ответы
        public DNode QPredohran = new DNode("Сгорел ли предохранитель?", 90); // 90 - фактор уверенности, показывающий, что пользователь ответит "Да" в приветственном меню и окажется на этим вопросе.
        public DNode QKabel = new DNode("Кабель питания поврежден?", 50); // с вероятностью 50% не сгорел предохранитель и пользователь оказался на этом вопросе.
        public DNode QRazbiraetes = new DNode("Вы разбираетесь в радиоэлектронике?", 40);
        public DNode QRazbiraetesVTele = new DNode("Вы разбираетесь в радиоэлектронике телевизоров?", 80);
        public DNode APredohran = new DNode("Тогда выполните замену предохранителя.", 50 );
        public DNode AKabel = new DNode("Тогда выполните замену кабеля питания." , 60);
        public DNode ARazbiraetes = new DNode("Тогда выполните ремонт телевизора самостоятельно.", 20);
        public DNode ANotRazbiraetes = new DNode("Тогда вызовите мастера.", 80);
        public DNode CurrentNode = new DNode("");  //узел, который будем менять в зависимости от ответа
        public DNode NotCurrentNode = new DNode(""); // тупиковый узел 
        public Form1()
        {
            InitializeComponent();
            //Устанавливается порядок узлов в дереве.
            CurrentNode.Mesto(null, QPredohran, NotCurrentNode);
            QPredohran.Mesto(QPredohran, APredohran, QKabel);
            QKabel.Mesto(QKabel, AKabel, QRazbiraetes);
            QRazbiraetes.Mesto(QRazbiraetes, QRazbiraetesVTele, ANotRazbiraetes);
            QRazbiraetesVTele.Mesto(QRazbiraetesVTele, ARazbiraetes, ANotRazbiraetes);
        }
        private void button1_Click(object sender, EventArgs e)     // лево да
        {
            CurrentNode = CurrentNode.Yes(CurrentNode, label1);  // Метод принимает currentnode - сдвигает его влево и выводит текст на экран, 
            button1.Text = "Да";                                // currentnode обновляется. label принимается для обновления на нем текста.
            if (CurrentNode.Left == null)                      // если вопросов больше не будет, то кнопки убираются через if.
            {
                this.Off();
                label3.Text += "С помощью первого метода (И) и первого (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv1_ORv1(CurrentNode, label4)) + "%" + "\n";
                label3.Text += "С помощью первого метода (и) и второго (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv1_ORv2(CurrentNode)) + "%" + "\n";
                label3.Text += "С помощью первого метода (и) и третьего (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv1_ORv3(CurrentNode)) + "%" + "\n";
                label3.Text += "С помощью второго метода (и) и первого (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv2_ORv1(CurrentNode)) + "%" + " \n";
                label3.Text += "С помощью второго метода (и) и второго (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv2_ORv2(CurrentNode)) + "%" + " \n";
                label3.Text += "С помощью второго метода (и) и третьего (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv2_ORv3(CurrentNode)) + "%" + " \n";
                label3.Text += "C помощью тертьего метода (и) и первого (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv3_ORv1(CurrentNode) + "%" + "\n");
                label3.Text += "C помощью тертьего метода (и) и второго (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv3_ORv2(CurrentNode)) + "%" + "\n";
                label3.Text += "C помощью тертьего метода (и) и третьего (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv3_ORv3(CurrentNode)) + "%" + "\n";
            }
        }
        private void button2_Click(object sender, EventArgs e) // право нет
        {
            CurrentNode = CurrentNode.No(CurrentNode, label1);
            if (CurrentNode.Data == "")
            {
                this.Close();
            }
            if (CurrentNode.Left == null)
            {
                this.Off();
                label3.Text += "С помощью первого метода (И) и первого (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv1_ORv1(CurrentNode, label4)) + "%" + "\n";
                label3.Text += "С помощью первого метода (и) и второго (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv1_ORv2(CurrentNode)) + "%" + "\n";
                label3.Text += "С помощью первого метода (и) и третьего (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv1_ORv3(CurrentNode)) + "%" + "\n";
                label3.Text += "С помощью второго метода (и) и первого (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv2_ORv1(CurrentNode)) + "%" + " \n";
                label3.Text += "С помощью второго метода (и) и второго (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv2_ORv2(CurrentNode)) + "%" + " \n";
                label3.Text += "С помощью второго метода (и) и третьего (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv2_ORv3(CurrentNode)) + "%" + " \n";
                label3.Text += "C помощью тертьего метода (и) и первого (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv3_ORv1(CurrentNode)) + "%" + "\n";
                label3.Text += "C помощью тертьего метода (и) и второго (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv3_ORv2(CurrentNode)) + "%" + "\n";
                label3.Text += "C помощью тертьего метода (и) и третьего (или) : " + Convert.ToString(CurrentNode.AnalitCF_ANDv3_ORv3(CurrentNode)) + "%" + "\n";
            }
        }
    }
    public class DNode
    {
        public string Data { get; set; }
        public DNode Left { get; set; }
        public DNode Right { get; set; }
        public DNode Parent { get; set; }
        public DNode Parent2 { get; set; }
        public int CF { get; set; }
        public DNode(string data, int cf)
        {
            Data = data;
            CF = cf;
        }
        public DNode(string data)
        {
            Data = data;
        }
        public void Mesto(DNode parent, DNode left, DNode right)
        {
            Left = left;
            Right = right;
            if (Left.Parent != null)
            {
                Left.Parent2 = parent;
            }
            else
            {
                Left.Parent = parent;
            }
            if (Right.Parent != null)
            {
                Right.Parent2 = parent;
            }
            else
            {
                Right.Parent = parent;
            }
        }
        public DNode Yes(DNode CurrentNode, System.Windows.Forms.Label label1)
        {
            if (CurrentNode.Left != null)
            {
                CurrentNode = CurrentNode.Left;
                label1.Text = CurrentNode.Data;
                return CurrentNode;
            }
            else
            {
                return CurrentNode;
            }
        }
        public DNode No(DNode CurrentNode, System.Windows.Forms.Label label1)
        {
            if (CurrentNode.Right != null)
            {
                CurrentNode = CurrentNode.Right;
                label1.Text = CurrentNode.Data;
                return CurrentNode;
            }
            else
            {
                return CurrentNode;
            }
        }
        public int MinZnach(List<int> ints) 
        {
            int min;
            int dlinna = ints.Count;
            if (dlinna > 1)
            {
                int minValue = ints[0];
                for (int i = 0; i<dlinna; i++)
                {
                    if (ints[i] < minValue)
                    {
                        minValue = ints[i];
                    }
                }
                min = minValue;
                return min;
            }
            else if (dlinna == 1)
            {
                return ints.First();
            }
            else
            {
                throw new Exception("Родителей нет");
            }
        }  
        public int AnalitCF_ANDv1_ORv1(DNode dNode, System.Windows.Forms.Label label)
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;           
                }
            }
            dNode = Clone; 
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                label.Text += "По 1 ветке: ";
                foreach (int q in CFParentsList)
                {
                    label.Text += Convert.ToString(q) + ", ";
                }
                return MinZnach(CFParentsList);
            }
            else      // Если родителей 2
            {
                for (int i = 0; i <counterParents+1 ; i++ )
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents+1; k < (counterParents + counterParents2); k++)
                {
                    while (j<0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                        dNode = dNode.Parent;
                        CFParents2List.Add(dNode.CF);
                }
            label.Text += "По первой ветке: ";
            foreach (int q in CFParentsList)
            {
               label.Text += Convert.ToString(q) + ", ";
            }
            label.Text += "А по второй ветке: ";
            foreach (int w in CFParents2List)
            {
               label.Text += Convert.ToString(w) + ", ";
            }
            return Math.Max(MinZnach(CFParents2List), MinZnach(CFParentsList));
            }
        }
        public int YmnozitIPodelitNa100(List<int> ints)
        {
            int multiplicate = 1;
            int counter = 0;
            foreach (int i in ints)
            {
                multiplicate *= i;
                counter++;
            }
            for (int i =0; i< counter-1; i++)  // делим на 100 каждую пару, -1 - чтобы при 2х числах не делить 2 раза на 100
            {
                multiplicate /= 100;
            }
            return multiplicate;
        }
        public int AnalitCF_ANDv2_ORv1(DNode dNode)  
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            dNode = Clone; 
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                return YmnozitIPodelitNa100(CFParentsList);
            }
            else      // Если родителей 2
            {
                for (int i = 0; i < counterParents + 1; i++)
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents + 1; k < (counterParents + counterParents2); k++)
                {
                    while (j < 0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                    dNode = dNode.Parent;
                    CFParents2List.Add(dNode.CF);
                }
            return  Math.Max(YmnozitIPodelitNa100(CFParents2List) , YmnozitIPodelitNa100(CFParentsList));
            }
        }
        public int AnalitCF_ANDv3_ORv1(DNode dNode)
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            dNode = Clone; 
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
            }
            else      // Если родителей 2
            {
                for (int i = 0; i < counterParents + 1; i++)
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents + 1; k < (counterParents + counterParents2); k++)
                {
                    while (j < 0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                    dNode = dNode.Parent;
                    CFParents2List.Add(dNode.CF);
                }
            }
            dNode = Clone;
            if (dNode.Parent2 == null)
            {
            return ((MinZnach(CFParentsList) + AnalitCF_ANDv2_ORv1(dNode)) / 2) ;
            }
            else
            {
                return Math.Max(((MinZnach(CFParentsList) + (YmnozitIPodelitNa100(CFParentsList)))/ 2), (MinZnach(CFParents2List) + (YmnozitIPodelitNa100(CFParents2List)))/ 2);
            }
        }
        public int AnalitCF_ANDv1_ORv2 (DNode dNode)
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            dNode = Clone; 
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
             
                return MinZnach(CFParentsList);
            }
            else      // Если родителей 2
            {
                for (int i = 0; i < counterParents + 1; i++)
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents + 1; k < (counterParents + counterParents2); k++)
                {
                    while (j < 0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                    dNode = dNode.Parent;
                    CFParents2List.Add(dNode.CF);
                }
                return (MinZnach(CFParentsList) + MinZnach(CFParents2List) - ((MinZnach(CFParentsList) * MinZnach(CFParents2List)) / 100));
            }
        }
        public int AnalitCF_ANDv1_ORv3(DNode dNode)
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            dNode = Clone; 
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }

                return MinZnach(CFParentsList);
            }
            else      // Если родителей 2
            {
                for (int i = 0; i < counterParents + 1; i++)
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents + 1; k < (counterParents + counterParents2); k++)
                {
                    while (j < 0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                    dNode = dNode.Parent;
                    CFParents2List.Add(dNode.CF);
                }
                return ((Math.Max(MinZnach(CFParentsList), MinZnach(CFParents2List)) + AnalitCF_ANDv1_ORv2(dNode))/2) ;
            }
        }
        public int AnalitCF_ANDv2_ORv2(DNode dNode)
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            dNode = Clone; 
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                return YmnozitIPodelitNa100(CFParentsList);
            }
            else      // Если родителей 2
            {
                for (int i = 0; i < counterParents + 1; i++)
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents + 1; k < (counterParents + counterParents2); k++)
                {
                    while (j < 0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                    dNode = dNode.Parent;
                    CFParents2List.Add(dNode.CF);
                }
                return YmnozitIPodelitNa100(CFParentsList) + YmnozitIPodelitNa100(CFParents2List) - ((YmnozitIPodelitNa100(CFParentsList) * YmnozitIPodelitNa100(CFParents2List)) / 100) ;
            }
        }
        public int AnalitCF_ANDv2_ORv3(DNode dNode)
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            dNode = Clone;
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }

                return YmnozitIPodelitNa100(CFParentsList);
            }
            else      // Если родителей 2
            {
                for (int i = 0; i < counterParents + 1; i++)
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents + 1; k < (counterParents + counterParents2); k++)
                {
                    while (j < 0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                    dNode = dNode.Parent;
                    CFParents2List.Add(dNode.CF);
                }
                int A = YmnozitIPodelitNa100(CFParentsList);
                int B = YmnozitIPodelitNa100(CFParents2List);
                return (Math.Max(A, B) + (A + B - A * B / 100)) / 2;
            }
        }
        public int AnalitCF_ANDv3_ORv2(DNode dNode)
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            dNode = Clone; 
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }

                return (MinZnach(CFParentsList) +  YmnozitIPodelitNa100(CFParentsList))/2;
            }
            else      // Если родителей 2
            {
                for (int i = 0; i < counterParents + 1; i++)
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents + 1; k < (counterParents + counterParents2); k++)
                {
                    while (j < 0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                    dNode = dNode.Parent;
                    CFParents2List.Add(dNode.CF);
                }
                int A = ((MinZnach(CFParentsList) + YmnozitIPodelitNa100(CFParentsList)) / 2);
                int B = ((MinZnach(CFParents2List) + YmnozitIPodelitNa100(CFParents2List)) / 2);
                return (A + B - A* B /100);
            }
        }
        public int AnalitCF_ANDv3_ORv3(DNode dNode)
        {
            int counterParents = 0;        // для подсчета родителей
            int counterParents2 = 0;    // для подсчета родителей по 2й ветке родителей
            DNode Clone = dNode;        // клон потомка, т.к. потомка меняем для перебора родителей.
            if (dNode.Parent2 == null)
            {
                while (dNode.Parent != null)  // Считаем сколько родителей у потомка, в случае если родитель всегда 1. 
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            else
            {
                int k = 0;
                while (dNode.Parent != null)  // считаем родителей потомка по пути второго родителя.
                {
                    while (k < 1)
                    {
                        dNode = dNode.Parent2;
                        counterParents2++;
                        k++;
                    }
                    dNode = dNode.Parent;
                    counterParents2++;
                }
                dNode = Clone;
                while (dNode.Parent != null)    // по пути первого родителя
                {
                    dNode = dNode.Parent;
                    counterParents++;
                }
            }
            dNode = Clone;
            List<int> CFParentsList = new List<int>();   //создаем лист со всеми факторами уверенности потомка и родителя по 1 ветке
            List<int> CFParents2List = new List<int>();  // лист с факторами уверенности родителей по 2й ветке
            if (dNode.Parent2 == null)  // Если родитель только 1
            {
                for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }

                return (MinZnach(CFParentsList) + YmnozitIPodelitNa100(CFParentsList)) / 2;
            }
            else      // Если родителей 2
            {
                for (int i = 0; i < counterParents + 1; i++)
                {
                    CFParentsList.Add(dNode.CF);
                    dNode = dNode.Parent;
                }
                dNode = Clone;
                int j = 0;
                for (int k = counterParents + 1; k < (counterParents + counterParents2); k++)
                {
                    while (j < 0)
                    {
                        dNode = dNode.Parent2;
                        CFParents2List.Add(dNode.CF);
                        j++;
                    }
                    dNode = dNode.Parent;
                    CFParents2List.Add(dNode.CF);
                }
                int A = ((MinZnach(CFParentsList) + YmnozitIPodelitNa100(CFParentsList)) / 2);
                int B = ((MinZnach(CFParents2List) + YmnozitIPodelitNa100(CFParents2List)) / 2);
                return (Math.Max(A,B) + (A+B-A*B/100))/2;
            }
        }
    }
}