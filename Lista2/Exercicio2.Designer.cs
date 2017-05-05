namespace Lista2
{
    partial class Exercicio2
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
            this.btn_loadImage = new System.Windows.Forms.Button();
            this.txt_limiar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_loadImage
            // 
            this.btn_loadImage.Location = new System.Drawing.Point(13, 13);
            this.btn_loadImage.Name = "btn_loadImage";
            this.btn_loadImage.Size = new System.Drawing.Size(75, 23);
            this.btn_loadImage.TabIndex = 0;
            this.btn_loadImage.Text = "Load Image";
            this.btn_loadImage.UseVisualStyleBackColor = true;
            this.btn_loadImage.Click += new System.EventHandler(this.btn_loadImage_Click);
            // 
            // txt_limiar
            // 
            this.txt_limiar.Location = new System.Drawing.Point(95, 15);
            this.txt_limiar.Name = "txt_limiar";
            this.txt_limiar.Size = new System.Drawing.Size(268, 20);
            this.txt_limiar.TabIndex = 1;
            // 
            // Exercicio2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 47);
            this.Controls.Add(this.txt_limiar);
            this.Controls.Add(this.btn_loadImage);
            this.Name = "Exercicio2";
            this.Text = "Exercicio2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_loadImage;
        private System.Windows.Forms.TextBox txt_limiar;
    }
}