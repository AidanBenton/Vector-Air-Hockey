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
        int pOneScore;
        int pTwoScore; 
        bool mouseHover = false; 
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blackBrush = new SolidBrush(Color.White);
        Pen drawPen = new Pen(Color.White, 3);
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
        //player information
        double Cos;
        double Sin;
        int player1PosX;
        int player1PosY;
        float player1Distance;
        float player1XDistance;
        float player1YDistance;
        int player1SpeedX = 4;
        int player1SpeedY = 4;
        
        Vector position = new Vector(100, 100);
        Vector Acceleration = new Vector();
        Vector velocity = new Vector();
        public Form1()
        {
            Vector ballAcceleration = new Vector(xA, yA);
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
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrow = false;
                    break;
                case Keys.Down:
                    downArrow = false;
                    break;
                case Keys.Left:
                    aDown = false;
                    break;
                case Keys.Right:
                    rightArrow = false;
                    break;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            faxLabel.Text = $"{player1PosX}"; 
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
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrow = true;
                    break;
                case Keys.Down:
                    downArrow = true;
                    break;
                case Keys.Left:
                    aDown = true;
                    break;
                case Keys.Right:
                    rightArrow = true;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {

          

            //ball stuck with walls 
            if (position.X == 10)
            {
                MyWatch.Start();
            }
            else
            {
                MyWatch.Stop();
            }


            if (wDown == true && player1PosY > 50)
            {
                player1PosY -= player1SpeedY;
            }
            if (sDown == true && player1PosY < 451 - 35)
            {
                player1PosY += player1SpeedY;
            }
            if (aDown == true && player1PosX > 0)
            {
                player1PosX -= player1SpeedX;
            }
            if (dDown == true && player1PosX < this.Width)
            {
                player1PosX += player1SpeedX;
            }
            player1XDistance = Convert.ToSingle((player1PosX + 20) - (position.X + 10));
            player1YDistance = Convert.ToSingle((player1PosY + 20) - (position.Y + 10));
            player1Distance = Convert.ToSingle(Math.Sqrt(Math.Pow(player1XDistance, 2) + Math.Pow(player1YDistance, 2)));
            //Angle and friction calculations
            if (player1Distance <= 30)
            {
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
            runTime++;
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

               
            aXLabel.Text = $"{XV1}";

            //ball collsion with walls
            if (position.X -3  <= 10)
            {

                if (XV1 != Math.Abs(XV1))
                {
                    XV1 = XV1 * -1;
                    position.X = 11;
                }
            }
            if (position.X + 10 >= 223)
            {
                if (XV1 == Math.Abs(XV1))
                {
                    XV1 *= -1;
                }
            }
            if (position.Y <= 50 && position.X <=  83 - 10 || position.Y <= 50 && position.X >= 163)
            {
                if (YV1 != Math.Abs(YV1))
                {
                    YV1 *= -1;
                }
            }
            if (position.Y >= 451 - 10 && position.X <=  83 - 10 || position.Y >= 451 - 10 && position.X >= 163)
            {
                if (YV1 == Math.Abs(YV1))
                {
                    YV1 *= -1;
                }
            }

            //Ball scoring 
            if (position.Y == 35)
            {
                pTwoScore++; 
            }

            if (position.Y == 466)
            {
                pOneScore++; 
            }


            faxLabel.Text = $"{XV1}";
            velocity = new Vector(XV1, YV1);
            position += velocity;
            Refresh();
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillEllipse(blueBrush, player1PosX, player1PosY, 40, 40);
                e.Graphics.FillEllipse(blackBrush, Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 20, 20);
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
                e.Graphics.DrawLine(drawPen, 83, 50, 83, 0); 
                //bottom lines 
                e.Graphics.DrawLine(drawPen, 15, 461, 83, 461);
                e.Graphics.DrawLine(drawPen, 235, 461, 162, 461);
                //middle line 
                e.Graphics.DrawLine(drawPen, 10, 250, 237, 250); 
        }

            public void collisionCalculation(float xDistance, float yDistance, float playerDistance)
            {
                // Cos = Cos-1(Adj/Hyp) 
                Cos = Math.Acos((xDistance / playerDistance));
                // Fax = FA * Cos
                Fax = Convert.ToSingle(-1 * (300 * Math.Cos(Cos)));

                // Sin = Sin-1(Opp/Hyp) 
                Sin = Math.Asin((yDistance / playerDistance));
                // Fay = FA * Sin
                Fay = Convert.ToSingle(-1 * (300 * Math.Sin(Sin)));
            }

     
    }
    }
