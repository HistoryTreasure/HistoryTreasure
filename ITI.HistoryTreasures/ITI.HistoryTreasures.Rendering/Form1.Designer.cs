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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryTreasures));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuControl1 = new ITI.HistoryTreasures.Rendering.MenuControl();
            this.interactionsControl1 = new ITI.HistoryTreasures.Rendering.InteractionsControl();
            this.riddleControl1 = new ITI.HistoryTreasures.Rendering.RiddleControl();
            this.gameControl1 = new ITI.HistoryTreasures.Rendering.GameControl();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600;
            // 
            // menuControl1
            // 
            this.menuControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuControl1.Game = null;
            this.menuControl1.GameControl = null;
            this.menuControl1.InteractionsControl = null;
            this.menuControl1.Location = new System.Drawing.Point(0, 0);
            this.menuControl1.Name = "menuControl1";
            this.menuControl1.RiddleControl = null;
            this.menuControl1.Size = new System.Drawing.Size(584, 561);
            this.menuControl1.TabIndex = 3;
            this.menuControl1.Load += new System.EventHandler(this.menuControl1_Load);
            // 
            // interactionsControl1
            // 
            this.interactionsControl1.InteractionText = "";
            this.interactionsControl1.IsClue = false;
            this.interactionsControl1.Location = new System.Drawing.Point(3, 12);
            this.interactionsControl1.Name = "interactionsControl1";
            this.interactionsControl1.Size = new System.Drawing.Size(170, 457);
            this.interactionsControl1.TabIndex = 2;
            this.interactionsControl1.Load += new System.EventHandler(this.interactionsControl1_Load);
            // 
            // riddleControl1
            // 
            this.riddleControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.riddleControl1.BackColor = System.Drawing.SystemColors.Control;
            this.riddleControl1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.riddleControl1.LevelContext = null;
            this.riddleControl1.Location = new System.Drawing.Point(3, 475);
            this.riddleControl1.Name = "riddleControl1";
            this.riddleControl1.Size = new System.Drawing.Size(569, 74);
            this.riddleControl1.TabIndex = 1;
            this.riddleControl1.Load += new System.EventHandler(this.riddleControl1_Load);
            // 
            // gameControl1
            // 
            this.gameControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameControl1.GameContext = null;
            this.gameControl1.LevelContext = null;
            this.gameControl1.Location = new System.Drawing.Point(179, 12);
            this.gameControl1.MCBitmap = null;
            this.gameControl1.Name = "gameControl1";
            this.gameControl1.Size = new System.Drawing.Size(393, 457);
            this.gameControl1.TabIndex = 0;
            this.gameControl1.Load += new System.EventHandler(this.gameControl1_Load);
            this.gameControl1.SizeChanged += new System.EventHandler(this.gameControl1_SizeChanged);
            // 
            // HistoryTreasures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.menuControl1);
            this.Controls.Add(this.interactionsControl1);
            this.Controls.Add(this.riddleControl1);
            this.Controls.Add(this.gameControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "HistoryTreasures";
            this.ShowInTaskbar = false;
            this.Text = "History Treasures";
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

        internal void IsInteractionAClue(bool isClue)
        {
            interactionsControl1.IsClue = isClue;
        }

        private MenuControl menuControl1;
    }
}

