namespace Lista5
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
            this.boxColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxSize = new System.Windows.Forms.ComboBox();
            this.btn_apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boxColor
            // 
            this.boxColor.FormattingEnabled = true;
            this.boxColor.Items.AddRange(new object[] {
            "Colorida",
            "Preto e Branco"});
            this.boxColor.Location = new System.Drawing.Point(12, 24);
            this.boxColor.Name = "boxColor";
            this.boxColor.Size = new System.Drawing.Size(121, 21);
            this.boxColor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Colorida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filtro";
            // 
            // boxFilter
            // 
            this.boxFilter.FormattingEnabled = true;
            this.boxFilter.Items.AddRange(new object[] {
            "Media",
            "Mediana",
            "Moda",
            "Linha Vertical",
            "Linha Horizontal",
            "Linha Diagonal Principal",
            "Linha Diagonal Secundaria",
            "Borda Normal",
            "Sobel"});
            this.boxFilter.Location = new System.Drawing.Point(12, 64);
            this.boxFilter.Name = "boxFilter";
            this.boxFilter.Size = new System.Drawing.Size(121, 21);
            this.boxFilter.TabIndex = 3;
            this.boxFilter.SelectedIndexChanged += new System.EventHandler(this.boxFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tamanho";
            // 
            // boxSize
            // 
            this.boxSize.FormattingEnabled = true;
            this.boxSize.Items.AddRange(new object[] {
            "3x3",
            "5x5",
            "7x7",
            "9x9"});
            this.boxSize.Location = new System.Drawing.Point(12, 104);
            this.boxSize.Name = "boxSize";
            this.boxSize.Size = new System.Drawing.Size(121, 21);
            this.boxSize.TabIndex = 5;
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(12, 132);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(121, 23);
            this.btn_apply.TabIndex = 6;
            this.btn_apply.Text = "Aplicar Filtro";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 172);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.boxSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxColor);
            this.Name = "Form1";
            this.Text = "Filtros";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox boxColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxSize;
        private System.Windows.Forms.Button btn_apply;
    }
}

