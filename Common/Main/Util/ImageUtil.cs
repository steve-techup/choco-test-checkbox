using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Util
{
    public class ImageUtil
    {
        // resize image to a max width and height
        public static System.Drawing.Image ResizeImage(System.Drawing.Image image, int maxWidth, int maxHeight)
        {
            var newWidth = image.Width;
            var newHeight = image.Height;

            // check if the image needs to be resized
            if (image.Width > maxWidth || image.Height > maxHeight)
            {
                // get the ratio
                double ratioX = (double)maxWidth / image.Width;
                double ratioY = (double)maxHeight / image.Height;
                // use whichever multiplier is smaller
                double ratio = ratioX < ratioY ? ratioX : ratioY;

                // now we can get the new height and width
                newWidth = (int)(image.Width * ratio);
                newHeight = (int)(image.Height * ratio);
            }

            // create a new image object
            var newImage = new System.Drawing.Bitmap(newWidth, newHeight);

            // get a graphics object from the new image
            var graphics = System.Drawing.Graphics.FromImage(newImage);

            // set the resize quality modes to high quality
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // draw the image into the target bitmap
            graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            // dispose the graphics object
            graphics.Dispose();

            // return the new image
            return newImage;
        }


    }
}
