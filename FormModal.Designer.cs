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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // FormModal
            // 
            this.AcceptButton = this.buttonO;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonC;
            this.ClientSize = new System.Drawing.Size(425, 224);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModal";
            this.Text = "FormModal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonO;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.TextBox textBox1;
    }
}