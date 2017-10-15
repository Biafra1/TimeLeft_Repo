using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YourTime {
    public partial class Form1 : Form {

        double timeAliveInSeconds;
        double lifeSpan = 2230000000; //seconds
        double timeLeft;
        double timeLeftInPercent;
        bool isDead;

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            isDead = false;
            DateTime yourDate = new DateTime((int)yearBox.Value, (int)monthBox.Value, (int)dayBox.Value);
            DateTime today = DateTime.Today;
            TimeSpan timeAlive = today.Subtract(yourDate);
            timeAliveInSeconds = timeAlive.TotalSeconds;

            timeLabel.Text = "" + timeAliveInSeconds+" seconds.";
            timeLeft = lifeSpan - timeAliveInSeconds;
            if (timeLeft < 0) {
                isDead = true;
            }

            timeLeftLabel.Text = "" + timeLeft+" seconds left to live..";
            //timeLeftInPercent = (inSeconds / timeLeft) + "%";

            if (!isDead) {
                progressBar1.Value = (int)(timeAliveInSeconds / 223);
            }


            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e) {
            timeAliveInSeconds++;
            timeLabel.Text = "" + timeAliveInSeconds + " seconds.";
            if (timeLeft < 0) {
                timeLeftLabel.Text = "You should be dead by now!";
            } else {
                timeLeft--;
                timeLeftLabel.Text = "" + timeLeft + " seconds left to live..";
            }


            timeLeftInPercent = (timeAliveInSeconds/lifeSpan)*100;
            progressLabel.Text = timeLeftInPercent+"% finished.";
            if (!isDead) {
                progressBar1.Value = (int)(timeAliveInSeconds / 223);
            }
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) {
            switch (comboBox1.SelectedItem) {
                case "Europe":
                    lifeSpan *= 1.06;
                    break;
                case "Africa":
                    lifeSpan *= 0.89;
                    break;
                case "Asia":
                    lifeSpan = 2230000000;
                    break;
                case "North America":
                    lifeSpan *= 1.07;
                    break;
                case "South America":
                    lifeSpan *= 1.04;
                    break;
                default:
                    lifeSpan = 2230000000;
                    break;
            }
        }
    }
}
