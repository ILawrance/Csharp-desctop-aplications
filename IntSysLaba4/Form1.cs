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

namespace IntSysLaba4V1
{
    public partial class Form1 : Form
    {
        int counterPopitok = 0;
        List<int> HistoryCFs = new List<int>();
        public void ButtonsVisable(bool bl)
        {
            button1.Visible = bl;
            button2.Visible = bl;
        }
        /// <summary>
        /// 
        /// </summary>
        // Экземпляры класса, представляющие из себя все вопросы и ответы
        public DNode QDefects = new DNode("Появились ли дефекты на окрашенной поверхности ?", 98);
        public DNode QPytna = new DNode("Эти дефекты-пятна??", 80);
        public DNode QPolosy = new DNode("Эти дефекты-полосы?", 40);
        public DNode QPyziri = new DNode("Эти дефекты-пузыри?", 50); // добавленный вопрос по варианту 2А
        public DNode QZhirPytna = new DNode("Это жирные пятна?",60);
        public DNode QPoverhShtyk = new DNode("Окрашенная поверхность является штукатуркой?",35);
        public DNode QZhelezobeton = new DNode("Окрашенная поверхность являетсяжелезобетонной?",45);
        public DNode QRzhavchina = new DNode("Это желтые ржавые пятна?", 65);
        public DNode AOtdih = new DNode("Если нет дефектов то ничего делать не нужно. \nВот что вам следует сделать в данной ситуации:" +
            " \nПойдите отдохните, у вас все в порядке.",20);
        public DNode ANotZhelezobeton = new DNode("Причина появления этих пятен мне неизвестна. \nВот что вам следует сделать в данной ситуации:" +
            " \nПопробуйте обратиться к более опытному специалисту.",25);
        public DNode AZhelezobeton = new DNode("Если жирные пятна на железобетоне, \nто эта проблема вполне разрешима." +
            " \nВот что вам следует сделать в данной ситуации: \nОчистить поверхность от слоя краски со шпаклевкой. \nПромыть 5%-м раствором кальцевой соды," +
            " \nнейтрализовать поверхность 5%-м \nраствором соляной кислоты и вновь окрасить", 75);
        public DNode APoverhShtyk = new DNode("Если жирные пятна на штукатурке, \nто эта проблема вполне разрешима. \nВот что вам следует сделать в данной ситуации:" +
            " \nВырубить штукатурку на участке пятна, \nвновь оштукатурить и окрасить.", 55);
        public DNode ANotRzavchina = new DNode("Если появились какие-то другие пятна, \nто ничего путного посоветовать вам я не могу." +
            " \nВот что вам следует сделать в данной ситуации: \nПопробуйте обратиться к более опытному специалисту.",28);
        public DNode ARzhavchina = new DNode("Если ржавые пятна на штукатурке, \nто эта проблема вполне разрешима." +
            " \nВот что вам следует сделать в данной ситуации: \nУдалить старый набел, \nи промыть 3%-м раствором соляной кислоты" +
            " \nи если пятна не велики, отгрунтовать \nмеднокупоросной грунтовкой без мела, \nа при больших размерах щелочным или канифольным лаком.", 72);
        public DNode APolosy = new DNode("Если полосы на окрашенной поверхности, \nто эта проблема вполне разрешима." +
            " \nВот что вам следует сделать в данной ситуации: \nПромыть поверхность и окрасить.", 50);
        public DNode ANotPyziri = new DNode("Если появились какие-то другие дефекты \nто ничего путного я вам посоветовать не могу." +
            " \nВот что вам следует сделать в данной ситуации: \nПопробуйте обратиться к более опытному специалисту.", 15);
        public DNode APyziri = new DNode("Если появились пузыри на окрашенной поверхности, \nто эта проблема вполне разрешими." +
            " \nВот что вам следует сделать в данной ситуации: \nОчистить поверхность от краски, \nперемешивать краску до удаления в ней пузырей воздуха," +
            " \nснова выполнить покраску.", 85);
        public DNode CurrentNode = new DNode("");  //узел, который будем менять в зависимости от ответа
        public DNode NotCurrentNode = new DNode(""); // тупиковый узел 
        public DNode StartNode = new DNode("");
        public Form1()
        {
            InitializeComponent();
        }
        public void PishetZapominaet(DNode dNode) // несколько действий вынесено в этот отдельный метод для сокращения кода
        {
            if (CurrentNode.Left == null)                      // если вопросов больше не будет, то кнопки убираются через if.
            {
                counterPopitok++;
                this.ButtonsVisable(false);
                richTextBox1.Text += "\nНа " + Convert.ToString(counterPopitok) + " попытке результаты : \n";
                richTextBox1.Text += "Вычисление в пределах правила 5 методом : " + Convert.ToString(CurrentNode.MetodCF5(CurrentNode)) + "%\n";
                richTextBox1.Text += "Вычисление в пределах правила 6 методом : " + Convert.ToString(CurrentNode.MetodCF6(CurrentNode)) + "%\n";
                richTextBox1.Text += "Вычисление в пределах правила 7 методом : " + Convert.ToString(CurrentNode.MetodCF7(CurrentNode)) + "%\n";
                richTextBox1.Text += "Вычисление в пределах правила 8 методом : " + Convert.ToString(CurrentNode.MetodCF8(CurrentNode)) + "%\n";

                HistoryCFs.Add(CurrentNode.MetodCF5(CurrentNode));
                HistoryCFs.Add(CurrentNode.MetodCF6(CurrentNode));
                HistoryCFs.Add(CurrentNode.MetodCF7(CurrentNode));
                HistoryCFs.Add(CurrentNode.MetodCF8(CurrentNode));

                button3.Visible = true;
                if (counterPopitok > 1)
                {
                    richTextBox1.Text += "\nВычисление по правилам после " + Convert.ToString(counterPopitok) + " попытки : "
                        + Convert.ToString(CurrentNode.MaxZnach(HistoryCFs)) + "\n";
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            CurrentNode = CurrentNode.Yes(CurrentNode, label1);  // Метод принимает currentnode - сдвигает его влево и выводит текст на экран, 
            button1.Text = "Да";                                // currentnode обновляется. label принимается для обновления на нем текста.
            PishetZapominaet(CurrentNode);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            CurrentNode = CurrentNode.No(CurrentNode, label1);
            if (CurrentNode.Data == "")
            {
                this.Close();
            }
            PishetZapominaet(CurrentNode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Устанавливается порядок узлов в дереве.
            StartNode.Mesto(null, QDefects, NotCurrentNode);
            CurrentNode.Mesto(null, QDefects, NotCurrentNode);
            QDefects.Mesto(QDefects, QPytna, AOtdih);
            QPytna.Mesto(QPytna, QZhirPytna, QPolosy);
            QZhirPytna.Mesto(QZhirPytna, QPoverhShtyk, QRzhavchina);
            QRzhavchina.Mesto(QRzhavchina, ARzhavchina, ANotRzavchina);
            QPoverhShtyk.Mesto(QPoverhShtyk, APoverhShtyk, QZhelezobeton);
            QZhelezobeton.Mesto(QZhelezobeton, AZhelezobeton, ANotZhelezobeton);
            QPolosy.Mesto(QPolosy, APolosy, QPyziri);
            QPyziri.Mesto(QPyziri, APyziri, ANotPyziri);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CurrentNode = StartNode;
            label1.Text = "После окраски поверхности водными красками могут\r\nпроявиться дефекты.\r" +
                "\nМы постараемся дать вам совет по их устранинию и\r\nпричинам появления.\r\nНо для этого вы должны предоставить мне всю информацию.\r\n\tитак начнем... ";
            button3.Visible = false;
            this.ButtonsVisable(true);
        }
    }
    public class DNode
    {
        public string Data { get; set; }
        public DNode Left { get; set; }
        public DNode Right { get; set; }
        public DNode Parent { get; set; }
        public int CF { get; set; }
        public DNode(string data, int cF)
        {
            Data = data;
            CF = cF;
        }
        public DNode(string data)
        {
            Data = data;
        }
        public void Mesto(DNode parent, DNode left, DNode right)
        {
            Left = left;
            Right = right;
            Left.Parent = parent;
            Right.Parent = parent;
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
        public int YmnozitIPodelitNa100(List<int> ints)
        {
            double multiplicate = 1;
            int counter = 0;
            List<Double> doubles = new List<Double>();
            foreach (int i in ints)
            {
                doubles.Add(Convert.ToDouble(i));
            }
            foreach (double d in doubles)
            {
                multiplicate *= d;
                counter++;
            }
            for (int i = 0; i < counter - 1; i++)  // делим на 100 каждую пару, -1 - чтобы при 2х числах не делить 2 раза на 100
            {
                multiplicate /= 100;
            }
            return Convert.ToInt32(multiplicate);
        }
        public int MinZnach(List<int> ints)
        {

            int dlinna = ints.Count;
            if (dlinna > 1)
            {
                int minValue = ints[0];
                for (int i = 0; i < dlinna; i++)
                {
                    if (ints[i] < minValue)
                    {
                        minValue = ints[i];
                    }
                }
                return minValue;
            }
            else if (dlinna == 1)
            {
                return ints.First();
            }
            else
            {
                throw new Exception("Никого нет");
            }
        }
        public int MaxZnach(List<int> ints)
        {
            int dlinna = ints.Count;
            if (dlinna > 1)
            {
                int maxValue = ints[0];
                for (int i = 0; i < dlinna; i++)
                {
                    if (ints[i] > maxValue)
                    {
                        maxValue = ints[i];
                    }
                }
                return maxValue;
            }
            else if (dlinna == 1)
            {
                return ints.First();
            }
            else
            {
                throw new Exception("Никого нет");
            }
        }
        public List<int> CountCFParents(DNode dNode) // вернет лист всех коэфициентов нода и родителей
        {
            int counterParents = 0;
            DNode Clone = dNode;
            while (dNode.Parent != null)
            {
                dNode = dNode.Parent;
                counterParents++;
            }
            dNode = Clone;
            List<int> CFParentsList = new List<int>();
            for (int i = 0; i < counterParents + 1; i++) // закидываем в лист все значения факторов уверенности родителей и потомка +1 из-за потомка
            {
                CFParentsList.Add(dNode.CF);
                dNode = dNode.Parent;
            }
            return CFParentsList;
        }

        public int MetodCF5(DNode dNode)
        {
            return YmnozitIPodelitNa100(CountCFParents(dNode));
        }
        public int MetodCF6(DNode dNode)
        {
            return MinZnach(CountCFParents(dNode));
        }
        public int MetodCF7(DNode dNode)
        {
            return ((MinZnach(CountCFParents(dNode)) + YmnozitIPodelitNa100(CountCFParents(dNode))) / 2);
        }
        public int MetodCF8(DNode dNode)
        {
            return ((YmnozitIPodelitNa100(CountCFParents(dNode))) * (200 - MaxZnach(CountCFParents(dNode))) / 100);
        }
    }
}
