namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TreatMachine_Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Treatment_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public long? Treatment_Machine_ID { get; set; }

        public long? Cycle_Nr { get; set; }

        public DateTime? ChangeDate { get; set; }
    }
}
