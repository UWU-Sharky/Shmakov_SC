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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.edHieght = new System.Windows.Forms.NumericUpDown();
            this.edAngle = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.edSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.edSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.edWeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.edStart = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Cancle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edDt = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.edHieght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edDt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Высота: ";
            // 
            // edHieght
            // 
            this.edHieght.DecimalPlaces = 1;
            this.edHieght.Location = new System.Drawing.Point(72, 17);
            this.edHieght.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.edHieght.Name = "edHieght";
            this.edHieght.Size = new System.Drawing.Size(120, 20);
            this.edHieght.TabIndex = 1;
            this.edHieght.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // edAngle
            // 
            this.edAngle.DecimalPlaces = 1;
            this.edAngle.Location = new System.Drawing.Point(72, 43);
            this.edAngle.Name = "edAngle";
            this.edAngle.Size = new System.Drawing.Size(120, 20);
            this.edAngle.TabIndex = 3;
            this.edAngle.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Угол: ";
            // 
            // edSpeed
            // 
            this.edSpeed.DecimalPlaces = 1;
            this.edSpeed.Location = new System.Drawing.Point(72, 69);
            this.edSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.edSpeed.Name = "edSpeed";
            this.edSpeed.Size = new System.Drawing.Size(120, 20);
            this.edSpeed.TabIndex = 5;
            this.edSpeed.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Скорость: ";
            // 
            // edSize
            // 
            this.edSize.DecimalPlaces = 1;
            this.edSize.Location = new System.Drawing.Point(272, 17);
            this.edSize.Name = "edSize";
            this.edSize.Size = new System.Drawing.Size(120, 20);
            this.edSize.TabIndex = 7;
            this.edSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Размер: ";
            // 
            // edWeight
            // 
            this.edWeight.DecimalPlaces = 1;
            this.edWeight.Location = new System.Drawing.Point(272, 43);
            this.edWeight.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.edWeight.Name = "edWeight";
            this.edWeight.Size = new System.Drawing.Size(120, 20);
            this.edWeight.TabIndex = 9;
            this.edWeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Масса: ";
            // 
            // edStart
            // 
            this.edStart.BackColor = System.Drawing.Color.GreenYellow;
            this.edStart.Location = new System.Drawing.Point(436, 19);
            this.edStart.Name = "edStart";
            this.edStart.Size = new System.Drawing.Size(75, 23);
            this.edStart.TabIndex = 10;
            this.edStart.Text = "Запуск";
            this.edStart.UseVisualStyleBackColor = false;
            this.edStart.Click += new System.EventHandler(this.edStart_Click);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(0, 103);
            this.chart.Name = "chart";
            series1.BorderColor = System.Drawing.Color.White;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.LightSeaGreen;
            series1.LabelBorderWidth = 5;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(734, 465);
            this.chart.TabIndex = 11;
            this.chart.Text = "chart";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Cancle
            // 
            this.Cancle.BackColor = System.Drawing.Color.Salmon;
            this.Cancle.Location = new System.Drawing.Point(436, 48);
            this.Cancle.Name = "Cancle";
            this.Cancle.Size = new System.Drawing.Size(75, 23);
            this.Cancle.TabIndex = 12;
            this.Cancle.Text = "Очистить";
            this.Cancle.UseVisualStyleBackColor = false;
            this.Cancle.Click += new System.EventHandler(this.Cancle_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edDt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.edHieght);
            this.panel1.Controls.Add(this.Cancle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edStart);
            this.panel1.Controls.Add(this.edAngle);
            this.panel1.Controls.Add(this.edWeight);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.edSpeed);
            this.panel1.Controls.Add(this.edSize);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 100);
            this.panel1.TabIndex = 13;
            // 
            // edDt
            // 
            this.edDt.DecimalPlaces = 5;
            this.edDt.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.edDt.Location = new System.Drawing.Point(272, 69);
            this.edDt.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edDt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.edDt.Name = "edDt";
            this.edDt.Size = new System.Drawing.Size(120, 20);
            this.edDt.TabIndex = 14;
            this.edDt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Шаг: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 574);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(734, 149);
            this.dataGridView1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 735);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.Text = "Laboratory1";
            ((System.ComponentModel.ISupportInitialize)(this.edHieght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edDt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown edHieght;
        private System.Windows.Forms.NumericUpDown edAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown edSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown edSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown edWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button edStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Cancle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown edDt;
        private System.Windows.Forms.Label label6;
    }
}

