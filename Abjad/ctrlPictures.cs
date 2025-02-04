using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Abjad
{
    public partial class ctrlPictures : UserControl
    {
        public ctrlPictures()
        {
            InitializeComponent();
        }

        int index = 0;

        private async void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;

            await Task.Delay(500);

            if(progressBar1.Value==5)
            {
                index++;
                if(index==imageList1.Images.Count)
                {
                    index = 0;
                }
                pictureBox1.Image = imageList1.Images[index];
                progressBar1.Value = 0;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPictures_Load(object sender, EventArgs e)
        {
            string[] picturespathes = File.ReadAllLines("C:\\Users\\AnaniFamily\\Downloads\\Pictures.txt");

            foreach (string picture in picturespathes)
            {
                Image image = Image.FromFile(picture);
                imageList1.Images.Add(image);
            }
            pictureBox1.Image = imageList1.Images[0];
        }
    }
}
