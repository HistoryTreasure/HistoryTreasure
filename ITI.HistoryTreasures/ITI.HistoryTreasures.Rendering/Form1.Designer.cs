namespace ITI.HistoryTreasures.Rendering
{
    partial class HistoryTreasures
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.riddleControl1 = new ITI.HistoryTreasures.Rendering.RiddleControl();
            this.gameControl1 = new ITI.HistoryTreasures.Rendering.GameControl();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(581, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "En quelle année a eu lieu la prise de la bastille ?\r\n";
            // 
            // riddleControl1
            // 
            this.riddleControl1.LevelContext = null;
            this.riddleControl1.Location = new System.Drawing.Point(3, 475);
            this.riddleControl1.Name = "riddleControl1";
            this.riddleControl1.Size = new System.Drawing.Size(569, 74);
            this.riddleControl1.TabIndex = 1;
            // 
            // gameControl1
            // 
            this.gameControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameControl1.GameContext = null;
            this.gameControl1.LevelContext = null;
            this.gameControl1.Location = new System.Drawing.Point(179, 12);
            this.gameControl1.Name = "gameControl1";
            this.gameControl1.Size = new System.Drawing.Size(393, 457);
            this.gameControl1.TabIndex = 0;
            this.gameControl1.SizeChanged += new System.EventHandler(this.gameControl1_SizeChanged);
            // 
            // HistoryTreasures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.riddleControl1);
            this.Controls.Add(this.gameControl1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "HistoryTreasures";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.HistoryTreasures_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HistoryTreasures_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameControl gameControl1;
        private System.Windows.Forms.Timer timer1;
        private RiddleControl riddleControl1;
        private System.Windows.Forms.Label label1;
    }
}

