namespace Lista2
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
            this.Calc = new System.Windows.Forms.Button();
            this.txt_size = new System.Windows.Forms.TextBox();
            this.lbl_number = new System.Windows.Forms.Label();
            this.lbl_binary = new System.Windows.Forms.Label();
            this.lbl_analog = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Calc
            // 
            this.Calc.Cursor = System.Windows.Forms.Cursors.Default;
            this.Calc.Location = new System.Drawing.Point(12, 226);
            this.Calc.Name = "Calc";
            this.Calc.Size = new System.Drawing.Size(75, 23);
            this.Calc.TabIndex = 1;
            this.Calc.Text = "Calc";
            this.Calc.UseVisualStyleBackColor = true;
            this.Calc.Click += new System.EventHandler(this.Calc_Click);
            // 
            // txt_size
            // 
            this.txt_size.Location = new System.Drawing.Point(12, 77);
            this.txt_size.Name = "txt_size";
            this.txt_size.Size = new System.Drawing.Size(100, 20);
            this.txt_size.TabIndex = 2;
            // 
            // lbl_number
            // 
            this.lbl_number.AutoSize = true;
            this.lbl_number.Location = new System.Drawing.Point(12, 207);
            this.lbl_number.Name = "lbl_number";
            this.lbl_number.Size = new System.Drawing.Size(46, 13);
            this.lbl_number.TabIndex = 3;
            this.lbl_number.Text = "Base 10";
            // 
            // lbl_binary
            // 
            this.lbl_binary.AutoSize = true;
            this.lbl_binary.Location = new System.Drawing.Point(12, 191);
            this.lbl_binary.Name = "lbl_binary";
            this.lbl_binary.Size = new System.Drawing.Size(39, 13);
            this.lbl_binary.TabIndex = 4;
            this.lbl_binary.Text = "Binario";
            // 
            // lbl_analog
            // 
            this.lbl_analog.AutoSize = true;
            this.lbl_analog.Location = new System.Drawing.Point(15, 173);
            this.lbl_analog.Name = "lbl_analog";
            this.lbl_analog.Size = new System.Drawing.Size(54, 13);
            this.lbl_analog.TabIndex = 5;
            this.lbl_analog.Text = "Analogico";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Passa Alta",
            "Passa Baixa",
            "Passa Faixa",
            "Rejeita Faixa"});
            this.comboBox1.Location = new System.Drawing.Point(12, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(38, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(194, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 8;
            // 
            // Exercicio1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbl_analog);
            this.Controls.Add(this.lbl_binary);
            this.Controls.Add(this.lbl_number);
            this.Controls.Add(this.txt_size);
            this.Controls.Add(this.Calc);
            this.Name = "Exercicio1";
            this.Text = "Exercicio1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Calc;
        private System.Windows.Forms.TextBox txt_size;
        private System.Windows.Forms.Label lbl_number;
        private System.Windows.Forms.Label lbl_binary;
        private System.Windows.Forms.Label lbl_analog;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}