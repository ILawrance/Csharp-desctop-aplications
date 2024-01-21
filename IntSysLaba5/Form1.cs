using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntSysLaba5v3  // знаокмство с работа с бд при помощи EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                context.BonusLists.RemoveRange(context.BonusLists);
                context.Employeers.RemoveRange(context.Employeers);
                context.Accrues.RemoveRange(context.Accrues);
                context.Positions.RemoveRange(context.Positions);
                context.SaveChanges();
                var positions = new List<Position>  // Данные для бд специально заполняю ручками
                {
                    new Position() {Name = "Accountant", Salary = 40000},
                    new Position() {Name = "Manager", Salary = 50000 },
                    new Position() {Name = "Medic", Salary = 60000},
                    new Position() {Name = "Driver", Salary = 35000},
                    new Position() {Name = "Security", Salary = 30000 },
                    new Position() {Name = "Deliveryman", Salary = 30000}
                };
                var accrues = new List<Accrue>
                {
                    new Accrue() {Date = "24.02.2023", EmploeeTabNumber = 3020, Accrued = 60000},
                    new Accrue() {Date = "24.02.2023", EmploeeTabNumber = 3040, Accrued = 60000},
                    new Accrue() {Date = "24.02.2023", EmploeeTabNumber = 3070, Accrued = 70000},
                    new Accrue() {Date = "24.02.2023", EmploeeTabNumber = 3520, Accrued = 40000},
                    new Accrue() {Date = "24.02.2023", EmploeeTabNumber = 4200, Accrued = 70000},
                    new Accrue() {Date = "24.02.2023", EmploeeTabNumber = 4420, Accrued = 60000},
                    new Accrue() {Date = "24.02.2023", EmploeeTabNumber = 4480, Accrued = 35000},
                    new Accrue() {Date = "24.02.2023", EmploeeTabNumber = 4520, Accrued = 30000}
                };
                var employees = new List<Employee>
                {
                    new Employee() {TabNumber = 3020, FIO = "Maklyaev Ilya Egorovich", Position = positions[0].Name , DateOfStratWorking = "1.08.2021"},
                    new Employee() {TabNumber = 3040, FIO = "Fedotova Anastasiya Dmitrevna", Position = positions[1].Name, DateOfStratWorking = "4.02.2022"},
                    new Employee() {TabNumber = 3070, FIO = "Sichev Nikita Mihailovich", Position = positions[2].Name, DateOfStratWorking = "18.04.2022"},
                    new Employee() {TabNumber = 3520, FIO = "Grishina Masha Vasilevna", Position = positions[3].Name, DateOfStratWorking = "3.05.2022" },
                    new Employee() {TabNumber = 4200, FIO = "Kalin Anton Andreevich", Position = positions[2].Name, DateOfStratWorking = "21.05.2022"},
                    new Employee() {TabNumber = 4420, FIO = "Egorov Alexander Alexandrovich", Position = positions[1].Name, DateOfStratWorking = "27.06.2022" },
                    new Employee() {TabNumber = 4480, FIO = "Egorov Egor Egorovich", Position = positions[4].Name, DateOfStratWorking = "2.07.2022" },
                    new Employee() {TabNumber = 4520, FIO = "Birabidjon Machoobek Birabidjonovich", Position = positions[4].Name, DateOfStratWorking = "18.07.2022"}
                };
                context.Employeers.AddRange(employees);
                context.Positions.AddRange(positions);
                context.Accrues.AddRange(accrues);
                context.SaveChanges();
                var bonuslists = new List<BonusList>
                {
                    new BonusList() {
                        Date = "1.03.2023", EmploeeTabNumber = employees[0].TabNumber, EmloeeFIO = employees[0].FIO,
                        EmploeePost = employees[0].Position, EmploeeExperience = "2 years, sins " + employees[0].DateOfStratWorking,
                        EmploeeSalary = positions[0].Salary, EmploeeAccrued = accrues[0].Accrued,
                        EmploeePocentBonus = Convert.ToInt32((Convert.ToDouble(accrues[0].Accrued)/Convert.ToDouble(positions[0].Salary))*100)-100,
                        EmploeeSummOfBunus = (accrues[0].Accrued - positions[0].Salary)
                    },
                    new BonusList() {
                        Date = "1.03.2023", EmploeeTabNumber = employees[1].TabNumber, EmloeeFIO = employees[1].FIO,
                        EmploeePost = employees[1].Position, EmploeeExperience = "1 years, sins " + employees[1].DateOfStratWorking,
                        EmploeeSalary = positions[1].Salary, EmploeeAccrued = accrues[1].Accrued,
                        EmploeePocentBonus = Convert.ToInt32((Convert.ToDouble(accrues[1].Accrued)/Convert.ToDouble(positions[1].Salary))*100)-100,
                        EmploeeSummOfBunus = (accrues[1].Accrued - positions[1].Salary)
                    },
                    new BonusList() {
                        Date = "1.03.2023", EmploeeTabNumber = employees[2].TabNumber, EmloeeFIO = employees[2].FIO,
                        EmploeePost = employees[2].Position, EmploeeExperience = "1 years, sins " + employees[2].DateOfStratWorking,
                        EmploeeSalary = positions[2].Salary, EmploeeAccrued = accrues[2].Accrued,
                        EmploeePocentBonus = Convert.ToInt32((Convert.ToDouble(accrues[2].Accrued)/Convert.ToDouble(positions[2].Salary))*100)-100,
                        EmploeeSummOfBunus = (accrues[2].Accrued - positions[2].Salary)
                    },
                    new BonusList() {
                        Date = "1.03.2023", EmploeeTabNumber = employees[3].TabNumber, EmloeeFIO = employees[3].FIO,
                        EmploeePost = employees[3].Position, EmploeeExperience = "1 years, sins " + employees[3].DateOfStratWorking,
                        EmploeeSalary = positions[3].Salary, EmploeeAccrued = accrues[3].Accrued,
                        EmploeePocentBonus = Convert.ToInt32((Convert.ToDouble(accrues[3].Accrued)/Convert.ToDouble(positions[3].Salary))*100)-100,
                        EmploeeSummOfBunus = (accrues[3].Accrued - positions[3].Salary)
                    },
                    new BonusList() {
                        Date = "1.03.2023", EmploeeTabNumber = employees[4].TabNumber, EmloeeFIO = employees[4].FIO,
                        EmploeePost = employees[2].Position, EmploeeExperience = "1 years, sins " + employees[4].DateOfStratWorking,
                        EmploeeSalary = positions[1].Salary, EmploeeAccrued = accrues[4].Accrued,
                        EmploeePocentBonus = Convert.ToInt32((Convert.ToDouble(accrues[4].Accrued)/Convert.ToDouble(positions[2].Salary))*100)-100,
                        EmploeeSummOfBunus = (accrues[4].Accrued - positions[2].Salary)
                    },
                    new BonusList() {
                        Date = "1.03.2023", EmploeeTabNumber = employees[5].TabNumber, EmloeeFIO = employees[5].FIO,
                        EmploeePost = employees[5].Position, EmploeeExperience = "1 years, sins " + employees[5].DateOfStratWorking,
                        EmploeeSalary = positions[1].Salary, EmploeeAccrued = accrues[5].Accrued,
                        EmploeePocentBonus = Convert.ToInt32((Convert.ToDouble(accrues[5].Accrued)/Convert.ToDouble(positions[1].Salary))*100)-100,
                        EmploeeSummOfBunus = (accrues[5].Accrued - positions[1].Salary)
                    },
                    new BonusList() {
                        Date = "1.03.2023", EmploeeTabNumber = employees[6].TabNumber, EmloeeFIO = employees[6].FIO,
                        EmploeePost = employees[6].Position, EmploeeExperience = "1 years, sins " + employees[6].DateOfStratWorking,
                        EmploeeSalary = positions[4].Salary, EmploeeAccrued = accrues[6].Accrued,
                        EmploeePocentBonus = Convert.ToInt32((Convert.ToDouble(accrues[6].Accrued)/Convert.ToDouble(positions[4].Salary))*100)-100,
                        EmploeeSummOfBunus = (accrues[6].Accrued - positions[4].Salary)
                    },
                    new BonusList() {
                        Date = "1.03.2023", EmploeeTabNumber = employees[7].TabNumber, EmloeeFIO = employees[7].FIO,
                        EmploeePost = employees[7].Position, EmploeeExperience = "1 years, sins " + employees[7].DateOfStratWorking,
                        EmploeeSalary = positions[5].Salary, EmploeeAccrued = accrues[7].Accrued,
                        EmploeePocentBonus = Convert.ToInt32((Convert.ToDouble(accrues[7].Accrued)/Convert.ToDouble(positions[5].Salary))*100)-100,
                        EmploeeSummOfBunus = (accrues[7].Accrued - positions[5].Salary)
                    }
                };
                context.BonusLists.AddRange(bonuslists);
                context.SaveChanges();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var BList = db.BonusLists.OrderByDescending(p => p.EmploeeSummOfBunus);
                richTextBox1.Text = "";
                foreach (var blist in BList)
                {
                   richTextBox1.Text += $"Дата: {blist.Date} / Табельный номер: {blist.EmploeeTabNumber} / ФИО: {blist.EmloeeFIO} / Должность: {blist.EmploeePost} " +
                       $"/ Стаж работы: {blist.EmploeeExperience} / Оклад: {blist.EmploeeSalary} / Ничислено: {blist.EmploeeAccrued} / % Премии: {blist.EmploeePocentBonus}% " +
                       $" / Сумма премии: {blist.EmploeeSummOfBunus} \n";
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                richTextBox1.Text = "";
                foreach (Employee emloyee in context.Employeers)
                {
                    richTextBox1.Text += $"Табельный номер работника: {emloyee.TabNumber} / ФИО: {emloyee.FIO} / Должность: {emloyee.Position} " +
                        $"/ Дата начала работы: {emloyee.DateOfStratWorking} \n";
                }
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                richTextBox1.Text = "";
                foreach (Position position in context.Positions)
                {
                    richTextBox1.Text += $"Название должности: {position.Name} / Оклад: {position.Salary} \n";
                }
            }
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                richTextBox1.Text = "";
                foreach (BonusList oklad in context.BonusLists)
                {
                    richTextBox1.Text += $"Работник: {oklad.EmloeeFIO} / Оклад: {oklad.EmploeeSalary} \n";
                }
            }
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                richTextBox1.Text = "";
                foreach (BonusList exp in context.BonusLists)
                {
                    richTextBox1.Text += $"Работник: {exp.EmloeeFIO} / Опыт работы: {exp.EmploeeExperience} \n";
                }
            }
        }
    }
}
