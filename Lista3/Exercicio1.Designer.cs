namespace Lista3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graphOrig = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphChang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.img_orig = new System.Windows.Forms.PictureBox();
            this.img_chang = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphOrig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphChang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_orig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_chang)).BeginInit();
            this.SuspendLayout();
            // 
            // graphOrig
            // 
            chartArea5.Name = "ChartArea1";
            this.graphOrig.ChartAreas.Add(chartArea5);
            this.graphOrig.Location = new System.Drawing.Point(12, 12);
            this.graphOrig.Name = "graphOrig";
            series5.ChartArea = "ChartArea1";
            series5.Name = "Series1";
            this.graphOrig.Series.Add(series5);
            this.graphOrig.Size = new System.Drawing.Size(524, 300);
            this.graphOrig.TabIndex = 0;
            this.graphOrig.Text = "chart1";
            // 
            // graphChang
            // 
            chartArea6.Name = "ChartArea1";
            this.graphChang.ChartAreas.Add(chartArea6);
            this.graphChang.Location = new System.Drawing.Point(12, 318);
            this.graphChang.Name = "graphChang";
            series6.ChartArea = "ChartArea1";
            series6.Name = "Series1";
            this.graphChang.Series.Add(series6);
            this.graphChang.Size = new System.Drawing.Size(524, 300);
            this.graphChang.TabIndex = 2;
            this.graphChang.Text = "chart3";
            // 
            // img_orig
            // 
            this.img_orig.Location = new System.Drawing.Point(542, 12);
            this.img_orig.Name = "img_orig";
            this.img_orig.Size = new System.Drawing.Size(515, 300);
            this.img_orig.TabIndex = 3;
            this.img_orig.TabStop = false;
            // 
            // img_chang
            // 
            this.img_chang.Location = new System.Drawing.Point(542, 318);
            this.img_chang.Name = "img_chang";
            this.img_chang.Size = new System.Drawing.Size(515, 300);
            this.img_chang.TabIndex = 4;
            this.img_chang.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1045, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exercicio1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 686);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.img_chang);
            this.Controls.Add(this.img_orig);
            this.Controls.Add(this.graphChang);
            this.Controls.Add(this.graphOrig);
            this.Name = "Exercicio1";
            this.Text = "Exercicio1";
            ((System.ComponentModel.ISupportInitialize)(this.graphOrig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphChang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_orig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_chang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graphOrig;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphChang;
        private System.Windows.Forms.PictureBox img_orig;
        private System.Windows.Forms.PictureBox img_chang;
        private System.Windows.Forms.Button button1;
    }
}