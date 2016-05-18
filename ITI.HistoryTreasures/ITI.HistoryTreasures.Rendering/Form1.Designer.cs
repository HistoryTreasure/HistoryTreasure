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
            this.gameControl1 = new ITI.HistoryTreasures.Rendering.GameControl();
            this.SuspendLayout();
            // 
            // gameControl1
            // 
            this.gameControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameControl1.LevelContext = null;
            this.gameControl1.Location = new System.Drawing.Point(0, 0);
            this.gameControl1.Name = "gameControl1";
            this.gameControl1.Size = new System.Drawing.Size(534, 353);
            this.gameControl1.TabIndex = 0;
            // 
            // HistoryTreasures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(534, 353);
            this.Controls.Add(this.gameControl1);
            this.DoubleBuffered = true;
            this.Name = "HistoryTreasures";
            this.ShowInTaskbar = false;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HistoryTreasures_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private GameControl gameControl1;
    }
}

