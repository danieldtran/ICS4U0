
namespace Fraction_Calculator___DT
{
    partial class formFractionCalculator
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
            this.txtNum1 = new System.Windows.Forms.TextBox();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtNum2 = new System.Windows.Forms.TextBox();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.lblFraction1 = new System.Windows.Forms.Label();
            this.lblFraction2 = new System.Windows.Forms.Label();
            this.txtResultNum = new System.Windows.Forms.TextBox();
            this.txtResultDenom = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblFractionLine1 = new System.Windows.Forms.Label();
            this.lblFractionLine = new System.Windows.Forms.Label();
            this.lblFractionLine3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNum1
            // 
            this.txtNum1.Location = new System.Drawing.Point(72, 21);
            this.txtNum1.Name = "txtNum1";
            this.txtNum1.Size = new System.Drawing.Size(51, 20);
            this.txtNum1.TabIndex = 0;
            this.txtNum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Location = new System.Drawing.Point(72, 54);
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.Size = new System.Drawing.Size(51, 20);
            this.txtDenom1.TabIndex = 1;
            this.txtDenom1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNum2
            // 
            this.txtNum2.Location = new System.Drawing.Point(202, 21);
            this.txtNum2.Name = "txtNum2";
            this.txtNum2.Size = new System.Drawing.Size(51, 20);
            this.txtNum2.TabIndex = 2;
            this.txtNum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Location = new System.Drawing.Point(202, 54);
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.Size = new System.Drawing.Size(51, 20);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(72, 87);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add (+)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Location = new System.Drawing.Point(178, 87);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(75, 23);
            this.btnMultiply.TabIndex = 6;
            this.btnMultiply.Text = "Multiply (x)";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(72, 116);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(75, 23);
            this.btnSubtract.TabIndex = 5;
            this.btnSubtract.Text = "Subtract (-)";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(178, 116);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(75, 23);
            this.btnDivide.TabIndex = 7;
            this.btnDivide.Text = "Divide (÷)";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // lblFraction1
            // 
            this.lblFraction1.AutoSize = true;
            this.lblFraction1.Location = new System.Drawing.Point(12, 37);
            this.lblFraction1.Name = "lblFraction1";
            this.lblFraction1.Size = new System.Drawing.Size(54, 13);
            this.lblFraction1.TabIndex = 8;
            this.lblFraction1.Text = "Faction 1:";
            // 
            // lblFraction2
            // 
            this.lblFraction2.AutoSize = true;
            this.lblFraction2.Location = new System.Drawing.Point(139, 37);
            this.lblFraction2.Name = "lblFraction2";
            this.lblFraction2.Size = new System.Drawing.Size(57, 13);
            this.lblFraction2.TabIndex = 9;
            this.lblFraction2.Text = "Fraction 2:";
            // 
            // txtResultNum
            // 
            this.txtResultNum.Location = new System.Drawing.Point(287, 21);
            this.txtResultNum.Name = "txtResultNum";
            this.txtResultNum.ReadOnly = true;
            this.txtResultNum.Size = new System.Drawing.Size(51, 20);
            this.txtResultNum.TabIndex = 10;
            this.txtResultNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtResultDenom
            // 
            this.txtResultDenom.Location = new System.Drawing.Point(287, 54);
            this.txtResultDenom.Name = "txtResultDenom";
            this.txtResultDenom.ReadOnly = true;
            this.txtResultDenom.Size = new System.Drawing.Size(51, 20);
            this.txtResultDenom.TabIndex = 11;
            this.txtResultDenom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(268, 44);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(13, 13);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "=";
            // 
            // lblFractionLine1
            // 
            this.lblFractionLine1.AutoSize = true;
            this.lblFractionLine1.BackColor = System.Drawing.Color.Transparent;
            this.lblFractionLine1.Location = new System.Drawing.Point(66, 37);
            this.lblFractionLine1.Name = "lblFractionLine1";
            this.lblFractionLine1.Size = new System.Drawing.Size(67, 13);
            this.lblFractionLine1.TabIndex = 13;
            this.lblFractionLine1.Text = "__________";
            // 
            // lblFractionLine
            // 
            this.lblFractionLine.AutoSize = true;
            this.lblFractionLine.Location = new System.Drawing.Point(199, 37);
            this.lblFractionLine.Name = "lblFractionLine";
            this.lblFractionLine.Size = new System.Drawing.Size(61, 13);
            this.lblFractionLine.TabIndex = 14;
            this.lblFractionLine.Text = "_________";
            // 
            // lblFractionLine3
            // 
            this.lblFractionLine3.AutoSize = true;
            this.lblFractionLine3.Location = new System.Drawing.Point(282, 38);
            this.lblFractionLine3.Name = "lblFractionLine3";
            this.lblFractionLine3.Size = new System.Drawing.Size(67, 13);
            this.lblFractionLine3.TabIndex = 15;
            this.lblFractionLine3.Text = "__________";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(263, 99);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // formFractionCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 158);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResultDenom);
            this.Controls.Add(this.txtResultNum);
            this.Controls.Add(this.lblFraction2);
            this.Controls.Add(this.lblFraction1);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDenom2);
            this.Controls.Add(this.txtNum2);
            this.Controls.Add(this.txtDenom1);
            this.Controls.Add(this.txtNum1);
            this.Controls.Add(this.lblFractionLine1);
            this.Controls.Add(this.lblFractionLine);
            this.Controls.Add(this.lblFractionLine3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formFractionCalculator";
            this.Text = "Fraction Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum1;
        private System.Windows.Forms.TextBox txtDenom1;
        private System.Windows.Forms.TextBox txtNum2;
        private System.Windows.Forms.TextBox txtDenom2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Label lblFraction1;
        private System.Windows.Forms.Label lblFraction2;
        private System.Windows.Forms.TextBox txtResultNum;
        private System.Windows.Forms.TextBox txtResultDenom;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblFractionLine1;
        private System.Windows.Forms.Label lblFractionLine;
        private System.Windows.Forms.Label lblFractionLine3;
        private System.Windows.Forms.Button btnReset;
    }
}

