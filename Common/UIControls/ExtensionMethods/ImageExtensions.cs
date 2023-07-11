using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIControls
{
    public static partial class ImageExtensions
    {

        #region Public Extension Methods
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

        /// <summary>
        /// Return a Thumbnail with correct aspect ratio.
        /// </summary>
        /// <param name="sourceImg"></param>
        /// <param name="thumbnailSize">The size of the thumbnail returned</param>
        /// <returns></returns>
        public static Bitmap Thumbnail(this Image sourceImg, Size thumbnailSize)
        {
            if (sourceImg is null)
                return null;

            Size ThumbnailSize = ResizeKeepAspect(sourceImg.Size, thumbnailSize);
            var Thumbnail = ResizeImage(sourceImg, ThumbnailSize);
            return Thumbnail;
        }
        #endregion

        #region Private

        private static Bitmap ResizeImage(Image image, Size size)
        {
            var destRect = new Rectangle(0, 0, size.Width, size.Height);
            var destImage = new Bitmap(size.Width, size.Height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private static Size ResizeKeepAspect(Size src, Size dest)
        {
            dest.Width = Math.Min(dest.Width, src.Width);
            dest.Height = Math.Min(dest.Height, src.Height);

            decimal rnd = Math.Min(dest.Width / (decimal)src.Width, dest.Height / (decimal)src.Height);
            return new Size((int)Math.Round(src.Width * rnd), (int)Math.Round(src.Height * rnd));
        }
        #endregion
    }
}
