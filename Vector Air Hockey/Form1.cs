using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Diagnostics;

namespace Vector_Air_Hockey
{
    public partial class Form1 : Form
    {
        Rectangle goalOne = new Rectangle(83, 45, 163, 45);
        Rectangle goalTwo = new Rectangle(83, 455, 163, 455);
        int pOneScore;
        int pTwoScore;
        bool mouseHover = false;
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("MS UI Gothic", 16, FontStyle.Bold);
        SolidBrush drawBrush = new SolidBrush(Color.White);

        Pen drawPen = new Pen(Color.White, 3);
        Pen greyPen = new Pen(Color.Gray, 3);
        //Game states
        string gameState = "start"; 
        //Physics variables/stopwatch
        bool collsion = false;
        Stopwatch MyWatch = new Stopwatch();
        float time = 1;
        float Fax;
        float Fay;
        float xFnet;
        float yFnet;
        float xA;
        float yA;
        float XV1;
        float YV1;
        double Cos;
        double Sin;
        int runTime;
        //Input Buttons
        bool wDown;
        bool sDown;
        bool aDown;
        bool dDown;
        bool upArrow;
        bool downArrow;
        bool leftArrow;
        bool rightArrow;
        bool enter;
        bool esc; 
        //player information
        int player1PosX;
        int player1PosY;
        float player1Distance;
        float player1XDistance;
        float player1YDistance;
        int player2PosX;
        int player2PosY;
        float player2Distance;
        float player2XDistance;
        float player2YDistance;
        int playerSpeedX = 4;
        int playerSpeedY = 4;
        //goal information
        bool goalHasBeenScored = false; 
        Vector position = new Vector(100, 100);
        Vector Acceleration = new Vector();
        Vector velocity = new Vector();
        public Form1()
        {
            Vector ballAcceleration = new Vector(xA, yA);
            position.X = 125 - 10;
            position.Y = 250 - 10;

            player1PosX = 125 - 20;
            player1PosY = 80;

            player2PosX = 125 - 20;
            player2PosY = 431 - 40;

            //backgroundLabelTop.Size = new System.Drawing.Size(250, 0);
            //backgroundLabelTop.Size = new System.Drawing.Size(250, 0);
            InitializeComponent();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //keypress inputs 
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrow = false;
                    break;
                case Keys.Down:
                    downArrow = false;
                    break;
                case Keys.Left:
                    leftArrow = false;
                    break;
                case Keys.Right:
                    rightArrow = false;
                    break;
                case Keys.Enter:
                    enter = false;
                    break;
                case Keys.Escape:
                    esc = false;
                    break;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //keyup inputs
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrow = true;
                    break;
                case Keys.Down:
                    downArrow = true;
                    break;
                case Keys.Left:
                    leftArrow = true;
                    break;
                case Keys.Right:
                    rightArrow = true;
                    break;
                case Keys.Enter:
                    enter = true;
                    break;
                case Keys.Escape:
                    esc = true;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == "start")
            {
                //Start up mode
                playerScoredLabel.Location = new System.Drawing.Point(65, 222);
                playerScoredLabel.Text = $"Air Hockey \nPLAY: ENTER \nEXIT: ESC";
                //Starts game
                if (enter == true)
                {
                    gameState = "running";
                    playerScoredLabel.Text = $"";
                    for (int i = 0; i < 500; i++)
                    {
                        backgroundLabelTop.Size = new System.Drawing.Size(250, 500);
                        backgroundLabelTop.Size = new System.Drawing.Size(250, 500 - i);
                        Refresh();

                    }
                    playerScoredLabel.Location = new System.Drawing.Point(24, 241);
                }
                //Closes program
                else if (esc)
                {
                    this.Close(); 
                }
            }
            //used for goal scoring procedure, and game over procedure
            if (gameState == "stalled")
            {
                //restarts game
                if (enter == true)
                {
                    pOneScore = 0;
                    pTwoScore = 0;
                    XV1 = 0;
                    YV1 = 0;
                    position.X = 125 - 10;
                    position.Y = 250 - 10;

                    player1PosX = 125 - 20;
                    player1PosY = 80;

                    player2PosX = 125 - 20;
                    player2PosY = 431 - 40;
                    backgroundLabelTop.Visible = true;
                    gameState = "running"; 
                    for (int i = 0; i < 500; i++)
                    {
                        backgroundLabelTop.Size = new System.Drawing.Size(250, 500 - i);
                        Refresh();
                    }
                    gameTimer.Enabled = true;
                }
                //Closes game
                else if (esc == true)
                {
                    this.Close();
                }
            }
            //game running procedure
            else if (gameState == "running")
            {
                //player one input resolution 
                if (wDown == true && player1PosY > 50)
                {
                    player1PosY -= playerSpeedY;
                }
                if (sDown == true && player1PosY + 42 < 250)
                {
                    player1PosY += playerSpeedY;
                }
                if (aDown == true && player1PosX > 10)
                {
                    player1PosX -= playerSpeedX;
                }
                if (dDown == true && player1PosX < 237 - 40)
                {
                    player1PosX += playerSpeedX;
                }

                //player one input resolution 
                if (upArrow == true && player2PosY - 2 > 250)
                {
                    player2PosY -= playerSpeedY;
                }
                if (downArrow == true && player2PosY < 451 - 35)
                {
                    player2PosY += playerSpeedY;
                }
                if (leftArrow == true && player2PosX > 10)
                {
                    player2PosX -= playerSpeedX;
                }
                if (rightArrow == true && player2PosX < 237 - 40)
                {
                    player2PosX += playerSpeedX;
                }

                //player one's distance to the ball
                player1XDistance = Convert.ToSingle((player1PosX + 20) - (position.X + 10));
                player1YDistance = Convert.ToSingle((player1PosY + 20) - (position.Y + 10));
                player1Distance = Convert.ToSingle(Math.Sqrt(Math.Pow(player1XDistance, 2) + Math.Pow(player1YDistance, 2)));

                //player two's distance to the ball
                player2XDistance = Convert.ToSingle((player2PosX + 20) - (position.X + 10));
                player2YDistance = Convert.ToSingle((player2PosY + 20) - (position.Y + 10));
                player2Distance = Convert.ToSingle(Math.Sqrt(Math.Pow(player2XDistance, 2) + Math.Pow(player2YDistance, 2)));

                //player one collision and angle calculations
                if (player2Distance <= 30)
                {
                    //calculates angle
                    collisionCalculation(player2XDistance, player2YDistance, player2Distance);
                    //Fnet = FA x (mass x coefficiant of friction) 
                    xFnet = Fax;
                    // A = fnet * mass
                    xA = xFnet / 20;
                    XV1 = Convert.ToInt32(xA * time);

                    //Fnet = FA x (mass x coefficiant of friction) 
                    yFnet = Fay;
                    // A = fnet * mass
                    yA = yFnet / 20;
                    //V1 = V2 + A(t)
                    YV1 = Convert.ToInt32(yA * time);
                }

                //player two collision and angle calculations
                if (player1Distance <= 30)
                {
                    //calculates angle
                    collisionCalculation(player1XDistance, player1YDistance, player1Distance);
                    //Fnet = FA x (mass x coefficiant of friction) 
                    xFnet = Fax;
                    // A = fnet * mass
                    xA = xFnet / 20;
                    XV1 = Convert.ToInt32(xA * time);

                    //Fnet = FA x (mass x coefficiant of friction) 
                    yFnet = Fay;
                    // A = fnet * mass
                    yA = yFnet / 20;
                    //V1 = V2 + A(t)
                    YV1 = Convert.ToInt32(yA * time);
                }

                //simulates friction
                runTime++;
                //checks if runtime/8 has a remainder of 0
                if (runTime % 8 == 0)
                {
                    if (XV1 < 0)
                    {
                        XV1++;
                    }
                    else if (XV1 > 0)
                    {
                        XV1--;
                    }

                    if (YV1 < 0)
                    {
                        YV1++;
                    }
                    else if (YV1 > 0)
                    {
                        YV1--;
                    }
                }

                //all weight is represented in grams
                //ball collsion with walls
                if (position.X - 3 <= 10)
                {
                    //collsion with left wall
                    if (XV1 != Math.Abs(XV1))
                    {
                        XV1 = XV1 * -1;
                        position.X = 11;
                    }
                }
                if (position.X + 10 >= 223)
                {
                    //collsion wil right wall
                    if (XV1 == Math.Abs(XV1))
                    {
                        XV1 *= -1;
                        position.X = 223 - 20;
                    }
                }
                if (position.Y <= 50 && position.X <= 83 || position.Y <= 50 && position.X + 20 >= 162)
                {
                    //collision with top wall
                    if (YV1 != Math.Abs(YV1))
                    {
                        YV1 *= -1;
                        position.Y = 50;
                    }
                }
                if (position.Y + 20 >= 451 && position.X + 20 <= 83 || position.Y + 20 >= 451 && position.X + 20 >= 162)
                {
                    //collision bottom wall
                    if (YV1 == Math.Abs(YV1))
                    {
                        YV1 *= -1;
                        position.Y = 451 - 20;
                    }
                }

                //Vector math
                velocity = new Vector(XV1, YV1);
                position += velocity;

                //Goal collision calculation followed by goal scored procedure 
                if (position.Y + 10 < goalOne.Y)
                {
                    XV1 = 0;
                    YV1 = 0;
                    pTwoScore++;
                    playerGoalSleep("TWO", pTwoScore);
                    position.X = 125 - 10;
                    position.Y = 250 - 10;

                    player1PosX = 125 - 20;
                    player1PosY = 80;

                    player2PosX = 125 - 20;
                    player2PosY = 431 - 40;
                }
                //Goal collision calculation followed by goal scored procedure 
                if (position.Y > goalTwo.Y)
                {
                    XV1 = 0;
                    YV1 = 0;
                    pOneScore++;
                    playerGoalSleep("ONE", pOneScore);
                    position.X = 125 - 10;
                    position.Y = 250 - 10;

                    player1PosX = 125 - 20;
                    player1PosY = 80;

                    player2PosX = 125 - 20;
                    player2PosY = 431 - 40;
                }
                Refresh();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Game state check
            if (gameState == "stalled")
            {
                e.Graphics.Clear(Color.Black);
            }
            //Game state check
            else if (gameState == "running")
            {
                e.Graphics.DrawString($"{pOneScore}", drawFont, drawBrush, 218, 228);
                e.Graphics.DrawString($"{pTwoScore}", drawFont, drawBrush, 218, 253);
                e.Graphics.FillEllipse(blueBrush, player1PosX, player1PosY, 40, 40);
                e.Graphics.FillEllipse(redBrush, player2PosX, player2PosY, 40, 40);
                e.Graphics.FillEllipse(whiteBrush, Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 20, 20);
                //rightside line 
                e.Graphics.DrawLine(drawPen, 10, 55, 10, 456);
                //rightside arcs 
                e.Graphics.DrawArc(drawPen, 10, 50, 10, 10, 180, 90);
                e.Graphics.DrawArc(drawPen, 10, 450, 10, 10, 90, 90);
                //leftside line 
                e.Graphics.DrawLine(drawPen, 237, 55, 237, 456);
                //leftside arc
                e.Graphics.DrawArc(drawPen, 227, 50, 10, 10, 0, -90);
                e.Graphics.DrawArc(drawPen, 227, 450, 10, 10, 0, 90);
                //top lines 
                e.Graphics.DrawLine(drawPen, 15, 50, 83, 50);
                e.Graphics.DrawLine(drawPen, 235, 50, 162, 50);
                e.Graphics.DrawLine(drawPen, 83, 50, 83, 20);
                e.Graphics.DrawLine(drawPen, 162, 50, 162, 20);
                e.Graphics.DrawLine(drawPen, 82, 20, 162, 20);
                e.Graphics.DrawLine(greyPen, 82, 50, 162, 50);

                //bottom lines 
                e.Graphics.DrawLine(drawPen, 15, 461, 83, 461);
                e.Graphics.DrawLine(drawPen, 235, 461, 162, 461);
                e.Graphics.DrawLine(drawPen, 83, 461, 83, 491);
                e.Graphics.DrawLine(drawPen, 162, 461, 162, 491);
                e.Graphics.DrawLine(drawPen, 82, 491, 162, 491);
                e.Graphics.DrawLine(greyPen, 82, 461, 162, 461);
                //middle line 
                e.Graphics.DrawLine(drawPen, 10, 250, 237, 250);
            }
           
        }

