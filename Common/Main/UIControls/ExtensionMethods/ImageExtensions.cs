using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIControls
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Return a Thumbnail with correct aspect ratio.
        /// </summary>
        /// <param name="sourceImg"></param>
        /// <param name="thumbnailSize">The size of the thumbnail returned</param>
        /// <returns></returns>
        public static Bitmap? Thumbnail(this Image? sourceImg, Size thumbnailSize)
        {
            if (sourceImg is null)
                return null;

            var targetSize = ResizeKeepAspect(sourceImg.Size, thumbnailSize);
            var resizedImage = ResizeImage(sourceImg, targetSize);
            return resizedImage;
        }
        /// <summary>
        /// Returns a MemoryStream with a specific file format
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageFormat">File format wanted</param>
        /// <returns></returns>
        public static MemoryStream GetFormattedStream(this Image image, ImageFormat imageFormat)
        {
            var stream = new MemoryStream();
            image.Save(stream, imageFormat);
            stream.Position = 0;
            return stream;
        }
        

        private static Bitmap? ResizeImage(Image image, Size size)
        {
            var destRect = new Rectangle(0, 0, size.Width, size.Height);
            var destImage = new Bitmap(size.Width, size.Height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using var graphics = Graphics.FromImage(destImage);
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using var wrapMode = new ImageAttributes();
            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);

            return destImage;
        }

        private static Size ResizeKeepAspect(Size src, Size dest)
        {
            dest.Width = Math.Min(dest.Width, src.Width);
            dest.Height = Math.Min(dest.Height, src.Height);

            decimal rnd = Math.Min(dest.Width / (decimal)src.Width, dest.Height / (decimal)src.Height);
            return new Size((int)Math.Round(src.Width * rnd), (int)Math.Round(src.Height * rnd));
        }

        /// <summary>
        /// Load a thumbnail with correct aspect ratio into the DestinationPictureBox.
        /// </summary>
        /// <param name="sourceImg"></param>
        /// <param name="destinationPictureBox">PictureBox that is to hold the thumbnail</param>
        public static void Thumbnail(this Image? sourceImg, PictureBox destinationPictureBox)
        {
            if (sourceImg is null)
                return;

            destinationPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            destinationPictureBox.Image = sourceImg.Thumbnail(destinationPictureBox.Size);
        }
        /// <summary>
        /// Return a small cutout of the image.
        /// </summary>
        /// <param name="sourceImg"></param>
        /// <param name="location">The location to cut out - If used in MouseMove use e.Location</param>
        /// <param name="destinationPictureBox">The picturebox to show the cutout in</param>
        public static void CutOut(this Image sourceImg, Point location, PictureBox destinationPictureBox)
        {
            // Create Bitmap using the original picture, so Pixel settings are maintained
            Bitmap cutOut = new Bitmap(sourceImg, new Size(destinationPictureBox.Width, destinationPictureBox.Height));

            using (Graphics graphics = Graphics.FromImage(cutOut))
            {

                // Fill picture background with background color of the picturebox to avoid artifacting
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(destinationPictureBox.BackColor))
                {
                    graphics.FillRectangle(myBrush, new Rectangle(0, 0, cutOut.Width, cutOut.Height));

                }

                // Math
                double dX, dY, multiplierX, multiplierY;
                multiplierX = (double)sourceImg.Width / cutOut.Width;
                multiplierY = (double)sourceImg.Height / cutOut.Height;
                dX = (location.X * multiplierX);
                dY = (location.Y * multiplierY);

                // Get resized original image
                var newSource = ResizeImgToMatchThumbnailAspect(sourceImg, cutOut.Size, multiplierX, multiplierY,
                    destinationPictureBox.BackColor);

                // Copy Image Region
                Rectangle srcRegion = new Rectangle((int)dX, (int)dY, cutOut.Width, cutOut.Height);
                Rectangle destRegion = new Rectangle(0, 0, cutOut.Width - 1, cutOut.Height - 1);
                CopyRegionIntoImage(newSource, srcRegion, ref cutOut, destRegion);

                destinationPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                destinationPictureBox.Image = cutOut;
            }
        }
        
        private static Image ResizeImgToMatchThumbnailAspect(Image srcImage, Size thumbnailSize, double multiplierX,
            double multiplierY, Color backColor)
        {
            // Create a source image with matching aspect ratio to the destination, so X and Y line up.
            var w = (int)Math.Round(multiplierX * thumbnailSize.Width);
            var h = (int)Math.Round(multiplierY * thumbnailSize.Height);

            Bitmap newImage = new Bitmap(w, h, srcImage.PixelFormat);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                using var myBrush = new SolidBrush(backColor);
                graphics.FillRectangle(myBrush, new Rectangle(0, 0, newImage.Width, newImage.Height));
            }

            // calculate x and y to center img
            double x = (newImage.Width / 2) - (srcImage.Width / 2);
            double y = (newImage.Height / 2) - (srcImage.Height / 2);

            // Copy Image Region
            Rectangle srcRegion = new Rectangle(0, 0, srcImage.Width, srcImage.Height);
            Rectangle destRegion = new Rectangle((int)x, (int)y, newImage.Width, newImage.Height);
            CopyRegionIntoImage(srcImage, srcRegion, ref newImage, destRegion);

            return newImage;
        }
        
        private static void CopyRegionIntoImage(Image srcImage, Rectangle srcRegion, ref Bitmap destBitmap, Rectangle destRegion)
        {
            using Graphics grD = Graphics.FromImage(destBitmap);
            grD.DrawImage(srcImage, destRegion, srcRegion, GraphicsUnit.Pixel);
        }
    }
}
