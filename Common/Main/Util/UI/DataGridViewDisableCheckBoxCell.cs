using System.Drawing;using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Caretag_Class.Util.UI
{
    /// <summary>
    /// A DataGridViewCheckBoxCell that can be disabled if value is null.
    /// Used by setting the Cell Template on the column to an instance of this class.
    /// NOTES:
    /// (1) Even though the checkbox is rendered as disabled, it is still clickable. To disallow changes, make sure
    /// each cell is read only.
    /// (2) Only supports booleans. 
    /// </summary>
    public class DataGridViewDisableCheckBoxCell : DataGridViewCheckBoxCell
    {
        public override object Clone()
        {
            DataGridViewDisableCheckBoxCell cell =
                (DataGridViewDisableCheckBoxCell)base.Clone();
            return cell;
        }

        private void Click()
        {
            if (ReadOnly || Value == null)
            {
                return;
            }
            DataGridView.BeginEdit(true);
            SetValue(RowIndex, !(bool)Value);
            DataGridView.EndEdit();
            this.Selected = false;
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Click();
            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(DataGridViewCellMouseEventArgs e)
        {
            Click();
            base.OnMouseDoubleClick(e);
        }

        /// <summary>
        /// Brittle method to paint a disabled checkbox if value is null.
        /// Note: Do NOT attempt to get value or modify cell in any way - stick to painting only or strange things happen. 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipBounds"></param>
        /// <param name="cellBounds"></param>
        /// <param name="rowIndex"></param>
        /// <param name="elementState"></param>
        /// <param name="value"></param>
        /// <param name="formattedValue"></param>
        /// <param name="errorText"></param>
        /// <param name="cellStyle"></param>
        /// <param name="advancedBorderStyle"></param>
        /// <param name="paintParts"></param>
        protected override void Paint
        (Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
                int rowIndex, DataGridViewElementStates elementState, object value,
                object formattedValue, string errorText, DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                    DataGridViewPaintParts paintParts)
        {

            var val = (bool?)value;
            if (val != null)
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText, cellStyle,
                    advancedBorderStyle, paintParts);
            else
            {
                SolidBrush cellBackground = new SolidBrush(cellStyle.BackColor);
                graphics.FillRectangle(cellBackground, cellBounds);
                cellBackground.Dispose();
                
                Rectangle checkBoxArea = cellBounds;
                Rectangle buttonAdjustment = BorderWidths(advancedBorderStyle);
                checkBoxArea.X += buttonAdjustment.X;
                checkBoxArea.Y += buttonAdjustment.Y;

                checkBoxArea.Height -= buttonAdjustment.Height;
                checkBoxArea.Width -= buttonAdjustment.Width;
                Point drawInPoint = new Point(cellBounds.X + cellBounds.Width / 2 - 7,
                cellBounds.Y + cellBounds.Height / 2 - 7);
                
                CheckBoxRenderer.DrawCheckBox(graphics, drawInPoint, CheckBoxState.UncheckedDisabled);
                
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            }

        }
    }
}
