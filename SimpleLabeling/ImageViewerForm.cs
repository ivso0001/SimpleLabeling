﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SimpleLabeling
{
    public partial class ImageViewerForm : Form
    {
        public static string CSV_PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\file.csv";

        private Point startPos;
        private Point currentPos;
        private List<Data> dataList;

        private int currentIndex;
        private bool drawing;
        private string[] files;

        public delegate void StateUpdateHandler(int index);
        public event StateUpdateHandler OnStateUpdate;

        public ImageViewerForm(string[] files)
        {
            InitializeComponent();

            this.files = files;
            dataList = new List<Data>();
            UpdateForm();
        }

        public void Save()
        {
            using (StreamWriter file = new StreamWriter(CSV_PATH.Replace(".", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString() + ".")))
            {
                foreach (Data data in dataList)
                {
                    file.WriteLine(data.File + ", " + data.X1 + ", " + data.Y1 + ", " + data.X2 + ", " + data.Y2);
                }
            }
        }

        public void Load(string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            if (fileInfo.Exists)
            {
                dataList.Clear();
                string[] texts = File.ReadAllLines(@fileInfo.ToString());
                foreach (string text in texts)
                {
                    string[] datas = text.Replace(", ", ",").Split(',');
                    if (datas.Length == 5)
                    {
                        dataList.Add(new Data(datas[0], Int32.Parse(datas[1]), Int32.Parse(datas[2]), Int32.Parse(datas[3]), Int32.Parse(datas[4])));
                    }
                }
                pictureBox1.Refresh();
            }
        }

        private void StateUpdate(int index)
        {
            if (OnStateUpdate == null) return;
            OnStateUpdate(index);
        }

        private void UpdateForm()
        {
            try
            {
                Text = files[currentIndex].Split('\\')[files[currentIndex].Split('\\').Length - 1];
                pictureBox1.Load(files[currentIndex]);
                pictureBox1.Size = new Size(pictureBox1.Image.Width, pictureBox1.Image.Height);
                Size = new Size(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Refresh();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void MoveFile(int index)
        {
            if (files.Length > index && index > -1)
            {
                currentIndex = index;
                UpdateForm();
                StateUpdate(currentIndex);
            }
        }

        private void NextFile()
        {
            if (files.Length - 1 > currentIndex)
            {
                currentIndex++;
                UpdateForm();
                StateUpdate(currentIndex);
            }
        }

        private void PrevFile()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                UpdateForm();
                StateUpdate(currentIndex);
            }
        }

        private void Draw(Graphics graphics)
        {
            DrawRectangles(graphics);
            if (!drawing) DrawLines(graphics);
            if (drawing) DrawRectangle(graphics);
        }

        private void DrawRectangles(Graphics graphics)
        {
            foreach (Data data in dataList)
            {
                if (data.File == files[currentIndex])
                {
                    graphics.DrawRectangle(Pens.Aqua, getRectangle(data.X1, data.X2, data.Y1, data.Y2));
                }
            }
        }

        private void DrawRectangle(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Red, getRectangle(startPos.X, currentPos.X, startPos.Y, currentPos.Y));
        }

        private void DrawLines(Graphics graphics)
        {
            graphics.DrawLine(Pens.Red, currentPos.X, 0, currentPos.X, pictureBox1.Image.Height);
            graphics.DrawLine(Pens.Red, 0, currentPos.Y, pictureBox1.Image.Width, currentPos.Y);
        }

        private Rectangle getRectangle(int x1, int x2, int y1, int y2)
        {
            return new Rectangle(
                Math.Min(x1, x2),
                Math.Min(y1, y2),
                Math.Abs(x1 - x2),
                Math.Abs(y1 - y2));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    currentPos = startPos = e.Location;
                    drawing = true;
                    break;
                case MouseButtons.Right:
                    if (dataList.Count > 0)
                    {
                        int end = -1;
                        for (int i = 0; i < dataList.Count; i++)
                        {
                            if (dataList[i].File == files[currentIndex]) end = i;
                        }
                        if (end != -1)
                        {
                            dataList.RemoveAt(end);
                            pictureBox1.Refresh();
                        }
                    }
                    break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            currentPos = e.Location;
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                dataList.Add(new Data(files[currentIndex], startPos.X, startPos.Y, currentPos.X, currentPos.Y));
                pictureBox1.Refresh();
            }
        }

        private void ImageViewerForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    PrevFile();
                    break;
                case Keys.Right:
                    NextFile();
                    break;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }
    }
}
