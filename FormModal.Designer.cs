namespace GameOfLife
{
    partial class FormModal
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
            this.buttonO = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.seedNum = new System.Windows.Forms.Label();
            this.RandButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonO
            // 
            this.buttonO.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonO.Location = new System.Drawing.Point(257, 189);
            this.buttonO.Name = "buttonO";
            this.buttonO.Size = new System.Drawing.Size(75, 23);
            this.buttonO.TabIndex = 0;
            this.buttonO.Text = "Ok";
            this.buttonO.UseVisualStyleBackColor = true;
            // 
            // buttonC
            // 
            this.buttonC.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonC.Location = new System.Drawing.Point(338, 189);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(75, 23);
            this.buttonC.TabIndex = 1;
            this.buttonC.Text = "Cancel";
            this.buttonC.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(156, 71);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // seedNum
            // 
            this.seedNum.AllowDrop = true;
            this.seedNum.AutoSize = true;
            this.seedNum.Location = new System.Drawing.Point(101, 73);
            this.seedNum.Name = "seedNum";
            this.seedNum.Size = new System.Drawing.Size(39, 13);
            this.seedNum.TabIndex = 4;
            this.seedNum.Text = "Seed#";
            this.seedNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RandButton
            // 
            this.RandButton.Location = new System.Drawing.Point(282, 68);
            this.RandButton.Name = "RandButton";
            this.RandButton.Size = new System.Drawing.Size(75, 23);
            this.RandButton.TabIndex = 5;
            this.RandButton.Text = "Randomize";
            this.RandButton.UseVisualStyleBackColor = true;
            this.RandButton.Click += new System.EventHandler(this.RandButton_Click);
            // 
            // FormModal
            // 
            this.AcceptButton = this.buttonO;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonC;
            this.ClientSize = new System.Drawing.Size(425, 224);
            this.Controls.Add(this.RandButton);
            this.Controls.Add(this.seedNum);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seed Picker";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonO;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label seedNum;
        private System.Windows.Forms.Button RandButton;
    }
}