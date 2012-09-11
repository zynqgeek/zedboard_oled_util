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

        #region Constants

        private const int OLED_PIXEL_WIDTH = 128;
        private const int OLED_PIXEL_HEIGHT = 32;

        #endregion Constants

        #region Global Load States

        bool binFileOpened = false;
        bool pngFileOpened = false;

        #endregion Gloabl Load States

        #region Constructor

        public FormMain()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Button Pushes

        #region .bin -> .png

        private void buttonOpenBin_Click(object sender, EventArgs e)
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
                                Bitmap image = ConversionHelper.byteArrayToBitmap(byteBuffer, OLED_PIXEL_HEIGHT, OLED_PIXEL_WIDTH);

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

        private void buttonClearBin_Click(object sender, EventArgs e)
        {
            pictureBoxBin.Image = new Bitmap(128, 32);
            binFileOpened = false;
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
                        byte[] byteArray = ConversionHelper.bitmapToByteArray((Bitmap)pictureBoxPng.Image);

                        // show the output display
                        Display disp = new Display();
                        disp.updateImage(ConversionHelper.byteArrayToBitmap(byteArray, pictureBoxPng.Height, pictureBoxPng.Width));
                        disp.ShowDialog();

                        // write out the stream
                        myStream.Write(byteArray, 0, byteArray.Length);

                        // close the stream, we are all done here.
                        myStream.Close();
                    }
                }
            }
        }

        #endregion .bin -> .png

        #region .png -> .bin
       
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
                        Bitmap newImage = new Bitmap(pictureBoxBin.Image.Width, pictureBoxBin.Image.Height);

                        for (int i = 0; i < pictureBoxBin.Image.Height; i++)
                        {
                            for (int j = 0; j < pictureBoxBin.Image.Width; j++)
                            {
                                if (((Bitmap)pictureBoxBin.Image).GetPixel(j, i).R == 0 &&
                                    ((Bitmap)pictureBoxBin.Image).GetPixel(j, i).G == 0 &&
                                    ((Bitmap)pictureBoxBin.Image).GetPixel(j, i).B == 0
                                    )
                                    newImage.SetPixel(j, i, Color.White);
                                else
                                    newImage.SetPixel(j, i, Color.Black);
                            }
                        }

                        // write out the file
                        newImage.Save(myStream, System.Drawing.Imaging.ImageFormat.Png);

                        // close the stream, we are all done here.
                        myStream.Close();

                        // show the output display
                        Display disp = new Display();
                        disp.updateImage((Bitmap)Bitmap.FromFile(saveFileDialog1.FileName));
                        disp.ShowDialog();
                    }
                }
            }
        }

        private void buttonClearPng_Click(object sender, EventArgs e)
        {
            pictureBoxPng.Image = new Bitmap(128, 32);
            pngFileOpened = false;
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

        #endregion .png -> .bin

        private void buttonConvertDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();

            if (fdb.ShowDialog() == DialogResult.OK)
            {
                string folder = fdb.SelectedPath;
                foreach (string fileName in Directory.GetFiles(folder, "*.png", SearchOption.TopDirectoryOnly))
                {
                    string baseFileNameWithPath = fileName.Substring(0, fileName.LastIndexOf('.'));

                    byte[] byteArray = ConversionHelper.bitmapToByteArray(new Bitmap(fileName));

                    File.WriteAllBytes(baseFileNameWithPath + ".bin", byteArray);

                    //StreamWriter sw = new StreamWriter(baseFileNameWithPath + ".bin");

                    //sw.Write(byteArray);

                    //sw.Close();
                }

                MessageBox.Show(Directory.GetFiles(folder, "*.png", SearchOption.TopDirectoryOnly).Length + " images converted.");
            }
        }

        #endregion Button Pushes

    }

   
}