namespace LineDrawingAlgorithms
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
            this.panel = new System.Windows.Forms.Panel();
            this.lblXStart = new System.Windows.Forms.Label();
            this.lblYStart = new System.Windows.Forms.Label();
            this.lblXEnd = new System.Windows.Forms.Label();
            this.lblYEnd = new System.Windows.Forms.Label();
            this.txtXStart = new System.Windows.Forms.TextBox();
            this.txtYStart = new System.Windows.Forms.TextBox();
            this.txtXEnd = new System.Windows.Forms.TextBox();
            this.txtYEnd = new System.Windows.Forms.TextBox();
            this.btnDDA = new System.Windows.Forms.Button();
            this.btnBresenham = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 400);
            this.panel.TabIndex = 0;
            // 
            // lblXStart
            // 
            this.lblXStart.AutoSize = true;
            this.lblXStart.Location = new System.Drawing.Point(418, 21);
            this.lblXStart.Name = "lblXStart";
            this.lblXStart.Size = new System.Drawing.Size(45, 13);
            this.lblXStart.TabIndex = 1;
            this.lblXStart.Text = "X - Start";
            // 
            // lblYStart
            // 
            this.lblYStart.AutoSize = true;
            this.lblYStart.Location = new System.Drawing.Point(418, 47);
            this.lblYStart.Name = "lblYStart";
            this.lblYStart.Size = new System.Drawing.Size(45, 13);
            this.lblYStart.TabIndex = 2;
            this.lblYStart.Text = "Y - Start";
            // 
            // lblXEnd
            // 
            this.lblXEnd.AutoSize = true;
            this.lblXEnd.Location = new System.Drawing.Point(418, 76);
            this.lblXEnd.Name = "lblXEnd";
            this.lblXEnd.Size = new System.Drawing.Size(42, 13);
            this.lblXEnd.TabIndex = 3;
            this.lblXEnd.Text = "X - End";
            // 
            // lblYEnd
            // 
            this.lblYEnd.AutoSize = true;
            this.lblYEnd.Location = new System.Drawing.Point(418, 102);
            this.lblYEnd.Name = "lblYEnd";
            this.lblYEnd.Size = new System.Drawing.Size(42, 13);
            this.lblYEnd.TabIndex = 4;
            this.lblYEnd.Text = "Y - End";
            // 
            // txtXStart
            // 
            this.txtXStart.Location = new System.Drawing.Point(469, 18);
            this.txtXStart.Name = "txtXStart";
            this.txtXStart.Size = new System.Drawing.Size(100, 20);
            this.txtXStart.TabIndex = 5;
            // 
            // txtYStart
            // 
            this.txtYStart.Location = new System.Drawing.Point(469, 44);
            this.txtYStart.Name = "txtYStart";
            this.txtYStart.Size = new System.Drawing.Size(100, 20);
            this.txtYStart.TabIndex = 6;
            // 
            // txtXEnd
            // 
            this.txtXEnd.Location = new System.Drawing.Point(469, 73);
            this.txtXEnd.Name = "txtXEnd";
            this.txtXEnd.Size = new System.Drawing.Size(100, 20);
            this.txtXEnd.TabIndex = 7;
            // 
            // txtYEnd
            // 
            this.txtYEnd.Location = new System.Drawing.Point(469, 99);
            this.txtYEnd.Name = "txtYEnd";
            this.txtYEnd.Size = new System.Drawing.Size(100, 20);
            this.txtYEnd.TabIndex = 8;
            // 
            // btnDDA
            // 
            this.btnDDA.Location = new System.Drawing.Point(469, 125);
            this.btnDDA.Name = "btnDDA";
            this.btnDDA.Size = new System.Drawing.Size(100, 30);
            this.btnDDA.TabIndex = 9;
            this.btnDDA.Text = "DDA";
            this.btnDDA.UseVisualStyleBackColor = true;
            this.btnDDA.Click += new System.EventHandler(this.btnDDA_Click);
            // 
            // btnBresenham
            // 
            this.btnBresenham.Location = new System.Drawing.Point(469, 161);
            this.btnBresenham.Name = "btnBresenham";
            this.btnBresenham.Size = new System.Drawing.Size(100, 30);
            this.btnBresenham.TabIndex = 10;
            this.btnBresenham.Text = "Bresenham";
            this.btnBresenham.UseVisualStyleBackColor = true;
            this.btnBresenham.Click += new System.EventHandler(this.btnBresenham_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(469, 197);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 423);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBresenham);
            this.Controls.Add(this.btnDDA);
            this.Controls.Add(this.txtYEnd);
            this.Controls.Add(this.txtXEnd);
            this.Controls.Add(this.txtYStart);
            this.Controls.Add(this.txtXStart);
            this.Controls.Add(this.lblYEnd);
            this.Controls.Add(this.lblXEnd);
            this.Controls.Add(this.lblYStart);
            this.Controls.Add(this.lblXStart);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblXStart;
        private System.Windows.Forms.Label lblYStart;
        private System.Windows.Forms.Label lblXEnd;
        private System.Windows.Forms.Label lblYEnd;
        private System.Windows.Forms.TextBox txtXStart;
        private System.Windows.Forms.TextBox txtYStart;
        private System.Windows.Forms.TextBox txtXEnd;
        private System.Windows.Forms.TextBox txtYEnd;
        private System.Windows.Forms.Button btnDDA;
        private System.Windows.Forms.Button btnBresenham;
        private System.Windows.Forms.Button btnClear;
    }
}

