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

namespace Vector_Air_Hockey
{

    public partial class Form1 : Form
    {
        
      
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blackBrush = new SolidBrush(Color.White);
        Pen drawPen = new Pen(Color.White, 3);
        //Physics variables
        double time = 2;
        double Fax;
        double Fay; 
        double xFnet;
        double yFnet;
        double xA;
        double yA;
        int XV1;
        int YV1;
        //Input Buttons
        bool wDown;
        bool sDown;
        bool aDown;
        bool dDown;
        //player information
        double Cos;
        double Sin; 
        int player1PosX;
        int player1PosY;
        double player1Distance;
        double player1XDistance;
        double player1YDistance;
        int player1SpeedX = 2;
        int player1SpeedY = 2;
        Vector ballPos = new Vector(200,200);
        Vector velocity = new Vector(); 
        public Form1()
        {
           
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
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (wDown == true && player1PosY > 0)
            {
                player1PosY -= player1SpeedY;
            }

            if (sDown == true && player1PosY < this.Height - 40)
            {
                player1PosY += player1SpeedY;
            }
            if (aDown == true && player1PosX > 0)
            {
                player1PosX -= player1SpeedX;
            }

            if (dDown == true && player1PosX < this.Height - 40)
            {
                player1PosX += player1SpeedX;
            }
            player1XDistance = (player1PosX + 20) - (ballPos.X + 10);
            player1YDistance = (player1PosY + 20) - (ballPos.Y + 10);
            player1Distance = Math.Sqrt(Math.Pow(player1XDistance, 2) + Math.Pow(player1YDistance, 2)); 
            if (player1Distance <= 30)
            {
                collisionCalculation(player1XDistance, player1YDistance, player1Distance);  
            }
            faxLabel.Text = $"XFnet: {xFnet}";
            aXLabel.Text = $"xA: {xA}";
            VX1Label.Text = $"XV1: {XV1}";

            //all weight is represented in grams

            //Fnet = FA x (mass x coefficiant of friction) 
            xFnet = Fax - (20 * 0.015);
            // A = fnet * mass
            xA = xFnet / 20;
            //V1 = V2 + A(t)
            XV1 = Convert.ToInt32(xA * time);

            //Fnet = FA x (mass x coefficiant of friction) 
            yFnet = Fay - (20 * 0.015);
            // A = fnet * mass
            yA = yFnet / 20;
            //V1 = V2 + A(t)
            YV1 = Convert.ToInt32(yA * time);

            velocity = new Vector(XV1, YV1);
            ballPos = ballPos + velocity;

            Refresh();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(blueBrush, player1PosX, player1PosY, 40, 40);
            e.Graphics.FillEllipse(blackBrush, Convert.ToInt32(ballPos.X), Convert.ToInt32(ballPos.Y), 20, 20);
            e.Graphics.DrawLine(drawPen, 10, 45, 10, 415);
            e.Graphics.DrawArc(drawPen, 10, 30, 30, 30, 180, 90);
            e.Graphics.DrawArc(drawPen, 10, 399, 30, 30, 90, 90);
            e.Graphics.DrawLine(drawPen, 224, 45, 224, 415);
            e.Graphics.DrawArc(drawPen, 194, 30, 30, 30, 0, -90);
            e.Graphics.DrawArc(drawPen, 194, 399, 30, 30, 0, 90);
            e.Graphics.DrawLine(drawPen, 25, 30, 100, 30);
        }

        public void collisionCalculation(double xDistance, double yDistance, double playerDistance)
        {

            if (player1PosY < ballPos.Y)
            {
                // Cos = Cos-1(Adj/Hyp) 
                Cos = Math.Acos(((xDistance + 20) - (ballPos.X + 10)) / playerDistance);
                // Fax = FA * Cos
                Fax = 200 * Math.Cos(Cos);

                // Sin = Sin-1(Opp/Hyp) 
                Sin = Math.Asin(((xDistance + 20) - (ballPos.X + 10)) / playerDistance);
                // Fay = FA * Sin
                Fay = 200 * Math.Sin(Sin);
            }
        }
    }
}
