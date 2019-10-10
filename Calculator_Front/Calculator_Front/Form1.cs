using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorEngine;

namespace Calculator_Front
{
    /* key to opperands
     * char  opperand
    
     * n    negative
     * +    add
     * -    subtract
     * /    divide
     * %    mod
     * *    multiply
     * |    absolute value
     * (    left parenthesis
     * )    Right parenthesis
     * s(    Sin   there will always be a following Rparen after one of these
     * c(    Cos
     * t(    Tan
     * S(    CSC
     * C(    Sec
     * T(    cotan
     * ^    power
     * D    degrees
     * R    Radians
     */ 


    public partial class buttonRParen : Form
    {
        private string Equation = "";
        LinkedList<string> Expressions = new LinkedList<string>();
        LinkedList<string> DispExpressions = new LinkedList<string>();
        LinkedList<Double> Answers = new LinkedList<Double>();

        char Mode = 'D';
            

        public buttonRParen()
        {
            InitializeComponent();
        }

        private void buttonRParen_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '1';
            this.Equation = this.Equation + '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '2';
            this.Equation = this.Equation + '2';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '3';
            this.Equation = this.Equation + '3';
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '+';
            this.Equation = this.Equation + '+';
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '-';
            this.Equation = this.Equation + '-';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '4';
            this.Equation = this.Equation + '4';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '5';
            this.Equation = this.Equation + '5';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '6';
            this.Equation = this.Equation + '6';
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + 'x';
            this.Equation = this.Equation + '*';
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '/';
            this.Equation = this.Equation + '/';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '7';
            this.Equation = this.Equation + '7';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '8';
            this.Equation = this.Equation + '8';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '9';
            this.Equation = this.Equation + '9';
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '%';
            this.Equation = this.Equation + '%';
        }

        private void buttonAbs_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '|';
            this.Equation = this.Equation + '|';  
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.Equation = "";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '0';
            this.Equation = this.Equation + '0';
        }

        private void buttonNeg_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '-';
            this.Equation = this.Equation + 'n';
           
        }

        private void buttonLParen_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '(';
            this.Equation = this.Equation + '(';
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + ')';
            this.Equation = this.Equation + ')';
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + "sin(";
            this.Equation = this.Equation + "s"+Mode+"(";
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + "cos(";
            this.Equation = this.Equation + "c" + Mode + "(";
        }

        private void buttonTan_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + "tan(";
            this.Equation = this.Equation + "t" + Mode + "(";
        }

        private void buttonSec_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + "sec(";
            this.Equation = this.Equation + "C" + Mode + "(";
        }

        private void buttonCsc_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + "Csc(";
            this.Equation = this.Equation + "S" + Mode + "(";
        }

        private void buttonCot_Click(object sender, EventArgs e)
        {

            this.textBox1.Text = this.textBox1.Text + "Cot(";
            this.Equation = this.Equation + "T" + Mode + "(";
                   }

        private void buttonEquls_Click(object sender, EventArgs e)
        {
         
            this.Expressions.AddFirst(this.textBox1.Text);
            this.DispExpressions.AddFirst(this.textBox1.Text);
            
            ExpressionTree expression =new ExpressionTree(this.Equation);
           double answer= expression.Evaluate();
   
            this.historyToolStripMenuItem.DropDown.Items.Add(this.textBox1.Text.ToString()+"="+answer.ToString());
            this.textBox1.Text = answer.ToString();
           


        }

        private void buttonDel_Click(object sender, EventArgs e)
        {

            string newEquation = "";
            string newDisplay = "";

         
            if (this.Equation.Length > 1&& this.Equation[this.Equation.Length - 1] == '(' && (((this.Equation[this.Equation.Length - 2] >= 'a' && this.Equation[this.Equation.Length - 2] <= 'z')) || (this.Equation[this.Equation.Length - 2] >= 'A' && this.Equation[this.Equation.Length - 2] <= 'Z'))){


                for (int i = 0; i < this.Equation.Length - 2; i++)
                {
                    newEquation = newEquation + this.Equation[i];
                }
                this.Equation = newEquation;

                for (int i = 0; i < this.textBox1.Text.Length - 4; i++)
                {
                    newDisplay = newDisplay + this.textBox1.Text[i];
                }
            }
            else
            {


                for (int i = 0; i < this.Equation.Length - 1; i++)
                {
                    newEquation = newEquation + this.Equation[i];
                }
                this.Equation = newEquation;

                for (int i = 0; i < this.textBox1.Text.Length - 1; i++)
                {
                    newDisplay = newDisplay + this.textBox1.Text[i];
                }
            }


         

            this.textBox1.Text = newDisplay;
        

 
        }

        private void buttonExp_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + '^';
            this.Equation = this.Equation + '^';
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeg_Click(object sender, EventArgs e)
        {

        }

        private void buttonRad_Click(object sender, EventArgs e)
        {


            string temp = "";
            if (Mode == 'R')
            {
              Mode = 'D';
                MessageBox.Show("Degree Mode");
                for (int i = 0; i < Equation.Length; i++)
                {
                    if (Equation[i] == 'R')
                    {
                        temp = temp + 'D';
                    }
                    else
                    {
                        temp = temp + Equation[i];
                    }
                }
            }
            else if (Mode == 'D')
            {
                MessageBox.Show("Radian Mode"); 
                Mode = 'R';
                for (int i = 0; i < Equation.Length;i++)
                {
                    if (Equation[i] == 'D')
                    {
                        temp = temp + 'R';
                    }
                    else
                    {
                        temp = temp + Equation[i];
                    }
                }

            }

            this.Equation = temp;
        }

        private void pythagoreanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a^2+b^2=c^2");
        }

        private void quadraticToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(-b+- (b^2 -4ac)^.5)/2a");
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("square:side^2\n rectangle: base* hight\n triangle:base*hight/2 ");
        }

        private void volumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("square:side^3\n rectangle: base* hight* width ");
        }
    
    }
}
