using System.Windows.Forms;

namespace ntrbase.Helpers
{
    class Delg
    {
        // For all controls
        delegate void SetTextDelegate(Control ctrl, string text);

        public static void SetText(Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextDelegate del = new SetTextDelegate(SetText);
                ctrl.Invoke(del, ctrl, text);
            }
            else
                ctrl.Text = text;
        }

        delegate void SeVisibleDelegate(Control ctrl, bool en);

        public static void SetVisible(Control ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SeVisibleDelegate del = new SeVisibleDelegate(SetVisible);
                ctrl.Invoke(del, ctrl, en);
            }
            else
                ctrl.Visible = en;
        }

        delegate void SetEnabledDelegate(Control ctrl, bool en);

        public static void SetEnabled(Control ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SetEnabledDelegate del = new SetEnabledDelegate(SetEnabled);
                ctrl.Invoke(del, ctrl, en);
            }
            else
                ctrl.Enabled = en;
        }

        // NumericUpDown
        delegate void SetValueDelegate(NumericUpDown ctrl, decimal val);

        public static void SetValue(NumericUpDown ctrl, decimal val)
        {
            if (ctrl.InvokeRequired)
            {
                SetValueDelegate del = new SetValueDelegate(SetValue);
                ctrl.Invoke(del, ctrl, val);
            }
            else
                ctrl.Value = val;
        }
    }
}
