namespace GameTemplate.Screens
{
    partial class InstructionScreen
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
            this.howToPlayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.YellowGreen;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(438, 276);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(120, 39);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // howToPlayLabel
            // 
            this.howToPlayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.howToPlayLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.howToPlayLabel.Location = new System.Drawing.Point(-71, 53);
            this.howToPlayLabel.Name = "howToPlayLabel";
            this.howToPlayLabel.Size = new System.Drawing.Size(1053, 162);
            this.howToPlayLabel.TabIndex = 12;
            this.howToPlayLabel.Text = "How to Play: Press D to accelarate and W to jump up, Pick up an umbrella for prot" +
    "ection.Don\'t get hit or you won\'t make it to the school bus in time to catch it!" +
    "";
            this.howToPlayLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.howToPlayLabel.Click += new System.EventHandler(this.howToPlayLabel_Click);
            // 
            // InstructionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.Controls.Add(this.howToPlayLabel);
            this.Controls.Add(this.exitButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InstructionScreen";
            this.Size = new System.Drawing.Size(1066, 497);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label howToPlayLabel;
    }
}
