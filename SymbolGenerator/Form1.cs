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
        private TextBox[] txtBoxes = new TextBox[16];
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

            txtBoxes[0] = this.txtBRow0;
            txtBoxes[1] = this.txtBRow1;
            txtBoxes[2] = this.txtBRow2;
            txtBoxes[3] = this.txtBRow3;
            txtBoxes[4] = this.txtBRow4;
            txtBoxes[5] = this.txtBRow5;
            txtBoxes[6] = this.txtBRow6;
            txtBoxes[7] = this.txtBRow7;
            txtBoxes[8] = this.txtBRow8;
            txtBoxes[9] = this.txtBRow9;
            txtBoxes[10] = this.txtBRow10;
            txtBoxes[11] = this.txtBRow11;
            txtBoxes[12] = this.txtBRow12;
            txtBoxes[13] = this.txtBRow13;
            txtBoxes[14] = this.txtBRow14;
            txtBoxes[15] = this.txtBRow15;

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
                    txtBoxes[a].Text = rows[a].ToString("X");
                    output += rows[a].ToString("X") + ",";
                }
            }
            else
            {
                for (int a = 0; a < 16; a++)
                {
                    txtBoxes[a].Text = rows[a].ToString();
                    output += rows[a].ToString() + ",";
                }
            }
            txtOutput.Text = output.Substring(0, output.Length - 1);
        }

        private void CheckBox_CheckChanged(Object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int boxval = Int32.Parse(checkbox.Tag.ToString().Split(',')[1]);
            if (checkbox.Checked)
            {
                checkbox.BackColor = System.Drawing.Color.Black;
            }
            else
            {
                checkbox.BackColor = System.Drawing.Color.White;
            }

            int row = Int32.Parse(checkbox.Tag.ToString().Split(',')[0]);
            rows[row] = 0;
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox && c.Tag != null && c.Tag.ToString() != "")
                {
                    if (c.Tag.ToString().Split(',')[0] == row.ToString())
                    {
                        CheckBox cb = c as CheckBox;
                        if (cb.Checked)
                        {
                            int value = Int32.Parse(cb.Tag.ToString().Split(',')[1]);
                            rows[row] += value;
                        }
                    }
                }
            }

            UpdateLabels();
        }

        private void TextBox_TextChanged(Object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Text == "")
            {
                textbox.Text = "0";
            }
            string value = Convert.ToString(int.Parse(textbox.Text),2);
            string row = textbox.Tag.ToString();
            var rowBoxes = new List<CheckBox>();
            // get the CheckBoxes in this row into a list
            foreach(Control c in this.Controls)
            {
                if (c is CheckBox && c.Tag != null && c.Tag.ToString() != "")
                {
                    if (c.Tag.ToString().Split(',')[0] == row)
                    {
                        rowBoxes.Add((CheckBox)c);
                    }
                }
            }
            int bitval = 128;
            for(int index = 8; index > 0; index--)
            {
                // get the checkbox for this bit
                foreach(Control c in rowBoxes)
                {
                    CheckBox cb = c as CheckBox;
                    if (cb.Tag.ToString() == row + "," + bitval.ToString())
                    {
                        if (index < value.Length + 1)
                        {
                            if (value[value.Length - index] == '1')
                            {
                                cb.Checked = true;
                            }
                            else
                            {
                                cb.Checked = false;
                            }
                        } else
                        {
                            cb.Checked = false;
                        }
                    }
                }
                bitval /= 2;
            }
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
