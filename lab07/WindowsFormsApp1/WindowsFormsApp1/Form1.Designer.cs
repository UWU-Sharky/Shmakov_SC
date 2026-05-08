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
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel7 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel8 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel9 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Glomy_Glomy = new System.Windows.Forms.TextBox();
            this.Glomy_Cloudy = new System.Windows.Forms.TextBox();
            this.Glomy_Clear = new System.Windows.Forms.TextBox();
            this.Cloudy_Glomy = new System.Windows.Forms.TextBox();
            this.Cloudy_Cloudy = new System.Windows.Forms.TextBox();
            this.Cloudy_Clear = new System.Windows.Forms.TextBox();
            this.Clear_Glomy = new System.Windows.Forms.TextBox();
            this.Clear_Cloudy = new System.Windows.Forms.TextBox();
            this.Clear_Clear = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.Norm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label8 = new System.Windows.Forms.Label();
            this.TotalDays = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDays)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TotalDays);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Glomy_Glomy);
            this.panel1.Controls.Add(this.Glomy_Cloudy);
            this.panel1.Controls.Add(this.Glomy_Clear);
            this.panel1.Controls.Add(this.Cloudy_Glomy);
            this.panel1.Controls.Add(this.Cloudy_Cloudy);
            this.panel1.Controls.Add(this.Cloudy_Clear);
            this.panel1.Controls.Add(this.Clear_Glomy);
            this.panel1.Controls.Add(this.Clear_Cloudy);
            this.panel1.Controls.Add(this.Clear_Clear);
            this.panel1.Controls.Add(this.Start);
            this.panel1.Controls.Add(this.Norm);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 450);
            this.panel1.TabIndex = 0;
            // 
            // Glomy_Glomy
            // 
            this.Glomy_Glomy.Location = new System.Drawing.Point(180, 127);
            this.Glomy_Glomy.Name = "Glomy_Glomy";
            this.Glomy_Glomy.Size = new System.Drawing.Size(40, 20);
            this.Glomy_Glomy.TabIndex = 26;
            // 
            // Glomy_Cloudy
            // 
            this.Glomy_Cloudy.Location = new System.Drawing.Point(124, 127);
            this.Glomy_Cloudy.Name = "Glomy_Cloudy";
            this.Glomy_Cloudy.Size = new System.Drawing.Size(40, 20);
            this.Glomy_Cloudy.TabIndex = 25;
            // 
            // Glomy_Clear
            // 
            this.Glomy_Clear.Location = new System.Drawing.Point(68, 127);
            this.Glomy_Clear.Name = "Glomy_Clear";
            this.Glomy_Clear.Size = new System.Drawing.Size(40, 20);
            this.Glomy_Clear.TabIndex = 24;
            // 
            // Cloudy_Glomy
            // 
            this.Cloudy_Glomy.Location = new System.Drawing.Point(180, 91);
            this.Cloudy_Glomy.Name = "Cloudy_Glomy";
            this.Cloudy_Glomy.Size = new System.Drawing.Size(40, 20);
            this.Cloudy_Glomy.TabIndex = 23;
            // 
            // Cloudy_Cloudy
            // 
            this.Cloudy_Cloudy.Location = new System.Drawing.Point(124, 91);
            this.Cloudy_Cloudy.Name = "Cloudy_Cloudy";
            this.Cloudy_Cloudy.Size = new System.Drawing.Size(40, 20);
            this.Cloudy_Cloudy.TabIndex = 22;
            // 
            // Cloudy_Clear
            // 
            this.Cloudy_Clear.Location = new System.Drawing.Point(68, 91);
            this.Cloudy_Clear.Name = "Cloudy_Clear";
            this.Cloudy_Clear.Size = new System.Drawing.Size(40, 20);
            this.Cloudy_Clear.TabIndex = 21;
            // 
            // Clear_Glomy
            // 
            this.Clear_Glomy.Location = new System.Drawing.Point(180, 58);
            this.Clear_Glomy.Name = "Clear_Glomy";
            this.Clear_Glomy.Size = new System.Drawing.Size(40, 20);
            this.Clear_Glomy.TabIndex = 20;
            // 
            // Clear_Cloudy
            // 
            this.Clear_Cloudy.Location = new System.Drawing.Point(124, 58);
            this.Clear_Cloudy.Name = "Clear_Cloudy";
            this.Clear_Cloudy.Size = new System.Drawing.Size(40, 20);
            this.Clear_Cloudy.TabIndex = 19;
            // 
            // Clear_Clear
            // 
            this.Clear_Clear.Location = new System.Drawing.Point(68, 58);
            this.Clear_Clear.Name = "Clear_Clear";
            this.Clear_Clear.Size = new System.Drawing.Size(40, 20);
            this.Clear_Clear.TabIndex = 18;
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Start.Location = new System.Drawing.Point(70, 238);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(151, 25);
            this.Start.TabIndex = 17;
            this.Start.Text = "Старт";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Norm
            // 
            this.Norm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Norm.Location = new System.Drawing.Point(69, 164);
            this.Norm.Name = "Norm";
            this.Norm.Size = new System.Drawing.Size(152, 25);
            this.Norm.TabIndex = 16;
            this.Norm.Text = "Отнормировать";
            this.Norm.UseVisualStyleBackColor = false;
            this.Norm.Click += new System.EventHandler(this.Norm_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Облачно";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Облачно";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Пасмурно";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Пасмурно";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ясно";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ясно";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Матрица интенсивностей";
            // 
            // chart1
            // 
            chartArea3.AxisX.Title = "Продолжительность";
            customLabel7.FromPosition = -0.5D;
            customLabel7.Text = "Ясно";
            customLabel7.ToPosition = 0.5D;
            customLabel8.FromPosition = 0.5D;
            customLabel8.Text = "Облачно";
            customLabel8.ToPosition = 1.5D;
            customLabel9.FromPosition = 1.5D;
            customLabel9.Text = "Пасмурно";
            customLabel9.ToPosition = 2.5D;
            chartArea3.AxisY.CustomLabels.Add(customLabel7);
            chartArea3.AxisY.CustomLabels.Add(customLabel8);
            chartArea3.AxisY.CustomLabels.Add(customLabel9);
            chartArea3.AxisY.Title = "Вид Погоды";
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart1.Location = new System.Drawing.Point(250, 0);
            this.chart1.Name = "chart1";
            series3.BorderWidth = 4;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series3.Color = System.Drawing.Color.Green;
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(550, 300);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Количество Дней:";
            // 
            // TotalDays
            // 
            this.TotalDays.Location = new System.Drawing.Point(117, 205);
            this.TotalDays.Maximum = new decimal(new int[] {
            -1304428544,
            434162106,
            542,
            0});
            this.TotalDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TotalDays.Name = "TotalDays";
            this.TotalDays.Size = new System.Drawing.Size(67, 20);
            this.TotalDays.TabIndex = 28;
            this.TotalDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(250, 300);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(550, 150);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Laboratory 7";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Norm;
        private System.Windows.Forms.TextBox Glomy_Glomy;
        private System.Windows.Forms.TextBox Glomy_Cloudy;
        private System.Windows.Forms.TextBox Glomy_Clear;
        private System.Windows.Forms.TextBox Cloudy_Glomy;
        private System.Windows.Forms.TextBox Cloudy_Cloudy;
        private System.Windows.Forms.TextBox Cloudy_Clear;
        private System.Windows.Forms.TextBox Clear_Glomy;
        private System.Windows.Forms.TextBox Clear_Cloudy;
        private System.Windows.Forms.TextBox Clear_Clear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown TotalDays;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox1;
    }
}

