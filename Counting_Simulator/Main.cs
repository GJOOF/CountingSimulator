using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Counting_Simulator
{
    public partial class Main : Form
    {

        int Max_Try = 20;
        int Try;
        Random random = new Random();
        string Operator;
        int answer;
        int RightAnswer;
        int WrongAnswer;
        int timeForTimer;
        int minuteTimeForTimer;
        string AllAnswers;
        public Main()
        {
            InitializeComponent();
            tb_answer.Enabled = false;
        }
        private void Start()
        {
            btn_add.Visible = false;
            btn_sub.Visible = false;
            btn_mult.Visible = false;
            btn_div.Visible = false;
            tb_answer.Text = "";
            tb_answer.Focus();
            Try = 0;
            Consider();
        }
        private void Consider()
        {
            timer1.Enabled = true;
            tb_answer.Text = "";
            tb_answer.Focus();
            if (Try <= Max_Try)
            {
                int a = random.Next(1, 20);
                int b = random.Next(1, 20);
                int a_2 = random.Next(1, 10);
                int b_2 = random.Next(1, 10);

                if (Operator == "Addition")
                {
                    string a_text = Convert.ToString(a, 2);
                    string b_text = Convert.ToString(b, 2);
                    answer = Convert.ToInt32(Convert.ToString(Convert.ToByte(a_text, 2) + Convert.ToByte(b_text, 2), 2), 2);
                    lab_equation.Text = $"{a.ToString()} + {b.ToString()}  =";
                }
                if (Operator == "Subtraction")
                {
                    if (a < b)
                    {
                        int x = a;
                        a = b;
                        b = x;
                    }
                    string a_text = Convert.ToString(a, 2);
                    string b_text = Convert.ToString(b, 2);
                    answer = Convert.ToInt32(Convert.ToString(Convert.ToByte(a_text, 2) - Convert.ToByte(b_text, 2), 2), 2);
                    lab_equation.Text = $"{a.ToString()} - {b.ToString()}  =";
                }
                if (Operator == "Multiplication")
                {
                    string a_text = Convert.ToString(a_2, 2);
                    string b_text = Convert.ToString(b_2, 2);
                    answer = Convert.ToInt32(Convert.ToString(Convert.ToByte(a_text, 2) * Convert.ToByte(b_text, 2), 2), 2);
                    lab_equation.Text = $"{a_2.ToString()} * {b_2.ToString()}  =";
                }
                if (Operator == "Division")
                {
                    if (a_2 < b_2)
                    {
                        int x_2 = a_2;
                        a_2 = b_2;
                        b_2 = x_2;
                    }
                    string a_text = Convert.ToString(a_2, 2);
                    string b_text = Convert.ToString(b_2, 2);
                    answer = Convert.ToInt32(Convert.ToString(Convert.ToByte(a_text, 2)));
                    lab_equation.Text = $"{Convert.ToString(Convert.ToByte(a_text, 2) * (Convert.ToByte(b_text, 2)))} : {Convert.ToString(Convert.ToByte(b_text, 2))} =";
                }
            }
            else
            {
                timer1.Stop();
                MessageBox.Show($" Gived answers : {RightAnswer + WrongAnswer} \n" +
               $" Correct answers: {RightAnswer}\n" +
               $" Wrong answers: {WrongAnswer}", "Statistics",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                Done();
            }

            lab_equation_done.Text = (RightAnswer + WrongAnswer).ToString();
        }
        private void Done()
        {
            tb_answer.Focus();
            Try = 0;
            AllAnswers = (RightAnswer + WrongAnswer).ToString();
            lab_equation_done.Text = AllAnswers;
            lab_equation.Text = "Equation";
            MessageBox.Show($" Gived answers : {AllAnswers} \n" +
                $" Correct answers: {RightAnswer}\n" +
                $" Wrong answers: {WrongAnswer}", "Statistics",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            btn_add.Visible = true;
            btn_sub.Visible = true;
            btn_mult.Visible = true;
            btn_div.Visible = true;
            WrongAnswer = 0;
            RightAnswer = 0;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Operator = "Addition";
            tb_answer.Focus();
            tb_answer.Enabled = true;
            Start();
        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            Operator = "Subtraction";
            tb_answer.Focus();
            tb_answer.Enabled = true;
            Start();
        }

        private void btn_mult_Click(object sender, EventArgs e)
        {
            Operator = "Multiplication";
            tb_answer.Focus();
            tb_answer.Enabled = true;
            Start();
        }

        private void btn_div_Click(object sender, EventArgs e)
        {
            Operator = "Division";
            tb_answer.Focus();
            tb_answer.Enabled = true;
            Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeForTimer < 60)
            {
                if (timeForTimer == 59)
                {
                    timeForTimer = 0;
                    minuteTimeForTimer++;
                    lab_timer.Text = $"{minuteTimeForTimer}:{timeForTimer}";
                }
                else
                {
                    timeForTimer++;
                }
                lab_timer.Text = $"{minuteTimeForTimer}:{timeForTimer}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_answer.Focus();
            if (tb_answer.Text == "")
            {
                MessageBox.Show("ENTER ANSWER!");
            }
            else
            {

                if (progressBar1.Value < 100)
                {

                    progressBar1.Value += (progressBar1.Maximum / Max_Try);
                    if (answer == Convert.ToInt32(tb_answer.Text))
                    {
                        Try++;
                        RightAnswer++;
                    }
                    else
                    {
                        WrongAnswer++;
                    }

                    Consider();
                    if (progressBar1.Value == 100)
                    {
                        progressBar1.Value = 0;
                        Done();
                    }
                }
            }
        }
    }
}
