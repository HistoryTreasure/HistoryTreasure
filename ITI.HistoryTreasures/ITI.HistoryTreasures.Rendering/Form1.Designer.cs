using System;

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
            this.riddleControl1 = new ITI.HistoryTreasures.Rendering.RiddleControl();
            this.gameControl1 = new ITI.HistoryTreasures.Rendering.GameControl();
            this.interactionsControl1 = new ITI.HistoryTreasures.Rendering.InteractionsControl();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600;
            // 
            // riddleControl1
            // 
            this.riddleControl1.LevelContext = null;
            this.riddleControl1.Location = new System.Drawing.Point(3, 475);
            this.riddleControl1.Name = "riddleControl1";
            this.riddleControl1.Size = new System.Drawing.Size(569, 74);
            this.riddleControl1.TabIndex = 1;
            this.riddleControl1.Load += new System.EventHandler(this.riddleControl1_Load);
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
            this.gameControl1.Load += new System.EventHandler(this.gameControl1_Load);
            this.gameControl1.SizeChanged += new System.EventHandler(this.gameControl1_SizeChanged);
            // 
            // interactionsControl1
            this.interactionsControl1.Location = new System.Drawing.Point(3, 12);
            this.interactionsControl1.Name = "interactionsControl1";
            this.interactionsControl1.Size = new System.Drawing.Size(170, 457);
            this.interactionsControl1.TabIndex = 2;
            this.interactionsControl1.Load += new System.EventHandler(this.interactionsControl1_Load);
            // HistoryTreasures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.interactionsControl1);
            this.Controls.Add(this.riddleControl1);
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
        private RiddleControl riddleControl1;
        private InteractionsControl interactionsControl1;

        internal void SetInteractionMessage(string message)
        {
            interactionsControl1.InteractionText = message;
        }
    }
}

