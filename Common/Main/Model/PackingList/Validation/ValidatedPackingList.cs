using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Caretag_Class.Model;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model.PackingList.Validation
{
    public class ValidatedPackingList : IEquatable<ValidatedPackingList>
    {
        public ValidatedPackingList()
        {
            Lines = new List<ValidatedPackingListLineItem>();
            Timestamp = DateTime.Now;
        }

        public List<string> Tags
        {
            get
            {
                var l = Lines.SelectMany(l => l.Instruments.Select(i => i.EPC_Nr)).ToList();
                if (!string.IsNullOrEmpty(TrayEPC))
                    l.Add(TrayEPC);
                return l; 
            }
        }

        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; }
        public int? TrayId { get; set; }
        public List<Instrument_RFID> InstrumentLifecycleRfids { get; set; }

        public virtual PackingListState Result { get; set; }

        public void ValidateResult()
        {
            Result = Lines.All(row => row.Actual == row.Expected) ? PackingListState.Ok : PackingListState.NotOk;
        }
        
        public virtual List<ValidatedPackingListLineItem> Lines { get; set; }

        [ForeignKey("TrayId")]
        public virtual Tray_Description Tray { get; set; }

        public virtual string TrayEPC { get; set; }

        public enum PackingListState
        {
            Ok,
            NotOk,
            MoreThanOneTray,
            NoTray
        }

        public bool Equals(ValidatedPackingList? other)
        {
            if (ReferenceEquals(null, other)) return false;
            return Id == other.Id && Timestamp.Equals(other.Timestamp) && Location == other.Location && TrayId == other.TrayId && Result == other.Result && Lines.Equals(other.Lines) && Tray.Equals(other.Tray) && TrayEPC == other.TrayEPC;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValidatedPackingList) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Timestamp.GetHashCode();
                hashCode = (hashCode * 397) ^ Location.GetHashCode();
                hashCode = (hashCode * 397) ^ TrayId.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Result;
                hashCode = (hashCode * 397) ^ Lines.GetHashCode();
                hashCode = (hashCode * 397) ^ Tray.GetHashCode();
                hashCode = (hashCode * 397) ^ TrayEPC.GetHashCode();
                return hashCode;
            }
        }
    }
}
