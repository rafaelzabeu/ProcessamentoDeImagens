namespace ProcessamentoDeImagens
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
            this.btn_exe1 = new System.Windows.Forms.Button();
            this.btn_exe2 = new System.Windows.Forms.Button();
            this.lbl_stp = new System.Windows.Forms.Label();
            this.btn_exe3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_exe1
            // 
            this.btn_exe1.Location = new System.Drawing.Point(13, 13);
            this.btn_exe1.Name = "btn_exe1";
            this.btn_exe1.Size = new System.Drawing.Size(75, 23);
            this.btn_exe1.TabIndex = 0;
            this.btn_exe1.Text = "Exercicio 1";
            this.btn_exe1.UseVisualStyleBackColor = true;
            this.btn_exe1.Click += new System.EventHandler(this.btn_exe1_Click);
            // 
            // btn_exe2
            // 
            this.btn_exe2.Location = new System.Drawing.Point(13, 42);
            this.btn_exe2.Name = "btn_exe2";
            this.btn_exe2.Size = new System.Drawing.Size(75, 23);
            this.btn_exe2.TabIndex = 1;
            this.btn_exe2.Text = "Exercicio 2";
            this.btn_exe2.UseVisualStyleBackColor = true;
            this.btn_exe2.Click += new System.EventHandler(this.btn_exe2_Click);
            // 
            // lbl_stp
            // 
            this.lbl_stp.AutoSize = true;
            this.lbl_stp.Location = new System.Drawing.Point(188, 342);
            this.lbl_stp.Name = "lbl_stp";
            this.lbl_stp.Size = new System.Drawing.Size(37, 13);
            this.lbl_stp.TabIndex = 2;
            this.lbl_stp.Text = "lbl_stp";
            // 
            // btn_exe3
            // 
            this.btn_exe3.Location = new System.Drawing.Point(13, 71);
            this.btn_exe3.Name = "btn_exe3";
            this.btn_exe3.Size = new System.Drawing.Size(75, 23);
            this.btn_exe3.TabIndex = 3;
            this.btn_exe3.Text = "Exercicio 3";
            this.btn_exe3.UseVisualStyleBackColor = true;
            this.btn_exe3.Click += new System.EventHandler(this.btn_exe3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 428);
            this.Controls.Add(this.btn_exe3);
            this.Controls.Add(this.lbl_stp);
            this.Controls.Add(this.btn_exe2);
            this.Controls.Add(this.btn_exe1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exe1;
        private System.Windows.Forms.Button btn_exe2;
        private System.Windows.Forms.Label lbl_stp;
        private System.Windows.Forms.Button btn_exe3;
    }
}

