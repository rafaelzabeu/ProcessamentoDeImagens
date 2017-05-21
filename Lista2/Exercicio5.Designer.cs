namespace Lista2
{
    partial class Exercicio5
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
            this.bnt_loadImage = new System.Windows.Forms.Button();
            this.txt_cut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bnt_loadImage
            // 
            this.bnt_loadImage.Location = new System.Drawing.Point(30, 25);
            this.bnt_loadImage.Name = "bnt_loadImage";
            this.bnt_loadImage.Size = new System.Drawing.Size(75, 23);
            this.bnt_loadImage.TabIndex = 0;
            this.bnt_loadImage.Text = "Load Image";
            this.bnt_loadImage.UseVisualStyleBackColor = true;
            this.bnt_loadImage.Click += new System.EventHandler(this.bnt_loadImage_Click);
            // 
            // txt_cut
            // 
            this.txt_cut.Location = new System.Drawing.Point(125, 27);
            this.txt_cut.Name = "txt_cut";
            this.txt_cut.Size = new System.Drawing.Size(100, 20);
            this.txt_cut.TabIndex = 1;
            // 
            // Exercicio5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txt_cut);
            this.Controls.Add(this.bnt_loadImage);
            this.Name = "Exercicio5";
            this.Text = "Exercicio5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnt_loadImage;
        private System.Windows.Forms.TextBox txt_cut;
    }
}