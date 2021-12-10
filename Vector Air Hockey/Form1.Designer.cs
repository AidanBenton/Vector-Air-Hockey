
namespace Vector_Air_Hockey
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.playerScoredLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundLabelTop = new System.Windows.Forms.Label();
            this.backgroundLabelBottom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 17;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // playerScoredLabel
            // 
            this.playerScoredLabel.AutoSize = true;
            this.playerScoredLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerScoredLabel.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScoredLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerScoredLabel.Location = new System.Drawing.Point(24, 241);
            this.playerScoredLabel.Name = "playerScoredLabel";
            this.playerScoredLabel.Size = new System.Drawing.Size(0, 19);
            this.playerScoredLabel.TabIndex = 5;
            this.playerScoredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // backgroundLabelTop
            // 
            this.backgroundLabelTop.Location = new System.Drawing.Point(0, 0);
            this.backgroundLabelTop.Name = "backgroundLabelTop";
            this.backgroundLabelTop.Size = new System.Drawing.Size(250, 0);
            this.backgroundLabelTop.TabIndex = 7;
            this.backgroundLabelTop.Text = "label2";
            // 
            // backgroundLabelBottom
            // 
            this.backgroundLabelBottom.Location = new System.Drawing.Point(0, 500);
            this.backgroundLabelBottom.Name = "backgroundLabelBottom";
            this.backgroundLabelBottom.Size = new System.Drawing.Size(250, 0);
            this.backgroundLabelBottom.TabIndex = 8;
            this.backgroundLabelBottom.Text = "label2";
            this.backgroundLabelBottom.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(250, 500);
            this.Controls.Add(this.backgroundLabelBottom);
            this.Controls.Add(this.backgroundLabelTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerScoredLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label playerScoredLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label backgroundLabelTop;
        private System.Windows.Forms.Label backgroundLabelBottom;
    }
}

