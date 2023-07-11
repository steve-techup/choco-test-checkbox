using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class;
using Caretag_Class.Model;
using Main.Model.PackingList.Validation;

namespace AdminStation.ViewModels.ReactiveUI
{
    public class ValidatedPackingListDetailsViewModel : ReactiveObject, IRoutableViewModel, IDisposable
    {
        private readonly CaretagModel _model;
        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }

        public ValidatedPackingListDetailsViewModel(CaretagModelFactory caretagModelFactory, int validatedPackingListId)
        {
            _model = caretagModelFactory.Create();
            LineItems = _model.ValidatedPackingList.Include(x => x.Lines.Select(l => l.Instruments))
                .First(packinglist => packinglist.Id == validatedPackingListId).Lines.ToList();
        }
        
        public List<ValidatedPackingListLineItem> LineItems { get; }

        public void Dispose()
        {
            _model.Dispose();
        }
    }
}
