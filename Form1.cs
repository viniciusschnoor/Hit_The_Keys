using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hit_The_Keys
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Add a key at listbox
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count > 7 )
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game Over");
                timer1.Stop();
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user press the correct key, remove it
            // so increase the game speed
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;
                int progressValue = 800 - timer1.Interval;
                if (progressValue <= 0)
                {
                    difficultyProgressBar.Value = 0;
                }
                else
                {
                    difficultyProgressBar.Value = 800 - timer1.Interval;
                }

                // The user press a correct key so update the object Stats calling the method Update() with True argument
                stats.Update(true);
            }
            else
            {
                // The user pressed a incorrect key, so update the object Stats calling the method Update() with False argument
                stats.Update(false);
            }

            // Update the labels
            correctLabel.Text = "Correct: " + stats.Correct;
            missedLabel.Text = "Missed: " + stats.Missed;
            totalLabel.Text = "Total: " + stats.Total;
            accuracyLabel.Text = "Accuracy: " + stats.Accuracy + "%";
        }
    }
}
