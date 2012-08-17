using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace oled_util
{
    public partial class Display : Form
    {
        const int BITS_IN_A_BYTE = 8;

        public Display()
        {
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {

        }

        public void updateImageWithByteArray(byte[] byteArray, int height, int width)
        {
            Bitmap image = byteArrayToBitmap(byteArray, height, width);

            pictureBoxBin.Image = image;
        }

        private Bitmap byteArrayToBitmap(byte[] byteArray, int height, int width)
        {
            // create our bitmap image that we will be maping the contents of the byte
            // array into
            Bitmap image = new Bitmap(width, height);

            // we need to expand out the byte array to a single byte representing each bit
            // in each of the bytes.  This will allow the next loop to be less than confusing.
            for (int heightIndex = 0; heightIndex < height / BITS_IN_A_BYTE; heightIndex++)
            {
                for (int widthIndex = 0; widthIndex < width; widthIndex++)
                {
                    for (int maskOffset = 0; maskOffset < BITS_IN_A_BYTE; maskOffset++)
                    {
                        int value = byteArray[(heightIndex * width) + widthIndex];
                        int maskResult = value & (1 << maskOffset);

                        // calculate the x,y location in the image we need to update
                        int x = width - widthIndex - 1;

                        int y = (heightIndex * (BITS_IN_A_BYTE)) + maskOffset;

                        if (maskResult != 0)
                            image.SetPixel(x, y, Color.Aqua);
                        else
                            image.SetPixel(x, y, Color.Black);
                    }
                }
            }

            // reaturn our created image
            return image;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
