using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace math2
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        Random randomizer = new Random();

        int addend1;
        int addend2;
        int addend3;
        int addend4;

        int minuend;
        int subtrahend;
        int minuend1;
        int subtrahend1;

        int multiplicand;
        int multiplier;
        int multiplicand1;
        int multiplier1;


        int dividend;
        int divisor;
        int dividend1;
        int divisor1;

        int timeLeft;

        public void StartTheQuiz()
        {
            //+
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            addend3 = randomizer.Next(51);
            addend4 = randomizer.Next(51);
            plusLeftLabel1.Text = addend3.ToString();
            plusRightLabel1.Text = addend4.ToString();
            sum1.Value = 0;
            // -
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            minuend1 = randomizer.Next(1, 101);
            subtrahend1 = randomizer.Next(1, minuend1);
            minusLeftLabel1.Text = minuend1.ToString();
            minusRightLabel1.Text = subtrahend1.ToString();
            difference1.Value = 0;
            //   *
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            multiplicand1 = randomizer.Next(2, 11);
            multiplier1 = randomizer.Next(2, 11);
            timesLeftLabel1.Text = multiplicand1.ToString();
            timesRightLabel1.Text = multiplier1.ToString();
            product.Value = 0;
            //  /
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            divisor1 = randomizer.Next(2, 11);
            int temporaryQuotient1 = randomizer.Next(2, 11);
            dividend1 = divisor1 * temporaryQuotient1;
            dividedLeftLabel1.Text = dividend1.ToString();
            dividedRightLabel1.Text = divisor1.ToString();
            quotient.Value = 0;

            timeLeft = 60;
            timeLabel.Text = "60 seconds";
            timer1.Start();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {

                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                timeLabel.BackColor = Color.Orange;
            }
            else
            {

                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend3 + addend4;
                button1.Enabled = true;
            }
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                button1.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() return false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = addend1 + addend2;
                sum1.Value = addend3 + addend4;
                difference.Value = minuend - subtrahend;
                difference1.Value = minuend1 - subtrahend1;
                product.Value = multiplicand * multiplier;
                product1.Value = multiplicand1 * multiplier1;
                quotient.Value = dividend / divisor;
                quotient1.Value = dividend1 / divisor1;
                button1.Enabled = true;
            }
            
             if (timeLeft < 11)
            {
                timeLabel.BackColor = Color.Red;
            }
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
         && (addend3 + addend4 == sum1.Value)
         && (minuend - subtrahend == difference.Value)
         && (minuend1 - subtrahend1 == difference1.Value)
         && (multiplicand * multiplier == product.Value)
         && (multiplicand1 * multiplier1 == product1.Value)
         && (dividend / divisor == quotient.Value)
         && (dividend1 / divisor1 == quotient1.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
           // MessageBox.Show("You are in the NumericUpDown.ValueChanged event.");
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
