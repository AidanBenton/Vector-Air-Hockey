
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
            this.faxLabel = new System.Windows.Forms.Label();
            this.aXLabel = new System.Windows.Forms.Label();
            this.VX1Label = new System.Windows.Forms.Label();
            this.collsionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 17;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // faxLabel
            // 
            this.faxLabel.AutoSize = true;
            this.faxLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.faxLabel.Location = new System.Drawing.Point(12, 357);
            this.faxLabel.Name = "faxLabel";
            this.faxLabel.Size = new System.Drawing.Size(76, 13);
            this.faxLabel.TabIndex = 1;
            this.faxLabel.Text = "Collision: False";
            // 
            // aXLabel
            // 
            this.aXLabel.AutoSize = true;
            this.aXLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.aXLabel.Location = new System.Drawing.Point(12, 370);
            this.aXLabel.Name = "aXLabel";
            this.aXLabel.Size = new System.Drawing.Size(76, 13);
            this.aXLabel.TabIndex = 2;
            this.aXLabel.Text = "Collision: False";
            // 
            // VX1Label
            // 
            this.VX1Label.AutoSize = true;
            this.VX1Label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.VX1Label.Location = new System.Drawing.Point(12, 383);
            this.VX1Label.Name = "VX1Label";
            this.VX1Label.Size = new System.Drawing.Size(76, 13);
            this.VX1Label.TabIndex = 3;
            this.VX1Label.Text = "Collision: False";
            // 
            // collsionLabel
            // 
            this.collsionLabel.AutoSize = true;
            this.collsionLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.collsionLabel.Location = new System.Drawing.Point(12, 396);
            this.collsionLabel.Name = "collsionLabel";
            this.collsionLabel.Size = new System.Drawing.Size(76, 13);
            this.collsionLabel.TabIndex = 4;
            this.collsionLabel.Text = "Collision: False";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(234, 461);
            this.Controls.Add(this.collsionLabel);
            this.Controls.Add(this.VX1Label);
            this.Controls.Add(this.aXLabel);
            this.Controls.Add(this.faxLabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label faxLabel;
        private System.Windows.Forms.Label aXLabel;
        private System.Windows.Forms.Label VX1Label;
        private System.Windows.Forms.Label collsionLabel;
    }
}

