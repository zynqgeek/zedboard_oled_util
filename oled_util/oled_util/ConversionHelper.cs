using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace oled_util
{
    class ConversionHelper
    {

        #region Constants

        private const int BITS_IN_A_BYTE = 8;

        #endregion Constants

        #region Static Functions

        static public Bitmap byteArrayToBitmap(byte[] byteArray, int height, int width)
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

        static public byte[] bitmapToByteArray(Bitmap image)
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
                        Color pixel = image.GetPixel(image.Width - widthIndex - 1, (heightIndex * BITS_IN_A_BYTE) + maskIndex);

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

        #endregion Static Functions

    }
}
