using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model.DevexpressModels
{
    [Persistent("Tray_Image")]
    public class TrayImageXPOModel : XPLiteObject
    {
    
        public TrayImageXPOModel(Session session) : base(session) { }


        private long _image_ID;

        [DisplayName("Image ID")]
        [Key(true)]
        public long Image_ID
        {
            get => _image_ID;
            set => SetPropertyValue(nameof(Image_ID), ref _image_ID, value);
        }


        private byte[] _theImage;
        public byte[] TheImage
        {
            get => _theImage;
            set => SetPropertyValue(nameof(TheImage), ref _theImage, value);
        }

        private DateTime? _dateChanged;
        public DateTime? Date_Changed
        {
            get => _dateChanged;
            set => SetPropertyValue(nameof(Date_Changed), ref _dateChanged, value);
        }


        private static byte[] ImageToByte(Image img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private static Image ByteToImage(byte[] bytes)
        {
            var ms = new System.IO.MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        [Association]
        [DisplayName("Tray Description")]
        public TrayDescriptionXPOModel Description_ID
        {
            get => GetPropertyValue<TrayDescriptionXPOModel>(nameof(Description_ID));
            set => SetPropertyValue(nameof(Description_ID), value);
        }

        [NonPersistent]
        public Image Image
        {
            get => ByteToImage(TheImage);
            set => TheImage = ImageToByte(value);
        }
    }
}