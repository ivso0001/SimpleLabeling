using SimpleLabeling.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimpleLabeling
{
    public partial class Form1 : Form
    {
        private ImageViewerForm imageViewerForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void openImages (string[] files)
        {
            trackBar1.Maximum = files.Length - 1;

            if (imageViewerForm != null) imageViewerForm.Close();
            imageViewerForm = new ImageViewerForm(files);
            imageViewerForm.Show();
            imageViewerForm.Location = new Point(Location.X + Size.Width, Location.Y);
            imageViewerForm.OnStateUpdate += new ImageViewerForm.StateUpdateHandler(StateUpdate);
        }

        private void StateUpdate(int index)
        {
            trackBar1.Value = index;
        }

        private void openImageDirectoryBtn_Click(object sender, EventArgs e)
        {
            string lastDirectory = Settings.Default.LastDirectory;

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = lastDirectory;
                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Settings.Default.LastDirectory = fbd.SelectedPath;
                    Settings.Default.Save();

                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    openImages(files);
                }
            }
        }

        private void openImageFileBtn_Click(object sender, EventArgs e)
        {
            string lastDirectory = Settings.Default.LastDirectory;
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = lastDirectory;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.LastDirectory = ofd.FileName.Replace(ofd.FileName.Split('\\')[ofd.FileName.Split('\\').Length - 1], "");
                    Settings.Default.Save();

                    string[] files = new string[] { ofd.FileName };
                    openImages(files);
                }
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (imageViewerForm != null)
            {
                imageViewerForm.Location = new Point(Location.X + Size.Width, Location.Y);
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (imageViewerForm != null)
                        imageViewerForm.Load(ofd.FileName);
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (imageViewerForm != null)
                imageViewerForm.Save();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (imageViewerForm != null)
                imageViewerForm.MoveFile(trackBar1.Value);
        }
    }
}
