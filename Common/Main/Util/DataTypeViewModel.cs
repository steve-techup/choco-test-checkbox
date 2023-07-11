using System.ComponentModel;
using System.Runtime.CompilerServices;
using DevExpress.Utils.About;
using Main.Annotations;

namespace Main.Util
{
    public abstract class DataTypeViewModel<TId, TDb> : INotifyPropertyChanged
    {
        // This is the primary key of the data type
        public abstract TId Pkid { get; set; }

        public abstract void UpdateToDbItem(TDb dbItem);

        public abstract void UpdateFromDbItem(TDb dbItem);

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