        public void collisionCalculation(float xDistance, float yDistance, float playerDistance)
        {
            //collision calculations
            // Cos = Cos-1(Adj/Hyp) 
            Cos = Math.Acos((xDistance / playerDistance));
            // Fax = FA * Cos
            Fax = Convert.ToSingle(-1 * (300 * Math.Cos(Cos)));

            // Sin = Sin-1(Opp/Hyp) 
            Sin = Math.Asin((yDistance / playerDistance));
            // Fay = FA * Sin
            Fay = Convert.ToSingle(-1 * (300 * Math.Sin(Sin)));
        }

        public async Task playerGoalSleep(string playerGoal, int playerScore)
        {
            //Player Scored procedure 
            Graphics g = this.CreateGraphics();
            Font drawFont = new Font("MS PGothic", 16, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            gameTimer.Enabled = false;
                for (int i = 0; i < 500; i++)
                {
                //creates wall sinking down animation
                    backgroundLabelTop.Size = new System.Drawing.Size(500, i);
                    Refresh();
                }
           
            backgroundLabelTop.Visible = false;
            //changes game state
            gameState = "stalled";
            //checks if player has won
            if (playerScore == 3)
            {
                gameTimer.Enabled = false;
                gameOver(playerGoal);
            }
            else
            {
                //displays various information on screen
                g.FillRectangle(blackBrush, 0, 0, 250, 500);
                playerScoredLabel.Location = new System.Drawing.Point(24, 241);
                await Task.Delay(750);
                playerScoredLabel.Text = $"PLAYER {playerGoal} SCORED";
                await Task.Delay(750);
                playerScoredLabel.Text = $"";
                await Task.Delay(750);
                playerScoredLabel.Text = $"PLAYER {playerGoal} SCORED";
                await Task.Delay(750);
                playerScoredLabel.Text = $"";
                gameState = "running";
                backgroundLabelTop.Visible = true;
                //creates wall rising up animation
                for (int i = 0; i < 500; i++)
                {
                    backgroundLabelTop.Size = new System.Drawing.Size(250, 500 - i);
                    Refresh();
                }
                gameTimer.Enabled = true;
            }
        }

        public async Task gameOver(string whoWon)
        {
            //Game over procedure
            Graphics g = this.CreateGraphics();
            Font drawFont = new Font("MS PGothic", 14, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            //Game over procedure 
            await Task.Delay(750);
            playerScoredLabel.Location = new System.Drawing.Point(41, 241); 
            playerScoredLabel.Text = $"PLAYER {whoWon} WINS";
            await Task.Delay(750);
            playerScoredLabel.Text = $"";
            await Task.Delay(750);
            playerScoredLabel.Text = $"PLAYER {whoWon} WINS";
            await Task.Delay(750);
            playerScoredLabel.Text = $"";
            await Task.Delay(750);
            g.DrawString($"PLAY AGAIN: ENTER \nEXIT: ESC", drawFont, drawBrush, 24, 241);
            gameTimer.Enabled = true;
        }
    }
}