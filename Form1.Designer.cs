namespace Messing_with_Classes_and_Memory
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
            this.startPauseButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.OpeningTimeTextBox = new System.Windows.Forms.TextBox();
            this.openintTimeLabel = new System.Windows.Forms.Label();
            this.closingTimeLabel = new System.Windows.Forms.Label();
            this.closingTimeTextBox = new System.Windows.Forms.TextBox();
            this.timeInputLabel = new System.Windows.Forms.Label();
            this.currentOrdersTextBox = new System.Windows.Forms.TextBox();
            this.simSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.simSpeedLabel = new System.Windows.Forms.Label();
            this.CompletedOrdersTextBox = new System.Windows.Forms.TextBox();
            this.currentOrdersLabel = new System.Windows.Forms.Label();
            this.CompletedOrdersLabel = new System.Windows.Forms.Label();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.currentTimeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startPauseButton
            // 
            this.startPauseButton.Location = new System.Drawing.Point(13, 13);
            this.startPauseButton.Name = "startPauseButton";
            this.startPauseButton.Size = new System.Drawing.Size(75, 73);
            this.startPauseButton.TabIndex = 0;
            this.startPauseButton.Text = "START";
            this.startPauseButton.UseVisualStyleBackColor = true;
            this.startPauseButton.Click += new System.EventHandler(this.startPauseButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(311, 12);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 73);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // OpeningTimeTextBox
            // 
            this.OpeningTimeTextBox.Location = new System.Drawing.Point(205, 13);
            this.OpeningTimeTextBox.Name = "OpeningTimeTextBox";
            this.OpeningTimeTextBox.Size = new System.Drawing.Size(100, 22);
            this.OpeningTimeTextBox.TabIndex = 2;
            this.OpeningTimeTextBox.Text = "23:55";
            this.OpeningTimeTextBox.TextChanged += new System.EventHandler(this.OpeningTimeTextBox_TextChanged);
            // 
            // openintTimeLabel
            // 
            this.openintTimeLabel.AutoSize = true;
            this.openintTimeLabel.Location = new System.Drawing.Point(94, 16);
            this.openintTimeLabel.Name = "openintTimeLabel";
            this.openintTimeLabel.Size = new System.Drawing.Size(105, 17);
            this.openintTimeLabel.TabIndex = 3;
            this.openintTimeLabel.Text = "Opening Time: ";
            // 
            // closingTimeLabel
            // 
            this.closingTimeLabel.AutoSize = true;
            this.closingTimeLabel.Location = new System.Drawing.Point(94, 41);
            this.closingTimeLabel.Name = "closingTimeLabel";
            this.closingTimeLabel.Size = new System.Drawing.Size(101, 17);
            this.closingTimeLabel.TabIndex = 5;
            this.closingTimeLabel.Text = "Closing Time:  ";
            // 
            // closingTimeTextBox
            // 
            this.closingTimeTextBox.Location = new System.Drawing.Point(205, 38);
            this.closingTimeTextBox.Name = "closingTimeTextBox";
            this.closingTimeTextBox.Size = new System.Drawing.Size(100, 22);
            this.closingTimeTextBox.TabIndex = 4;
            this.closingTimeTextBox.Text = "00:05";
            this.closingTimeTextBox.TextChanged += new System.EventHandler(this.closingTimeTextBox_TextChanged);
            // 
            // timeInputLabel
            // 
            this.timeInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInputLabel.Location = new System.Drawing.Point(94, 66);
            this.timeInputLabel.Name = "timeInputLabel";
            this.timeInputLabel.Size = new System.Drawing.Size(211, 53);
            this.timeInputLabel.TabIndex = 6;
            this.timeInputLabel.Text = "*Input Format: HOUR:MINUTE\r\nFor afternoon hours please use 24 hour time values";
            // 
            // currentOrdersTextBox
            // 
            this.currentOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentOrdersTextBox.Location = new System.Drawing.Point(10, 210);
            this.currentOrdersTextBox.Multiline = true;
            this.currentOrdersTextBox.Name = "currentOrdersTextBox";
            this.currentOrdersTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.currentOrdersTextBox.Size = new System.Drawing.Size(566, 634);
            this.currentOrdersTextBox.TabIndex = 7;
            // 
            // simSpeedComboBox
            // 
            this.simSpeedComboBox.AllowDrop = true;
            this.simSpeedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.simSpeedComboBox.FormattingEnabled = true;
            this.simSpeedComboBox.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "1.0",
            "2.0",
            "5.0",
            "10.0"});
            this.simSpeedComboBox.Location = new System.Drawing.Point(134, 144);
            this.simSpeedComboBox.Name = "simSpeedComboBox";
            this.simSpeedComboBox.Size = new System.Drawing.Size(171, 24);
            this.simSpeedComboBox.TabIndex = 8;
            this.simSpeedComboBox.SelectedIndexChanged += new System.EventHandler(this.simSpeedComboBox_SelectedIndexChanged);
            this.simSpeedComboBox.SelectionChangeCommitted += new System.EventHandler(this.simSpeedComboBox_SelectionChangeCommitted);
            // 
            // simSpeedLabel
            // 
            this.simSpeedLabel.AutoSize = true;
            this.simSpeedLabel.Location = new System.Drawing.Point(12, 147);
            this.simSpeedLabel.Name = "simSpeedLabel";
            this.simSpeedLabel.Size = new System.Drawing.Size(116, 17);
            this.simSpeedLabel.TabIndex = 9;
            this.simSpeedLabel.Text = "Simulator Speed:";
            // 
            // CompletedOrdersTextBox
            // 
            this.CompletedOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompletedOrdersTextBox.Location = new System.Drawing.Point(616, 66);
            this.CompletedOrdersTextBox.Multiline = true;
            this.CompletedOrdersTextBox.Name = "CompletedOrdersTextBox";
            this.CompletedOrdersTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CompletedOrdersTextBox.Size = new System.Drawing.Size(566, 778);
            this.CompletedOrdersTextBox.TabIndex = 10;
            // 
            // currentOrdersLabel
            // 
            this.currentOrdersLabel.AutoSize = true;
            this.currentOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentOrdersLabel.Location = new System.Drawing.Point(6, 187);
            this.currentOrdersLabel.Name = "currentOrdersLabel";
            this.currentOrdersLabel.Size = new System.Drawing.Size(136, 20);
            this.currentOrdersLabel.TabIndex = 11;
            this.currentOrdersLabel.Text = "Current Orders";
            // 
            // CompletedOrdersLabel
            // 
            this.CompletedOrdersLabel.AutoSize = true;
            this.CompletedOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompletedOrdersLabel.Location = new System.Drawing.Point(612, 37);
            this.CompletedOrdersLabel.Name = "CompletedOrdersLabel";
            this.CompletedOrdersLabel.Size = new System.Drawing.Size(162, 20);
            this.CompletedOrdersLabel.TabIndex = 12;
            this.CompletedOrdersLabel.Text = "Completed Orders";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Location = new System.Drawing.Point(330, 147);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(98, 17);
            this.currentTimeLabel.TabIndex = 14;
            this.currentTimeLabel.Text = "Current Time: ";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new System.Drawing.Point(441, 144);
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.ReadOnly = true;
            this.currentTimeTextBox.Size = new System.Drawing.Size(100, 22);
            this.currentTimeTextBox.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 856);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.currentTimeTextBox);
            this.Controls.Add(this.CompletedOrdersLabel);
            this.Controls.Add(this.currentOrdersLabel);
            this.Controls.Add(this.CompletedOrdersTextBox);
            this.Controls.Add(this.simSpeedLabel);
            this.Controls.Add(this.simSpeedComboBox);
            this.Controls.Add(this.currentOrdersTextBox);
            this.Controls.Add(this.timeInputLabel);
            this.Controls.Add(this.closingTimeLabel);
            this.Controls.Add(this.closingTimeTextBox);
            this.Controls.Add(this.openintTimeLabel);
            this.Controls.Add(this.OpeningTimeTextBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.startPauseButton);
            this.Name = "Form1";
            this.Text = "A Day of Orders Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startPauseButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox OpeningTimeTextBox;
        private System.Windows.Forms.Label openintTimeLabel;
        private System.Windows.Forms.Label closingTimeLabel;
        private System.Windows.Forms.TextBox closingTimeTextBox;
        private System.Windows.Forms.Label timeInputLabel;
        private System.Windows.Forms.TextBox currentOrdersTextBox;
        private System.Windows.Forms.ComboBox simSpeedComboBox;
        private System.Windows.Forms.Label simSpeedLabel;
        private System.Windows.Forms.TextBox CompletedOrdersTextBox;
        private System.Windows.Forms.Label currentOrdersLabel;
        private System.Windows.Forms.Label CompletedOrdersLabel;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.TextBox currentTimeTextBox;
    }
}

