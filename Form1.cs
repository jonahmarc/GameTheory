using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GameTheory
{
    public partial class Form1 : Form
    {
        // ------------------ vs     R A N D O M     variables   ---------------------------------

        int roundsPlayed = 0, size = 0;
        Random random = new Random();
        int firstPlay = 2;
        int[] checkRounds;
        int index = 0;
        int displayRounds = 1;

        int p1po1;
        int p1po2;
        int p1po3;
        int p1po4;
        int p2po1;
        int p2po2;
        int p2po3;
        int p2po4;


        // ------------------  1      vs     1       variables       ---------------------------------

        int rounds_Played = 0, size_ = 0;
        Random random_ = new Random();
        int first_Play = 2;
        int[] check_Rounds;
        int index_ = 0;
        int display_Rounds = 1;

        int p1__po1;
        int p1__po2;
        int p1__po3;
        int p1__po4;
        int p2__po1;
        int p2__po2;
        int p2__po3;
        int p2__po4;

        public Form1()
        {
            InitializeComponent();
        }

        // ------------------ vs     R A N D O M        ---------------------------------
        private void start_Click_1(object sender, EventArgs e)
        {
            try
            {
                roundsPlayed = Convert.ToInt32(rounds.Text);
                size = roundsPlayed * 2;
                checkRounds = new int[roundsPlayed * 2];
                p1po1 = Convert.ToInt32(p1po_1.Text);
                p1po2 = Convert.ToInt32(p1po_2.Text);
                p1po3 = Convert.ToInt32(p1po_3.Text);
                p1po4 = Convert.ToInt32(p1po_4.Text);
                p2po1 = Convert.ToInt32(p2po_1.Text);
                p2po2 = Convert.ToInt32(p2po_2.Text);
                p2po3 = Convert.ToInt32(p2po_3.Text);
                p2po4 = Convert.ToInt32(p2po_4.Text);

                outcome1.Text = "( " + p1po1 + ", " + p2po1 + " )";
                outcome2.Text = "( " + p1po2 + ", " + p2po2 + " )";
                outcome3.Text = "( " + p1po3 + ", " + p2po3 + " )";
                outcome4.Text = "( " + p1po4 + ", " + p2po4 + " )";

                ComputeProbabilityRandom();

                firstPlay = random.Next(2);
                if (firstPlay == 0)
                    MessageBox.Show("YOU Choose A Move First!");
                else if (firstPlay == 1)
                {
                    MessageBox.Show("OPPONENT Makes A Move First!");
                    MessageBox.Show("YOUR TURN!");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error Message:\n\n" + error.Message);
            }
        }

        private void move1_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstPlay == 0 && index != size)
                {
                    checkRounds[index] = 0;

                    int enemyMove = random.Next(2);
                    index++;
                    checkRounds[index] = enemyMove;

                    if (checkRounds[index - 1] == 0 && checkRounds[index] == 0)
                    {
                        p1po1 += Convert.ToInt32(p1score.Text);
                        p2po1 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text = "" + p1po1;
                        p2score.Text = "" + p2po1;
                    }
                    else if (checkRounds[index - 1] == 0 && checkRounds[index] == 1)
                    {
                        p1po2 += Convert.ToInt32(p1score.Text);
                        p2po2 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po2;
                        p2score.Text += p2po2;
                    }
                    else if (checkRounds[index - 1] == 1 && checkRounds[index] == 0)
                    {
                        p1po3 += Convert.ToInt32(p1score.Text);
                        p2po3 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po3;
                        p2score.Text += p2po3;
                    }
                    else if (checkRounds[index - 1] == 1 && checkRounds[index] == 1)
                    {
                        p1po4 += Convert.ToInt32(p1score.Text);
                        p2po4 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po4;
                        p2score.Text += p2po4;
                    }

                    roundsPlayed--;
                    update.Text += "Round  " + displayRounds + " DONE! \n";
                    displayRounds++;
                    index++;

                    if (index == size)
                    {
                        int p1_score = Convert.ToInt32(p1score.Text);
                        int p2_score = Convert.ToInt32(p2score.Text);

                        if (p1_score > p2_score)
                        {
                            MessageBox.Show("YOU WIN !!");
                        }
                        else if (p1_score == p2_score)
                        {
                            MessageBox.Show("DRAW !!");
                        }
                        else
                        {
                            MessageBox.Show("OPPONENT WINS !!");
                        }
                    }
                    else
                        MessageBox.Show("YOUR TURN!");

                }
                else if (firstPlay == 1 && index != size)
                {
                    int enemyMove = random.Next(2);
                    checkRounds[index] = enemyMove;
                    index++;
                    checkRounds[index] = 0;

                    if (checkRounds[index - 1] == 0 && checkRounds[index] == 0)
                    {
                        p1po1 += Convert.ToInt32(p1score.Text);
                        p2po1 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text = "" + p1po1;
                        p2score.Text = "" + p2po1;
                    }
                    else if (checkRounds[index - 1] == 1 && checkRounds[index] == 0)
                    {
                        p1po2 += Convert.ToInt32(p1score.Text);
                        p2po2 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po2;
                        p2score.Text += p2po2;
                    }
                    else if (checkRounds[index - 1] == 0 && checkRounds[index] == 1)
                    {
                        p1po3 += Convert.ToInt32(p1score.Text);
                        p2po3 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po3;
                        p2score.Text += p2po3;
                    }
                    else if (checkRounds[index - 1] == 1 && checkRounds[index] == 1)
                    {
                        p1po4 += Convert.ToInt32(p1score.Text);
                        p2po4 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po4;
                        p2score.Text += p2po4;
                    }

                    roundsPlayed--;
                    update.Text += "Round  " + displayRounds + " DONE! \n";
                    displayRounds++;
                    index++;

                    if (index == size)
                    {
                        int p1_score = Convert.ToInt32(p1score.Text);
                        int p2_score = Convert.ToInt32(p2score.Text);

                        if (p1_score > p2_score)
                        {
                            MessageBox.Show("YOU WIN !!");
                        }
                        else if (p1_score == p2_score)
                        {
                            MessageBox.Show("DRAW !!");
                        }
                        else
                        {
                            MessageBox.Show("OPPONENT WINS !!");
                        }
                    }
                    else
                        MessageBox.Show("YOUR TURN!");

                }

            }
            catch (NullReferenceException err)
            {
                MessageBox.Show("Error Message:\n\n" + err.Message);
            }
        }

        private void move2_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstPlay == 0)
                {
                    checkRounds[index] = 1;

                    int enemyMove = random.Next(2);
                    index++;
                    checkRounds[index] = enemyMove;

                    if (checkRounds[index - 1] == 0 && checkRounds[index] == 0)
                    {
                        p1po1 += Convert.ToInt32(p1score.Text);
                        p2po1 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text = "" + p1po1;
                        p2score.Text = "" + p2po1;
                    }
                    else if (checkRounds[index - 1] == 0 && checkRounds[index] == 1)
                    {
                        p1po2 += Convert.ToInt32(p1score.Text);
                        p2po2 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po2;
                        p2score.Text += p2po2;
                    }
                    else if (checkRounds[index - 1] == 1 && checkRounds[index] == 0)
                    {
                        p1po3 += Convert.ToInt32(p1score.Text);
                        p2po3 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po3;
                        p2score.Text += p2po3;
                    }
                    else if (checkRounds[index - 1] == 1 && checkRounds[index] == 1)
                    {
                        p1po4 += Convert.ToInt32(p1score.Text);
                        p2po4 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po4;
                        p2score.Text += p2po4;
                    }

                    roundsPlayed--;
                    update.Text += "Round  " + displayRounds + " DONE! \n";
                    displayRounds++;
                    index++;

                    if (index == size)
                    {
                        int p1_score = Convert.ToInt32(p1score.Text);
                        int p2_score = Convert.ToInt32(p2score.Text);

                        if (p1_score > p2_score)
                        {
                            MessageBox.Show("YOU WIN !!");
                        }
                        else if (p1_score == p2_score)
                        {
                            MessageBox.Show("DRAW !!");
                        }
                        else
                        {
                            MessageBox.Show("OPPONENT WINS !!");
                        }
                    }
                    else
                        MessageBox.Show("YOUR TURN!");

                }
                else if (firstPlay == 1)
                {
                    int enemyMove = random.Next(2);
                    checkRounds[index] = enemyMove;
                    index++;
                    checkRounds[index] = 1;

                    if (checkRounds[index - 1] == 0 && checkRounds[index] == 0)
                    {
                        p1po1 += Convert.ToInt32(p1score.Text);
                        p2po1 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text = "" + p1po1;
                        p2score.Text = "" + p2po1;
                    }
                    else if (checkRounds[index - 1] == 1 && checkRounds[index] == 0)
                    {
                        p1po2 += Convert.ToInt32(p1score.Text);
                        p2po2 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po2;
                        p2score.Text += p2po2;
                    }
                    else if (checkRounds[index - 1] == 0 && checkRounds[index] == 1)
                    {
                        p1po3 += Convert.ToInt32(p1score.Text);
                        p2po3 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po3;
                        p2score.Text += p2po3;
                    }
                    else if (checkRounds[index - 1] == 1 && checkRounds[index] == 1)
                    {
                        p1po4 += Convert.ToInt32(p1score.Text);
                        p2po4 += Convert.ToInt32(p2score.Text);

                        p1score.Text = "";
                        p2score.Text = "";
                        p1score.Text += p1po4;
                        p2score.Text += p2po4;
                    }

                    roundsPlayed--;
                    update.Text += "Round  " + displayRounds + " DONE! \n";
                    displayRounds++;
                    index++;

                    if (index == size)
                    {
                        int p1_score = Convert.ToInt32(p1score.Text);
                        int p2_score = Convert.ToInt32(p2score.Text);

                        if (p1_score > p2_score)
                        {
                            MessageBox.Show("YOU WIN !!");
                        }
                        else if (p1_score == p2_score)
                        {
                            MessageBox.Show("DRAW !!");
                        }
                        else
                        {
                            MessageBox.Show("OPPONENT WINS !!");
                        }
                    }
                    else
                        MessageBox.Show("YOUR TURN!");

                }

            }
            catch (NullReferenceException err)
            {
                MessageBox.Show("Error Message:\n\n" + err.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetRandom();
        }
        private void exitGame_Click_1(object sender, EventArgs e)
        {
            Close();
        }


        //---------------------------   1     vs       1 --------------------------------------------

        private void start2_Click(object sender, EventArgs e)
        {
            try
            {
                rounds_Played = Convert.ToInt32(rounds2.Text);
                size_ = rounds_Played * 2;
                check_Rounds = new int[rounds_Played * 2];
                p1__po1 = Convert.ToInt32(p1_po1.Text);
                p1__po2 = Convert.ToInt32(p1_po2.Text);
                p1__po3 = Convert.ToInt32(p1_po3.Text);
                p1__po4 = Convert.ToInt32(p1_po4.Text);
                p2__po1 = Convert.ToInt32(p2_po1.Text);
                p2__po2 = Convert.ToInt32(p2_po2.Text);
                p2__po3 = Convert.ToInt32(p2_po3.Text);
                p2__po4 = Convert.ToInt32(p2_po4.Text);

                outcome_1.Text = "( " + p1__po1 + ", " + p2__po1 + " )";
                outcome_2.Text = "( " + p1__po2 + ", " + p2__po2 + " )";
                outcome_3.Text = "( " + p1__po3 + ", " + p2__po3 + " )";
                outcome_4.Text = "( " + p1__po4 + ", " + p2__po4 + " )";

                ComputeProbability1v1();

                first_Play = random_.Next(2);
                if (first_Play == 0)
                    MessageBox.Show("YOU Choose a Move First!");
                else if (first_Play == 1)
                    MessageBox.Show("OPPONENT Makes a MoveFirst!");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Message:\n\n" + error.Message);
            }
        }

        private void move_1_Click(object sender, EventArgs e)
        {
            try
            {
                check_Rounds[index_] = 0;
                if (first_Play == 0)
                {
                    if (index_ % 2 != 0)
                    {
                        if (check_Rounds[index_ - 1] == 0 && check_Rounds[index_] == 0)
                        {
                            p1__po1 += Convert.ToInt32(p1_score.Text);
                            p2__po1 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text = "";
                            p2_score.Text = "";
                            p1_score.Text = "" + p1__po1;
                            p2_score.Text = "" + p2__po1;
                        }
                        else if (check_Rounds[index_ - 1] == 0 && check_Rounds[index_] == 1)
                        {
                            p1__po2 += Convert.ToInt32(p1_score.Text);
                            p2__po2 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text = "";
                            p2_score.Text = "";
                            p1_score.Text += p1__po2;
                            p2_score.Text += p2__po2;
                        }
                        else if (check_Rounds[index_ - 1] == 1 && check_Rounds[index_] == 0)
                        {
                            p1__po3 += Convert.ToInt32(p1_score.Text);
                            p2__po3 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text = "";
                            p2_score.Text = "";
                            p1_score.Text += p1__po3;
                            p2_score.Text += p2__po3;
                        }
                        else if (check_Rounds[index_ - 1] == 1 && check_Rounds[index_] == 1)
                        {
                            p1__po4 += Convert.ToInt32(p1_score.Text);
                            p2__po4 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text = "";
                            p2_score.Text = "";
                            p1_score.Text += p1__po4;
                            p2_score.Text += p2__po4;
                        }

                        rounds_Played--;
                        update2.Text += "Round  " + display_Rounds + ": Player 2 done! \n";
                        index_++;
                        display_Rounds++;

                        if (index_ == size_)
                        {
                            int p1__score = Convert.ToInt32(p1_score.Text);
                            int p2__score = Convert.ToInt32(p2_score.Text);
                            if (p1__score > p2__score)
                            {
                                MessageBox.Show("YOU WIN !!");
                            }
                            else if (p1__score == p2__score)
                            {
                                MessageBox.Show("DRAW !!");
                            }
                            else
                            {
                                MessageBox.Show("OPPONENT WINS !!");
                            }

                        }
                    }
                    else
                    {
                        update2.Text += "Round  " + display_Rounds + ": Player 1 done! \n";
                        index_++;
                    }
                }
                else if (first_Play == 1)
                {
                    if (index_ % 2 != 0)
                    {
                        if (check_Rounds[index_ - 1] == 0 && check_Rounds[index_] == 0)
                        {
                            p1__po1 += Convert.ToInt32(p1_score.Text);
                            p2__po1 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text += p1__po1;
                            p2_score.Text += p2__po1;
                        }
                        else if (check_Rounds[index_ - 1] == 1 && check_Rounds[index_] == 0)
                        {
                            p1__po2 += Convert.ToInt32(p1_score.Text);
                            p2__po2 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text += p1__po2;
                            p2_score.Text += p2__po2;
                        }
                        else if (check_Rounds[index_ - 1] == 0 && check_Rounds[index_] == 1)
                        {
                            p1__po3 += Convert.ToInt32(p1_score.Text);
                            p2__po3 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text += p1__po3;
                            p2_score.Text += p2__po3;
                        }
                        else if (check_Rounds[index_ - 1] == 1 && check_Rounds[index_] == 1)
                        {
                            p1__po4 += Convert.ToInt32(p1_score.Text);
                            p2__po4 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text += p1__po4;
                            p2_score.Text += p2__po4;
                        }

                        rounds_Played--;
                        update2.Text += "Round  " + display_Rounds + ": Player 1 done! \n";
                        index_++;
                        display_Rounds++;

                        if (index_ == size_)
                        {
                            int p1__score = Convert.ToInt32(p1_score.Text);
                            int p2__score = Convert.ToInt32(p2_score.Text);
                            if (p1__score > p2__score)
                            {
                                MessageBox.Show("YOU WIN !!");
                            }
                            else if (p1__score == p2__score)
                            {
                                MessageBox.Show("DRAW !!");
                            }
                            else
                            {
                                MessageBox.Show("OPPONENT WINS !!");
                            }
                        }
                    }
                    else
                    {
                        update2.Text += "Round  " + display_Rounds + ": Player 2 done! \n";
                        index_++;
                    }
                }
            }
            catch (NullReferenceException err)
            {
                MessageBox.Show("Error Message:\n\n" + err.Message);
            }
        }

        private void move_2_Click(object sender, EventArgs e)
        {
            try
            {
                check_Rounds[index_] = 1;
                if (first_Play == 0)
                {
                    if (index_ % 2 != 0)
                    {
                        if (check_Rounds[index_ - 1] == 0 && check_Rounds[index_] == 0)
                        {
                            p1__po1 += Convert.ToInt32(p1_score.Text);
                            p2__po1 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text = "";
                            p2_score.Text = "";
                            p1_score.Text = "" + p1__po1;
                            p2_score.Text = "" + p2__po1;
                        }
                        else if (check_Rounds[index_ - 1] == 0 && check_Rounds[index_] == 1)
                        {
                            p1__po2 += Convert.ToInt32(p1_score.Text);
                            p2__po2 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text = "";
                            p2_score.Text = "";
                            p1_score.Text += p1__po2;
                            p2_score.Text += p2__po2;
                        }
                        else if (check_Rounds[index_ - 1] == 1 && check_Rounds[index_] == 0)
                        {
                            p1__po3 += Convert.ToInt32(p1_score.Text);
                            p2__po3 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text = "";
                            p2_score.Text = "";
                            p1_score.Text += p1__po3;
                            p2_score.Text += p2__po3;
                        }
                        else if (check_Rounds[index_ - 1] == 1 && check_Rounds[index_] == 1)
                        {
                            p1__po4 += Convert.ToInt32(p1_score.Text);
                            p2__po4 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text = "";
                            p2_score.Text = "";
                            p1_score.Text += p1__po4;
                            p2_score.Text += p2__po4;
                        }

                        rounds_Played--;
                        update2.Text += "Round  " + display_Rounds + ": Player 2 done! \n";
                        index_++;
                        display_Rounds++;

                        if (index_ == size_)
                        {
                            int p1__score = Convert.ToInt32(p1_score.Text);
                            int p2__score = Convert.ToInt32(p2_score.Text);
                            if (p1__score > p2__score)
                            {
                                MessageBox.Show("YOU WIN !!");
                            }
                            else if (p1__score == p2__score)
                            {
                                MessageBox.Show("DRAW !!");
                            }
                            else
                            {
                                MessageBox.Show("OPPONENT WINS !!");
                            }

                        }
                    }
                    else
                    {
                        update2.Text += "Round  " + display_Rounds + ": Player 1 done! \n";
                        index_++;
                    }
                }
                else if (first_Play == 1)
                {
                    if (index_ % 2 != 0)
                    {
                        if (check_Rounds[index_ - 1] == 0 && check_Rounds[index_] == 0)
                        {
                            p1__po1 += Convert.ToInt32(p1_score.Text);
                            p2__po1 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text += p1__po1;
                            p2_score.Text += p2__po1;
                        }
                        else if (check_Rounds[index_ - 1] == 1 && check_Rounds[index_] == 0)
                        {
                            p1__po2 += Convert.ToInt32(p1_score.Text);
                            p2__po2 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text += p1__po2;
                            p2_score.Text += p2__po2;
                        }
                        else if (check_Rounds[index_ - 1] == 0 && check_Rounds[index_] == 1)
                        {
                            p1__po3 += Convert.ToInt32(p1_score.Text);
                            p2__po3 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text += p1__po3;
                            p2_score.Text += p2__po3;
                        }
                        else if (check_Rounds[index_ - 1] == 1 && check_Rounds[index_] == 1)
                        {
                            p1__po4 += Convert.ToInt32(p1_score.Text);
                            p2__po4 += Convert.ToInt32(p2_score.Text);

                            p1_score.Text += p1__po4;
                            p2_score.Text += p2__po4;
                        }

                        rounds_Played--;
                        update2.Text += "Round  " + display_Rounds + ": Player 1 done! \n";
                        index_++;
                        display_Rounds++;

                        if (index_ == size_)
                        {
                            int p1__score = Convert.ToInt32(p1_score.Text);
                            int p2__score = Convert.ToInt32(p2_score.Text);
                            if (p1__score > p2__score)
                            {
                                MessageBox.Show("YOU WIN !!");
                            }
                            else if (p1__score == p2__score)
                            {
                                MessageBox.Show("DRAW !!");
                            }
                            else
                            {
                                MessageBox.Show("OPPONENT WINS !!");
                            }
                        }
                    }
                    else
                    {
                        update2.Text += "Round  " + display_Rounds + ": Player 2 done! \n";
                        index_++;
                    }
                }
            }
            catch (NullReferenceException err)
            {
                MessageBox.Show("Error Message:\n\n" + err.Message);
            }
        }

        private void reset2_Click(object sender, EventArgs e)
        {
            Reset1v1();
        }
        private void exit2_Click(object sender, EventArgs e)
        {
            Close();
        }






        //---------------------- H  E   L   P   E   R     function   ---------------------


        public void ComputeProbabilityRandom()
        {
            int diff1 = Math.Abs(p1po1 - p2po1);
            int diff2 = Math.Abs(p1po2 - p2po2);
            int diff3 = Math.Abs(p1po3 - p2po3);
            int diff4 = Math.Abs(p1po4 - p2po4);

            if (p1po1 < p2po1 && p1po2 < p2po2)
            {
                if(diff1 < diff2)
                    probability1.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 20%\n\n   TO MOVE 2 -- 30%";
                else
                    probability1.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 30%\n\n   TO MOVE 2 -- 20%";
            }
            else if (p1po1 > p2po1 && p1po2 < p2po2)
            {
                probability1.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 20%\n\n   TO MOVE 2 -- 30%";
            }
            else if (p1po1 < p2po1 && p1po2 > p2po2)
            {
                probability1.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 30%\n\n   TO MOVE 2 -- 20%";
            }
            else if (p1po1 == p2po1 && p1po2 == p2po2)
            {
                probability1.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 25%\n\n   TO MOVE 2 -- 25%";
            }
            else
                probability1.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 25%\n\n   TO MOVE 2 -- 25%";


            if (p1po3 < p2po3 && p1po4 < p2po4)
            {
                if (diff3 < diff4)
                    probability2.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 20%\n\n   TO MOVE 2 -- 30%";
                else
                    probability2.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 30%\n\n   TO MOVE 2 -- 20%";
            }
            else if (p1po3 > p2po3 && p1po4 < p2po4)
            {
                probability2.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 20%\n\n   TO MOVE 2 -- 30%";
            }
            else if (p1po3 < p2po3 && p1po4 > p2po4)
            {
                probability2.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 30%\n\n   TO MOVE 2 -- 20%";
            }
            else if (p1po3 == p2po3 && p1po4 == p2po4)
            {
                probability2.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 25%\n\n   TO MOVE 2 -- 25%";
            }
            else
                probability2.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 25%\n\n   TO MOVE 2 -- 25%";

        }


        public void ComputeProbability1v1()
        {
            int diff1 = Math.Abs(p1__po1 - p2__po1);
            int diff2 = Math.Abs(p1__po2 - p2__po2);
            int diff3 = Math.Abs(p1__po3 - p2__po3);
            int diff4 = Math.Abs(p1__po4 - p2__po4);

            if (p1__po1 < p2__po1 && p1__po2 < p2__po2)
            {
                if (diff1 < diff2)
                    probability3.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 20%\n\n   TO MOVE 2 -- 30%";
                else
                    probability3.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 30%\n\n   TO MOVE 2 -- 20%";
            }
            else if (p1__po1 > p2__po1 && p1__po2 < p2__po2)
            {
                probability3.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 20%\n\n   TO MOVE 2 -- 30%";
            }
            else if (p1__po1 < p2__po1 && p1__po2 > p2__po2)
            {
                probability3.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 30%\n\n   TO MOVE 2 -- 20%";
            }
            else if (p1__po1 == p2__po1 && p1__po2 == p2__po2)
            {
                probability3.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 25%\n\n   TO MOVE 2 -- 25%";
            }
            else
                probability3.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 25%\n\n   TO MOVE 2 -- 25%";


            if (p1__po3 < p2__po3 && p1__po4 < p2__po4)
            {
                if (diff3 < diff4)
                    probability4.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 20%\n\n   TO MOVE 2 -- 30%";
                else
                    probability4.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 30%\n\n   TO MOVE 2 -- 20%";
            }
            else if (p1__po3 > p2__po3 && p1__po4 < p2__po4)
            {
                probability4.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 20%\n\n   TO MOVE 2 -- 30%";
            }
            else if (p1__po3 < p2__po3 && p1__po4 > p2__po4)
            {
                probability4.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 30%\n\n   TO MOVE 2 -- 20%";
            }
            else if (p1__po3 == p2__po3 && p1__po4 == p2__po4)
            {
                probability4.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 25%\n\n   TO MOVE 2 -- 25%";
            }
            else
                probability4.Text = "Probability of the Enemy:\n\n   TO MOVE 1 -- 25%\n\n   TO MOVE 2 -- 25%";

        }

        public void ResetRandom()
        {

            //---------- vs     R  A  N  D  O  M  -----------

            p1po_1.Text = "";
            p1po_2.Text = "";
            p1po_3.Text = "";
            p1po_4.Text = "";
            p2po_1.Text = "";
            p2po_2.Text = "";
            p2po_3.Text = "";
            p2po_4.Text = "";
            rounds.Text = "";

            outcome1.Text = "";
            outcome2.Text = "";
            outcome3.Text = "";
            outcome4.Text = "";

            p1score.Text = "0";
            p2score.Text = "0";

            update.Text = "";

            displayRounds = 1;
            firstPlay = 2;
            index = 0;

            probability1.Text = "";
            probability2.Text = "";

        }

        public void Reset1v1()
        {
            //----------- 1    vs    1  ----------------

            p1_po1.Text = "";
            p1_po2.Text = "";
            p1_po3.Text = "";
            p1_po4.Text = "";
            p2_po1.Text = "";
            p2_po2.Text = "";
            p2_po3.Text = "";
            p2_po4.Text = "";
            rounds2.Text = "";

            outcome_1.Text = "";
            outcome_2.Text = "";
            outcome_3.Text = "";
            outcome_4.Text = "";

            p1_score.Text = "0";
            p2_score.Text = "0";

            update2.Text = "";

            display_Rounds = 1;
            first_Play = 2;
            index_ = 0;

            probability3.Text = "";
            probability4.Text = "";
        }
    }
}
