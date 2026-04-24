namespace WindowsFormsApp1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Start = new System.Windows.Forms.Button();
            this.SampleSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.Normalize = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Prob5 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.Prob4 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Prob3 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Prob2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Prob1 = new System.Windows.Forms.NumericUpDown();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblChi = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SampleSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Controls.Add(this.SampleSize);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Normalize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Prob5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Prob4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Prob3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Prob2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Prob1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.LightGreen;
            this.Start.Location = new System.Drawing.Point(27, 270);
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
            this.SampleSize.Location = new System.Drawing.Point(108, 244);
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
            this.SampleSize.Size = new System.Drawing.Size(84, 20);
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
            this.label6.Location = new System.Drawing.Point(13, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Кол-во Опытов: ";
            // 
            // Normalize
            // 
            this.Normalize.BackColor = System.Drawing.Color.Khaki;
            this.Normalize.Location = new System.Drawing.Point(27, 206);
            this.Normalize.Name = "Normalize";
            this.Normalize.Size = new System.Drawing.Size(165, 25);
            this.Normalize.TabIndex = 13;
            this.Normalize.Text = "Нормировка";
            this.Normalize.UseVisualStyleBackColor = false;
            this.Normalize.Click += new System.EventHandler(this.Normalize_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Вероятность 5:";
            // 
            // Prob5
            // 
            this.Prob5.DecimalPlaces = 3;
            this.Prob5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Prob5.Location = new System.Drawing.Point(108, 180);
            this.Prob5.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Prob5.Name = "Prob5";
            this.Prob5.Size = new System.Drawing.Size(84, 20);
            this.Prob5.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Вероятность 4:";
            // 
            // Prob4
            // 
            this.Prob4.DecimalPlaces = 3;
            this.Prob4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Prob4.Location = new System.Drawing.Point(108, 143);
            this.Prob4.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Prob4.Name = "Prob4";
            this.Prob4.Size = new System.Drawing.Size(84, 20);
            this.Prob4.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Вероятность 3:";
            // 
            // Prob3
            // 
            this.Prob3.DecimalPlaces = 3;
            this.Prob3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Prob3.Location = new System.Drawing.Point(108, 104);
            this.Prob3.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Prob3.Name = "Prob3";
            this.Prob3.Size = new System.Drawing.Size(84, 20);
            this.Prob3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Вероятность 2:";
            // 
            // Prob2
            // 
            this.Prob2.DecimalPlaces = 3;
            this.Prob2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Prob2.Location = new System.Drawing.Point(108, 67);
            this.Prob2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Prob2.Name = "Prob2";
            this.Prob2.Size = new System.Drawing.Size(84, 20);
            this.Prob2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вероятность 1:";
            // 
            // Prob1
            // 
            this.Prob1.DecimalPlaces = 3;
            this.Prob1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Prob1.Location = new System.Drawing.Point(108, 29);
            this.Prob1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Prob1.Name = "Prob1";
            this.Prob1.Size = new System.Drawing.Size(84, 20);
            this.Prob1.TabIndex = 3;
            // 
            // chart1
            // 
            chartArea3.AxisX.Title = "Значения (X)";
            chartArea3.AxisY.Title = "Вероятность / Частота";
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(225, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series5.BorderColor = System.Drawing.Color.RoyalBlue;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.LightSkyBlue;
            series5.IsValueShownAsLabel = true;
            series5.LabelFormat = "0.000";
            series5.Legend = "Legend1";
            series5.Name = "Теория";
            series6.BorderColor = System.Drawing.Color.LimeGreen;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.Color = System.Drawing.Color.Aquamarine;
            series6.IsValueShownAsLabel = true;
            series6.LabelFormat = "0.000";
            series6.Legend = "Legend1";
            series6.Name = "Практика";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(575, 325);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblChi);
            this.groupBox2.Controls.Add(this.lblResults);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(225, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 119);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Характеристики";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Laboratory 6.1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SampleSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prob1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown Prob1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Prob5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Prob4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Prob3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Prob2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Normalize;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.NumericUpDown SampleSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblChi;
    }
}

