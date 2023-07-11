using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Repositories;
using Main.Model.PackingList.Validation;

namespace PackingStation.Models
{
    
    public class PackingListModel
    {
        public List<ValidatedPackingListLineItem> PackingList { get; set; }

        public PackingListModel(List<PackingListRow> packingListRows)
        {
           // PackingList = packingListRows.Select(r =>
           //     new ValidatedPackingListLineItem());
        }


    }
}
