﻿namespace GameOfLife
{
    partial class OptionsForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCan = new System.Windows.Forms.Button();
            this.labelT = new System.Windows.Forms.Label();
            this.labelW = new System.Windows.Forms.Label();
            this.labelh = new System.Windows.Forms.Label();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelG = new System.Windows.Forms.Label();
            this.checkBoxGrid = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(133, 205);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCan
            // 
            this.buttonCan.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCan.Location = new System.Drawing.Point(214, 205);
            this.buttonCan.Name = "buttonCan";
            this.buttonCan.Size = new System.Drawing.Size(75, 23);
            this.buttonCan.TabIndex = 1;
            this.buttonCan.Text = "Cancel";
            this.buttonCan.UseVisualStyleBackColor = true;
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(58, 55);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(139, 13);
            this.labelT.TabIndex = 2;
            this.labelT.Text = "Time Interval in Milliseconds";
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Location = new System.Drawing.Point(69, 88);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(128, 13);
            this.labelW.TabIndex = 3;
            this.labelW.Text = "Width of Universe in Cells";
            // 
            // labelh
            // 
            this.labelh.AutoSize = true;
            this.labelh.Location = new System.Drawing.Point(66, 120);
            this.labelh.Name = "labelh";
            this.labelh.Size = new System.Drawing.Size(131, 13);
            this.labelh.TabIndex = 4;
            this.labelh.Text = "Height of Universe in Cells";
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(203, 53);
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTime.TabIndex = 5;
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(203, 86);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownWidth.TabIndex = 6;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(203, 118);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownHeight.TabIndex = 7;
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(107, 146);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(90, 13);
            this.labelG.TabIndex = 8;
            this.labelG.Text = "Toggle Grid Lines";
            // 
            // checkBoxGrid
            // 
            this.checkBoxGrid.AutoSize = true;
            this.checkBoxGrid.Location = new System.Drawing.Point(204, 146);
            this.checkBoxGrid.Name = "checkBoxGrid";
            this.checkBoxGrid.Size = new System.Drawing.Size(15, 14);
            this.checkBoxGrid.TabIndex = 9;
            this.checkBoxGrid.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCan;
            this.ClientSize = new System.Drawing.Size(413, 261);
            this.Controls.Add(this.checkBoxGrid);
            this.Controls.Add(this.labelG);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.numericUpDownTime);
            this.Controls.Add(this.labelh);
            this.Controls.Add(this.labelW);
            this.Controls.Add(this.labelT);
            this.Controls.Add(this.buttonCan);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCan;
        private System.Windows.Forms.Label labelT;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.Label labelh;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.CheckBox checkBoxGrid;
    }
}