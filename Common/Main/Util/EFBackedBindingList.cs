using Caretag_Class.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageExt;
using DevExpress.XtraGrid.Views.Base;
using System.Reactive;
using FluentValidation;

namespace Main.Util
{
    /// <summary>
    /// Used to bind to a list of entities in a view model. Useful for DevExpress controls which do not support ReactiveUI style binding, such as GridControl. 
    /// May have performance issues, because the need to flush changes all the time in order to keep the list up to date with the db.
    /// </summary>
    /// <typeparam name="TViewModel">Type of the viewmodel for the database type</typeparam>
    /// <typeparam name="TDb">The database model type (the Entity Framework class)</typeparam>
    /// <typeparam name="TId">The type of the primary key for TDb</typeparam>
    public class EFBackedBindingList<TViewModel, TDb, TId> : BindingList<TViewModel> where TViewModel : DataTypeViewModel<TId, TDb> where TDb : class, new()
    {
        private readonly RowValidator<TViewModel> _validator;
        private List<TId> _pkids = new();
        private bool _allowFullControl;

        /// <summary>
        /// Sets AllowNew, AllowEdit and AllowRemove all at the same time.
        /// Defaults to true.
        /// </summary>
        public bool AllowFullControl
        {
            get => _allowFullControl;
            set
            {
                if (value)
                {
                    _allowFullControl = true;
                    AllowNew = true;
                    AllowEdit = true;
                    AllowRemove = true;
                }
                else
                {
                    _allowFullControl = false;
                    AllowNew = false;
                    AllowEdit = false;
                    AllowRemove = false;
                }
                _allowFullControl = value;
            }
        }

        /// <summary>
        /// Should be bound to the ValidateRow event in the view to enable support for validation.
        /// </summary>
        /// <param name="eventArgs"></param>
        public void RowValidating(EventPattern<object> eventArgs)
        {
            _validator.RowValidating(eventArgs);
        }

        public EFBackedBindingList(DbSet<TDb> dbSet, Action saveChanges, RowValidator<TViewModel> validator, IEnumerable < TViewModel> items = null, Func<TDb> creator = null)
        {
            _validator = validator;
            RaiseListChangedEvents = true;
            AllowFullControl = true;

            if (items != null)
                foreach (var item in items)
                {
                    Add(item);
                    _pkids.Add(item.Pkid);
                }

            ListChanged += (sender, args) =>
            {
                switch (args.ListChangedType)
                {
                    case ListChangedType.ItemAdded:
                        
                        break;
                    case ListChangedType.ItemDeleted:
                        var dbItem = _pkids.Count > args.NewIndex ? dbSet.Find(_pkids[args.NewIndex]) : null;
                        if (dbItem != null)
                        {
                            dbSet.Remove(dbItem);
                            _pkids.RemoveAt(args.NewIndex);
                            saveChanges();
                        }
                        break;
                    case ListChangedType.ItemChanged:
                        dbItem = _pkids.Count > args.NewIndex ? dbSet.Find(_pkids[args.NewIndex]) : null;
                        var vmItem = this[args.NewIndex];

                        if (_validator.Validate(vmItem).IsValid)
                        {
                            if (dbItem == null)
                            {
                                try
                                {
                                    dbItem = creator != null ? creator() : new TDb();
                                    vmItem.UpdateToDbItem(dbItem);
                                    dbSet.Add(dbItem);
                                    saveChanges();
                                    //Get primary key from dbItem using key attribute from entity framework and reflection
                                    var keyPropertyInfo = dbItem.GetType().GetProperties()
                                        .FirstOrDefault(p =>
                                            p.GetCustomAttributes(
                                                typeof(System.ComponentModel.DataAnnotations.KeyAttribute), false).Any());
                                    var key = (TId)keyPropertyInfo.GetValue(dbItem);
                                    vmItem.Pkid = key;
                                    _pkids.Add(key);
                                }
                                catch (DbEntityValidationException ex)
                                {
                                    MessageBox.Show("Error adding new item: " + ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
                                    this.RemoveAt(args.NewIndex);
                                    if (dbItem != null)
                                        dbSet.Remove(dbItem);
                                }
                            }
                            else
                            {
                                this[args.NewIndex].UpdateToDbItem(dbItem);
                                saveChanges();
                            }
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };
        }
    }
}
