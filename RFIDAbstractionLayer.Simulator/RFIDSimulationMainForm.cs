using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RFIDAbstractionLayer.Forms
{
    public partial class RFIDSimulationMainForm : Form
    {
        int _genCounter = 1;
        string genString = "RFIDInjection-";

        public RFIDSimulationMainForm()
        {
            InitializeComponent();
            tagsListBox.Items.Clear();
            
        }
        
            
        /// <summary>
        /// Used by the reader class to get the next tag(s) from the simulator.
        /// </summary>
        /// <returns></returns>
        public List<string> GetNextRFID()
        {
            List<string> result = new List<string>();

            try
            {

                // If no tags are to be returned, return an empty list
                if (tagsListBox.Items.Count == 0)
                {
                    return result;
                }

                if (tagsListBox.SelectedItems.Count > 0)
                {
                    // There is an active selection, grab the selected lines
                    foreach (var item in tagsListBox.SelectedItems)
                    {
                        result.Add(item.ToString());
                    }

                    if (cbDeleteWhenRead.Checked)
                        ClearSelectedItemsFromListBox();
                }
                else
                {
                    // There is no active selection, so pick the item at the top of the list
                    result.Add(tagsListBox.Items[0].ToString());

                    if (cbDeleteWhenRead.Checked)
                        tagsListBox.Items.RemoveAt(0);
                }
            }
            catch (Exception e)
            {
                DisplayError(e, "GetNextRFID()");
            }

            return result;
        }

        private void ClearSelectedItemsFromListBox()
        {
            try
            {
                // Running for loop in reverse to ensure index hasn't changed because something was deleted higher up.
                for (int i = tagsListBox.SelectedItems.Count - 1; i > -1; i--)
                {
                    DeleteListBoxItem(tagsListBox.SelectedItems[i].ToString());
                }
            }
            catch (Exception e)
            {
                DisplayError(e, "ClearSelectedItemsFromListBox()");
            }


        }

        private void DeleteListBoxItem(string itemToDelete)
        {
            try
            {
                for (int i = 0; i < tagsListBox.Items.Count; i++)
                {
                    if (tagsListBox.Items[i].ToString() == itemToDelete)
                    {
                        tagsListBox.Items.RemoveAt(i);
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                DisplayError(e, "DeleteListBoxItem('" + itemToDelete + "')");
            }
        }

        /// <summary>
        /// Add string in rfidTextBox to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            tagsListBox.Items.Add(rfidTextBox.Text);
            rfidTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Fill the listbox with sender.tag number of new items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddXItems_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem mi = (ToolStripMenuItem)sender;

                // Try to convert the tag property to a number, default value is 0
                int count = 0;
                int.TryParse((string)mi.Tag, out count);
                for (int i = 0; i < count; i++)
                {
                    tagsListBox.Items.Add(genString + _genCounter.ToString("D9"));
                    // keep track of how many item names has been generated
                    _genCounter++;
                }
            }
            catch (Exception err)
            {
                DisplayError(err, "btnAddXItems_Click()");
            }
        }

        /// <summary>
        /// Clear the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiClearList_Click(object sender, EventArgs e)
        {
            tagsListBox.Items.Clear();
        }

        /// <summary>
        /// Fail gracefully with a properly formatted error message
        /// </summary>
        /// <param name="err">exception that was triggered</param>
        /// <param name="location">which method triggered the exception?</param>
        private void DisplayError(Exception err, string location)
        {
            MessageBox.Show("Class: " + this.GetType().Name + "\n" +
                            "Location: " + location + "\n" +
                            "Exception Type: " + err.GetType().Name + "\n" +
                            "Message: " + err.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
