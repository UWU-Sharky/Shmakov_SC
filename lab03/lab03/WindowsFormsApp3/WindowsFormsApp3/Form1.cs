using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1(int N)
        {
            InitializeComponent();
            map = new Bitmap(N, N);
            using (Graphics g = Graphics.FromImage(map))
            {
                g.Clear(Color.White);
                currentColor = Color.White;
            }
        }

        Color currentColor;

        private bool isMousePress = false;

        Bitmap map;

        int[,] data;
        int[,] Health;
        int maxBurnTime, maxRockStable, maxTreeStable, timeDay;
        string Wind;
        decimal Humidity;
        string Day;
        private Random rnd = new Random();
        double windFactor = 1.5;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
       
                isMousePress = true;
                DrawAt(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMousePress = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePress)
            {
                DrawAt(e.X, e.Y);
            }
        }
        private void DrawAt(int mouseX, int mouseY)
        {
            if (currentColor != null)
            {
                int x = mouseX * map.Width / pictureBox1.Width;
                int y = mouseY * map.Height / pictureBox1.Height;

                if (x >= 0 && x < map.Width && y >= 0 && y < map.Height)
                {
                    map.SetPixel(x, y, currentColor);
                    pictureBox1.Refresh();
                }
            }
        }
        private int[,] GetArrayFromBitmap(Bitmap bmp)
        {
            int[,] array = new int[bmp.Width, bmp.Height];

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;
                    int max = Math.Max(r, Math.Max(g, b));
                    int min = Math.Min(r, Math.Min(g, b));

                    if (max - min < 30)
                    {
                        if (min > 200)
                            array[x, y] = 0; // Индекс для БЕЛОГО
                        else
                            array[x, y] = 4; // Индекс для СЕРОГО
                    }
                    else if (r >= g && r >= b)
                    {
                        array[x, y] = 2; // Индекс для КРАСНОГО
                    }
                    else if (g >= r && g >= b)
                    {
                        array[x, y] = 1; // Индекс для ЗЕЛЕНОГО
                    }
                    else
                    {
                        array[x, y] = 3; // Индекс для СИНЕГО
                    }
                }
            }
            return array;
        }

        private int[,] GetHealthFromArray(int[,] data)
        {
            int[,] res = new int[data.GetLength(0), data.GetLength(1)];

            for(int i = 0; i < data.GetLength(0); i++)
            {
                for(int j = 0; j < data.GetLength(1); j++)
                {
                    if (res[i, j] == 0)
                    {
                        if (data[i, j] == 1)
                        {
                            res[i, j] = maxTreeStable;
                        }
                        else if (data[i, j] == 2)
                        {
                            res[i, j] = maxBurnTime;
                        }
                        else if (data[i, j] == 4)
                        {
                            res[i, j] = maxRockStable;
                        }
                    }
                }
            }

            return res;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            if (map != null)
            {
                e.Graphics.DrawImage(map, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
        }

        private void edClear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (map != null)
            {
                using (Graphics g = Graphics.FromImage(map))
                {
                    g.Clear(Color.White);
                }

                pictureBox1.Image = map;
                pictureBox1.Invalidate();
            }
        }

        private void TileButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentColor = btn.BackColor;
        }

        private void edStart_Click(object sender, EventArgs e)
        {
            var timeData = new Dictionary<string, int>
            {
                { "Утро", 2 },
                { "Полдень", 4 },
                { "Ночь", 0 }
            };
 
            data = GetArrayFromBitmap(map);
            Wind = edWind.Text;
            Humidity = (decimal)edHumidity.Value;
            Day = edDay.Text;
            timeDay = timeData[Day];

            maxBurnTime = 4 - (int)(Humidity * (1/4)) + timeDay;
            maxRockStable = 30;
            maxTreeStable = 2 + (int)(Humidity * (1/4)) - timeDay;

            Health = GetHealthFromArray(data);

            timer1.Interval = (int)(edTime.Value);
            //MessageBox.Show(Convert.ToString(timer1.Interval));
            timer1.Start();
        }

        /* 0 - БЕЛЫЙ
         * 1 - ЗЕЛЕНЫЙ
         * 2 - КРАСНЫЙ
         * 3 - СИНИЙ
         * 4 - СЕРЫЙ
         */

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    int currentCell = data[i, j];

                    if (currentCell == 0)
                    {
                        // Если клетка пустая, то с некой вер-стью в ней появится огонь 
                        if (rnd.NextDouble() < (Math.Abs(0.05 * (double)Humidity - 0.5))/2)
                        {
                            data[i, j] = 2;
                            Health[i, j] = maxBurnTime;
                        }
                        // Если клетка пустая, то с некой вер-стью в ней появится дерево
                        else if (rnd.NextDouble() < (Math.Abs(0.05 * (double)Humidity + 0.5)))
                        {
                            data[i, j] = 1;
                            Health[i, j] = maxTreeStable;
                        }

                        //else
                        //{
                        //    for (int ni = -1; ni <= 1; ni++)
                        //    {
                        //        for (int nj = -1; nj <= 1; nj++)
                        //        {
                        //            if (ni == 0 && nj == 0) continue;

                        //            int checkX = i + ni;
                        //            int checkY = j + nj;

                        //            if (checkX >= 0 && checkX < data.GetLength(0) &&
                        //                checkY >= 0 && checkY < data.GetLength(1))
                        //            {
                        //                int neighborValue = data[checkX, checkY];
                        //                if (neighborValue == 2)
                        //                {
                        //                    if (rnd.NextDouble() < (Math.Abs(0.05 * (double)Humidity - 0.5)))
                        //                    {
                        //                        data[i, j] = 2;
                        //                        Health[i, j] = maxBurnTime;
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                    }

                    else if (currentCell == 1)
                    {
                        for (int ni = -1; ni <= 1; ni++)
                        {
                            for (int nj = -1; nj <= 1; nj++)
                            {
                                if (ni == 0 && nj == 0) continue;

                                int checkX = i + ni;
                                int checkY = j + nj;

                                if (checkX >= 0 && checkX < data.GetLength(0) &&
                                    checkY >= 0 && checkY < data.GetLength(1))
                                {
                                    int neighborValue = data[checkX, checkY];
                                    if (neighborValue == 2)
                                    {
                                        double probability = (Math.Abs(0.05 * (double)Humidity - 0.5));

                                        if (Wind == "Север" && nj == 1) 
                                            probability *= windFactor;
                                        else if (Wind == "Юг" && nj == -1) 
                                            probability *= windFactor;
                                        else if (Wind == "Запад" && ni == 1) 
                                            probability *= windFactor;
                                        else if (Wind == "Восток" && ni == -1)
                                            probability *= windFactor;

                                        if (Health[i, j] > 0)
                                        {
                                            if (rnd.NextDouble() < probability)
                                            {
                                                Health[i, j]--;
                                            }
                                        }
                                        else
                                        {
                                            if (rnd.NextDouble() < probability)
                                            {
                                                data[i, j] = 2;
                                                Health[i, j] = maxBurnTime;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else if (currentCell == 2)
                    {
                        if (Health[i, j] > 0)
                        {
                            Health[i, j]--;
                        }
                        else
                        {
                            data[i, j] = 0;
                        }
                    }

                    else if (currentCell == 3) { continue; } // Проверяем не вода ли

                    else if (currentCell == 4)
                    {
                        for (int ni = -1; ni <= 1; ni++)
                        {
                            for (int nj = -1; nj <= 1; nj++)
                            {
                                if (ni == 0 && nj == 0) continue;

                                int checkX = i + ni;
                                int checkY = j + nj;

                                if (checkX >= 0 && checkX < data.GetLength(0) &&
                                    checkY >= 0 && checkY < data.GetLength(1))
                                {
                                    int neighborValue = data[checkX, checkY];
                                    if (neighborValue == 2)
                                    {
                                        if (Health[i, j] > 0)
                                        {
                                            Health[i, j]--;
                                        }
                                        else
                                        {
                                            if (rnd.NextDouble() < (Math.Abs(0.05 * (double)Humidity - 0.5)))
                                            {
                                                data[i, j] = 2;
                                                Health[i, j] = maxBurnTime;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            UpdateBitmapFromArray();
        }

        private void UpdateBitmapFromArray()
        {
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    Color c;
                    switch (data[x, y])
                    {
                        case 0: c = Color.White; break;
                        case 1: c = Color.Green; break;
                        case 2: c = Color.Red; break;
                        case 3: c = Color.Blue; break;
                        case 4: c = Color.Gray; break;
                        default: c = Color.Black; break;
                    }
                    map.SetPixel(x, y, c);
                }
            }
            pictureBox1.Invalidate(); // Принудительная перерисовка
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Process.GetCurrentProcess().Kill(); // Жесткое завершение процесса
        }
    }
}
