using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymbolGenerator
{
    public partial class Form1 : Form
    {
        private int[] rows = new int[16];
        private Label[] labels = new Label[16];
        private bool hexOutput = true;

        public Form1()
        {
            InitializeComponent();

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(CheckBox))
                {
                    c.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labels[0] = this.lblRow0;
            labels[1] = this.lblRow1;
            labels[2] = this.lblRow2;
            labels[3] = this.lblRow3;
            labels[4] = this.lblRow4;
            labels[5] = this.lblRow5;
            labels[6] = this.lblRow6;
            labels[7] = this.lblRow7;
            labels[8] = this.lblRow8;
            labels[9] = this.lblRow9;
            labels[10] = this.lblRow10;
            labels[11] = this.lblRow11;
            labels[12] = this.lblRow12;
            labels[13] = this.lblRow13;
            labels[14] = this.lblRow14;
            labels[15] = this.lblRow15;

            UpdateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateLabels()
        {
            string output = "";

            if (hexOutput)
            {
                for (int a = 0; a < 16; a++)
                {
                    labels[a].Text = rows[a].ToString("X");
                    output += rows[a].ToString("X") + ",";
                }
            }
            else
            {
                for (int a = 0; a < 16; a++)
                {
                    labels[a].Text = rows[a].ToString();
                    output += rows[a].ToString() + ",";
                }
            }
            txtOutput.Text = output.Substring(0, output.Length - 1);
        }

        private void CheckBox_CheckChanged(Object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked)
            {
                rows[Int32.Parse(checkbox.Tag.ToString().Split(',')[0])] += Int32.Parse(checkbox.Tag.ToString().Split(',')[1]);
                checkbox.BackColor = System.Drawing.Color.Black;
            }
            else
            {
                rows[Int32.Parse(checkbox.Tag.ToString().Split(',')[0])] -= Int32.Parse(checkbox.Tag.ToString().Split(',')[1]);
                checkbox.BackColor = System.Drawing.Color.White;
            }

            UpdateLabels();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hexOutput = radioButton1.Checked;
            UpdateLabels();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hexOutput = radioButton1.Checked;
            UpdateLabels();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(CheckBox))
                {
                    CheckBox checkbox = (CheckBox)c;
                    checkbox.Checked = false;
                }
            }
        }
    }
}
