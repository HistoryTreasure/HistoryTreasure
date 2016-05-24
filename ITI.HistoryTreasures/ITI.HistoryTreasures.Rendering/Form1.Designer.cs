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
            this.gameControl1 = new ITI.HistoryTreasures.Rendering.GameControl();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gameControl1
            // 
            this.gameControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameControl1.LevelContext = null;
            this.gameControl1.Location = new System.Drawing.Point(0, 0);
            this.gameControl1.Name = "gameControl1";
            this.gameControl1.Size = new System.Drawing.Size(584, 561);
            this.gameControl1.TabIndex = 0;
            this.gameControl1.SizeChanged += new System.EventHandler(this.gameControl1_SizeChanged);
            // 
            // HistoryTreasures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.gameControl1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "HistoryTreasures";
            this.ShowInTaskbar = false;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HistoryTreasures_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private GameControl gameControl1;
        private System.Windows.Forms.Timer timer1;
    }
}

