namespace MemoryGame
{
    partial class MainPage
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
            this.GridPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SetsLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridPanel
            // 
            this.GridPanel.Location = new System.Drawing.Point(594, 100);
            this.GridPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(812, 900);
            this.GridPanel.TabIndex = 0;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(740, 248);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(222, 89);
            this.StartGameButton.TabIndex = 1;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(276, 100);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(222, 89);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainPanel.Controls.Add(this.StartGameButton);
            this.MainPanel.Location = new System.Drawing.Point(13, 14);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1900, 1108);
            this.MainPanel.TabIndex = 9;
            // 
            // SetsLabel
            // 
            this.SetsLabel.AutoSize = true;
            this.SetsLabel.Location = new System.Drawing.Point(404, 235);
            this.SetsLabel.Name = "SetsLabel";
            this.SetsLabel.Size = new System.Drawing.Size(18, 20);
            this.SetsLabel.TabIndex = 5;
            this.SetsLabel.Text = "0";
            this.SetsLabel.Visible = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1896, 1028);
            this.Controls.Add(this.SetsLabel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.GridPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel GridPanel;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label SetsLabel;
        public System.Windows.Forms.Panel MainPanel;
    }
}

