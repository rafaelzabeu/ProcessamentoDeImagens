namespace Lista4
{
    partial class Exercicio1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txt_por1 = new System.Windows.Forms.TextBox();
            this.txt_por2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Images";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_por1
            // 
            this.txt_por1.Location = new System.Drawing.Point(95, 13);
            this.txt_por1.Name = "txt_por1";
            this.txt_por1.Size = new System.Drawing.Size(100, 20);
            this.txt_por1.TabIndex = 1;
            // 
            // txt_por2
            // 
            this.txt_por2.Location = new System.Drawing.Point(201, 12);
            this.txt_por2.Name = "txt_por2";
            this.txt_por2.Size = new System.Drawing.Size(100, 20);
            this.txt_por2.TabIndex = 2;
            // 
            // Exercicio1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 47);
            this.Controls.Add(this.txt_por2);
            this.Controls.Add(this.txt_por1);
            this.Controls.Add(this.button1);
            this.Name = "Exercicio1";
            this.Text = "Exercicio1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_por1;
        private System.Windows.Forms.TextBox txt_por2;
    }
}