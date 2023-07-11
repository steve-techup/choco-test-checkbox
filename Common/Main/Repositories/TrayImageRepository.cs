using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BitFaster.Caching.Lru;
using Caretag_Class.Model;
using Caretag_Class.Util;
using DevExpress.Drawing.Native;

namespace Caretag_Class.Repositories
{
    public class TrayImageRepository
    {
        private readonly CaretagModel _dbContext;
        private readonly ConcurrentLru<int, Image?> _imageCache = new(100);

        public TrayImageRepository(CaretagModel dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Image?> GetResizedImageByTrayIdAsync(int tray_description_id, int width, int height)
        {
            return await _imageCache.GetOrAddAsync(tray_description_id, id =>
            {
                var image = _dbContext.Tray_Image.AsNoTracking().FirstOrDefault(t => t.Description_ID == tray_description_id);

                if (image == null) return Task.FromResult<Image?>(null);
                
                using var stream = new MemoryStream(image.TheImage);
                var loadedImage = Image.FromStream(stream);
                return Task.Run(() => ImageUtil.ResizeImage(loadedImage, width, height));

            });
        }
    }
}
