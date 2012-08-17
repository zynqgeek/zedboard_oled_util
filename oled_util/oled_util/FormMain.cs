using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace oled_util
{
    public partial class FormMain : Form
    {
        private const int OLED_PIXEL_WIDTH = 128;
        private const int OLED_PIXEL_HEIGHT = 32;
        private const int BITS_IN_A_BYTE = 8;

        bool binFileOpened = false;
        bool pngFileOpened = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            
            OpenFileDialog ofd = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            ofd.Filter = "OLED BIN File (*.bin)|*.bin|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // create our buffer
                            byte[] byteBuffer = new byte[myStream.Length];
                            
                            // populate our buffer
                            myStream.Read(byteBuffer, 0, (int)myStream.Length);

                            myStream.Close();

                            if (byteBuffer.Length != 512)
                            {
                                MessageBox.Show("Input bit file not 512 bytes in size (file is " + byteBuffer.Length + " bytes in size)");
                            }
                            else
                            {

                                // convery our buffer to an image
                                Bitmap image = byteArrayToBitmap(byteBuffer, OLED_PIXEL_HEIGHT, OLED_PIXEL_WIDTH);

                                // set image
                                pictureBoxBin.Image = image;

                                binFileOpened = true;

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

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

        private void buttonClearBin_Click(object sender, EventArgs e)
        {
            pictureBoxBin.Image = new Bitmap(128, 32);
            binFileOpened = false;
        }

        private void buttonClearPng_Click(object sender, EventArgs e)
        {
            pictureBoxPng.Image = new Bitmap(128, 32);
            pngFileOpened = false;
        }

        private void buttonSavePng_Click(object sender, EventArgs e)
        {
            if (binFileOpened == false)
            {
                MessageBox.Show("You must load a .bin file first that is 512Bytes large.");
            }
            else
            {

                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "image files (*.png)|*.png|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        // write out the file
                        pictureBoxPng.Image.Save(myStream, System.Drawing.Imaging.ImageFormat.Png);

                        // close the stream, we are all done here.
                        myStream.Close();
                    }
                }
            }
        }

        private void buttonOpenPng_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            
            OpenFileDialog ofd = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            ofd.Filter = "OLED BIN File (*.bin)|*.bin|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        using (myStream)
                        {


                            // load the image into the image box
                            Image image = Image.FromStream(myStream);

                            if (!(image.Size.Height == 32 && image.Size.Width == 128))
                            {
                                MessageBox.Show("The image must be 128x32 pixels in size");
                            }
                            else
                            {

                                // assign the image to the picture box
                                pictureBoxPng.Image = image;

                                // set our flag so we know an image is loaded
                                pngFileOpened = true;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                }
            }
        }

        private void buttonSaveBin_Click(object sender, EventArgs e)
        {
            if (pngFileOpened == false)
            {
                MessageBox.Show("You must load a png file that is 128x32 first");
            }
            else
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "image files (*.png)|*.png|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        // we need to convert out image to a bin file.
                        byte[] byteArray = bitmapToByteArray((Bitmap)pictureBoxPng.Image);

                        // show the output display
                        Display disp = new Display();
                        disp.updateImageWithByteArray(byteArray, pictureBoxPng.Height, pictureBoxPng.Width);
                        disp.ShowDialog();

                        // write out the stream
                        myStream.Write(byteArray, 0, byteArray.Length);

                        // close the stream, we are all done here.
                        myStream.Close();
                    }
                }
            }
        }

        private byte[] bitmapToByteArray(Bitmap image)
        {
            byte[] byteArray = new byte[(image.Height / BITS_IN_A_BYTE) * image.Width];

            // for every width pixel ...
            for (int widthIndex = 0; widthIndex < image.Width; widthIndex++)
            {
            
                // four the height / BITS_IN_A_BYTE we will create a single byte that will represent these 8 pixels    
                for (int heightIndex = 0; heightIndex < (image.Height / BITS_IN_A_BYTE); heightIndex++)
                {

                    int tempVal = 0;

                    for (int maskIndex = 0; maskIndex < BITS_IN_A_BYTE; maskIndex++)
                    {
                        Color pixel = image.GetPixel(image.Width - widthIndex-1, (heightIndex * BITS_IN_A_BYTE) + maskIndex);

                        if (pixel.R == 255 & pixel.G == 255 && pixel.B == 255)
                        {
                            // no need to do anything since this bit will be zero
                        }
                        else
                        {
                            // need to set that bit within the byte to a 1
                            tempVal += (1 << maskIndex);
                        }

                    }

                    byteArray[(heightIndex * image.Width) + widthIndex] = (byte)tempVal;
                }
            }

            return byteArray;
        }
    }
}