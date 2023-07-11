using System.Windows.Forms;

namespace AdminStation.Infrastructure;

public static class DataGridViewExtensions
{
    public static bool Edited(this DataGridView grid)
    {
        foreach (DataGridViewRow dataGridViewRow in grid.Rows)
            if (dataGridViewRow.Edited())
                return true;

        return false;
    }

    public static bool Edited(this DataGridViewRow row)
    {
        return row.Tag != null;
    }

    public static void MarkAsEdited(this DataGridViewRow row)
    {
        row.Tag = "Edited";
    }
}