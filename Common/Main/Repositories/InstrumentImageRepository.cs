using BitFaster.Caching.Lru;
using Caretag_Class.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Util;

namespace Caretag_Class.Repositories
{
    public class InstrumentImageRepository
    {
        private readonly CaretagModel _dbContext;
        private readonly ConcurrentLru<string?, Image?> _imageCache = new(100);

        public InstrumentImageRepository(CaretagModel dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Image?> GetResizedImageByInstrumentDescriptionId(string? instrument_description_id, int width, int height)
        {
            return await _imageCache.GetOrAddAsync(instrument_description_id, id =>
            {
                var image = _dbContext.Instrument_Image.AsNoTracking().FirstOrDefault(i => i.Description_ID == instrument_description_id);

                if (image == null) return Task.FromResult<Image?>(null);

                using var stream = new MemoryStream(image.TheImage);
                var loadedImage = Image.FromStream(stream);
                return Task.Run(() => ImageUtil.ResizeImage(loadedImage, width, height));

            });
        }
    }
}
