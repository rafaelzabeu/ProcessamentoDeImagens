namespace Lista2
{
    partial class Exercicio3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_loadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartB)).BeginInit();
            this.SuspendLayout();
            // 
            // chartR
            // 
            this.chartR.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartR.ChartAreas.Add(chartArea1);
            this.chartR.Location = new System.Drawing.Point(12, 12);
            this.chartR.Name = "chartR";
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Series 1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartR.Series.Add(series1);
            this.chartR.Size = new System.Drawing.Size(369, 300);
            this.chartR.TabIndex = 0;
            // 
            // chartG
            // 
            this.chartG.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartG.ChartAreas.Add(chartArea2);
            this.chartG.Location = new System.Drawing.Point(387, 12);
            this.chartG.Name = "chartG";
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series2.Color = System.Drawing.Color.Green;
            series2.Name = "Series 1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartG.Series.Add(series2);
            this.chartG.Size = new System.Drawing.Size(383, 300);
            this.chartG.TabIndex = 1;
            // 
            // chartB
            // 
            this.chartB.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chartB.ChartAreas.Add(chartArea3);
            this.chartB.Location = new System.Drawing.Point(776, 12);
            this.chartB.Name = "chartB";
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series3.Color = System.Drawing.Color.Blue;
            series3.Name = "Series 1";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartB.Series.Add(series3);
            this.chartB.Size = new System.Drawing.Size(392, 300);
            this.chartB.TabIndex = 2;
            // 
            // btn_loadImage
            // 
            this.btn_loadImage.Location = new System.Drawing.Point(12, 335);
            this.btn_loadImage.Name = "btn_loadImage";
            this.btn_loadImage.Size = new System.Drawing.Size(75, 23);
            this.btn_loadImage.TabIndex = 3;
            this.btn_loadImage.Text = "Load Image";
            this.btn_loadImage.UseVisualStyleBackColor = true;
            this.btn_loadImage.Click += new System.EventHandler(this.btn_loadImage_Click);
            // 
            // Exercicio3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 370);
            this.Controls.Add(this.btn_loadImage);
            this.Controls.Add(this.chartB);
            this.Controls.Add(this.chartG);
            this.Controls.Add(this.chartR);
            this.Name = "Exercicio3";
            this.Text = "Exercicio3";
            ((System.ComponentModel.ISupportInitialize)(this.chartR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartR;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartG;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartB;
        private System.Windows.Forms.Button btn_loadImage;
    }
}