using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IntSysLaba2V2
{
    public partial class Form1 : Form
    {
        public void Off()
        {
            button1.Visible = false;
            button2.Visible = false;
        }
        // Экземпляры класса, представляющие из себя все вопросы и ответы
        public DNode QDefects = new DNode("Появились ли дефекты на окрашенной поверхности ?");
        public DNode QPytna = new DNode("Эти дефекты-пятна?");
        public DNode QPolosy = new DNode("Эти дефекты-полосы?");
        public DNode QPyziri = new DNode("Эти дефекты-пузыри?"); // добавленный вопрос по варианту 2А
        public DNode QZhirPytna = new DNode("Это жирные пятна?");
        public DNode QPoverhShtyk = new DNode("Окрашенная поверхность является штукатуркой?");
        public DNode QZhelezobeton = new DNode("Окрашенная поверхность являетсяжелезобетонной?");
        public DNode QRzhavchina = new DNode("Это желтые ржавые пятна?");
        public DNode AOtdih = new DNode("Если нет дефектов то ничего делать не нужно. \nВот что вам следует сделать в данной ситуации: \nПойдите отдохните, у вас все в порядке.");
        public DNode ANotZhelezobeton = new DNode("Причина появления этих пятен мне неизвестна. \nВот что вам следует сделать в данной ситуации: \nПопробуйте обратиться к более опытному специалисту.");
        public DNode AZhelezobeton = new DNode("Если жирные пятна на железобетоне, \nто эта проблема вполне разрешима. \nВот что вам следует сделать в данной ситуации: \nОчистить поверхность от слоя краски со шпаклевкой. \nПромыть 5%-м раствором кальцевой соды, \nнейтрализовать поверхность 5%-м \nраствором соляной кислоты и вновь окрасить");
        public DNode APoverhShtyk = new DNode("Если жирные пятна на штукатурке, \nто эта проблема вполне разрешима. \nВот что вам следует сделать в данной ситуации: \nВырубить штукатурку на участке пятна, \nвновь оштукатурить и окрасить.");
        public DNode ANotRzavchina = new DNode("Если появились какие-то другие пятна, \nто ничего путного посоветовать вам я не могу. \nВот что вам следует сделать в данной ситуации: \nПопробуйте обратиться к более опытному специалисту.");
        public DNode ARzhavchina = new DNode("Если ржавые пятна на штукатурке, \nто эта проблема вполне разрешима. \nВот что вам следует сделать в данной ситуации: \nУдалить старый набел, \nи промыть 3%-м раствором соляной кислоты \nи если пятна не велики, отгрунтовать \nмеднокупоросной грунтовкой без мела, \nа при больших размерах щелочным или канифольным лаком.");
        public DNode APolosy = new DNode("Если полосы на окрашенной поверхности, \nто эта проблема вполне разрешима. \nВот что вам следует сделать в данной ситуации: \nПромыть поверхность и окрасить.");
        public DNode ANotPyziri = new DNode("Если появились какие-то другие дефекты \nто ничего путного я вам посоветовать не могу. \nВот что вам следует сделать в данной ситуации: \nПопробуйте обратиться к более опытному специалисту.");
        public DNode APyziri = new DNode("Если появились пузыри на окрашенной поверхности, \nто эта проблема вполне разрешими. \nВот что вам следует сделать в данной ситуации: \nОчистить поверхность от краски, \nперемешивать краску до удаления в ней пузырей воздуха, \nснова выполнить покраску.");
        public DNode CurrentNode = new DNode("");  //узел, который будем менять в зависимости от ответа
        public DNode NotCurrentNode = new DNode(""); // тупиковый узел 
        public Form1()
        {
            InitializeComponent();
            //Устанавливается порядок узлов в дереве.
            CurrentNode.Mesto(QDefects, NotCurrentNode);    
            QDefects.Mesto(QPytna, AOtdih);
            QPytna.Mesto(QZhirPytna, QPolosy);
            QZhirPytna.Mesto(QPoverhShtyk, QRzhavchina);
            QRzhavchina.Mesto(ARzhavchina, ANotRzavchina);
            QPoverhShtyk.Mesto(APoverhShtyk, QZhelezobeton);
            QZhelezobeton.Mesto(AZhelezobeton, ANotZhelezobeton);
            QPolosy.Mesto(APolosy, QPyziri);
            QPyziri.Mesto(APyziri, ANotPyziri);
        }
        private void button1_Click(object sender, EventArgs e) // лево да
        {
            CurrentNode = CurrentNode.Yes(CurrentNode, label1);  // Метод принимает currentnode - сдвигает его влево и выводит текст на экран, 
            button1.Text = "Да";                                // currentnode обновляется. label принимается для обновления на нем текста.
            if (CurrentNode.Left == null)                      // если вопросов больше не будет, то кнопки убираются через if.
            {
                this.Off();
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
            }
        }
    }
   public class DNode
    {
        public string Data { get; set; }
        public DNode Left { get; set; }
        public DNode Right { get; set; }
        public DNode(string data)
        {
            Data = data;
        }
        public void Mesto(DNode left, DNode right)
        {
            Left = left;
            Right = right;
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
    }
}