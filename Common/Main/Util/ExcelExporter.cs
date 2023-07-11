using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using MiniExcelLibs.Attributes;
using Westwind.Utilities;

namespace Main.Util
{
    /// <summary>
    /// Exports an IEnumerable<T> to an Excel file using NanoXLSX.
    /// </summary>
    public class ExcelExporter
    {
        private readonly NanoXLSX.Workbook _workbook;

        public ExcelExporter()
        {
            _workbook = new NanoXLSX.Workbook();
        }

        /// <summary>
        /// Exports the given IEnumerable to an Excel file.
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable.</typeparam>
        /// <param name="data">The IEnumerable to export.</param>
        /// <param name="sheetName">The name of the sheet to add</param>
        public void AddSheet<T>(IEnumerable<T> data, string sheetName)
        {
            _workbook.AddWorksheet(sheetName.Truncate(31));
            var properties = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(ExcelIgnoreAttribute), false).Length == 0);

            if (!properties.Any())
                return;

            // If property is decorated with DisplayName attribute is it instead of property name
            var propertyNames = properties
                .Select(p => p.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                    .FirstOrDefault() is DisplayNameAttribute displayName ? displayName.DisplayName : p.Name);

            foreach (var propertyName in propertyNames)
                _workbook.WS.Value(propertyName);
            
            _workbook.WS.Down();

            foreach (var item in data)
            {
                foreach (var property in properties)
                    _workbook.WS.Value(property.GetValue(item));

                _workbook.WS.Down();
            }
        }

        /// <summary>
        /// Exports an IEnumerable<T> to an Excel file using NanoXLSX.
        /// </summary>
        /// <param name="filename">The filename to export to.</param>
        public void Save(string filename)
        {
            _workbook.SaveAs(filename);
        }
    }
}
