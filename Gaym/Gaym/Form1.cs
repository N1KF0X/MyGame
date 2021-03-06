using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaym
{
    public partial class Form1 : Form
    {
        Label labelFirst = null;
        Label labelSecond = null;
        Random random = new Random();
        int attempts = 0;
        int attempts1 = 16;

        private void InitOfCupls()
        {
            List<string> pictures = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k",
                "b", "b", "v", "v", "w", "w", "z", "z"
            };
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(pictures.Count);
                    iconLabel.Text = pictures[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    pictures.RemoveAt(randomNumber);
                }
            }
            labelFirst = null;
            labelSecond = null;
            attempts = 0;
            attempts1 = 16;
            label17.Text = "Оставшиеся попытки: " + attempts1;
        }
        public Form1()
        {
            InitializeComponent();

            InitOfCupls();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (labelFirst == null)
                {
                    labelFirst = clickedLabel;
                    labelFirst.ForeColor = Color.Black;
                    return;
                }

                labelSecond = clickedLabel;
                labelSecond.ForeColor = Color.Black;
                attempts++;
                attempts1--;
                label17.Text = "Оставшиеся попытки: " + attempts1;

                CheckForWinner();
                if (labelFirst==null)
                {
                    return;
                }

                if (labelFirst.Text == labelSecond.Text)
                {
                    labelFirst = null;
                    labelSecond = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            labelFirst.ForeColor = labelFirst.BackColor;
            labelSecond.ForeColor = labelSecond.BackColor;

            labelFirst = null;
            labelSecond = null;
        }

        private void CheckForWinner()
        {
            if (attempts == 16)
            {
                MessageBox.Show("Вы потратилли слишлом много попыток","Провал :(");
                InitOfCupls();
            }
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("Вы нашли все пары.\n Вы использовали "+attempts+" попыток.", "Победа!");
            InitOfCupls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitOfCupls();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
