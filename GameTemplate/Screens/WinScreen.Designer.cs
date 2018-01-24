namespace GameTemplate.Screens
{
    partial class WinScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.wonLabel = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.YellowGreen;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(111, 241);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(120, 39);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            // 
            // playAgainButton
            // 
            this.playAgainButton.BackColor = System.Drawing.Color.YellowGreen;
            this.playAgainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playAgainButton.Location = new System.Drawing.Point(111, 180);
            this.playAgainButton.Margin = new System.Windows.Forms.Padding(2);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(120, 39);
            this.playAgainButton.TabIndex = 13;
            this.playAgainButton.Text = "Play Again";
            this.playAgainButton.UseVisualStyleBackColor = false;
            this.playAgainButton.Click += new System.EventHandler(this.playAgainButton_Click);
            // 
            // wonLabel
            // 
            this.wonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wonLabel.Location = new System.Drawing.Point(-19, 21);
            this.wonLabel.Name = "wonLabel";
            this.wonLabel.Size = new System.Drawing.Size(8, 8);
            this.wonLabel.TabIndex = 14;
            this.wonLabel.Text = "Congraulations! You won ....... Nothing!";
            // 
            // winLabel
            // 
            this.winLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.Location = new System.Drawing.Point(3, 23);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(342, 89);
            this.winLabel.TabIndex = 15;
            this.winLabel.Text = "Congrats, you won! ..... nothing!";
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.wonLabel);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.exitButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WinScreen";
            this.Size = new System.Drawing.Size(345, 333);
            this.Load += new System.EventHandler(this.WinScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button playAgainButton;
        private System.Windows.Forms.Label wonLabel;
        private System.Windows.Forms.Label winLabel;
    }
}
