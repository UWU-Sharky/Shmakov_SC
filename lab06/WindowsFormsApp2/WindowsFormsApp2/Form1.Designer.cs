namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblResults = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.SampleSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Variance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Mean = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Bins = new System.Windows.Forms.NumericUpDown();
            this.lblChi = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.SampleSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Variance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mean)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bins)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResults.Location = new System.Drawing.Point(3, 16);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(35, 13);
            this.lblResults.TabIndex = 3;
            this.lblResults.Text = "label7";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.LightGreen;
            this.Start.Location = new System.Drawing.Point(37, 213);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(165, 25);
            this.Start.TabIndex = 16;
            this.Start.Text = "Старт";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // SampleSize
            // 
            this.SampleSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SampleSize.Location = new System.Drawing.Point(118, 179);
            this.SampleSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.SampleSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SampleSize.Name = "SampleSize";
            this.SampleSize.Size = new System.Drawing.Size(70, 20);
            this.SampleSize.TabIndex = 15;
            this.SampleSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Кол-во Опытов: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дисперсия: ";
            // 
            // Variance
            // 
            this.Variance.DecimalPlaces = 3;
            this.Variance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Variance.Location = new System.Drawing.Point(118, 127);
            this.Variance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Variance.Name = "Variance";
            this.Variance.Size = new System.Drawing.Size(70, 20);
            this.Variance.TabIndex = 5;
            this.Variance.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Среднее: ";
            // 
            // Mean
            // 
            this.Mean.DecimalPlaces = 3;
            this.Mean.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Mean.Location = new System.Drawing.Point(118, 101);
            this.Mean.Name = "Mean";
            this.Mean.Size = new System.Drawing.Size(70, 20);
            this.Mean.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Bins);
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Controls.Add(this.SampleSize);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Variance);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Mean);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 337);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Кол-во Бинов: ";
            // 
            // Bins
            // 
            this.Bins.Location = new System.Drawing.Point(118, 153);
            this.Bins.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Bins.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Bins.Name = "Bins";
            this.Bins.Size = new System.Drawing.Size(70, 20);
            this.Bins.TabIndex = 17;
            this.Bins.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblChi
            // 
            this.lblChi.AutoSize = true;
            this.lblChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChi.Location = new System.Drawing.Point(3, 29);
            this.lblChi.Name = "lblChi";
            this.lblChi.Size = new System.Drawing.Size(35, 13);
            this.lblChi.TabIndex = 4;
            this.lblChi.Text = "label7";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblChi);
            this.groupBox2.Controls.Add(this.lblResults);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 337);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 113);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Характеристики";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(225, 0);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.Green;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.PaleTurquoise;
            series1.LabelFormat = "0.000";
            series1.Legend = "Legend1";
            series1.Name = "Практика";
            series2.BorderWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Tomato;
            series2.Legend = "Legend1";
            series2.Name = "Теория";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(575, 331);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Laboratory 6.2";
            ((System.ComponentModel.ISupportInitialize)(this.SampleSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Variance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mean)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bins)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.NumericUpDown SampleSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Variance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Mean;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblChi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Bins;
    }
}

