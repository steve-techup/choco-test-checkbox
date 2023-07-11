using System.Collections.Generic;
using System.Linq;
using Caretag_Class;
using Caretag_Class.Model;
using DevExpress.XtraTreeList;
using static DevExpress.XtraTreeList.TreeList;

namespace Main.Model.DevexpressModels.TrayTree
{
    public class TrayVirtualTreeListData
    {
        enum NodeType
        {
            Root, 
            Tray, 
            Instrument
        }

        private NodeType _nodeType; 
        private TrayVirtualTreeListData _parent = null;
        private readonly CaretagModelFactory _caretagModelFactory;
        private List<Tray_Description> _trayChildren;
        private List<Instrument_Description> _instruments = null;
        private Tray_Description _tray = null;
        private Instrument_Description _instrument = null;

        public string Key {
            get
            {
                return _nodeType switch
                {
                    NodeType.Root => "ROOT",
                    NodeType.Instrument => "i_" + _instrument.Description_ID,
                    NodeType.Tray => "t_" + _tray.Description_ID,
                    _ => "NoKey"
                };
            }
        }

        public string ParentKey => _parent.Key;

        // Constructor for root node
        public TrayVirtualTreeListData(CaretagModelFactory caretagModelFactory)
        {
            _nodeType = NodeType.Root;
            _caretagModelFactory = caretagModelFactory;
            using var dbContext = caretagModelFactory.Create();
            _trayChildren = dbContext.Tray_Description.ToList();
        }
        

        protected TrayVirtualTreeListData(TrayVirtualTreeListData parent, Tray_Description tray, CaretagModelFactory caretagModelFactory)
        {
            _nodeType = NodeType.Tray;
            _parent = parent;
            _caretagModelFactory = caretagModelFactory;
            _tray = tray;
        }

        protected TrayVirtualTreeListData(TrayVirtualTreeListData parent, Instrument_Description instrument)
        {
            _nodeType = NodeType.Instrument;
            _parent = parent;
            _instrument = instrument;
        }

        public void GetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            switch (_nodeType)
            {
                case NodeType.Root:
                    info.Children = _trayChildren.Select(t => new TrayVirtualTreeListData(this, t, _caretagModelFactory))
                        .ToList();
                    break;
                case NodeType.Tray:
                    if (_instruments == null)
                    {
                        using var dbContext = _caretagModelFactory.Create();
                        _instruments = dbContext.Tray_PackList.Where(tp => tp.Tray_Descrip_ID == _tray.Description_ID)
                            .Select(tp => tp.InstrumentDescription).ToList();

                    }

                    info.Children = _instruments.Select(i => new TrayVirtualTreeListData(this, i)).ToList();
                    break;
            }
            
        }

        public void GetCellValue(VirtualTreeGetCellValueInfo info)
        {
            switch (_nodeType)
            {
                case NodeType.Tray:
                    info.CellData = _tray.Description_ID;
                    break;
                case NodeType.Instrument:
                    info.CellData = _instrument.GetFullDescription();
                    break;
            }
        }

        public void SetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }
    }
}
