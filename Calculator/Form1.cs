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
        double result = 0;
        String operation = " ";
        bool isoperation = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            //if part use for clear the text box default value(0)
            if (txtResult.Text == "0" || isoperation)
            {
                txtResult.Clear();
            }

            Button button = (Button)sender;     // object for getting values
            txtResult.Text = txtResult.Text + button.Text;
            //txtResult.Text = txtResult.Text + "1";

            isoperation = false;

            if(button.Text == ".")
            {
                if(!txtResult.Text.Contains("."))
                {
                    txtResult.Text = txtResult.Text + button.Text;
                }
            }
            else
            {
                //txtResult.Text = txtResult.Text + button.Text;
            }


        }

        private void operaters(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            if(result != 0)
            {
                btnEqual.PerformClick();
                operation = button.Text;

                isoperation = true;

                lblPreOperation.Text = result + " " + operation;

            }
            else
            {
                operation = button.Text;
                result = Double.Parse(txtResult.Text);

                isoperation = true;

                lblPreOperation.Text = result + " " + operation;
            }
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            result = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch(operation)
            {
                case "+":
                    txtResult.Text = (result + Double.Parse(txtResult.Text)).ToString();
                    break;
                case "-":
                    txtResult.Text = (result - Double.Parse(txtResult.Text)).ToString();
                    break;
                case "*":
                    txtResult.Text = (result * Double.Parse(txtResult.Text)).ToString();
                    break;
                case "/":
                    txtResult.Text = (result / Double.Parse(txtResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtResult.Text);
            lblPreOperation.Text = "";
            
        }
    }
}
