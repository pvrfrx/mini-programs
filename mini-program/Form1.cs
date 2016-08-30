using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_program
{  
    public partial class MainForm : Form
    {
        int count = 0;
        Random rand;
        public MainForm()
        {
            InitializeComponent();
            rand = new Random();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа создана по мотивам курса \"С#. Мини-программы\" от GeekBrains.\nАвтор: Павел.Р", "О программе");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString();
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            count = 0;
            lblCount.Text = count.ToString();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (cbRandomNoReply.Checked)
            {
                while (true)
                {
                    lblRandom.Text = rand.Next(Convert.ToInt32(nudFrom.Value), Convert.ToInt32(nudTo.Value) + 1).ToString();

                    if (tbRandom.Text.IndexOf(lblRandom.Text) == -1)
                    {
                        tbRandom.AppendText(lblRandom.Text + "\r\n");
                        break;
                    }
                    else if (i > (nudTo.Value - nudFrom.Value + 1))
                    {
                        break;
                    }
                    i++;
                }
            }
            else
            {
                lblRandom.Text = rand.Next(Convert.ToInt32(nudFrom.Value), Convert.ToInt32(nudTo.Value) + 1).ToString();
                tbRandom.AppendText(lblRandom.Text + "\r\n");
            }
        }

        private void btnRandomClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();
        }

        private void btnRandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);
        }
    }
}
