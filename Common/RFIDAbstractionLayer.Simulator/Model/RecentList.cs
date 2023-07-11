using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDAbstractionLayer.Simulator.Model
{
    public class RecentList
    {
        private List<SimulatorItem> _list = new List<SimulatorItem>();
        private const int MaxHistory = 10;
        private string _recentFilename;

        #region Properties
        public List<SimulatorItem> Items
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public string Filename
        {
            get
            {
                return _recentFilename;
            }
        }
        #endregion

        ~RecentList()
        {
            Save(_recentFilename);
        }

        #region Constructors
        public RecentList(string recentFilename)
        {
            _recentFilename = recentFilename;
            Load(recentFilename);
        }

        public RecentList(List<SimulatorItem> loadedList)
        {
            if (loadedList == null)
                loadedList = new List<SimulatorItem>();
            _list = loadedList;
        }
        #endregion

        #region Save/Load
        public bool Load(string filename)
        {
            bool result;
            try
            {
                _list.Clear();
                string[] lines = File.ReadAllLines(filename);
                foreach (var str in lines)
                {
                    var item = new SimulatorItem(str);
                    _list.Add(item);
                }
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

        public bool Save(string filename)
        {
            bool result;
            try
            {
                TextWriter file = new StreamWriter(filename);
                foreach (var item in _list)
                {
                    string s = String.Format("{0}|{1}|{2}|{3}", item.Id, item.EPC, item.Description,
                        item.ItemType.ToString());
                    file.WriteLine(s);
                }
                file.Close();
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
        #endregion

        public void Add(SimulatorItem item)
        {
            int index = -1;
            if (IsInList(item, ref index))
            {
                _list.RemoveAt(index);
            }

            // insert at the top
            _list.Insert(0, item);

            while (_list.Count > MaxHistory)
            {
                // Remove last item until length is within max history
                _list.RemoveAt(_list.Count - 1);
            }
        }

        public void Delete(SimulatorItem item)
        {
            int index = -1;
            if (!IsInList(item, ref index))
                return;

            _list.RemoveAt(index);
        }

        private bool IsInList(SimulatorItem item, ref int index)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (IsSameItem(item, _list[i]))
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        private bool IsSameItem(SimulatorItem item1, SimulatorItem item2)
        {
            return ((item1.EPC == item2.EPC) &&
                    (item1.Description == item2.Description) &&
                    (item1.Id == item2.Id) &&
                    (item1.ItemType == item2.ItemType));
        }
    }
}
