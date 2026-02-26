using System.Reflection.Emit;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edTau = new System.Windows.Forms.ComboBox();
            this.edDx = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.edT_right = new System.Windows.Forms.NumericUpDown();
            this.edT_left = new System.Windows.Forms.NumericUpDown();
            this.edT0 = new System.Windows.Forms.NumericUpDown();
            this.edT_total = new System.Windows.Forms.NumericUpDown();
            this.edL = new System.Windows.Forms.NumericUpDown();
            this.edLambda = new System.Windows.Forms.NumericUpDown();
            this.edC = new System.Windows.Forms.NumericUpDown();
            this.edRho = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Try = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edT_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edT_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edT0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edT_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLambda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edRho)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.edTau);
            this.groupBox1.Controls.Add(this.edDx);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.edT_right);
            this.groupBox1.Controls.Add(this.edT_left);
            this.groupBox1.Controls.Add(this.edT0);
            this.groupBox1.Controls.Add(this.edT_total);
            this.groupBox1.Controls.Add(this.edL);
            this.groupBox1.Controls.Add(this.edLambda);
            this.groupBox1.Controls.Add(this.edC);
            this.groupBox1.Controls.Add(this.edRho);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // edTau
            // 
            this.edTau.FormattingEnabled = true;
            this.edTau.Items.AddRange(new object[] {
            "0,1",
            "0,01",
            "0,001",
            "0,0001"});
            this.edTau.Location = new System.Drawing.Point(173, 157);
            this.edTau.Name = "edTau";
            this.edTau.Size = new System.Drawing.Size(121, 21);
            this.edTau.TabIndex = 24;
            // 
            // edDx
            // 
            this.edDx.FormattingEnabled = true;
            this.edDx.Items.AddRange(new object[] {
            "0,1",
            "0,01",
            "0,001",
            "0,0001"});
            this.edDx.Location = new System.Drawing.Point(173, 109);
            this.edDx.Name = "edDx";
            this.edDx.Size = new System.Drawing.Size(121, 21);
            this.edDx.TabIndex = 23;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Location = new System.Drawing.Point(174, 256);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 22;
            this.btnStart.Text = "Запуск";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // edT_right
            // 
            this.edT_right.Location = new System.Drawing.Point(174, 230);
            this.edT_right.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edT_right.Name = "edT_right";
            this.edT_right.Size = new System.Drawing.Size(120, 20);
            this.edT_right.TabIndex = 21;
            this.edT_right.Value = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            // 
            // edT_left
            // 
            this.edT_left.Location = new System.Drawing.Point(174, 205);
            this.edT_left.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edT_left.Name = "edT_left";
            this.edT_left.Size = new System.Drawing.Size(120, 20);
            this.edT_left.TabIndex = 20;
            this.edT_left.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // edT0
            // 
            this.edT0.Location = new System.Drawing.Point(174, 182);
            this.edT0.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edT0.Name = "edT0";
            this.edT0.Size = new System.Drawing.Size(120, 20);
            this.edT0.TabIndex = 18;
            this.edT0.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // edT_total
            // 
            this.edT_total.Location = new System.Drawing.Point(174, 134);
            this.edT_total.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edT_total.Name = "edT_total";
            this.edT_total.Size = new System.Drawing.Size(120, 20);
            this.edT_total.TabIndex = 16;
            this.edT_total.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // edL
            // 
            this.edL.DecimalPlaces = 1;
            this.edL.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edL.Location = new System.Drawing.Point(174, 86);
            this.edL.Name = "edL";
            this.edL.Size = new System.Drawing.Size(120, 20);
            this.edL.TabIndex = 14;
            this.edL.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // edLambda
            // 
            this.edLambda.DecimalPlaces = 3;
            this.edLambda.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.edLambda.Location = new System.Drawing.Point(174, 62);
            this.edLambda.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.edLambda.Name = "edLambda";
            this.edLambda.Size = new System.Drawing.Size(120, 20);
            this.edLambda.TabIndex = 2;
            this.edLambda.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // edC
            // 
            this.edC.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edC.Location = new System.Drawing.Point(174, 38);
            this.edC.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.edC.Name = "edC";
            this.edC.Size = new System.Drawing.Size(120, 20);
            this.edC.TabIndex = 13;
            this.edC.Value = new decimal(new int[] {
            460,
            0,
            0,
            0});
            // 
            // edRho
            // 
            this.edRho.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.edRho.Location = new System.Drawing.Point(174, 14);
            this.edRho.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.edRho.Name = "edRho";
            this.edRho.Size = new System.Drawing.Size(120, 20);
            this.edRho.TabIndex = 1;
            this.edRho.Value = new decimal(new int[] {
            7800,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(85, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Темп. справа: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(91, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Темп. слева: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(116, 264);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Начальная темп. T0: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Шаг по времени τ: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Время Моделирования: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Шаг по пространству dx:  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Длина Пластины L: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Коэф. Теплопроводности λ: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Уд. Теплоемкость c: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Плотность ρ: ";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(326, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 426);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "График";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 16);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(564, 282);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Try,
            this.Column1,
            this.Record});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 298);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(564, 125);
            this.dataGridView1.TabIndex = 23;
            // 
            // Try
            // 
            this.Try.HeaderText = "Номер";
            this.Try.Name = "Try";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "T0 в середине";
            this.Column1.Name = "Column1";
            // 
            // Record
            // 
            this.Record.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Record.HeaderText = "Замер";
            this.Record.Name = "Record";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Laboratory 2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edT_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edT_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edT0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edT_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edRho)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown edT_right;
        private System.Windows.Forms.NumericUpDown edT_left;
        private System.Windows.Forms.NumericUpDown edT0;
        private System.Windows.Forms.NumericUpDown edT_total;
        private System.Windows.Forms.NumericUpDown edL;
        private System.Windows.Forms.NumericUpDown edLambda;
        private System.Windows.Forms.NumericUpDown edC;
        private System.Windows.Forms.NumericUpDown edRho;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox edTau;
        private System.Windows.Forms.ComboBox edDx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Try;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Record;
    }
}

