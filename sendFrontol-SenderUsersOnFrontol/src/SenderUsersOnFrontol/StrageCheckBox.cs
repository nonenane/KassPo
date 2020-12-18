using System;
using System.Windows.Forms;
public class StrageCheckBox : CheckBox
{
    public event EventHandler Unchecked;
    //public event EventHandler Checked;

    protected override void OnCheckedChanged(EventArgs e)
    {
        base.OnCheckedChanged(e);

        if (!Checked)
            OnUnchecked(e);
        else
            OnChecked(e);
    }

    protected virtual void OnUnchecked(EventArgs e)
    {
        if (Unchecked != null)
            Unchecked(this, e);
    }

    protected virtual void OnChecked(EventArgs e)
    {
        if (Unchecked != null)
            Unchecked(this, e);
    }
}