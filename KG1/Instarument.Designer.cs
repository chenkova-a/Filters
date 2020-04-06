namespace KG1
{
    partial class Instarument
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
            this.Palette = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLockSize = new System.Windows.Forms.Button();
            this.textSizeY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textSizeX = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Palette
            // 
            this.Palette.AutoSize = true;
            this.Palette.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Palette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Palette.Location = new System.Drawing.Point(0, 0);
            this.Palette.Name = "Palette";
            this.Palette.Padding = new System.Windows.Forms.Padding(0, 0, 0, 31);
            this.Palette.Size = new System.Drawing.Size(322, 338);
            this.Palette.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLockSize);
            this.panel1.Controls.Add(this.textSizeY);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textSizeX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 307);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(322, 31);
            this.panel1.TabIndex = 5;
            // 
            // buttonLockSize
            // 
            this.buttonLockSize.AutoSize = true;
            this.buttonLockSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonLockSize.Location = new System.Drawing.Point(157, 5);
            this.buttonLockSize.Name = "buttonLockSize";
            this.buttonLockSize.Size = new System.Drawing.Size(160, 21);
            this.buttonLockSize.TabIndex = 6;
            this.buttonLockSize.Text = "Lock";
            this.buttonLockSize.UseVisualStyleBackColor = true;
            this.buttonLockSize.Click += new System.EventHandler(this.buttonLockSize_Click);
            // 
            // textSizeY
            // 
            this.textSizeY.Dock = System.Windows.Forms.DockStyle.Left;
            this.textSizeY.Location = new System.Drawing.Point(84, 5);
            this.textSizeY.Name = "textSizeY";
            this.textSizeY.Size = new System.Drawing.Size(67, 20);
            this.textSizeY.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(72, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "x";
            // 
            // textSizeX
            // 
            this.textSizeX.Dock = System.Windows.Forms.DockStyle.Left;
            this.textSizeX.Location = new System.Drawing.Point(5, 5);
            this.textSizeX.Name = "textSizeX";
            this.textSizeX.Size = new System.Drawing.Size(67, 20);
            this.textSizeX.TabIndex = 2;
            // 
            // Instarument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(322, 338);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Palette);
            this.Name = "Instarument";
            this.Text = "Instarument";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Palette;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLockSize;
        private System.Windows.Forms.TextBox textSizeY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSizeX;
    }
}